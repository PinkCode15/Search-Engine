using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikaOnDotNet.TextExtraction;
using System.Text.RegularExpressions;
using System.IO;


namespace Interface
{
    /// <summary>
    /// Gets and Rank the files matching the user's query representation
    /// </summary>
    public static class Ranker 
    {

        /// <summary>
        /// contains all the matching keywords in the query mapped to their IDF
        /// </summary>
        private static Dictionary<string, double> _queryRank = new Dictionary<string, double> { };
        /// <summary>
        /// contains the Inverted index of the all files mapped their TFIDF
        /// </summary>
        private static Dictionary<string, Dictionary<FileInfo, Dictionary<string, double>>> _invertedIndex = new Dictionary<string, Dictionary<FileInfo, Dictionary<string, double>>> { };
        /// <summary>
        /// contains the inverted document frequency for every notable terms in the corpus
        /// </summary>
        private static Dictionary<string, double> _termIDF = new Dictionary<string, double> { };
        /// <summary>
        /// contains all files and their cosine similarities to the query appended 
        /// </summary>
        private static Dictionary<FileInfo, double> _newRankList = new Dictionary<FileInfo, double> { };

        



        /// <summary>
        /// Accesses the Inverted Index for files matching the user query and sorts them by relevance
        /// </summary>
        /// <param name="query">a string array parameter</param>
        public static List<FileInfo> Rank(string[] query)
        {
            HashSet<Dictionary<FileInfo, Dictionary<string, double>>> allQueryFiles = new HashSet<Dictionary<FileInfo, Dictionary<string, double>>> { };
            Dictionary<FileInfo, Dictionary<string, double>> queryFiles = new Dictionary<FileInfo, Dictionary<string, double>> { };
            List<KeyValuePair<FileInfo, double>> _result = new List<KeyValuePair<FileInfo, double>> { };
            List<FileInfo> sortedList = new List<FileInfo> { };

            Dictionary<FileInfo, Dictionary<string, double>> value = new Dictionary<FileInfo, Dictionary<string, double>> { };
            foreach (var term in query)
            {
                if (_invertedIndex.TryGetValue(term, out value))
                {
                   
                    allQueryFiles.Add(value);
                }

            }

            foreach (var indexFiles in allQueryFiles)
            {
                var Files =
               from documentsCollection in indexFiles
               select documentsCollection;

                foreach (KeyValuePair<FileInfo, Dictionary<string, double>> files in Files)
                {
                    var docs = indexFiles.SingleOrDefault(p => p.Key == files.Key);
                    if (!queryFiles.ContainsKey(docs.Key)) queryFiles.Add(docs.Key, docs.Value);
                }

            }

            var queryWeights = getTermWeights(query);
            _newRankList.Clear();

            foreach (var doc in queryFiles)
            {
                if (!_newRankList.ContainsKey(doc.Key))
                {
                    _newRankList.Add(doc.Key, cosineSimilarity(queryWeights, doc.Value));
                }
            }

            _result = _newRankList.ToList();

            _result.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            _result.Reverse();

            foreach(var file in _result)
            {
                sortedList.Add(file.Key);
            }
            
            

            return sortedList;

        }


        /// <summary>
        /// gets the Inverted index of every file in the corpus and their normalized weight
        /// </summary>
        public static void getInvertedIndex(string path)
        {
            FileIndexer.buildIndex(path);
            compute_IDf();
            Console.WriteLine("Building Inverted Index...");
            foreach (var term in FileIndexer.getCommonIndex())
            {
                Dictionary<FileInfo, Dictionary<string, double>> files = new Dictionary<FileInfo, Dictionary<string, double>> { };
                foreach (var file in FileIndexer.getIndex())
                {
                    if (FileIndexer.containsTerm(term, file.Value))
                    {
                        files.Add(file.Key, normalizedWeights(file.Key));
                    }
                }
                if (!_invertedIndex.ContainsKey(term)) _invertedIndex.Add(term, files);
            }
            Console.WriteLine("Complete");
        }

        /// <summary>
        /// calculates the Inverted Documnent Frequency for every term in the common index
        /// </summary>
        public static void compute_IDf()
        {


            foreach (string term in FileIndexer.getCommonIndex())
            {
                double DFt = FileIndexer.docsContainingTerm(term);
                double IDF = (1 + Math.Log(1.0 * FileIndexer.getCorpus().Count / DFt));
                if (!_termIDF.ContainsKey(term)) _termIDF.Add(term, IDF);
            }
        }


        /// <summary>
        /// calculates the vectors of all the terms in a document
        /// </summary>
        /// <param name="doc">a Fileinfo parameter</param>
        /// <returns>a dictionary </returns>
        public static Dictionary<string, double> getTermWeights(FileInfo doc)
        {
            List<string> allTexts = new List<string> { };
            Dictionary<string, double> TF_IDF = new Dictionary<string, double> { };

            var docs = FileIndexer.getIndex().SingleOrDefault(p => p.Key == doc);

            foreach (string word in docs.Value)
            {
                double IDF, weight;
                if (_termIDF.TryGetValue(word, out IDF))
                {
                    double TF = FileIndexer.termFrequency(word, doc);
                    weight = TF * IDF;
                    if (!TF_IDF.ContainsKey(word))
                    {
                        TF_IDF.Add(word, weight);
                    }
                }
            }

            return TF_IDF;
        }

        /// <summary>
        /// calculates the vectors of all the terms in an array
        /// </summary>
        /// <param name="tokens">a string array parameter</param>
        /// <returns>a dictionary </returns>
        public static Dictionary<string, double> getTermWeights(string[] tokens)
        {
            HashSet<string> allTexts = new HashSet<string> { };
            Dictionary<string, double> TF_IDF = new Dictionary<string, double> { };

            foreach (string term in tokens)
            {
                double IDF, weight;
                if (_termIDF.TryGetValue(term, out IDF))
                {
                    double TF = FileIndexer.termFrequency(term, tokens);
                    weight = TF * IDF;
                    if (!TF_IDF.ContainsKey(term))
                    {
                        TF_IDF.Add(term, weight);
                    }
                }
                else
                {
                    if (!TF_IDF.ContainsKey(term))
                    {
                        TF_IDF.Add(term, 1.0);
                    }
                }
            }


            return TF_IDF;
        }

        /// <summary>
        /// calculates the normalized vectors of the TF*IDF vectors
        /// </summary>
        /// <param name="doc">a Fileinfo parameter</param>
        /// <returns>a dictionary</returns>
        public static Dictionary<string, double> normalizedWeights(FileInfo doc)
        {
            Dictionary<string, double> TF_IDF = new Dictionary<string, double> { };
            Dictionary<string, double> normalizedTF_IDF = new Dictionary<string, double> { };
            double totalWeightsMagn = 0;
            TF_IDF = getTermWeights(doc);
            foreach (var weight in TF_IDF)
            {
                totalWeightsMagn += Math.Pow(weight.Value, 2);
            }
            var Magnitude = Math.Sqrt(totalWeightsMagn);

            foreach (KeyValuePair<string, double> weight in TF_IDF)
            {
                normalizedTF_IDF.Add(weight.Key, weight.Value / Magnitude);
            }

            return normalizedTF_IDF;
        }

        /// <summary>
        /// calculates the Cosine Similarity of two vectors
        /// </summary>
        /// <param name="query">a type <c>Dictionary(string ,double)</c> parameter</param>
        /// <param name="doc">a type <c>Dictionary(string, double)</c> parameter</param>
        /// <returns>a type double value</returns>
        public static double cosineSimilarity(Dictionary<string, double> query, Dictionary<string, double> doc)
        {
            Dictionary<string, double> docVectors = new Dictionary<string, double> { };
            //docVectors = invertedIndex[doc];
            double dotProduct = 0;
            double queryMod = 0;
            double documentMod = 0;

            foreach (var term in query)
            {
                queryMod += Math.Pow(term.Value, 2);
                double value;
                if (doc.TryGetValue(term.Key, out value))
                {
                    documentMod += Math.Pow(value, 2);
                    dotProduct += term.Value * value;
                }

            }
            queryMod = Math.Sqrt(queryMod);
            documentMod = Math.Sqrt(documentMod);
            if (documentMod == 0) return 0;
            return dotProduct / (documentMod * queryMod);
        }
        /// <summary>
        /// Gets inverted Index
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Dictionary<FileInfo, Dictionary<string, double>>> extractInvertedIndex()
                   
         {
            return _invertedIndex;
         }

}
}
