using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Core.Dtos;
using Catalog.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handlers
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, BrandDTO>
    {
        private readonly BrandRepository _brandRepository;

        public UpdateBrandCommandHandler(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<BrandDTO> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.Brands.Where(b => b.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (brand == null)
            {
                throw new InvalidOperationException("Brand not found");
            }

            brand.Name = request.UpdateBrandDTO.Name;

            await _brandRepository.SaveChangesAsync();
            return brand.ToDto();
        }
    }
}
