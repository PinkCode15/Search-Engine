using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interface
{
    /// <summary>
    /// Generates a representation of the user's input
    /// Removes preposition and punctuations
    /// </summary>
    public static class QueryParser
    {
        
        

        /// <summary>
        /// The sentimentAnalysis method
        /// extracts the sentiment/keywords in the users search parameters
        /// </summary>
        /// <param name="userQuery">a string parameter</param>
        /// <returns>a string array colletion</returns>
        public static string[] parseQuery(string userQuery)
        {
            string[] allWords = new string[] { };
            var tokens = new List<string> { };
            bool check = false;
            userQuery = userQuery.ToLower();

            //creates an array of all punctuations present in the userQuery parameter (uses a LINQ expression)
            var punctuation = userQuery.Where(Char.IsPunctuation).Distinct().ToArray();
            
            //Trims all punctuation present in the userQuery and saves it to an IEnumerable collection 
            var splitKeywords = userQuery.Split().Select(x => x.Trim(punctuation));
            List<string> stopWords = new List<string> { "to", "from", "in", "on", "with", "without", "within",
                                                        "which", "a", "the", "an", "and", "upon", "by", "about", "for",
                                                       "after", "but", "above", "over", "at", "into", "until", "it" };

            //checks every substring in splitKeywords and removes them if its a stopword and adds them to a list
            foreach (string i in splitKeywords)
            {
                check = false;
                foreach (string p in stopWords)
                {
                    if (i.Equals(p))
                    {
                        check = true;
                        break;
                    }
                }
                if (check == false)
                {
                    tokens.Add(i);
                }
            }

            //returns the list converted to an array 
            return tokens.ToArray();
        }




    }
}
