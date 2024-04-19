using FreeSql.DataAnnotations;

namespace WebMap.Models
{
    public class Account
    {
        [Column(IsPrimary = true,IsIdentity =true)]
        public int Id { get; set; }
        public string user { get; set; }
        public string Password { get; set; }
    }
}
