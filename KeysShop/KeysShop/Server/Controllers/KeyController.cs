using KeysShop.Core;
using KeysShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Hosting;
using Swashbuckle.AspNetCore.Annotations;
using KeysShop.Shared.Dtos;

namespace KeysShop.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        /// <summary>
        /// Method returnes list of keys from database
        /// </summary>
        /// 
        [HttpGet]
        public List<KeyCreateDto> GetKeys()
        {
            var keys = keysRepository.GetKeysDto();
            return keys;
        }

        /// <summary>
        /// Method returnes key from database by id
        /// </summary>
        /// <param name="id">id of searching key</param>
        /// <returns>key from db</returns>
        [HttpGet("{id}")]
        public KeyCreateDto GetKey(int id)
        {
            var key = keysRepository.GetKey(id);
            var keyDto = new KeyCreateDto 
            {
                Id = key.Id,
                Name = key.Name,
                Description = key.Description,
                Price = key.Price,
                Sale = key.Sale,
                Frequency = key.Frequency,
                Count = key.Count,
                ImgPath = key.ImgPath,
                IsOriginal = key.IsOriginal,
                IsKeyless = key.IsKeyless,
                Brand = key.Brand.Name
            };
            return keyDto;
        }

        /// <summary>
        /// Method creates key and adds it to db
        /// </summary>
        /// <param name="brands">gives the name of brand, which we need to create key</param>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<KeyCreateDto> CreateKey(KeyCreateDto keyCreateDto)
        {
            var brand = brandsRepository.GetBrandByName(keyCreateDto.Brand);
            if (brand == null)
            {
                brand = new Brand() { Name = keyCreateDto.Brand };
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
            return key;
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


        /// <summary>
        /// Method edits key from database
        /// </summary>
        /// <param name="brands">name of brand, which we wanna edit</param>
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task Edit(KeyCreateDto model)
        {
            await keysRepository.UpdateAsync(model);
        }

        /// <summary>
        /// Method deletes key from database by id
        /// </summary>
        /// <param name="id">id of deleting key</param>
        [HttpDelete("{id}")]
        public async Task ConfirmDelete(int id)
        {
            await keysRepository.DeleteKeyAsync(id);
        }
    }
}