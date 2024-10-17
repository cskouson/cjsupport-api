using cjsupport.Common.Dtos;
using cjsupport.Data.Entities;
using AutoMapper;

namespace cjsupport.Common.Mapping
{
    public class DtoMapper : Profile
    {
        public DtoMapper() 
        {
                CreateMap<SupportTicketEntity, SupportTicketDto>().ReverseMap();
                CreateMap<SupportTicketControllerPostDto, SupportTicketDto>().ReverseMap();
        }

    }
}
