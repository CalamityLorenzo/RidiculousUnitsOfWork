﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
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

        static string LoremText()
        {
            return @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ullamcorper hendrerit condimentum. Nulla sapien neque, ullamcorper ac lorem id, egestas congue ligula. Donec nisl felis, interdum sit amet arcu et, sollicitudin consequat purus. Mauris posuere, tortor quis gravida hendrerit, elit lacus tempus quam, pellentesque hendrerit dolor lectus feugiat odio. Proin eget laoreet diam. Phasellus eget metus rutrum, pellentesque odio ut, molestie est. Praesent in interdum urna, nec aliquam erat. Cras at enim fermentum, varius orci ut, placerat nisi. Donec scelerisque lacus at congue accumsan.

Praesent rhoncus libero a tincidunt laoreet. Nulla vitae sapien commodo, consequat ipsum eget, ultrices lorem.Mauris varius sed massa vel malesuada. Ut a nisl eu enim dapibus fermentum.Sed id aliquam sapien. Aenean consectetur est nulla, sed aliquet tortor ornare ac. Proin tellus tellus, scelerisque id aliquam vitae, vulputate a dolor. Duis at metus nec orci porttitor ornare.In in orci vel nisi auctor feugiat vel et nunc. Mauris vitae consequat dolor. Pellentesque quis velit nisl.

Aliquam vel volutpat velit, ornare fringilla metus. Sed ipsum tellus, iaculis et leo sed, placerat porttitor sapien. Donec egestas ipsum quam, a dictum purus vestibulum finibus. Quisque pharetra ornare tellus a ultricies. Vivamus sit amet tincidunt orci, in convallis nisi. Aenean feugiat magna nunc, sit amet feugiat risus feugiat at.Cras vel ante eu arcu fermentum varius vitae non risus. Mauris vel laoreet nibh. Praesent in viverra justo. Vestibulum vitae sapien id neque interdum pretium suscipit dapibus mi.";
        }
    }
}
