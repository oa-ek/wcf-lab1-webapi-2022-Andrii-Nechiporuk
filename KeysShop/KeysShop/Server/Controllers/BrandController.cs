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

        [HttpGet]
        public List<Brand> Index()
        {
            var brands = _brandRepository.GetBrands();
            return brands;
        }
/*        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }*/
        [HttpPost]
        public async Task<Brand> Create(BrandCreateDto brandDto)
        {
            var createdBrand = await _brandRepository.AddBrandAsync(brandDto);
            return createdBrand;
        }
        /*[HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_brandRepository.GetBrand(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                await _brandRepository.UpdateBrandAsync(brand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_brandRepository.GetBrand(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Brand brand)
        {
            await _brandRepository.DeleteBrandAsync(brand.Id);
            return RedirectToAction("Index");
        }*/
    }
}