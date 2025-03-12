using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : Controller
{
    [HttpGet(Name = "Get All Products")]
    public List<Product> Get()
    {
        return ProductsService.Get();
    }

    [HttpGet("{id}")]
    public Product? Get(int id) {
        return ProductsService.Get(id);
    }

    [HttpPost()]
    public Product? Post(Product newData)
    {
        return ProductsService.Add(newData);
    }

    [HttpPatch()]
    public Object Patch(Product newData)
    {
        Product? updatedProduct = ProductsService.Update(newData);

        if (updatedProduct == null) {
            return new
            {
                StateIs = "Not Found",
                Code = 404
            };
        }

        return updatedProduct;
    }
}
