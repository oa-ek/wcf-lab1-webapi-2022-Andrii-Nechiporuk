using KeysShop.Core;
using KeysShop.Repository;
using KeysShop.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KeyShop.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly BrandRepository _brandRepository;
        public BrandController(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        /// <summary>
        /// Method returns list of brands
        /// </summary>
        /// <returns>array of brands</returns>
        [HttpGet("getbrands/")]
        public List<BrandCreateDto> GetBrands()
        {
            var brands = _brandRepository.GetBrands();
            return brands;
        }


        /*        [HttpGet]
                public IActionResult Create()
                {
                    return View();
                }*/

        /// <summary>
        /// Method creates brand and adds it to db
        /// </summary>
        /// <returns>created brand from db</returns>
        [HttpPost("createbrand/")]
        public async Task<Brand> Create(BrandCreateDto brandDto)
        {
            var createdBrand = await _brandRepository.AddBrandByDtoAsync(brandDto);
            return createdBrand;
        }

        /// <summary>
        /// Method takes brand from db
        /// </summary>
        /// <param name="id">id of searching brand</param>
        /// <returns>brand from db</returns>
        [HttpGet("getbrand/{id}")]
        public Brand GetBrand(int id)
        {
            return _brandRepository.GetBrand(id);
        }

        /// <summary>
        /// Method updates brand in db
        /// </summary>
        [HttpPost("updatebrand/")]
        public async Task Edit(BrandCreateDto brand)
        {
            await _brandRepository.UpdateBrandAsync(brand);
        }

        /// <summary>
        /// Method deletes brand 
        /// </summary>
        [HttpPost("deletebrand/")]
        public async Task Delete(BrandCreateDto brand)
        {
            await _brandRepository.DeleteBrandAsync(brand.Id);
        }
    }
}