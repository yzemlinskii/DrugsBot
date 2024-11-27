using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries;

public record GetDrugByIdQuery(Guid Id) : IRequest<Drug?>;