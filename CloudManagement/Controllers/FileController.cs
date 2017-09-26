using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using CloudManagement.Helper;

namespace CloudManagement.Controllers
{
    /// <summary>
    /// 文件控制器
    /// </summary>
    public class FileController : ApiController
    {
        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public HttpResponseMessage FileDownload(string fileName)
        {
            HttpResponseMessage result;
            var directoryInfo = new DirectoryInfo(Path.Combine(IOHelper.RootPath, @"Resources/Files/Upload"));
            var foundFileInfo = directoryInfo.GetFiles().FirstOrDefault(x => x.Name == fileName);
            if (foundFileInfo != null)
            {
                var fs = new FileStream(foundFileInfo.FullName, FileMode.Open);
                result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(fs)
                };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = foundFileInfo.Name
                };
            }
            else
            {
                result = new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return result;
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> FileUpload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var rootPath = Path.Combine(IOHelper.RootPath, "Temp");
            IOHelper.CreateDirectoryIfNotExist(rootPath);
            var provider = new MultipartFormDataStreamProvider(rootPath);
            // Read the form data.  
            await Request.Content.ReadAsMultipartAsync(provider);
            var fileNameList = new List<string>();
            var sb = new StringBuilder();
            long fileTotalSize = 0;
            var fileIndex = 1;
            // This illustrates how to get the file names.
            foreach (MultipartFileData file in provider.FileData)
            {
                //new folder
                var newRoot = Path.Combine(IOHelper.RootPath, @"Resources\Files\Upload");
                IOHelper.CreateDirectoryIfNotExist(newRoot);
                if (File.Exists(file.LocalFileName))
                {
                    //new fileName
                    var fileName = file.Headers.ContentDisposition.FileName.TrimStart('"').TrimEnd('"');
                    var newFileName = Guid.NewGuid() + "." + fileName.Split('.')[1];
                    var newFullFileName = Path.Combine(newRoot, newFileName);
                    fileNameList.Add(newFileName);
                    var fileInfo = new FileInfo(file.LocalFileName);
                    fileTotalSize += fileInfo.Length;
                    sb.Append($" #{fileIndex} Uploaded file: {newFileName} ({fileInfo.Length} bytes)");
                    fileIndex++;
                    File.Move(file.LocalFileName, newFullFileName);
                    Trace.WriteLine("1 file copied , filePath=" + newFullFileName);
                }
            }
            Logger.Info($"{fileNameList.Count} file(s) /{fileTotalSize} bytes uploaded successfully!     Details -> {sb}");

            return Request.CreateResponse(HttpStatusCode.OK, Json(fileNameList));
        }
    }
}