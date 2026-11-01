using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Dtos;
using Catalog.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handlers
{
    public class GetBrandByIDQueryHandler : IRequestHandler<GetBrandByIDQuery, BrandDTO>
    {
        private readonly BrandRepository _brandRepository;

        public GetBrandByIDQueryHandler(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<BrandDTO> Handle(GetBrandByIDQuery request, CancellationToken cancellationToken)
        {
            if (Guid.Empty == request.Id)
            {
                throw new ArgumentException("Invalid brand ID.");
            }
            var brand = await this._brandRepository.Brands.Where(b => b.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (brand == null)
            {
                throw new Exception($"Brand with ID {request.Id} not found.");
            }
            return brand.ToDto();
        }
    }
}
