using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JwNetSurvey;

namespace JwNetSurveryTest
{
    [TestClass]
    public class PalindromeEvaluatorTest
    {
        static string DataDirectory = @"data\";
        static string TestFileName = "palindrome.txt";
        static string TestFilePath = Util.ProjectPath + DataDirectory + TestFileName;
        IDataReader dataReader;
        PalindromeEvaluator eval;

        public PalindromeEvaluatorTest() {
            dataReader = new TextFileDataReader(TestFilePath);
            eval = new PalindromeEvaluator(dataReader);
        }

        [TestMethod]
        public void TestFileExistsTest()
        {
            Assert.IsTrue(File.Exists(TestFilePath), "Data File Exists");
        }


        [TestMethod]
        public void PalindromeTest_Even()
        {
            string value = "PalindromeemordnilaP";
            Assert.IsTrue(eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeTest_Odd()
        {
            string value = "PalindromemordnilaP";
            Assert.IsTrue(eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeFalseTest_Even()
        {
            string value = "PalondromeemordnilaP";
            Assert.IsFalse(eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeFalseTest_Odd()
        {
            string value = "PalindromenordnilaP";
            Assert.IsFalse(eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeFalseTest_Null()
        { 
            string value = null;
            Assert.IsFalse(eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeFalseTest_Empty()
        {
            string value = "";
            Assert.IsFalse(eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeTest_WithSpecialChar()
        {
            string value = "Nella's simple hymn: \"I attain my help, Miss Allen.\"";
            Assert.IsTrue(eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeTest_WithNumbers()
        {
            string value = "123 A nut for a jar of tuna. 3 2 1";
            Assert.IsTrue(eval.Evaluate(value));
        }


        [TestMethod]
        public void EvaluateAll_Test() {
            Assert.AreEqual(20, eval.EvaluateAll());
        }

    }
}
