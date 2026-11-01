using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Commands
{
    public record DeleteBrandCommand(Guid Id)
        : IRequest<bool>;
}
