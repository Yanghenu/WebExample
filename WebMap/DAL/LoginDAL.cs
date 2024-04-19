using Microsoft.AspNetCore.Mvc.Routing;
using System.Data;
using System.Security.Principal;
using System.Text;
using WebMap.Helpers;
using WebMap.Models;

namespace WebMap.DAL
{
    public class LoginDAL
    {
        private readonly DBHelper _DbHelper = new DBHelper();
        public string GetAccounts(string user, string password)
        {
            StringBuilder sb = new StringBuilder();
            
            var list = _DbHelper.Fsql.Select<Account>().Where(o => o.user == user && o.Password == password).ToList();
            if (list != null && list.Count > 0)
            {
                return list.First().user;
            }
            else
            {
                _DbHelper.Fsql.Insert<Account>(new Account { user = user,Password = password}).ExecuteAffrows();
                return user;
            }
        }
    }
}
