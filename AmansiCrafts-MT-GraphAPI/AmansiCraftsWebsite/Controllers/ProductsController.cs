using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmansiCraftsWebsite.Models;
using AmansiCraftsWebsite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmansiCraftsWebsite.Controllers
{
    [Route("home/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        [Route("Rate")]
        [HttpPatch]
        public ActionResult Patch([FromQuery] string ProductId, int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}