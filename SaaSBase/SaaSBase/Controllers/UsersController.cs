using Microsoft.AspNetCore.Mvc;
using SaaSBase.Extensions;
using SaaSBase.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaaSBase.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<AppUser> Get()
        {
            using (var session = RavenExtensions.Store.OpenSession("saas_" + tenet))
            {
                var users = session.Query<AppUser>().ToList();
                return users;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public AppUser Get(string id)
        {
            using (var session = RavenExtensions.Store.OpenSession("saas_" + tenet))
            {
                var user = session.Load<AppUser>(id);
                return user;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]AppUser value)
        {
            using (var session = RavenExtensions.Store.OpenSession("saas_" + tenet))
            {
                session.Store(value);
                session.SaveChanges();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]AppUser value)
        {
            using (var session = RavenExtensions.Store.OpenSession("saas_" + tenet))
            {
                var user = session.Load<AppUser>(id);
                if (user != null)
                {
                    user.AccessFailedCount = value.AccessFailedCount;
                    user.Email = value.Email;
                    user.EmailConfirmed = value.EmailConfirmed;
                    user.IsPhoneNumberConfirmed = value.IsPhoneNumberConfirmed;
                    user.LockoutEnabled = value.LockoutEnabled;
                    user.LockoutEndDate = value.LockoutEndDate;
                    user.PasswordHash = value.PasswordHash;
                    user.PhoneNumber = value.PhoneNumber;
                    user.SecurityStamp = value.SecurityStamp;
                    user.TwoFactorAuthenticatorKey = value.TwoFactorAuthenticatorKey;
                    user.TwoFactorEnabled = value.TwoFactorEnabled;
                    user.TwoFactorRecoveryCodes = value.TwoFactorRecoveryCodes;
                    user.UserName = value.UserName;
                    
                    session.SaveChanges();
                }
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            using (var session = RavenExtensions.Store.OpenSession("saas_" + tenet))
            {
                var user = session.Load<AppUser>(id);
                if (user != null)
                {
                    session.Delete(user);
                    session.SaveChanges();
                }
            }
        }
    }
}
