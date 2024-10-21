using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.ConsumerService.Bo;

namespace SupportLayer.JwtUtils;

public class CustomJwtService(IOptionsMonitor<JwtTokenOptions> jwtTokenOptions):ICustomJwtService
{
    //获取token选项
    private readonly JwtTokenOptions _jto = jwtTokenOptions.CurrentValue;
    
    /// <summary>
    /// 获取jwt Token
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    public string GetToken(ConsumerJwtBo info)
    {
        //jwt承载主体
        var claims = new[]
        {
            new Claim("ConsumerName", info.ConsumerName),
            new Claim("NickName", info.NickName ?? "default"),
            new Claim("LoginDate", info.LoginDate.ToString("yyyy-MM-dd")),
            new Claim("RoleName", info.RoleName)
        };
        //获取密钥
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jto.SecurityKey));
        //加密
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //Token 拼接
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _jto.Issuer,
            audience: _jto.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(_jto.Expired),
            signingCredentials: credentials
        );
        string returnToken = new JwtSecurityTokenHandler().WriteToken(token);
        return returnToken;
    }
}