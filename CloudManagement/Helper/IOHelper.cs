using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace CloudManagement.Helper
{
    public class IOHelper
    {
        /// <summary>
        /// 网站根目录
        /// </summary>
        public static string RootPath => HostingEnvironment.MapPath("~/App_Data");

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