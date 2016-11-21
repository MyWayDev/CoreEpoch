using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseEpoch.Data.POCO.Base;
using BaseEpoch.DataAccess;
using Mvc.Models;

namespace Mvc.Controllers
{
	public class ProductController : Controller
	{
#region Content Type Display and Attribute Configuration
		//public ActionResult Edit(int id)
		//{
		//    return Content("Id=" + id);
		//}
		//

		//public ActionResult page(int? pageIndex, string sortBy)
		//{
		//    if (!pageIndex.HasValue)
		//        pageIndex = 1;
		//    if (String.IsNullOrWhiteSpace(sortBy))
		//        sortBy = "Name";
				

		//    return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex,sortBy));
		//}
		//[Route("product/released/{year:regx(//d{4}:range(2000,2020)}/{month:regx(//d{2}):range(1,12)}")]
		//public ActionResult ByDate(int year,byte month)
		//{
		//    return Content(year +"/"+ month);
		//}
#endregion
		private DBC _context;
		public ProductController()
		{
			_context = new DBC();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		// GET: Produc\t
	  
		public ViewResult Index()
		{
			return View();
			#region
			//var productlist = new List<PG>();
			//foreach (var item in product)
			//{
			//    productlist.Add(
			//        new PG
			//        {
			//            Id = item.Id,
			//            ProductName = item.ProductName,
			//            GroupName = item.GroupName
			//        });

			//}
			#endregion
			//var product = _context.Products.ToList();
		 
			//return View("Index", product);
		   
		}

		public ActionResult  New()
		{
			var grouplist = _context.ProductGroups.ToList();
			var productview = new ProductView
			{
				Product = new Product(),
				ProductGroups =  grouplist
			};
			return View("New",productview);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Product product)
		{
			//_context.Products.Add(product);
			#region Not working mapping code To check again !!!
			//if (product.Id == "")
			//    _context.Products.Add(product);
			//else
			//{
			//    var productentry = _context.Products.Single(p => p.Id == product.Id);
			//    //productentry.Id = product.Id;
			//    productentry.ProductName = product.ProductName;
			//    productentry.GroupId = product.GroupId;
			//    productentry.AddDate = product.AddDate;
			//    productentry.Active = product.Active;
			//    productentry.Booking = product.Booking;
			//    productentry.Discontnuied = product.Discontnuied;
			   
			//}
			//try
			//{
			//   
			//}
			//catch (DbEntityValidationException e)
			//{

			//    Console.WriteLine(e);
			//}
			#endregion

			if (!ModelState.IsValid)
			{
				var viewmodel = new ProductView
				{
					Product = product,
					ProductGroups = _context.ProductGroups.ToList()
				};
				return View("New", viewmodel);
			}
		   

			_context.Products.AddOrUpdate(product);
			_context.SaveChanges();

			return RedirectToAction("Index", "Product");
		}

		public ActionResult Edit(string id)
		{
			var product = _context.Products.SingleOrDefault(p =>p.Id == id);
			
			if (product == null)
			{
				return HttpNotFound();
			}

			var productview = new ProductView
			{
				Product= product,
				ProductGroups = _context.ProductGroups.ToList()
			};
			return View("New", productview);
		}
	}
	public class PG
	{
		public string Id { get; set; }
		public string ProductName { get; set; }
		public string GroupName { get; set; }
	}
}