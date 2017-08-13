using System;
using System.IO;

namespace CloudManagement.Helper
{
    public class LoadDoc
    {
        public static string LoadDocument(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
