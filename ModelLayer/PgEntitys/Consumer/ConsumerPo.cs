using SqlSugar;
namespace ModelLayer.PgEntitys.Consumer;

[SugarTable("Consumer")]
public class ConsumerPo
{
    /// <summary>
    /// 注册用户表
    /// </summary>
    
    //数据库id
    [SugarColumn(IsIdentity = true,IsPrimaryKey = true)]
    public int DbId { get; set; }
    //用户名称/代号/注册号码
    public string ConsumerName { get; set; }
    //密码
    public string Password { get; set; }
    //昵称
    public string? NickName { get; set; }
    //注册日期
    public DateTime RegisterDate { get; set; }
    //登录日期
    public DateTime LoginDate { get; set; }
    //角色代号
    public int RoleCode { get; set; }
    //备注
    public string? Notice { get; set; }
}