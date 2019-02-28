using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DijleZonenApi.dijlezonen;
using System.Net.Http;
using System.Web;
using System;
using System.IO;
using DijleZonenApi.Filters;
using DijleZonenApi.utilities;
using DijleZonenApi.DAL;
using DijleZonenApi.requestObjects;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace DijleZonenApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        IHostingEnvironment _env;
        private readonly ProductDAO productDAO;

        public ProductController(_1718_SPRINGDBContext context, IHostingEnvironment env, ProductDAO productDAO)
        {
            this.productDAO = productDAO;
            this._env = env;

        }

        // GET: api/product
        [HttpGet]
        public IEnumerable<ProductResponseObject> Get()
        {
            return productDAO.GetAll().Select(x => new ProductResponseObject(x.Id, x.CriticalStock, x.ImageUrl, x.InStock, x.Name, x.Price));

        }

        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(200, Type = typeof(ProductResponseObject))]
        [ProducesResponseType(404)]
        public IActionResult GetById(long id)
        {
            Product x = productDAO.Get((int)id);

            if (x == null)
            {
                return NotFound();
            }
            return Ok(new ProductResponseObject(x.Id, x.CriticalStock, x.ImageUrl, x.InStock, x.Name, x.Price));
        }


        // POST api/product/create
        [HttpPost]
        [RequestFormSizeLimit(valueCountLimit: 12000, Order = 1)]
        [ProducesResponseType(201, Type = typeof(ProductResponseObject))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromForm] ProductCreateObject productCreateObject)
        {
            if (productCreateObject == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = new Product
            {
                CriticalStock = productCreateObject.CriticalStock,
                InStock = productCreateObject.InStock,
                Name = productCreateObject.Name,
                Price = productCreateObject.Price
            };

            await FileUtility.processFile(new List<IFormFile>() { productCreateObject.Image }, product, Path.GetFullPath(Path.Combine(_env.WebRootPath, "images")));

            product = this.productDAO.Create(product.Name, product.Price, product.ImageUrl, product.InStock, product.CriticalStock);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, new ProductResponseObject(product.Id, product.CriticalStock, product.ImageUrl, product.InStock, product.Name, product.Price));
        }

        // The response is 204 (No Content). According to the HTTP spec, 
        // a PUT request requires the client to send the entire updated entity, not just the deltas. 

        // PUT api/values/5
        [HttpPut("{id}")]
        [RequestFormSizeLimit(valueCountLimit: 12000, Order = 1)]
        [ProducesResponseType(201, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(long id, [FromForm]ProductUpdateObject productUpdateObject)
        {
            if (productUpdateObject == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = this.productDAO.Get((int)id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = productUpdateObject.Name;
            product.InStock = productUpdateObject.InStock;
            product.CriticalStock = productUpdateObject.CriticalStock;
            product.Price = productUpdateObject.Price;

            if (productUpdateObject.Image != null)
            {
                await FileUtility.processFile(new List<IFormFile>() { productUpdateObject.Image }, product, Path.GetFullPath(Path.Combine(_env.WebRootPath, "images")));
            }

            this.productDAO.Update(product);

            return new NoContentResult();
        }

        // DELETE api/product/delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var product = productDAO.Get((int)id);

            if (product == null)
            {
                return NotFound();
            }

            productDAO.Delete((int)id);

            return new NoContentResult();
        }
    }
}
