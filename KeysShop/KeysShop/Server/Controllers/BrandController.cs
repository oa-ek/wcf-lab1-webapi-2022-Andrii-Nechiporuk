using KeysShop.Core;
using KeysShop.Repository;
using KeysShop.Repository.Dto;
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

        [HttpGet("getbrands/")]
        public List<Brand> GetBrands()
        {
            var brands = _brandRepository.GetBrands();
            return brands;
        }
        /*        [HttpGet]
                public IActionResult Create()
                {
                    return View();
                }*/
        [HttpPost("createbrand/")]
        public async Task<Brand> Create(BrandCreateDto brandDto)
        {
            var createdBrand = await _brandRepository.AddBrandByDtoAsync(brandDto);
            return createdBrand;
        }

        [HttpGet("getbrand/")]
        public Brand GetBrand(int id)
        {
            return _brandRepository.GetBrand(id);
        }

        [HttpPost("updatebrand/")]
        public async Task Edit(BrandCreateDto brand)
        {
            await _brandRepository.UpdateBrandAsync(brand);
        }

        [HttpPost("deletebrand/")]
        public async Task Delete(BrandCreateDto brand)
        {
            await _brandRepository.DeleteBrandAsync(brand.Id);
        }
    }
}