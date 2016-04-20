using System;
using System.IO;

namespace JwNetSurvey
{
    public class TextFileDataReader : IDataReader
    {
        string FilePath { get; set; }
        StreamReader _streamReader;

        public TextFileDataReader(string filePath)
        {
            FilePath = filePath;
        }
        public IDataReader Init()
        {
            this.Dispose();
            _streamReader = new StreamReader(FilePath);
            return this;
        }

        public void Dispose()
        {
            try
            {
                if (_streamReader != null)
                {
                    _streamReader.Dispose();
                }
            }
            catch (Exception)
            {
            }
        }

        public String ReadLine()
        {
            return _streamReader.ReadLine();
        }

        public bool EndOfData
        {
            get
            {
                return _streamReader == null || _streamReader.EndOfStream;
            }
        }
    }
}
