using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CloudManagement.DatabaseContext;
using CloudManagement.Models;
using CloudManagement.Helper;

namespace CloudManagement.Controllers
{
    /// <summary>
    /// 第三方服务控制器
    /// </summary>
    public class ThirdPartyServiceController : ApiController
    {
        private readonly SqlServerContext _db;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ThirdPartyServiceController() : this(new SqlServerContext()) { }

        internal ThirdPartyServiceController(SqlServerContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 获取第三方服务列表
        /// </summary>
        /// <returns>第三方服务列表</returns>
        public async Task<HttpResponseMessage> GetThirdPartyServiceList()
        {
            var result = await _db.ThirdPartyService.ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由第三方服务编号获取第三方服务信息
        /// </summary>
        /// <param name="id">第三方服务编号</param>
        /// <returns>第三方服务信息</returns>
        public async Task<HttpResponseMessage> GetThirdPartyServiceByThirdPartyServiceId(int id)
        {
            var result = await _db.ThirdPartyService.SingleAsync(x => x.ThirdPartyServiceId == id);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由第三方服务代码获取第三方服务信息
        /// </summary>
        /// <param name="thirdPartyServiceCode">第三方服务代码</param>
        /// <returns>第三方服务信息</returns>
        public async Task<HttpResponseMessage> GetThirdPartyServiceByThirdPartyServiceCode(string thirdPartyServiceCode)
        {
            var result = await _db.ThirdPartyService.SingleAsync(x => x.ThirdPartyServiceCode == thirdPartyServiceCode);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由第三方服务绑定令牌获取第三方服务信息
        /// </summary>
        /// <param name="bindToken">绑定令牌</param>
        /// <returns>第三方服务信息</returns>
        public async Task<HttpResponseMessage> GetThirdPartyServiceByBindToken(string bindToken)
        {
            var result = await _db.ThirdPartyService.SingleAsync(x => x.BindToken == bindToken);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由第三方服务名称获取第三方服务列表
        /// </summary>
        /// <param name="thirdPartyServiceName">第三方服务名称</param>
        /// <returns>第三方服务列表</returns>
        public async Task<HttpResponseMessage> GetThirdPartyServiceListByThirdPartyServiceName(string thirdPartyServiceName)
        {
            var result = await _db.ThirdPartyService.Where(x => x.ThirdPartyServiceName == thirdPartyServiceName).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 添加第三方服务
        /// </summary>
        /// <param name="thirdPartyService">第三方服务信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddService(ThirdPartyService thirdPartyService)
        {
            _db.ThirdPartyService.Add(thirdPartyService);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 更新第三方服务信息
        /// </summary>
        /// <param name="id">第三方服务编号</param>
        /// <param name="thirdPartyService">第三方服务信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Update(int id, ThirdPartyService thirdPartyService)
        {
            thirdPartyService.ThirdPartyServiceId = id;
            _db.Entry(thirdPartyService).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 删除第三方服务
        /// </summary>
        /// <param name="id">第三方服务编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var thirdPartyService = await _db.ThirdPartyService.SingleAsync(x => x.ThirdPartyServiceId == id);
            _db.ThirdPartyService.Remove(thirdPartyService);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 第三方服务令牌登录
        /// </summary>
        /// <param name="bindToken">绑定令牌</param>
        /// <returns>用户编号</returns>
        public async Task<HttpResponseMessage> LoginByToken(string bindToken)
        {
            var token = await _db.ThirdPartyService.Where(x => x.BindToken == bindToken).Join(
                _db.UserThirdPartyServiceMapping,
                x => x.ThirdPartyServiceId,
                y => y.ThirdPartyServiceId,
                (x, y) => y.UserId).Join(
                _db.User,
                x => x,
                y => y.UserId,
                (x, y) => y.Token
                ).SingleAsync();
            var requestUrl = Path.Combine(HttpContext.Current.Request.Url.Host, "User/LoginByToken");
            var response = await requestUrl.ExecutePostServiceCall(Request.Headers.Authorization.Parameter, requestUrl, Json(token));

            return response;
        }
    }
}
