using WarehouseWebApp.Models;

namespace WarehouseWebApp.Repository;

public interface IRepository
{
    public Product? getProduct(int id);
    public Order? getOrderByProductAmount(Product product, int amount);
    public Warehouse? getWarehouse(int id);
    public ProductWarehouse getProductWarehouseByOrder(int orderId);
    public int insertProductWarehouse(ProductWarehouse productWarehouse);
    public int updateOrder(Order order);
}