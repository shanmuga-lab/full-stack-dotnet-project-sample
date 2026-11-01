using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Dtos;
using Catalog.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Handlers
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<BrandDTO>>
    {
        private readonly BrandRepository _brandRepository;

        public GetAllBrandsQueryHandler(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<List<BrandDTO>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.Brands.ToListAsync(cancellationToken);
            return brands.ToMapper();    
        }
    }
}
