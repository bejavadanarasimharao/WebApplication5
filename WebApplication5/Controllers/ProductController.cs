using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Controllers.DAL;
using WebApplication5.Models;
namespace WebApplication5.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
         public ActionResult ProductDetails()

        {
          ProductDAL productDAL = new ProductDAL();

           List<Product> product = new List<Product>();
            /* obj.ProductId = 123;
             obj.ProductName = "narasimharao";
             obj.ProductDescription = "its nice...";
             obj.CurrentPrice = 100;*/

            product= productDAL.GetAllProduct();

            return View("ProductDetails", product);
        }
        
        public ActionResult deleteProductDetails(int ProductId)
        {
            ProductDAL productDAL = new ProductDAL();
            productDAL.DeleteProductDetails(ProductId);
            return RedirectToAction("ProductDetails");
        }

        [HttpGet]
        public ActionResult SubmitProductDetails()
        {
            return View("DisplayProductDetails");
        }

        [HttpPost]
        public ActionResult DisplayProduct(Product obj)
        {
               ProductDAL p = new ProductDAL();
                p.AddProduct(obj);
               
            if (ModelState.IsValid)
            {
               


                return View("ProductDetails", obj);
            }
            {
                return View("error");
            }
        }
          [HttpGet]
          public ActionResult EditProductDetails(int ProductId)

        {

            ProductDAL p = new ProductDAL();


            return View(p.GetAllProduct().Find(Product => Product.ProductId == ProductId));

        }
          [HttpPost]
          public ActionResult EditProductDetails(Product Obj)
        {
            ProductDAL productDAL = new ProductDAL();
            productDAL.UpdateProductDetails(Obj);
            return RedirectToAction("ProductDetails");

        }

    }
}