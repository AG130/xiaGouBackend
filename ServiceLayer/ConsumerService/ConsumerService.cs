using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using ModelLayer.PgEntitys.Consumer;
using SqlSugar;
using SupportLayer.Db;
using ServiceLayer.ConsumerService.Dto;
using SupportLayer.JwtUtils;
using SupportLayer.JwtUtils.Bo;

namespace ServiceLayer.ConsumerService;

public class ConsumerService(IMapper mapper,ICustomJwtService customJwtService):IConsumerService
{
    
    #region MD5加密
    /// <summary>
    /// MD5加密密码
    /// </summary>
    /// <param name="input">密码</param>
    /// <returns>MD5加密串</returns>
    private static string ComputeMd5(string input)
    {
        using var md5 = MD5.Create();
        //获取输入字节
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        //转hash
        byte[] hash = md5.ComputeHash(inputBytes);
        StringBuilder sb = new StringBuilder();
        foreach (var bt  in hash)
        {
            sb.Append(bt.ToString("X2"));
        }

        return sb.ToString();
    }

    #endregion
    
    public async Task<string> ConsumerLogin(LoginDto info)
    {
        string pwdMd5 = ComputeMd5(info.Password);
        using var db1 = DbContext.XgDb;
        ConsumerPo csm = await db1.Queryable<ConsumerPo>()
            .FirstAsync(m=>m.ConsumerName.Equals(info.ConsumerName));
        ConsumerJwtBo cjb = mapper.Map<ConsumerJwtBo>(csm);
        string token = customJwtService.GetToken(cjb);
        return token;
    }
}