using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostsTestsApi.DbCreation
{
    // Take a file (listo'words and read it in)
    class DictionaryReader : IDisposable
    {
        bool disposed = false;
        public long lineCount = -1;
        StreamReader fileReader;
        string currentPath;
        public DictionaryReader()
        {
            currentPath = Environment.CurrentDirectory + "\\Dictionary\\MyDict.txt";
            fileReader = new StreamReader(currentPath);
            GetLineCount();
        }

        private void GetLineCount()
        {
            using (StreamReader sr = new StreamReader(currentPath))
            {
                while (sr.ReadLine() != null)
                {
                    lineCount += 1;
                }
            }


        }

        public IEnumerable<string> GetWords()
        {
            while (!fileReader.EndOfStream)
            {
                yield return fileReader.ReadLine();
            }
        }

        public string this[int position]
        {
            get
            {
                //this.fileReader.BaseStream.Seek(0, SeekOrigin.Begin);
                // for (var x = 0; x<this.lineCount; ++x){
                //Console.WriteLine     GetWords();
                //     if( x== position)
                //     {
                //         return GetWords().FirstOrDefault();
                //     }
                // }
                var x = GetWords().ElementAtOrDefault(position);
                fileReader.DiscardBufferedData();
                fileReader.Dispose();
                fileReader = null;
                fileReader = new StreamReader(currentPath);
                return x;
                throw new ArgumentOutOfRangeException("Learn to count");
            }
        }

        ~DictionaryReader()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                fileReader.Dispose();
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
