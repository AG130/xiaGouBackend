namespace ServiceLayer.ConsumerService.Dto;

/// <summary>
/// 登录Dto
/// </summary>
public class LoginDto
{
    //用户名
    public required string ConsumerName { get; set; }
    //密码
    public required string Password { get; set; }
}