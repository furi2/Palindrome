using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JwNetSurvey;

namespace JwNetSurveryTest
{
    [TestClass]
    public class ConsonantsEvaluatorTest
    {

        static string DataDirectory = @"data\";
        static string TestFileName = "consonants.txt";
        static string TestFilePath = Util.ProjectPath + DataDirectory + TestFileName;
        IDataReader dataReader;
        ConsonantsEvaluator eval;

        public ConsonantsEvaluatorTest()
        {
            dataReader = new TextFileDataReader(TestFilePath);
            eval = new ConsonantsEvaluator(dataReader);
        }
        [TestMethod]
        public void ConsonantsTest()
        {
            string value = "qwrty";
            Assert.IsTrue(eval.Evaluate(value), value);
            value = "plmkyghrgdst";
            Assert.IsTrue(eval.Evaluate(value), value);
        }

        [TestMethod]
        public void ConsonantsTest_CaseMixed()
        {
            string value = "QWRTyp";
            Assert.IsTrue(eval.Evaluate(value), value);
            value = "plmkyghrGDST";
            Assert.IsTrue(eval.Evaluate(value), value);
        }

        [TestMethod]
        public void ConsonantsFalseTest_CaseMixed()
        {
            string value = "QWaRETyp";
            Assert.IsFalse(eval.Evaluate(value), value);
            value = "plmkyghrEGDS9T";
            Assert.IsFalse(eval.Evaluate(value), value);
        }

        [TestMethod]
        public void ConsonantsTest_All()
        {
            Assert.AreEqual(4, eval.EvaluateAll());
        }
    }
}
