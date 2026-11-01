using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Core.Dtos;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handlers
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BrandDTO>
    {
        private readonly BrandRepository _brandRepository;

        public CreateBrandCommandHandler(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<BrandDTO> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new BrandModel { Id = Guid.NewGuid(), Name = request.CreateBrandDTO.Name };
                _brandRepository.Add(brand);
                await _brandRepository.SaveChangesAsync();
            return brand.ToDto();
        }
    }
}       