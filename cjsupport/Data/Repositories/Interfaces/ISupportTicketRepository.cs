using cjsupport.Data.Entities;

namespace cjsupport.Data.Repositories.Interfaces
{
    public interface ISupportTicketRepository
    {
        Task<ICollection<SupportTicketEntity>> GetAllSupportTickets();
        Task<SupportTicketEntity> GetSupportTicketById(Guid id);
        Task<bool> AddSupportTicket(SupportTicketEntity entity);
    }
}
