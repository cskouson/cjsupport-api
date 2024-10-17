using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using cjsupport.Common.Dtos;
using cjsupport.Domain.Services.Interfaces;

namespace cjsupport.Api.Controllers
{
    [ApiController]
    [Route("/support-tickets")]
    public class SupportTicketController : ControllerBase
    {
        private readonly ISupportTicketService _supportTicketService;
        private readonly IMapper _mapper;

        public SupportTicketController(ISupportTicketService supportTicketService, IMapper mapper)
        {
            _supportTicketService = supportTicketService;
            _mapper = mapper;
        }

        [Route("get-all-support-tickets")]
        [HttpGet]
        public async Task<IActionResult> GetAllSupportTickets()
        {
            var Tickets = await _supportTicketService.GetAllSupportTickets();
            return Ok(Tickets);
        }

        [Route("get-support-ticket-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetSupportTicketById(Guid id)
        {
            var Ticket = await _supportTicketService.GetSupportTicketById(id);
            return Ok(Ticket);
        }

        [Route("add-support-ticket")]
        [HttpPost]
        public async Task<IActionResult> AddSupportTicket([FromForm] SupportTicketControllerPostDto dto)
        {
            var Ticket = await _supportTicketService.AddSupportTicket(_mapper.Map<SupportTicketDto>(dto));
            return Ok(Ticket);
        }
    }
}
