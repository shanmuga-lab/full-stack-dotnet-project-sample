using Catalog.Core.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries
{
    public record GetBrandByIDQuery(Guid Id)
        : IRequest<BrandDTO>;
}
