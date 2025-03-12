using WebApplication1.Models;
namespace WebApplication1.Services;

public static class ProductsService
{
    static List<Product> productsList {get;}
    static int nextId = 0;
    static ProductsService()
    {
        productsList = new List<Product>
        {
            new Product { Id = nextId++, Name = "Abdurhman", Description = " Ahbal"},
            new Product { Id = nextId++, Name = "Amro" }
        };
    }

    static public List<Product> Get()
    {   
           return productsList;
    }

    static public Product? Get(int id)
    {
           return productsList.FirstOrDefault(x => x.Id == id);
    }

    static public Product? Get(string name)
    {
        return productsList.FirstOrDefault(x => string.Equals(x.Name, name));
    }

    static public Product? Update(Product newData)
    {   
        int index = productsList.FindIndex(x => x.Id == newData.Id);
        if (index == -1) return null;

        productsList[index] = newData;
        return newData;
    }

    public static Product? Delete(int id) {
        Product product = Get(id);
        if (product is null) return null;

        productsList.Remove(product);
        return product;
    }

    static public Product? Add(Product newData)
    {
        Product exists = Get(newData.Id);
        if (exists is not null) return null;

       productsList.Add(newData);
        return newData;
    }
}
