using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CloudManagement.Helper
{
    public class IOHelper
    {
        /// <summary>
        /// 网站根目录
        /// </summary>
        public static string RootPath => HttpRuntime.AppDomainAppPath;

        /// <summary>
        /// 创建目录如果不存在
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public static void CreateDirectoryIfNotExist(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }
    }
}