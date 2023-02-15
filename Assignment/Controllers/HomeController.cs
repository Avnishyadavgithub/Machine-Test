using Assignment.Models;
using Assignment.Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ProductCategoryRepository objRepository = new ProductCategoryRepository();
        public ActionResult Index()
        {
           
            //    List<Category> objCategory = new List<Category>();
            //List<Category> objProduct = new List<Category>();
            dynamic mymodel = new ExpandoObject();
            //List<Product> objProduct = new List<Product>();
            mymodel.Category = objRepository.GetAllCategory();
            mymodel.Product = objRepository.GetAllProduct();
          
                return View(mymodel);
            
                
            
           
        }
        [HttpPost]
        public JsonResult AddUpdateCategoryMaster(string CategoryName, int CategoryID, string Method)
        {
            string s = string.Empty;
            JsonResult objJsonResult = new JsonResult();
           bool flag = objRepository.AddUpdateCategory(CategoryName,CategoryID,Method);
            if(flag ==true)
            {
                if(Method =="INSERT")
                {
                    s = "Record Inserted Succesfully";
                }
                else
                {
                    s = "Record Updated Succesfully";
                }
               
                objJsonResult.Data = s;
            }

            return objJsonResult;
        }

        [HttpPost]
        public JsonResult AddUpdateProductMaster( int ProductID,string ProductName, int CategoryID, string Method)
        {
            string s = string.Empty;
            JsonResult objJsonResult = new JsonResult();
            bool flag = objRepository.AddUpdateProduct(ProductID, ProductName, CategoryID, Method);
            if (flag == true)
            {
                if (Method == "INSERT")
                {
                    s = "Record Inserted Succesfully";
                }
                else
                {
                    s = "Record Updated Succesfully";
                }
                objJsonResult.Data = s;
            }

            return objJsonResult;
        }


        [HttpGet]
        public ActionResult DeleteCategoryMaster(int id)
        {
            string s = string.Empty;

            bool flag = objRepository.DeleteCategory(id);
            
            if (flag ==true)
            {
                ViewBag.DeleteCategoryMsg = "Record Deleted Successfully";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteProductMaster(int id)
        {
            string s = string.Empty;

            bool flag = objRepository.DeleteProduct(id);
            
            if (flag == true)
            {
                ViewBag.DeleteCategoryMsg = "Record Deleted Successfully";
            }

            return RedirectToAction("Index");
        }


    }


}