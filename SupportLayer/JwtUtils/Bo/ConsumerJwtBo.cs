namespace SupportLayer.JwtUtils.Bo;

/// <summary>
/// 用于jwt生成的用户信息
/// </summary>
public class ConsumerJwtBo
{
    //用户名
    public required string ConsumerName { get; set; }
    //昵称
    public string? NickName { get; set; }
    //登录日期
    public DateTime LoginDate { get; set; }
    //角色
    public required string RoleName { get; set; }
}