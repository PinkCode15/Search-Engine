using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interface;
using System.IO;
using TikaOnDotNet.TextExtraction;


namespace SearchEngineTests
{
    [TestClass]
    public class UserQuery
    {
        [TestMethod]
        public void queryParser()
        {

            var actual = QueryParser.parseQuery("User, . disaster.");
            var substring = "user";
            StringAssert.Contains(actual[0], substring);
        }
    }

    [TestClass]
    public class Ranking
    {
        public string path = @"C:\Games\Test";
        public string keyword1 = "Testword";
        public string keyword2 = "public";
        [TestMethod]
        public void extractingText()
        {
            var files = new DirectoryInfo(path).GetFiles("*.*");
            var doc = files[0];
            var list = FileIndexer.extractText(doc);
            Assert.IsTrue(list.Contains(keyword1));
        }

        [TestMethod]
        public void generatingInvertedIndex()
        {
            Ranker.getInvertedIndex(path);
            Assert.IsTrue(Ranker.extractInvertedIndex().ContainsKey(keyword2));
        }

        [TestMethod]
        public void checkWordInDocuments()
        {
            FileIndexer.buildIndex(path);
            var docs = FileIndexer.docsContainingTerm(keyword1);
            Assert.IsTrue(docs > 0);
        }


    }

    [TestClass]
    public class FileIndexing
    {
        public string path = @"C:\Games\Test";
        [TestMethod]
        public void files()
        {
            FileIndexer.fileIndexer(path);
            Assert.IsTrue(FileIndexer.getCorpus().Count > 0);
        }
    }

}
