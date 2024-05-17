using System.Data.SqlClient;
using Microsoft.AspNetCore.Components.Infrastructure;
using WarehouseWebApp.Models;

namespace WarehouseWebApp.Repository;

public class SQLRepository: IRepository
{
    private IConfiguration _configuration;

    public SQLRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public Product? getProduct(int id)
    {
        string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM Product WHERE IdProduct = @IdProduct";
        cmd.Parameters.AddWithValue("@IdProduct", id);

        var dr = cmd.ExecuteReader();
        if (!dr.Read()) return null;
        return new Product
        {
            IdProduct = (int)dr["IdProduct"],
            Name = dr["Name"].ToString(),
            Description = dr["Description"].ToString(),
            Price = (decimal)dr["Price"]
        };
    }

    public Order? getOrderByProductAmount(Product product, int amount)
    {
        string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM \"Order\" WHERE IdProduct = @IdProduct AND Amount = @Amount";
        cmd.Parameters.AddWithValue("@IdProduct", product.IdProduct);
        cmd.Parameters.AddWithValue("@Amount", amount);

        var dr = cmd.ExecuteReader();
        if (!dr.Read()) return null;
        return new Order
        {
            IdOrder = (int)dr["IdOrder"],
            IdProduct = (int)dr["IdProduct"],
            Amount = (int)dr["Amount"],
            CreatedAt = Convert.ToDateTime(dr["CreatedAt"]),
            FulfilledAt = dr["FulfilledAt"] == DBNull.Value 
                ? null 
                : Convert.ToDateTime(dr["FulfilledAt"])
        };
    }

    public Warehouse? getWarehouse(int id)
    {
        string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM Warehouse WHERE IdWarehouse = @IdWarehouse";
        cmd.Parameters.AddWithValue("@IdWarehouse", id);

        var dr = cmd.ExecuteReader();
        if (!dr.Read()) return null;
        return new Warehouse
        {
            IdWarehouse = (int)dr["IdWarehouse"],
            Name = dr["Name"].ToString(),
            Address = dr["Address"].ToString(),
        };
    }

    public ProductWarehouse getProductWarehouseByOrder(int orderId)
    {
        string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM ProductWarehouse WHERE IdOrder = @IdOrder";
        cmd.Parameters.AddWithValue("@IdOrder", orderId);

        var dr = cmd.ExecuteReader();
        if (!dr.Read()) return null;
        return new ProductWarehouse
        {
            IdProductWarehouse = (int)dr["IdProductWarehouse"],
            IdOrder = (int)dr["IdOrder"],
            IdProduct = (int)dr["IdProduct"],
            IdWarehouse = (int)dr["IdWarehouse"],
            Amount = (int)dr["Amount"],
            CreatedAt = Convert.ToDateTime(dr["CreatedAt"]),
            Price = (decimal)dr["Price"]
        };
    }
    public int insertProductWarehouse(ProductWarehouse productWarehouse)
    {
        string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        con.Open();
        Console.Write("insertProductWarehouse()");

        // insert
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Product_Warehouse" +
                          "(IdWarehouse, IdProduct, IdOrder," +
                          " Amount, Price, CreatedAt) " +
                          "VALUES" +
                          "(@IdWarehouse, @IdProduct, @IdOrder, " +
                          "@Amount, @Price, @CreatedAt)";
        cmd.Parameters.AddWithValue("@IdWarehouse", productWarehouse.IdWarehouse);
        cmd.Parameters.AddWithValue("@IdProduct", productWarehouse.IdProduct);
        cmd.Parameters.AddWithValue("@IdOrder", productWarehouse.IdOrder);
        cmd.Parameters.AddWithValue("@Amount", productWarehouse.Amount);
        cmd.Parameters.AddWithValue("@Price", productWarehouse.Price);
        cmd.Parameters.AddWithValue("@CreatedAt", productWarehouse.CreatedAt);
        cmd.ExecuteNonQuery();
        
        //ExecuteScalar powinien zwrócić ID, ale obrywam
        // Object reference not set to an instance of an object.
        // mimo tworzenia się obiektu.
        
        // dlatego wrzucam drugie zapytanie, z tymi samymi bindami na parametrach
        cmd.CommandText = "SELECT IdProductWarehouse from Product_Warehouse Where " +
                          "IdProduct = @IdProduct and " +
                          "IdWarehouse = @IdWarehouse and " +
                          "Amount = @Amount and " +
                          "CreatedAt = @CreatedAt and " +
                          "Price = @Price";
        return (int)cmd.ExecuteScalar();
    }

    public int updateOrder(Order order)
    {
        string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE \"Order\" SET Amount=@Amount, CreatedAt=@CreatedAt, " +
                          "FulfilledAt=@FulfilledAt WHERE IdOrder = @IdOrder";
        cmd.Parameters.AddWithValue("@IdOrder", order.IdOrder);
        cmd.Parameters.AddWithValue("@Amount", order.Amount);
        cmd.Parameters.AddWithValue("@CreatedAt", order.CreatedAt);
        cmd.Parameters.AddWithValue("@FulfilledAt", order.FulfilledAt);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}