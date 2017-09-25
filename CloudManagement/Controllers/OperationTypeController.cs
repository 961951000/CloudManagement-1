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
    /// 操作类型控制器
    /// </summary>
    public class OperationTypeController : ApiController
    {
        private readonly SqlServerContext _db;

        /// <summary>
        /// 构造函数
        /// </summary>
        public OperationTypeController() : this(new SqlServerContext()) { }

        internal OperationTypeController(SqlServerContext db)
        {
            _db = db;
        }

        /// <summary>
        ///操作类型
        /// </summary>
        /// <param name="operationType">操作类型</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddOperationType(OperationType operationType)
        {
            _db.OperationType.Add(operationType);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由操作类型编号获取操作类型信息
        /// </summary>
        /// <param name="id">操作类型编号</param>
        /// <returns>操作类型信息</returns>
        public async Task<HttpResponseMessage> GetOperationTypeByOperationTypeId(int id)
        {
            var result = await _db.OperationType.SingleAsync(x => x.OperationTypeId == id);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由操作类型代码获取用户信息
        /// </summary>
        /// <param name="typeCode">操作类型代码</param>
        /// <returns>操作类型信息</returns>
        public async Task<HttpResponseMessage> GetOperationTypeByOperationTypeCode(string typeCode)
        {
            var result = await _db.OperationType.SingleAsync(x => x.TypeCode == typeCode);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由操作类型名称获取操作类型列表
        /// </summary>
        /// <param name="operationTypeName">操作类型名称</param>
        /// <returns>操作类型列表</returns>
        public async Task<HttpResponseMessage> GetOperationTypeByOperationTypeName(string operationTypeName)
        {
            var result = await _db.OperationType.Where(x => x.OperationName == operationTypeName).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }
    }
}
