using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.Dtos
{
    public record BrandDTO(
        Guid Id,
        string Name
    );
}
