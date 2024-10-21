using ServiceLayer.ConsumerService.Bo;

namespace SupportLayer.JwtUtils;

public interface ICustomJwtService
{
    string GetToken(ConsumerJwtBo info);
}