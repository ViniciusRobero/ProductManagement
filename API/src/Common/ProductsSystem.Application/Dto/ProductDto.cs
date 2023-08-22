using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProductsSystem.Domain.Entities;
using Mapster;

namespace ProductsSystem.Application.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string ProductCode { get; set; }

        public string Discription { get; set; }

        public decimal Value { get; set; }
    }
}
