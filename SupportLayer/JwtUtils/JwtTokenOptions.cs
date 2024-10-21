namespace SupportLayer.JwtUtils;

/// <summary>
/// jwtToken选项
/// </summary>
public class JwtTokenOptions
{
    //发布者
    public required string Issuer { get; set; }
    //接收者
    public required string Audience { get; set; }
    //密钥
    public required string SecurityKey { get; set; }
    //到期时间（day）
    public int Expired { get; set; }
}