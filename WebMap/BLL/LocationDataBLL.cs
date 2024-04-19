using WebMap.DAL;
using WebMap.Models;

namespace WebMap.BLL
{
    public class LocationDataBLL
    {
        LocationDataDAL dal = new LocationDataDAL();

        /// <summary>
        /// 插入用户定位数据
        /// </summary>
        /// <param name="LocationInfo"></param>
        public int InsertUserInfo(UserInfo userInfo)
        { 
            return dal.InsertUserInfo(userInfo);
        }

        public List<Position> GetOtherUserInfo()
        { 
            return dal.GetOtherUserInfo();
        }

        public void UpdateUserInfo(string LocationInfo)
        { 
            dal.UpdateUserInfo(LocationInfo);
        }
    }
}
