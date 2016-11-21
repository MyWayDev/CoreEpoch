using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using BaseEpoch.Data.POCO.Base;
using BaseEpoch.DataAccess;
using BaseEpoch.Dtos;
using Mvc.Models;


namespace Mvc.Controllers.API
{

    public class ProductsController : ApiController
    {
        private readonly  DBC _context;
        public ProductsController()
        {
            _context = new DBC();
        }
        //GET/api/products
        public IHttpActionResult GetProducts()
        {
            if (!ModelState.IsValid)
                return BadRequest();
           
            //var products= _context.Products.Include(p => p.ProductGroup).ToList();



            var api = _context.Products.Select(item => new PGModel()
            {
                Id = item.Id,
                ProductName = item.ProductName,
                GroupName = item.ProductGroup.GroupName
            }).ToList();
            ;

            return Ok(api);
        }
        //public  IEnumerable<Product> GetProducts()
        //{
        //    return _context.Products.ToList();
            
        //}
        //GET/api/products/1
        public IHttpActionResult GetProduct(string id)
        {
            var product = _context.Products.SingleOrDefault(p=> p.Id == id);
         
            if (product == null)
                return NotFound();

            return Ok(product);
        }
        //POST/api/products
        [HttpPost]
        public IHttpActionResult CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var duplicate =_context.Products.ToList();
            if (duplicate.Any(item => item.Id == product.Id))
            
                return Content(HttpStatusCode.Conflict, "Duplicate ProdcutId  "+ product.Id);
                
            
            _context.Products.Add(product);

            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri +"/"+ product.Id), product);
        }
        //PUT/api/prodcuts/1
        [HttpPut]
        public IHttpActionResult UpdateProduct(string id, Product product)
        {
        
            if (!ModelState.IsValid)          
                return BadRequest();
    
            var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                return NotFound();

            productInDb.Id = product.Id;
            
            productInDb.GroupId = product.GroupId;
            productInDb.ProductName = product.ProductName;
            productInDb.Active = product.Active;
            productInDb.AddDate = product.AddDate;
            productInDb.Booking = product.Booking;
            productInDb.Discontnuied = product.Discontnuied;
            productInDb.ProductType = product.ProductType;

            _context.SaveChanges();

            return Ok();
        }
        //DELETE/api/product/1
        [HttpDelete]
        public IHttpActionResult DeleteProduct(string id)
        {
            if (!ModelState.IsValid)
                return NotFound(); 

            var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                return NotFound();
            
            _context.Products.Remove(productInDb);
            _context.SaveChanges();
            
            return Ok();
        }
        
    }
}
