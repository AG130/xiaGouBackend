using SqlSugar;
using Microsoft.Extensions.Configuration;

namespace SupportLayer.Db;

public class DbContext
{
    //加载配置文件
    private static readonly IConfigurationRoot Config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
    
    //获取连接字符串
    private static readonly string XgDbString = Config["ConnectionStrings:xiaGouPg"]?? string.Empty;

    //创建数据库连接实例
    public static SqlSugarClient XgDb =>
        new(new ConnectionConfig()
        {
            ConnectionString = XgDbString,
            DbType = DbType.PostgreSQL,
            IsAutoCloseConnection = true,
            MoreSettings = new ConnMoreSettings()
            {
                PgSqlIsAutoToLower = false,             //关闭自动转小写
                PgSqlIsAutoToLowerCodeFirst = false,    // 关闭建表用驼峰命名
            }
        });

}