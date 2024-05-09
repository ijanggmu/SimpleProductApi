namespace SimpleProductApiTest
{
    using global::SimpleProductApi.Controllers;
    using global::SimpleProductApi.Entities;
    using global::SimpleProductApi.Models;
    using global::SimpleProductApi.Services.Product;
    using global::SimpleProductApi.Utilities;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace SimpleProductApi.Tests.Controllers
    {
        public class ProductsControllerTests
        {
            public async Task GetProducts_Returns_OkResult_With_Products()
            {
                // Arrange
                var productServiceMock = new Mock<IProductService>();

                var expectedProducts = new List<Product>
                        {
                            new Product { Id = 1, Name = "Product 1" },
                            new Product { Id = 2, Name = "Product 2" }
                        };

                var expectedResponse = new PaginationResponseModel<IEnumerable<Product>>
                {
                    Count = 2,
                    PageSize = 10,
                    Page = 1,
                    Data = expectedProducts
                };

                productServiceMock.Setup(x => x.GetProductsAsync(It.IsAny<int>(), It.IsAny<int>()))
                    .ReturnsAsync(expectedResponse);

                var controller = new ProductsController(productServiceMock.Object);

                // Act
                var result = await controller.GetProducts();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var actualResponse = Assert.IsAssignableFrom<PaginationResponseModel<IEnumerable<Product>>>(okResult.Value);
                Assert.Equal(expectedResponse.Count, actualResponse.Count);
                Assert.Equal(expectedResponse.PageSize, actualResponse.PageSize);
                Assert.Equal(expectedResponse.Page, actualResponse.Page);
                Assert.Equal(expectedResponse.Data, actualResponse.Data);
            }


            [Fact]
            public async Task GetProduct_Returns_OkResult_With_Product()
            {
                // Arrange
                var productServiceMock = new Mock<IProductService>();
                var expectedProduct = new Product { Id = 1, Name = "Product 1" };
                productServiceMock.Setup(x => x.GetProductByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(expectedProduct);

                var controller = new ProductsController(productServiceMock.Object);

                // Act
                var result = await controller.GetProduct(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var actualProduct = Assert.IsAssignableFrom<Product>(okResult.Value);
                Assert.Equal(expectedProduct, actualProduct);
            }

            [Fact]
            public async Task CreateProduct_Returns_OkResult_With_CreatedProduct()
            {
                // Arrange
                var productServiceMock = new Mock<IProductService>();
                var requestModel = new CreateProductRequestModel { Name = "New Product" };
                var expectedProduct = new Product { Id = 1, Name = "New Product" };
                productServiceMock.Setup(x => x.CreateProductAsync(requestModel))
                    .ReturnsAsync(expectedProduct);

                var controller = new ProductsController(productServiceMock.Object);

                // Act
                var result = await controller.CreateProduct(requestModel);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var actualProduct = Assert.IsAssignableFrom<Product>(okResult.Value);
                Assert.Equal(expectedProduct, actualProduct);
            }

            [Fact]
            public async Task UpdateProduct_Returns_OkResult_With_UpdatedProduct()
            {
                // Arrange
                var productServiceMock = new Mock<IProductService>();
                var requestModel = new UpdateProductRequestModel { Name = "Updated Product" };
                var existingProduct = new Product { Id = 1, Name = "Product 1" };
                var updatedProduct = new Product { Id = 1, Name = "Updated Product" };
                productServiceMock.Setup(x => x.UpdateProductAsync(1, requestModel))
                    .ReturnsAsync(updatedProduct);

                var controller = new ProductsController(productServiceMock.Object);

                // Act
                var result = await controller.UpdateProduct(1, requestModel);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var actualProduct = Assert.IsAssignableFrom<Product>(okResult.Value);
                Assert.Equal(updatedProduct, actualProduct);
            }

            [Fact]
            public async Task DeleteProduct_Returns_NoContentResult_When_ProductDeleted()
            {
                // Arrange
                var productServiceMock = new Mock<IProductService>();
                productServiceMock.Setup(x => x.DeleteProductAsync(It.IsAny<int>()))
                    .ReturnsAsync(true);

                var controller = new ProductsController(productServiceMock.Object);

                // Act
                var result = await controller.DeleteProduct(1);

                // Assert
                Assert.IsType<NoContentResult>(result);
            }

            [Fact]
            public async Task DeleteProduct_Returns_NotFoundResult_When_ProductNotFound()
            {
                // Arrange
                var productServiceMock = new Mock<IProductService>();
                productServiceMock.Setup(x => x.DeleteProductAsync(It.IsAny<int>()))
                    .ReturnsAsync(false);

                var controller = new ProductsController(productServiceMock.Object);

                // Act
                var result = await controller.DeleteProduct(1);

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }
    }

}