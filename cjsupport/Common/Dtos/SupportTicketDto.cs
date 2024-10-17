namespace cjsupport.Common.Dtos
{
    public class SupportTicketDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public bool IsComplete { get; set; }
    }
}
