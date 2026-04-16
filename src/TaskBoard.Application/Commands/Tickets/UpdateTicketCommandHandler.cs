using AutoMapper;
using MediatR;
using TaskBoard.Application.DTOs;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Commands.Tickets;

public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, TicketDto>
{
    private readonly IRepository<Ticket> _repository;
    private readonly IMapper _mapper;

    public UpdateTicketCommandHandler(IRepository<Ticket> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TicketDto> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _repository.GetByIdAsync(request.Id);

        if (ticket == null)
            throw new KeyNotFoundException($"Ticket with id {request.Id} not found");

        ticket.Title = request.Title;
        ticket.Description = request.Description;
        ticket.Priority = request.Priority;
        ticket.Status = request.Status;
        ticket.UpdatedAt = DateTime.UtcNow;

        _repository.Update(ticket);
        await _repository.SaveChangesAsync();

        return _mapper.Map<TicketDto>(ticket);
    }
}
