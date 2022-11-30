using AutoMapper;
using KeysShop.Core;
using KeysShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Repository
{
    public class BrandRepository
    {
        private readonly KeysShopContext _ctx;
        private readonly IMapper _mapper;

        public BrandRepository(KeysShopContext _ctx, IMapper mapper)
        {
            this._ctx = _ctx;
            _mapper = mapper;   
        }

        public List<BrandCreateDto> GetBrands()
        {
            var brandList = _ctx.Brands.ToList();
            return _mapper.Map<List<BrandCreateDto>>(_ctx.Brands.ToList());
        }

        public async Task<Brand> AddBrandByDtoAsync(BrandCreateDto brandDto)
        {
            var brand = new Brand();
            brand.Name = brandDto.Name;
            brand.Description = brandDto.Description;
            _ctx.Brands.Add(brand);
            await _ctx.SaveChangesAsync();
            return _ctx.Brands.FirstOrDefault(x => x.Name == brand.Name);
        }
        public async Task<Brand> AddBrandAsync(Brand brand)
        {
            _ctx.Brands.Add(brand);
            await _ctx.SaveChangesAsync();
            return _ctx.Brands.FirstOrDefault(x => x.Name == brand.Name);
        }

        public Brand GetBrand(int id)
        {
            return _ctx.Brands.FirstOrDefault(x => x.Id == id);
        }
        public Brand GetBrandByName(string name)
        {
            return _ctx.Brands.FirstOrDefault(x => x.Name == name);
        }
        
        public BrandCreateDto GetBrandDtoByName(string name)
        {
            var brand = _ctx.Brands.FirstOrDefault(x => x.Name == name);
            var brandDto = new BrandCreateDto 
            {
                Name = brand.Name,
                Description = brand.Description,
                Id = brand.Id
            };

            return brandDto;
        }



        public async Task DeleteBrandAsync(int id)
        {
            _ctx.Remove(GetBrand(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateBrandAsync(BrandCreateDto updatedBrand)
        {
            var brand = _ctx.Brands.FirstOrDefault(x => x.Id == updatedBrand.Id);
            brand.Description = updatedBrand.Description;
            brand.Name = updatedBrand.Name;
            await _ctx.SaveChangesAsync();
        }
    }
}