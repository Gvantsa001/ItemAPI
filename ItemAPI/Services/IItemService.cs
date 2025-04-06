using ItemAPI.Models;

namespace ItemAPI.Services
{
    public interface IItemService
    {
        void AddItemsToCache(List<Item> items);
        List<Item> GetItemsFromCache();
        List<Item> GetItemsByPage(int pageIndex, int pageSize);
        List<Item> GetItemsByType(string type, int minYear);

    }
}
