using WarehouseWebApp.Models;

namespace WarehouseWebApp.Services;

public interface IProductWarehouseBuilder
{
    public IProductWarehouseBuilder setProduct(Product product);
    public IProductWarehouseBuilder setWarehouse(Warehouse warehouse);
    public IProductWarehouseBuilder setOrder(Order order);
    public ProductWarehouse build();
}