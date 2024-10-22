using ServiceLayer.ConsumerService.Dto;

namespace ServiceLayer.ConsumerService;

public interface IConsumerService
{
    //登录
    Task<string> ConsumerLogin(LoginDto info);
}