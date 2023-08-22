//using System.Threading.Tasks;
//using ATSSystem.Application.Products.Queries.GetProducts;
//using ATSSystem.Domain.Entities;
//using FluentAssertions;
//using NUnit.Framework;
//using static ATSSystem.Application.IntegrationTests.Testing;

//namespace ProductsSystem.Application.IntegrationTests.Products.Queries
//{
//    public class GetAllProductsTests : TestBase
//    {
//        [Test]
//        public async Task ShouldReturnAllProducts()
//        {

//            await AddAsync(new Product
//            {
//                Name = "Manisa",
//            });

//            var query = new GetAllProductsQuery();

//            var result = await SendAsync(query);

//            result.Should().NotBeNull();
//            result.Succeeded.Should().BeTrue();
//            result.Data.Count.Should().BeGreaterThan(0);
//        }
//    }
//}