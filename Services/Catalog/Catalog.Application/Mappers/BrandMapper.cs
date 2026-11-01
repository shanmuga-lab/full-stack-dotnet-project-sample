using Catalog.Core.Dtos;
using Catalog.Core.Models;

namespace Catalog.Application.Mappers
{
    /// <summary>
    /// Extension methods for mapping between domain models and DTOs.
    /// </summary>
    public static class BrandMapper
    {
        /// <summary>
        /// Maps a list of BrandModel entities to a list of BrandDTO objects.
        /// </summary>
        /// <param name="brands">The list of BrandModel entities.</param>
        /// <returns>A task containing the mapped list of BrandDTO objects.</returns>
        public static List<BrandDTO> ToMapper(this List<BrandModel> brands)
        {
            if (brands == null) throw new ArgumentNullException(nameof(brands));
            var brandDtos = brands.Select(b => new BrandDTO(b.Id, b.Name)).ToList();
            return brandDtos;
        }

        /// <summary>
        /// Maps a single BrandModel entity to a BrandDTO object.
        /// </summary>
        /// <param name="brand">The BrandModel entity.</param>
        /// <returns>The mapped BrandDTO object.</returns>
        public static BrandDTO ToDto(this BrandModel brand)
        {
            return new BrandDTO(brand.Id, brand.Name);
        }
    }
}
