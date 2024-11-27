using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Read;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries;

public class GetDrugByIdQueryHandler(IDrugReadRepository drugReadRepository) : IRequestHandler<GetDrugByIdQuery, Drug?>
{
    public async Task<Drug?> Handle(GetDrugByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await drugReadRepository.GetByIdAsync(request.Id, cancellationToken);

        return response;
    }
}