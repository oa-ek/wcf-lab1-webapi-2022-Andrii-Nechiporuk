using KeysShop.Core;
using KeysShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KeysShop.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly KeysRepository keysRepository;

        public SearchController(KeysRepository keysRepository)
        {
            this.keysRepository = keysRepository;
        }

        /// <summary>
        /// Method searches needed keys by search string in db and returns the list of them
        /// </summary>
        /// <param name="keyname">searching string, enter value which you want to find</param>
        /// <returns>list of keys</returns>
        [HttpGet("searchkeys/")]
        public async Task<List<Key>> SearchKey(string keyname)
        {
            if (String.IsNullOrEmpty(keyname))
            {
                return null;
            }
            var list = keysRepository.GetKeys();
            list = list.Where(s => s.Name!.ToLower().Contains(keyname.ToLower())).ToList();
            return list;
                
        }
    }
}