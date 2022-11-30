using KeysShop.Core;
using KeysShop.Repository.Dto;
using KeysShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Hosting;

namespace KeysShop.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeyController : ControllerBase
    {
        private readonly KeysRepository keysRepository;
        private readonly BrandRepository brandsRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public KeyController(KeysRepository keysRepository, BrandRepository brandRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.keysRepository = keysRepository;
            brandsRepository = brandRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getkeys/")]
        public List<Key> GetKeys()
        {
            var keys = keysRepository.GetKeys();
            return keys;
        }

        [HttpGet("getkey/{id}")]
        public Key GetBrand(int id)
        {
            return keysRepository.GetKey(id);
        }

        [HttpPost("createkey/")]
        public async Task CreateKey(KeyCreateDto keyCreateDto, string brands)
        {
            var brand = brandsRepository.GetBrandByName(brands);
            if (brand == null)
            {
                brand = new Brand() { Name = brands };
                brand = await brandsRepository.AddBrandAsync(brand);
            }

            var key = await keysRepository.AddKeyAsync(new Key()
            {
                Name = keyCreateDto.Name,
                Description = keyCreateDto.Description,
                Price = keyCreateDto.Price,
                Sale = keyCreateDto.Sale,
                Frequency = keyCreateDto.Frequency,
                Count = keyCreateDto.Count,
                ImgPath = keyCreateDto.ImgPath,
                IsOriginal = keyCreateDto.IsOriginal,
                IsKeyless = keyCreateDto.IsKeyless,
                Brand = brand
            });
        }

        /*        [HttpGet("getimage/{id}")]
                public async Task<IActionResult> GetImage(int id)
                {
                    var key = keysRepository.GetKey(id);
                    var contentType = GetMimeTypeForFileExtension(key.ImgPath);
                    var imgPath = key.ImgPath;
                    if (!System.IO.File.Exists(imgPath))
                    {
                        imgPath = "https://www.shutterstock.com/image-vector/no-image-available-vector-hand-260nw-745639717.jpg";
                    }

                    return PhysicalFile(imgPath, contentType);
                }

                [NonAction]
                public string GetMimeTypeForFileExtension(string filePath)
                {
                    const string DefaultContentType = "application/octet-stream";

                    var provider = new FileExtensionContentTypeProvider();

                    if (!provider.TryGetContentType(filePath, out string contentType))
                    {
                        contentType = DefaultContentType;
                    }
                    return contentType;
                }*/

        [HttpPost("editkey/")]
        public async Task Edit(KeyCreateDto model, string brands)
        {
            await keysRepository.UpdateAsync(model, brands);
        }


        [HttpPost("confirmdelete/{id}")]
        public async Task ConfirmDelete(int id)
        {
            await keysRepository.DeleteKeyAsync(id);
        }
    }
}