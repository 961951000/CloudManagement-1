using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using CloudManagement.DatabaseContext;
using CloudManagement.Models;

namespace CloudManagement.Controllers
{
    public class DemoController : ApiController
    {
        private int Add(User user)
        {
            using (var db = new SqlServerContext())
            {
                db.User.Add(user);
                return db.SaveChanges();
            }
        }

        public int Update(User user)
        {
            using (var db = new SqlServerContext())
            {
                db.User.Attach(user);
                return db.SaveChanges();
            }
        }

        public JsonResult<User> Query(int id)
        {
            using (var db = new SqlServerContext())
            {
                return Json(db.User.FirstOrDefault(x => x.UserID == id));
            }
        }

        // GET api/values
        [AllowAnonymous]
        public JsonResult<User[]> Get()
        {
            using (var db = new SqlServerContext())
            {
                return Json(db.User.ToArray());
            }
        }

        // GET api/values/5
        public JsonResult<User> Get(int id)
        {
            return Query(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            using (var db = new SqlServerContext())
            {
                var user = db.User.FirstOrDefault(x => x.UserID == id);
                if (user != null)
                {
                    db.User.Remove(user);
                }
                db.SaveChanges();
            }
        }
    }
}
