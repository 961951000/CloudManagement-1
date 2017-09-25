using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CloudManagement.DatabaseContext;
using CloudManagement.Models;

namespace CloudManagement.Controllers
{
    /// <summary>
    /// 操作日志控制器
    /// </summary>
    public class OperationLogController : ApiController
    {
        private readonly SqlServerContext _db;

        /// <summary>
        /// 构造函数
        /// </summary>
        public OperationLogController() : this(new SqlServerContext()) { }

        internal OperationLogController(SqlServerContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 添加操作日志
        /// </summary>
        /// <param name="operationLog">服务信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddService(OperationLog operationLog)
        {
            operationLog.CreateTime = DateTime.Now;
            _db.OperationLog.Add(operationLog);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }
    }
}
