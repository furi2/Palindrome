using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JwNetSurvey;

namespace JwNetSurveryTest
{
    [TestClass]
    public class PalindromeEvaluatorTest
    {
        static string DataDirectory = @"data\";
        static string TestFileName1 = "UKACD17.TXT";
        static string TestFileName2 = "palindrome.txt";
        static string TestFilePath1 = Util.ProjectPath + DataDirectory + TestFileName1;
        static string TestFilePath2 = Util.ProjectPath + DataDirectory + TestFileName2;
        IDataReader _dataReader;
        PalindromeEvaluator _eval;

        public PalindromeEvaluatorTest() {
            _dataReader = new TextFileDataReader(TestFilePath1);
            _eval = new PalindromeEvaluator(_dataReader);
        }

        [TestMethod]
        public void TestFileExistsTest()
        {
            Assert.IsTrue(File.Exists(TestFilePath1), "Data File Exists");
        }


        [TestMethod]
        public void PalindromeTest_Even()
        {
            string value = "PalindromeemordnilaP";
            Assert.IsTrue(_eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeTest_Odd()
        {
            string value = "PalindromemordnilaP";
            Assert.IsTrue(_eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeFalseTest_Even()
        {
            string value = "PalondromeemordnilaP";
            Assert.IsFalse(_eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeFalseTest_Odd()
        {
            string value = "PalindromenordnilaP";
            Assert.IsFalse(_eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeFalseTest_Null()
        { 
            string value = null;
            Assert.IsFalse(_eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeFalseTest_Empty()
        {
            string value = "";
            Assert.IsFalse(_eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeTest_WithSpecialChar()
        {
            string value = "Nella's simple hymn: \"I attain my help, Miss Allen.\"";
            Assert.IsTrue(_eval.Evaluate(value));
        }

        [TestMethod]
        public void PalindromeTest_WithNumbers()
        {
            string value = "123 A nut for a jar of tuna. 3 2 1";
            Assert.IsTrue(_eval.Evaluate(value));
        }


        [TestMethod]
        public void EvaluateAll_Test() {
            Assert.AreEqual(170, _eval.EvaluateAll());
        }

        [TestMethod]
        public void EvaluateAll_Test2()
        {
            IDataReader dataReader = new TextFileDataReader(TestFilePath2);
            IStringEvaluator eval = new PalindromeEvaluator(dataReader);
            Assert.AreEqual(20, eval.EvaluateAll());
        }


    }
}
