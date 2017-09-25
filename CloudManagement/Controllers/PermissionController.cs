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
    /// 权限控制器
    /// </summary>
    public class PermissionController : ApiController
    {
        private readonly SqlServerContext _db;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PermissionController() : this(new SqlServerContext()) { }

        internal PermissionController(SqlServerContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns>权限列表</returns>
        public async Task<HttpResponseMessage> GetPermissionList()
        {
            var result = await _db.Permission.ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由权限编号获取权限信息
        /// </summary>
        /// <param name="id">权限编号</param>
        /// <returns>权限信息</returns>
        public async Task<HttpResponseMessage> GetPermissionByPermissionId(int id)
        {
            var result = await _db.Permission.SingleAsync(x => x.PermissionId == id);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由权限代码获取权限信息
        /// </summary>
        /// <param name="permissionCode">权限代码</param>
        /// <returns>权限信息</returns>
        public async Task<HttpResponseMessage> GetPermissionByPermissionCode(string permissionCode)
        {
            var result = await _db.Permission.SingleAsync(x => x.PermissionCode == permissionCode);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由服务获取权限列表
        /// </summary>
        /// <param name="id">服务编号</param>
        /// <returns>权限列表</returns>
        public async Task<HttpResponseMessage> GetPermissionListByService(int id)
        {
            var result = await _db.Permission.Where(x => x.ServiceId == id).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由角色获取权限列表
        /// </summary>
        /// <param name="id">角色编号</param>
        /// <returns>权限列表</returns>
        public async Task<HttpResponseMessage> GetPermissionListByRole(int id)
        {
            var result = await _db.RolePermissionMapping.Where(x => x.RoleId == id).Select(x => x.Permission).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由权限名称获取权限列表
        /// </summary>
        /// <param name="permissionName">权限名称</param>
        /// <returns>权限列表</returns>
        public async Task<HttpResponseMessage> GetGroupListByPermissionName(string permissionName)
        {
            var result = await _db.Permission.Where(x => x.PermissionName == permissionName).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由角色移入权限
        /// </summary>
        /// <param name="id">角色编号</param>
        /// <param name="permissionId">权限编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> MoveInPermissionByRole(int id, int permissionId)
        {
            var rolePermissionMapping = new RolePermissionMapping
            {
                RoleId = id,
                PermissionId = permissionId
            };
            _db.RolePermissionMapping.Add(rolePermissionMapping);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由角色移出权限
        /// </summary>
        /// <param name="id">角色编号</param>
        /// <param name="permissionId">权限编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> MoveOutPermissionByRole(int id, int permissionId)
        {
            var rolePermissionMappingList = _db.RolePermissionMapping.Where(x => x.RoleId == id && x.PermissionId == permissionId);
            _db.RolePermissionMapping.RemoveRange(rolePermissionMappingList);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由角色导入权限
        /// </summary>
        /// <param name="id">角色编号</param>
        /// <param name="permissionIdList">权限编号列表</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> ImportPermissionByRole(int id, IEnumerable<int> permissionIdList)
        {
            var rolePermissionListMappingList = permissionIdList.Select(permissionId => new RolePermissionMapping
            {
                RoleId = id,
                PermissionId = permissionId
            });
            _db.RolePermissionMapping.AddRange(rolePermissionListMappingList);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由角色导出权限
        /// </summary>
        /// <param name="id">角色编号</param>
        /// <param name="permissionIdList">权限编号列表</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> ExportPermissionByRole(int id, IQueryable<int> permissionIdList)
        {
            var rolePermissionListMappingList = await _db.RolePermissionMapping.Where(x => x.RoleId == id && permissionIdList.Contains((int)x.PermissionId)).ToListAsync();
            _db.RolePermissionMapping.RemoveRange(rolePermissionListMappingList);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="permission">权限信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddPermission(Permission permission)
        {
            _db.Permission.Add(permission);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 添加权限列表
        /// </summary>
        /// <param name="permissionList">权限列表</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddPermissionList(IEnumerable<Permission> permissionList)
        {
            _db.Permission.AddRange(permissionList);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由服务添加权限
        /// </summary>
        /// <param name="id">服务编号</param>
        /// <param name="permission">权限信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddPermissionByService(int id, Permission permission)
        {
            permission.ServiceId = id;
            _db.Permission.Add(permission);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由服务添加权限列表
        /// </summary>
        /// <param name="id">服务编号</param>
        /// <param name="permissionList">权限列表</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddPermissionListByService(int id, IEnumerable<Permission> permissionList)
        {
            permissionList = permissionList.Select(x => new Permission
            {
                ServiceId = id,
                PermissionId = x.PermissionId,
                PermissionName = x.PermissionName,
                PermissionCode = x.PermissionCode
            }).ToList();
            _db.Permission.AddRange(permissionList);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 更新权限信息
        /// </summary>
        /// <param name="id">权限编号</param>
        /// <param name="permission">权限信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Update(int id, Permission permission)
        {
            permission.PermissionId = id;
            _db.Entry(permission).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id">权限编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var permission = await _db.Permission.SingleAsync(x => x.PermissionId == id);
            _db.Permission.Remove(permission);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }
    }
}
