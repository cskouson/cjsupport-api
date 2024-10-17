using Microsoft.EntityFrameworkCore;
using cjsupport.Data.Repositories.Interfaces;
using cjsupport.Data.Entities;

namespace cjsupport.Data.Repositories
{
    public class SupportTicketRepository : ISupportTicketRepository
    {
        private readonly CjsupportDbContext _dbContext;

        public SupportTicketRepository(CjsupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<SupportTicketEntity>> GetAllSupportTickets()
        {
            return await _dbContext.SupportTickets.ToListAsync();
        }

        public async Task<SupportTicketEntity> GetSupportTicketById(Guid id)
        {
            return await _dbContext.SupportTickets.Where<SupportTicketEntity>(e => e.Id.Equals(id)).FirstAsync();
        }

        public async Task<bool> AddSupportTicket(SupportTicketEntity entity)
        {
            _dbContext.SupportTickets.Add(entity);
            return await Save();
        }

        public async Task<bool> DeleteSupportTicket(SupportTicketEntity entity)
        {
            _dbContext.SupportTickets.Remove(entity);
            return await Save();
        }

        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
