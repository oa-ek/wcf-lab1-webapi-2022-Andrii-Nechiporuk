using KeysShop.Core;
using KeysShop.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Repository
{
    public class KeysRepository
    {
        private readonly KeysShopContext _ctx;
        public KeysRepository(KeysShopContext _ctx)
        {
            this._ctx = _ctx;
        }

        public async Task<Key> AddKeyAsync(Key key)
        {
            _ctx.Keys.Add(key);
            await _ctx.SaveChangesAsync();
            return _ctx.Keys.Include(x => x.Brand).FirstOrDefault(x => x.Name == key.Name);
        }

        public Key GetKey(int id)
        {
            return _ctx.Keys.Include(x => x.Brand).Include(x => x.feedbacks).FirstOrDefault(x => x.Id == id);
        }

        public List<Key> GetKeys()
        {
            var keyList = _ctx.Keys.Include(x => x.Brand).ToList();
            return keyList;
        }

        public async Task DeleteKeyAsync(int id)
        {
            _ctx.Remove(GetKey(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateKeyAsync(Key updatedKey)
        {
            var key = _ctx.Keys.FirstOrDefault(x => x.Id == updatedKey.Id);
            key.Name = updatedKey.Name;
            key.Description = updatedKey.Description;
            key.Price = updatedKey.Price;
            key.Sale = updatedKey.Sale;
            key.Frequency = updatedKey.Frequency;
            key.Count = updatedKey.Count;
            key.ImgPath = updatedKey.ImgPath;
            key.IsOriginal = updatedKey.IsOriginal;
            key.IsKeyless = updatedKey.IsKeyless;
            key.Brand = updatedKey.Brand;
            key.feedbacks = updatedKey.feedbacks;
            await _ctx.SaveChangesAsync();
        }

        public async Task<KeyCreateDto> GetKeyDto(int id)
        {
            var k = await _ctx.Keys.Include(x => x.Brand).FirstAsync(x => x.Id == id);

            var keyDto = new KeyCreateDto
            {
                Id = k.Id,
                Name = k.Name,
                Description = k.Description,
                Price = k.Price,
                Sale = k.Sale,
                Frequency = k.Frequency,
                Count = k.Count,
                ImgPath = k.ImgPath,
                IsOriginal = k.IsOriginal,
                IsKeyless = k.IsKeyless,
                Brand = k.Brand.Name
            };
            return keyDto;
        }

        public async Task UpdateAsync(KeyCreateDto model, string brands)
        {
            var key = _ctx.Keys.Include(x => x.Brand).FirstOrDefault(x => x.Id == model.Id);
            if (key.Name != model.Name)
                key.Name = model.Name;
            if (key.Description != model.Description)
                key.Description = model.Description;
            if (key.Sale != model.Sale)
                key.Sale = model.Sale;
            if (key.Frequency != model.Frequency)
                key.Frequency = model.Frequency;
            if (key.Count != model.Count)
                key.Count = model.Count;
            if (key.ImgPath != model.ImgPath)
                key.ImgPath = model.ImgPath;
            if (key.IsOriginal != model.IsOriginal)
                key.IsOriginal = model.IsOriginal;
            if (key.IsKeyless != model.IsKeyless)
                key.IsKeyless = model.IsKeyless;
            if (key.Brand.Name != brands)
                key.Brand = _ctx.Brands.FirstOrDefault(x => x.Name == brands);
            _ctx.SaveChanges();
        }
    }
}