using cjsupport.Common.Dtos;

namespace cjsupport.Domain.Services.Interfaces
{
    public interface ISupportTicketService
    {
        Task<ServiceResponse<List<SupportTicketDto>>> GetAllSupportTickets();
        Task<ServiceResponse<SupportTicketDto>> GetSupportTicketById(Guid id);
        Task<ServiceResponse<SupportTicketDto>> AddSupportTicket(SupportTicketDto supportTicketDto);
    }
}
