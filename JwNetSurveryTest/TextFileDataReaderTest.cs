using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JwNetSurvey;

namespace JwNetSurveryTest
{
    [TestClass]
    public class TextFileDataReaderTest
    {

        static string DataDirectory = @"data\";
        static string TestFileName = "palindrome.txt";
        static string TestFilePath = Util.ProjectPath + DataDirectory + TestFileName;
        TextFileDataReader _dataReader;
        
        public TextFileDataReaderTest()
        {
            _dataReader = new TextFileDataReader(TestFilePath);
        }

        [TestMethod]
        public void ReadLineTest()
        {
            string line;
            using (var reader = _dataReader.Init())
            {
                line = reader.ReadLine();
                Assert.AreEqual("Kayak", line);
                line = reader.ReadLine();
                Assert.AreEqual("Rotator", line);
                line = reader.ReadLine();
                Assert.AreEqual("A nut for a jar of tuna.", line);
                line = reader.ReadLine();
                Assert.AreEqual("No lemon, no melon.", line);
            }
        }
    }
}
