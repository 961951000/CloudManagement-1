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
    /// 服务控制器
    /// </summary>
    public class ServiceController : ApiController
    {
        private readonly SqlServerContext _db;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ServiceController() : this(new SqlServerContext()) { }

        internal ServiceController(SqlServerContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 获取服务列表
        /// </summary>
        /// <returns>服务列表</returns>
        public async Task<HttpResponseMessage> GetServiceList()
        {
            var result = await _db.Service.ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由服务编号获取服务信息
        /// </summary>
        /// <param name="id">服务编号</param>
        /// <returns>服务信息</returns>
        public async Task<HttpResponseMessage> GetServiceByServiceId(int id)
        {
            var result = await _db.Service.SingleAsync(x => x.ServiceId == id);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由服务代码获取服务信息
        /// </summary>
        /// <param name="serviceCode">服务代码</param>
        /// <returns>服务信息</returns>
        public async Task<HttpResponseMessage> GetServiceByServiceCode(string serviceCode)
        {
            var result = await _db.Service.SingleAsync(x => x.ServiceCode == serviceCode);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由服务名称获取服务列表
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <returns>服务列表</returns>
        public async Task<HttpResponseMessage> GetServiceByServiceName(string serviceName)
        {
            var result = await _db.Service.Where(x => x.ServiceName == serviceName).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 添加服务
        /// </summary>
        /// <param name="service">服务信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddService(Service service)
        {
            _db.Service.Add(service);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 更新服务信息
        /// </summary>
        /// <param name="id">服务编号</param>
        /// <param name="service">服务信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Update(int id, Service service)
        {
            service.ServiceId = id;
            _db.Entry(service).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 删除服务
        /// </summary>
        /// <param name="id">服务编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var service = await _db.Service.SingleAsync(x => x.ServiceId == id);
            _db.Service.Remove(service);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }
    }
}
