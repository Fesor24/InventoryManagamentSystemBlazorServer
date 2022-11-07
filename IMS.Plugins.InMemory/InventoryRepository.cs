using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>
            {
                new Inventory
                {
                    InventoryId = 1,
                    InventoryName="Bike seats",
                    Quantity = 10,
                    Price =3
                },
                new Inventory
                {
                    InventoryId = 2,
                    InventoryName="Bike wheels",
                    Quantity = 10,
                    Price =5
                },

                new Inventory
                {
                    InventoryId = 3,
                    InventoryName="Bike body",
                    Quantity = 7,
                    Price =4
                },

                 new Inventory
                {
                    InventoryId = 4,
                    InventoryName="Bike pedals",
                    Quantity = 15,
                    Price =6
                }
            };
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}