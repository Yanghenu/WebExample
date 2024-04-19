using FreeSql.DataAnnotations;
using System.Security.Principal;
using System.Xml.Linq;

namespace WebMap.Models
{
    public class LocationTable
    {
        [Column(IsIdentity = true,IsPrimary = true)]
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Column(IsPrimary = true)]
        public string UserName { get; set; }
        /// <summary>
        /// 定位信息
        /// </summary>
        public string LocationInfo { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        public int Online { get; set; }
    }
}
