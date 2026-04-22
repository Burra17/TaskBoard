using AutoMapper;
using MediatR;
using TaskBoard.Application.DTOs;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Common;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Commands.Tickets;

public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, Result<TicketDto>>
{
    private readonly IRepository<Ticket> _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTicketCommandHandler(IRepository<Ticket> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TicketDto>> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _repository.GetByIdAsync(request.Id);

        if (ticket == null)
            return Result<TicketDto>.Fail($"ticket with id: {request.Id} not found", 404);

        ticket.Title = request.Title;
        ticket.Description = request.Description;
        ticket.Priority = request.Priority;
        ticket.Status = request.Status;
        ticket.UpdatedAt = DateTime.UtcNow;

        _repository.Update(ticket);
        await _unitOfWork.SaveChangesAsync();

        var ticketDto = _mapper.Map<TicketDto>(ticket);

        return Result<TicketDto>.Ok(ticketDto);
    }
}
