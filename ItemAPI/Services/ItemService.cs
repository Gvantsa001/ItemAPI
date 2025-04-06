using Microsoft.Extensions.Caching.Memory;
using   ItemAPI.Models;

namespace ItemAPI.Services
{
    public class ItemService : IItemService
    {
        private readonly IMemoryCache _cache;
        private const string CacheKey = "ItemsCache";
        public ItemService(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void AddItemsToCache(List<Item> items)
        {
            _cache.Set(CacheKey, items);
        }
        public List<Item> GetItemsFromCache()
        {
            if (_cache.TryGetValue(CacheKey, out List<Item> items))
            {
                return items;
            }
            return new List<Item>();
        }

        public List<Item> GetItemsByPage(int pageIndex, int pageSize)
        {
            var items = GetItemsFromCache();
            return items.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Item> GetItemsByType(string type, int minYear)
        {
            var items = GetItemsFromCache();
            return items.Where(item => item.Type ==type && item.CreateYear >= minYear).ToList();
        }
    }


}
