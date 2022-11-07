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

        public Task AddInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var maxId = _inventories.Max(x => x.InventoryId);

            inventory.InventoryId = maxId + 1;

            _inventories.Add(inventory);

            return Task.CompletedTask;
        }

        public async Task<Inventory> GetInventoriesByIdAsync(int id)
        {
            var inv = _inventories.FirstOrDefault(x => x.InventoryId == id);
            var newInv = new Inventory
            {
                InventoryId = inv.InventoryId,
                InventoryName = inv.InventoryName,
                Quantity = inv.Quantity,
                Price = inv.Price
            };


            return await Task.FromResult(newInv);
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryId != inventory.InventoryId && x.InventoryName.Equals(inventory.InventoryName,
                StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var inv = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);

            if (inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Quantity = inventory.Quantity;
                inv.Price = inventory.Price;
            }


            return Task.CompletedTask;

        }
    }
}