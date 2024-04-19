using WebMap.DAL;
using WebMap.Models;

namespace WebMap.BLL
{
    public class LoginBLL
    {
        LoginDAL dal = new LoginDAL();
        public string GetAccounts(string number, string password)
        { 
            return dal.GetAccounts(number, password);
        }
    }
}
