using Facemask.DAL;
using Facemask.DAL.Repositories.ProductRepo;
using Facemask.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Facemask.Test
{
    public class ProductRepositoryTest
    {
        public ProductRepositoryTest()
        {
            
        }

        [Fact]
        public void Test_ProductRepository_GetById_Returns_Product()
        {
            //Arrange
            var dbContextMock = new Mock<FacemaskDbContext>();
            var dbSetMock = new Mock<DbSet<Product>>();
            dbSetMock.Setup(s => s.FindAsync(It.IsAny<Guid>())).ReturnsAsync(new Product());
            dbContextMock.Setup(x => x.Set<Product>()).Returns(dbSetMock.Object);

            //Act

            var productRepository = new ProductRepository(dbContextMock.Object);
            var product = productRepository.GetById(It.IsAny<int>());

            //Assert
            Assert.NotNull(product);
            Assert.IsAssignableFrom<Product>(product);

        }
    }
}
