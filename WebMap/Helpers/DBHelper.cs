using FreeSql.Internal;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace WebMap.Helpers
{
    public class DBHelper
    {
        private IFreeSql _fsql;
        public IFreeSql Fsql
        {
            get
            {
                if (_fsql == null)
                {
                    _fsql = new FreeSql.FreeSqlBuilder()
                      .UseNameConvert(NameConvertType.ToLower)
                      .UseMonitorCommand(cmd => Trace.WriteLine($"Sql：{cmd.CommandText}"))//监听SQL语句,Trace在输出选项卡中查看
                      .UseConnectionString(FreeSql.DataType.SqlServer, "Data Source=127.0.0.1;Initial Catalog=Test;Persist Security Info=True;User ID=sa;Password=1qa2ws@G;Pooling=true;Max Pool Size=512;Min Pool Size=0;MultipleActiveResultSets=true")
                      .UseAutoSyncStructure(false) //自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表。
                      .Build();
                }
                return _fsql;
            }
        }
    }
}
