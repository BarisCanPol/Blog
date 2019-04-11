using Blog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Repository.Entity
{
   public  class AppUserRepository : BaseRepository<AppUser>
    {
        public bool CheckCredentials(string UserName,string Password) //Araştır
        {
            return table.Any(q => q.UserName == UserName && q.Password == Password);

        }
        public AppUser FindByUserName(string UserName)
        {
            return table.FirstOrDefault(a => a.UserName == UserName);
           // return table.Where(x => x.UserName == UserName).FirstOrDefault();
        }
    }
}
