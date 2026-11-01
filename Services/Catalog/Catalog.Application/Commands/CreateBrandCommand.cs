using Catalog.Core.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Commands
{
    public record CreateBrandCommand(CreateBrandDTO CreateBrandDTO)
        : IRequest<BrandDTO>;
}
