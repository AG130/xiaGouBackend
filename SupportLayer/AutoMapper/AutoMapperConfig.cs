using AutoMapper;
using ModelLayer.PgEntitys.Consumer;
using SupportLayer.JwtUtils.Bo;

namespace SupportLayer.AutoMapper;

public class AutoMapperConfig:Profile
{
    public AutoMapperConfig()
    {
        CreateMap<ConsumerPo, ConsumerJwtBo>()
            .ForMember(cjb => cjb.RoleName,
                opt =>
                    opt.MapFrom(csm => csm.RolePo.RoleName));
    }
}