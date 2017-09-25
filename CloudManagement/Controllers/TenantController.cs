﻿using CloudManagement.DatabaseContext;
using CloudManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CloudManagement.Controllers
{
    /// <summary>
    /// 租户控制器
    /// </summary>
    public class TenantController : ApiController
    {
        private readonly SqlServerContext _db;
        //private readonly string _endpoint= HttpContext.Current.Request.Url.Host;

        /// <summary>
        /// 构造函数
        /// </summary>
        public TenantController() : this(new SqlServerContext()) { }

        internal TenantController(SqlServerContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 获取租户列表
        /// </summary>
        /// <returns>租户列表</returns>
        public async Task<HttpResponseMessage> GetTenantList()
        {
            var result = _db.Tenant;
            foreach (var tenant in result)
            {
                tenant.TenantDetail = await _db.TenantDetail.SingleAsync(x => x.TenantDetailId == tenant.TenantDetailId);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户编号获取租户信息
        /// </summary>
        /// <param name="id">租户编号</param>
        /// <returns>租户信息</returns>
        public async Task<HttpResponseMessage> GetTenantByTenantId(int id)
        {
            var result = await _db.Tenant.SingleAsync(x => x.TenantId == id);
            result.TenantDetail = await _db.TenantDetail.SingleAsync(x => x.TenantDetailId == result.TenantDetailId);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由创建用户获取租户列表
        /// </summary>
        /// <param name="id">创建用户编号</param>
        /// <returns>租户列表</returns>
        public async Task<HttpResponseMessage> GetTenantListByCreateByUser(int id)
        {
            var result = await _db.Tenant.Where(x => x.CreateByUserId == id).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由租户名称获取租户列表
        /// </summary>
        /// <param name="tenantPrincipalName">租户名称</param>
        /// <returns>租户列表</returns>
        public async Task<HttpResponseMessage> GetTenantListByTenantPrincipalName(string tenantPrincipalName)
        {
            var tenantDetailList = _db.TenantDetail.Where(x => x.TenantPrincipalName == tenantPrincipalName);
            var result = new List<Tenant>();
            foreach (var tenantDetail in tenantDetailList)
            {
                var tenant = await _db.Tenant.SingleAsync(x => x.TenantDetailId == tenantDetail.TenantDetailId);
                tenant.TenantDetail = tenantDetail;
                result.Add(tenant);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 添加租户
        /// </summary>
        /// <param name="id">创建人用户编号</param>
        /// <param name="tenantDetail">租户详细信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddTenant(int id, TenantDetail tenantDetail)
        {
            var tenant = new Tenant
            {
                CreateByUserId = id,
                CreateTime = DateTime.Now,
                TenantDetail = tenantDetail
            };
            _db.Tenant.Add(tenant);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 更新租户信息
        /// </summary>
        /// <param name="id">租户编号</param>
        /// <param name="tenant">租户信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Update(int id, Tenant tenant)
        {
            tenant.TenantId = id;
            tenant.UpdateTime = DateTime.Now;
            _db.Entry(tenant).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 删除租户
        /// </summary>
        /// <param name="id">租户编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var tenant = await _db.Tenant.SingleAsync(x => x.TenantId == id);
            _db.Tenant.Remove(tenant);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }
    }
}
