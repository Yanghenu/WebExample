using Newtonsoft.Json;
using System;
using System.Diagnostics;
using WebMap.Helpers;
using WebMap.Models;

namespace WebMap.DAL
{
    public class LocationDataDAL
    {
        private readonly DBHelper _DbHelper = new DBHelper();
        
        public int InsertUserInfo(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return 0;
            }
            else
            {
                LocationTable locationTable = new LocationTable();
                locationTable.LocationInfo = JsonConvert.SerializeObject(userInfo.Geolocation);
                locationTable.Online = 1;
                locationTable.UserName = userInfo.UserName;

                _DbHelper.Fsql.InsertOrUpdate<LocationTable>().SetSource(locationTable).ExecuteAffrowsAsync();
                return 1;
            }
        }

        public List<Position> GetOtherUserInfo()
        {
            List<Position> result = new List<Position>();
            var list = _DbHelper.Fsql.Select<LocationTable>().ToList();
            string IP = IPHelper.GetIPv4();
            var locationInfo = list.Where(o => o.Online == 1).ToList().Select(o=> o.LocationInfo).ToList();
            foreach (var item in locationInfo)
            {
                var model = JsonConvert.DeserializeObject<GeolocationResult>(item);
                result.Add(model.position);
            }
            return result;
        }

        public void UpdateUserInfo(string LocationInfo)
        {
            _DbHelper.Fsql.Update<LocationTable>().Where(o => o.LocationInfo == LocationInfo).Set(o => o.Online == 0).ExecuteAffrows();
        }
    }
}
