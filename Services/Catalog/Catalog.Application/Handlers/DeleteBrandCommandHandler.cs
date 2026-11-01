using Catalog.Application.Commands;
using Catalog.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handlers
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, bool>
    {
        private readonly BrandRepository _brandRepository;

        public DeleteBrandCommandHandler(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.Brands.Where(b => b.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (brand == null)
            {
                throw new InvalidOperationException("Brand not found");
            }

            _brandRepository.Brands.Remove(brand);
            await _brandRepository.SaveChangesAsync();
            return true;
        }
    }
}
