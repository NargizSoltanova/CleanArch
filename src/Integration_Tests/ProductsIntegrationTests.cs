using practice.Domain.Entities;
using System.Net.Http.Json;

namespace practice.Integration_Tests;

public class ProductsIntegrationTests : IClassFixture<ProductsApiFixture>
{
    private readonly ProductsApiFixture _fixture;

    public ProductsIntegrationTests(ProductsApiFixture fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public async Task Get_ShouldReturn_Products()
    {
        var client = _fixture.Client;
        var products = await client.GetFromJsonAsync<List<Product>>("/api/Products");

        Assert.NotNull(products);
        Assert.Single(products);
    }
}
