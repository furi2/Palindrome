using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JwNetSurvey;

namespace JwNetSurveryTest
{
    [TestClass]
    public class ConsonantsEvaluatorTest
    {

        static string DataDirectory = @"data\";
        static string TestFileName1 = "UKACD17.TXT";
        static string TestFileName2 = "consonants.txt";
        static string TestFilePath1 = Util.ProjectPath + DataDirectory + TestFileName1;
        static string TestFilePath2 = Util.ProjectPath + DataDirectory + TestFileName2;
        IDataReader _dataReader;
        ConsonantsEvaluator _eval;

        public ConsonantsEvaluatorTest()
        {
            _dataReader = new TextFileDataReader(TestFilePath1);
            _eval = new ConsonantsEvaluator(_dataReader);
        }
        [TestMethod]
        public void ConsonantsTest()
        {
            string value = "qwrty";
            Assert.IsTrue(_eval.Evaluate(value), value);
            value = "plmkyghrgdst";
            Assert.IsTrue(_eval.Evaluate(value), value);
        }

        [TestMethod]
        public void ConsonantsTest_CaseMixed()
        {
            string value = "QWRTyp";
            Assert.IsTrue(_eval.Evaluate(value), value);
            value = "plmkyghrGDST";
            Assert.IsTrue(_eval.Evaluate(value), value);
        }

        [TestMethod]
        public void ConsonantsFalseTest_CaseMixed()
        {
            string value = "QWaRETyp";
            Assert.IsFalse(_eval.Evaluate(value), value);
            value = "plmkyghrEGDS9T";
            Assert.IsFalse(_eval.Evaluate(value), value);
        }

        [TestMethod]
        public void ConsonantsTest_All()
        {
            Assert.AreEqual(187, _eval.EvaluateAll());
        }
        [TestMethod]
        public void ConsonantsTest2_All()
        {
            IDataReader dataReader = new TextFileDataReader(TestFilePath2);
            IStringEvaluator eval = new ConsonantsEvaluator(dataReader);
            Assert.AreEqual(4, eval.EvaluateAll());
        }
    }
}
