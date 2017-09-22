using CloudManagement.DatabaseContext;
using CloudManagement.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CloudManagement.Services
{
    public class UserService
    {
        private readonly SqlServerContext _db = new SqlServerContext();

        public async Task<int?> Add(User user)
        {
            _db.User.Add(user);
            var result = await _db.SaveChangesAsync();

            return result;
        }

        public async Task<int?> Delete(User user)
        {
            _db.User.Remove(user);
            var result = await _db.SaveChangesAsync();

            return result;
        }

        public async Task<int?> Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<Tenant>> Query()
        {
            var result = await _db.Tenant.ToListAsync();

            return result;
        }

        public async Task<IQueryable<User>> GetUserListByTenant(int? tenantId)
        {
            var result = _db.User.Where(x => x.TenantId == tenantId);
            foreach (var item in result)
            {
                item.UserDetail = await GetUserDetailByUser(item.UserDetailId);
            }

            return result;
        }

        public async Task<User> GetUserByTenant(int? userId, int? tenantId)
        {
            var userListByTenant = await GetUserListByTenant(tenantId);
            var result = await userListByTenant.SingleAsync(x => x.UserId == userId);
            result.UserDetail = await GetUserDetailByUser(result.UserDetailId);

            return result;
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var result = await _db.User.Join(
                _db.UserDetail.Where(x => x.UserPrincipalName == userName),
                x => x.UserDetailId,
                y => y.UserDetailId,
                (x, y) => x).SingleAsync();

            return result;
        }

        public async Task<User> GetUserByTokenAsync(string token)
        {
            var result = await _db.User.SingleAsync(x => x.Token == token);

            return result;
        }

        

        public async Task<UserDetail> GetUserDetailByUser(int? userDetailId)
        {
            var result = await _db.UserDetail.SingleAsync(x => x.UserDetailId == userDetailId);

            return result;
        }
    }
}