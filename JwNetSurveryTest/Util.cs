using System.IO;

namespace JwNetSurveryTest
{
    public class Util
    {
        public static string ProjectPath
        {
            get
            {
                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
                return projectPath.FullName + "\\";
            }
        }
    }
}
