using AutoMapper;
using TaskBoard.Application.DTOs;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Mappings;

public class TicketProfile : Profile
{
    public TicketProfile()
    {
        CreateMap<Ticket, TicketDto>();
    }
}
