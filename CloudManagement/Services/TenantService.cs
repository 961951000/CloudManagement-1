using CloudManagement.DatabaseContext;
using CloudManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CloudManagement.Services
{
    public class TenantService
    {
        private readonly SqlServerContext _db = new SqlServerContext();

        public async Task<int?> Add(Tenant tenant)
        {
            _db.Tenant.Add(tenant);
            var result = await _db.SaveChangesAsync();

            return result;
        }

        public async Task<int?> Delete(Tenant tenant)
        {
            _db.Tenant.Remove(tenant);
            var result = await _db.SaveChangesAsync();

            return result;
        }

        public async Task<int?> Update(Tenant tenant)
        {
            _db.Entry(tenant).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<Tenant>> Query()
        {
            var result = await _db.Tenant.ToListAsync();

            return result;
        }

        public async Task<Tenant> GetTenantByUserAsync(int? userId)
        {
            var result = await _db.Tenant.SingleAsync(x => x.CreateByUserId == userId);

            return result;
        }
    }
}