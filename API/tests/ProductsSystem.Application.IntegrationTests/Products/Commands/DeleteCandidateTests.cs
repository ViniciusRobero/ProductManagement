//using System;
//using System.Threading.Tasks;
//using ATSSystem.Application.Products.Commands.Create;
//using ATSSystem.Application.Products.Commands.Delete;
//using ATSSystem.Application.Common.Exceptions;
//using ATSSystem.Domain.Entities;
//using FluentAssertions;
//using NUnit.Framework;
//using static ATSSystem.Application.IntegrationTests.Testing;

//namespace ATSSystem.Application.IntegrationTests.Products.Commands
//{
//    public class DeleteProductTests : TestBase
//    {
//        [Test]
//        public void ShouldRequireValidProductId()
//        {
//            var command = new DeleteProductCommand { Id = 99 };

//            FluentActions.Invoking(() =>
//                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
//        }

//        [Test]
//        public async Task ShouldDeleteProduct()
//        {

//            var product = await SendAsync(new CreateProductCommand("Jaqueline", "343434343", DateTime.Now, "Teste", "Senior", "Developer"));

//            await SendAsync(new DeleteProductCommand
//            {
//                Id = product.Data.Id
//            });

//            var list = await FindAsync<Product>(product.Data.Id);

//            list.Should().BeNull();
//        }
//    }
//}
