using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using practice.Application.Common.Interfaces;
using practice.Application.Common.Results;
using practice.Application.Handlers.Products.Queries;
using practice.Domain.Entities;
using practice.Infrastructure.Persistance;

namespace practice.practise.UnitTests.Systems.Controllers;

public class TestProductsController
{

    [Fact]
    public async void Get_OnSuccess_ReturnsGetProductsQueryList()
    {
        // Arrange
        var productList = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "TestProduct",
                    Price = 10,
                    Count = 3,
                    CreatedBy = "Nargiz",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = null,
                    ModifiedDate = null,
                    IsDeleted = false
                }
            };

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using var context = new AppDbContext(options);
        context.Products.AddRange(productList);
        context.SaveChanges();

        var mockContext = new Mock<IAppDbContext>();
        mockContext.Setup(c => c.Products).Returns(context.Products);

        var mockMapper = new Mock<IMapper>();
        var mappedProductList = new List<GetProductsQuery>
            {
           new GetProductsQuery
        {
            Id = 1,
            Name = "Test",
            Count = 1,
            Price = 2,
            IsDeleted = false,
            CreatedBy = "Nargiz",
            CreatedDate = DateTime.Now,
            ModifiedBy = null,
            ModifiedDate = null
        }
    };
        mockMapper.Setup(m => m.Map<IEnumerable<GetProductsQuery>>(It.IsAny<IEnumerable<Product>>()))
                  .Returns(mappedProductList);

        var handler = new GetProductsQuery.GetProductsQueryHandler(mockContext.Object, mockMapper.Object);
        var request = new GetProductsQuery();

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<SuccessDataResult<IEnumerable<GetProductsQuery>>>(result);
        var successDataResult = (SuccessDataResult<IEnumerable<GetProductsQuery>>)result;
        Assert.Equal(mappedProductList, successDataResult.Data);
    }
}