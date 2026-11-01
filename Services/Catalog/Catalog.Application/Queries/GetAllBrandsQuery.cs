using Catalog.Core.Dtos;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetAllBrandsQuery()
        : IRequest<List<BrandDTO>>
    {
    }
}
