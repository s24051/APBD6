using WarehouseWebApp.Models;

namespace WarehouseWebApp.Services;

public class ProductWarehouseBuilder: IProductWarehouseBuilder
{
    private Product? _product;
    private Warehouse? _warehouse;
    private Order? _order;
    
    public IProductWarehouseBuilder setProduct(Product product)
    {
        _product = product;
        return this;
    }

    public IProductWarehouseBuilder setWarehouse(Warehouse warehouse)
    {
        _warehouse = warehouse;
        return this;
    }

    public IProductWarehouseBuilder setOrder(Order order)
    {
        _order = order;
        return this;
    }

    public ProductWarehouse build()
    {
        return new ProductWarehouse
        {
            IdWarehouse = _warehouse.IdWarehouse,
            IdOrder = _order.IdOrder,
            IdProduct = _product.IdProduct,
            Amount = _order.Amount,
            CreatedAt = DateTime.Now,
            Price = _product.Price * _order.Amount
        };
    }
}