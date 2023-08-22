//using System;
//using System.Threading.Tasks;
//using ATSSystem.Application.Products.Commands.Create;
//using ATSSystem.Application.Products.Commands.Update;
//using ATSSystem.Application.Common.Exceptions;
//using ATSSystem.Domain.Entities;
//using FluentAssertions;
//using FluentAssertions.Extensions;
//using NUnit.Framework;
//using static ATSSystem.Application.IntegrationTests.Testing;

//namespace ATSSystem.Application.IntegrationTests.Products.Commands
//{
//    public class UpdateProductTests : TestBase
//    {
//        [Test]
//        public void ShouldRequireValidProductId()
//        {
//            var command = new UpdateProductCommand
//            {
//                Id = 99,
//                Name = "Kayseri"
//            };

//            FluentActions.Invoking(() =>
//                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
//        }

//        [Test]
//        public async Task ShouldRequireUniqueName()
//        {
            
//            var product = await SendAsync(new CreateProductCommand("Jaqueline", "343434343", DateTime.Now, "Teste", "Senior", "Developer"));

//            await SendAsync(new CreateProductCommand("Diniz", "343434343", DateTime.Now, "Teste", "Senior", "Developer"));

//            var command = new UpdateProductCommand
//            {
//                Id = product.Data.Id,
//                Name = "Denizli"
//            };

//            FluentActions.Invoking(() =>
//                    SendAsync(command))
//                .Should().ThrowAsync<ValidationException>().Where(ex => ex.Errors.ContainsKey("Name")).Result
//                .And.Errors["Name"].Should().Contain("The specified product already exists. If you just want to activate the product leave the name field blank!");
//        }

//        [Test]
//        public async Task ShouldUpdateProduct()
//        {
//            var result = await SendAsync(new CreateProductCommand("Norman", "343434343", DateTime.Now, "Teste", "Senior", "Developer"));

//            var command = new UpdateProductCommand
//            {
//                Id = result.Data.Id,
//                Name = "Jones"
//            };

//            await SendAsync(command);

//            var product = await FindAsync<Product>(result.Data.Id);

//            product.Name.Should().Be(command.Name);
//        }
//    }
//}
