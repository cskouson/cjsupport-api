using System;
using System.Collections.Generic;

namespace cjsupport.Data.Entities
{
    public class SupportTicketEntity
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
    }
}
