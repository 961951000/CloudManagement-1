using CloudManagement.DatabaseContext;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CloudManagement.Models;

namespace CloudManagement.Controllers
{
    /// <summary>
    /// 角色控制器
    /// </summary>
    public class RoleController : ApiController
    {
        private readonly SqlServerContext _db;

        /// <summary>
        /// 构造函数
        /// </summary>
        public RoleController() : this(new SqlServerContext()) { }

        internal RoleController(SqlServerContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns>角色列表</returns>
        public async Task<HttpResponseMessage> GetRoleList()
        {
            var result = await _db.Role.ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由角色编号获取角色信息
        /// </summary>
        /// <param name="id">角色编号</param>
        /// <returns>角色组信息</returns>
        public async Task<HttpResponseMessage> GetRoleByRoleId(int id)
        {
            var result = await _db.Role.SingleAsync(x => x.RoleId == id);

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由创建用户获取角色列表
        /// </summary>
        /// <param name="id">角色编号</param>
        /// <returns>角色列表</returns>
        public async Task<HttpResponseMessage> GetRoleListByCreateByUser(int id)
        {
            var result = await _db.Role.Where(x => x.CreateByUserId == id).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由用户组获取角色列表
        /// </summary>
        /// <param name="id">用户组编号</param>
        /// <returns>角色列表</returns>
        public async Task<HttpResponseMessage> GetRoleListByUserGroup(int id)
        {
            var result = await _db.Role.Where(x => x.UserGroupRoleMapping.UserGroupId == id).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由角色名称获取角色列表
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <returns>角色列表</returns>
        public async Task<HttpResponseMessage> GetGroupListByRoleName(string roleName)
        {
            var result = await _db.Role.Where(x => x.RoleName == roleName).ToListAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由用户组移入角色
        /// </summary>
        /// <param name="id">用户组编号</param>
        /// <param name="roleId">角色编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> MoveInRoleByUserGroup(int id, int roleId)
        {
            var userGroupRoleMapping = new UserGroupRoleMapping
            {
                UserGroupId = id,
                RoleId = roleId
            };
            _db.UserGroupRoleMapping.Add(userGroupRoleMapping);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 由用户组移出角色
        /// </summary>
        /// <param name="id">用户组编号</param>
        /// <param name="roleId">角色编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> MoveOutRoleByUserGroup(int id, int roleId)
        {
            var userGroupRoleMappingList = _db.UserGroupRoleMapping.Where(x => x.UserGroupId == id && x.RoleId == roleId);
            _db.UserGroupRoleMapping.RemoveRange(userGroupRoleMappingList);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="id">创建人用户编号</param>
        /// <param name="role">角色信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> AddRole(int id, Role role)
        {
            role.CreateByUserId = id;
            role.CreateTime = DateTime.Now;
            _db.Role.Add(role);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="id">角色编号</param>
        /// <param name="role">角色信息</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Update(int id, Role role)
        {
            role.RoleId = id;
            role.UpdateTime = DateTime.Now;
            _db.Entry(role).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id">角色编号</param>
        /// <returns>写入基础数据库的状态项数</returns>
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var role = await _db.Role.SingleAsync(x => x.RoleId == id);
            _db.Role.Remove(role);
            var result = await _db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, Json(result));
        }
    }
}
