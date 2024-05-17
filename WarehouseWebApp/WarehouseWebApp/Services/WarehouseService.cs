using WarehouseWebApp.Models;
using WarehouseWebApp.Repository;

namespace WarehouseWebApp.Services;

public class WarehouseService: IWarehouseService
{
    private IRepository _repository;
    private IProductWarehouseBuilder _productWarehouseBuilder;

    public WarehouseService(IRepository repository, IProductWarehouseBuilder productWarehouseBuilder)
    {
        _repository = repository;
        _productWarehouseBuilder = productWarehouseBuilder;
    }
    public int Fulfill(FulfilledOrder fulfilledOrder)
    {
        Console.WriteLine("Fulfill");
        Console.WriteLine(fulfilledOrder);
        
        Product? product = _repository.getProduct(fulfilledOrder.IdProduct);
        if (product == null)
            throw new Exception("Product does not exist!");
        Console.WriteLine(product);
        
        Warehouse? warehouse = _repository.getWarehouse(fulfilledOrder.IdWarehouse);
        if (warehouse == null)
            throw new Exception("Warehouse does not exist!");
        Console.WriteLine(warehouse);

        Order? order = _repository.getOrderByProductAmount(product, fulfilledOrder.Amount);
        if (order == null)
            throw new Exception("Order does not exist!");
        Console.WriteLine(order);

        if (order.FulfilledAt != null)
            throw new Exception("Order alredy fulfilled!");

        order.FulfilledAt = DateTime.Now;
        _repository.updateOrder(order);
        Console.WriteLine("UPDATING ");
        Console.WriteLine(order);
        
        ProductWarehouse vProductWarehouse = _productWarehouseBuilder
            .setProduct(product)
            .setOrder(order)
            .setWarehouse(warehouse)
            .build();
        int id = _repository.insertProductWarehouse(vProductWarehouse);
        Console.WriteLine("INSERT " + id);
        return id;
    }
}