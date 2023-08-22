using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProductsSystem.Application.Products.Commands.Create;
using ProductsSystem.Application.Products.Commands.Delete;
using ProductsSystem.Application.Products.Commands.Update;
using ProductsSystem.Application.Products.Queries.GetProducts;
using ProductsSystem.Application.Common.Models;
using ProductsSystem.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsSystem.Application.Products.Queries.GetProductByIBrandId;

namespace ProductsSystem.Api.Controllers
{
    /// <summary>
    /// Products
    /// </summary>
    public class ProductController : BaseApiController
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<ProductDto>>>> GetAllProducts(CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllProductsQuery(), cancellationToken));
        }

        /// <summary>
        /// Get product by brand name
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{brand}")]
        public async Task<ActionResult<ServiceResult<ProductDto>>> GetProductById(string brand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductByBrandQuery { Brand = brand }, cancellationToken));
        }

        /// <summary>
        /// Create product
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<ProductDto>>> Create(CreateProductCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ServiceResult<ProductDto>>> Update(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Delete product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<ProductDto>>> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteProductCommand { Id = id }, cancellationToken));
        }
    }
}