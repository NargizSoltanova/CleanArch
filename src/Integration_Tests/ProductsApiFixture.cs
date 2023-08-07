using Microsoft.Extensions.DependencyInjection;
using practice.Infrastructure.Persistance;

namespace practice.Integration_Tests;

public class ProductsApiFixture : IDisposable
{
    public ApiApplication Api { get; private set; }
    public HttpClient Client { get; private set; }

    public ProductsApiFixture()
    {
        Api = new ApiApplication();

        using (var scope = Api.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;

            using (var context = provider.GetRequiredService<AppDbContext>())
            {
                context.Database.EnsureCreated();

                context.Products.Add(new Domain.Entities.Product
                {
                    Name = "Test",
                    Count = 1,
                    CreatedBy = "Nargiz",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    Price = 20
                });

                context.SaveChanges();
            }
        }

        Client = Api.CreateClient();
    }

    public void Dispose()
    {
        Api.Dispose();
        GC.SuppressFinalize(this);
    }
}
