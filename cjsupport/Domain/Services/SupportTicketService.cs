using AutoMapper;
using cjsupport.Common.Dtos;
using cjsupport.Data.Entities;
using cjsupport.Data.Repositories.Interfaces;
//using cjsupport.Domain.BusinessRules.SupportTicketRules;
using cjsupport.Domain.Services.Interfaces;


namespace cjsupport.Domain.Services
{
    public class SupportTicketService : ISupportTicketService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ISupportTicketRepository _supportTicketrepository;

        public SupportTicketService(IMapper mapper, IConfiguration configuration, ISupportTicketRepository repository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _supportTicketrepository = repository;
        }

        public async Task<ServiceResponse<List<SupportTicketDto>>> GetAllSupportTickets()
        {
            ServiceResponse<List<SupportTicketDto>> Response = new();

            try
            {
                var TicketList = await _supportTicketrepository.GetAllSupportTickets();
                var TicketDtoList = new List<SupportTicketDto>();

                foreach (var ticket in TicketList)
                {
                    TicketDtoList.Add(_mapper.Map<SupportTicketDto>(ticket));
                }

                Response.Data = TicketDtoList;
                Response.Success = true;
                Response.Message = "Ok";
            }
            catch (Exception ex)
            {
                Response.Data = null;
                Response.Success = false;
                Response.Message = "Error";
                Response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return Response;
        }

        public async Task<ServiceResponse<SupportTicketDto>> GetSupportTicketById(Guid id)
        {
            ServiceResponse<SupportTicketDto> Response = new();

            try
            {
                var Ticket = await _supportTicketrepository.GetSupportTicketById(id);
                var TicketDto = _mapper.Map<SupportTicketDto>(Ticket);

                Response.Data = TicketDto;
                Response.Success = true;
                Response.Message = "Ok";
            }
            catch(Exception ex) 
            { 
                Response.Data = null;
                Response.Success = false;
                Response.Message = "Error";
                Response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return Response;
        }

        public async Task<ServiceResponse<SupportTicketDto>> AddSupportTicket(SupportTicketDto supportTicketDto)
        {
            ServiceResponse<SupportTicketDto> Response = new();

            try
            {
                SupportTicketEntity Ticket = new SupportTicketEntity()
                {
                    Id = Guid.NewGuid(),
                    UserEmail = supportTicketDto.UserEmail,
                    Description = supportTicketDto.Description,
                    DueDate = DateTime.Parse(supportTicketDto.DueDate).ToUniversalTime(),
                    IsComplete = false
                };

                if(!await _supportTicketrepository.AddSupportTicket(Ticket))
                {
                    Response.Data = null;
                    Response.Success = false;
                    Response.Error = "RepoError";
                    return Response;
                }

                Response.Data = _mapper.Map<SupportTicketDto>(Ticket);
                Response.Success = true;
                Response.Message = "Ok";
            }
            catch (Exception ex)
            {
                Response.Data = null;
                Response.Success = false;
                Response.Message = "Error";
                Response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return Response;
        }
    }
}
