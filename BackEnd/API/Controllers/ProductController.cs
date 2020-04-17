using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Dsmart.Repository.Sql;
using DALInvemtory.Models;
using API.Models;
using System.IO;
using System.Net.Http.Headers;
using System.Web;
using System.Text;

namespace API.Controllers
{
    public class ProductController : ApiController
    {
        public IBaseRepository<Product> repository = null;
        
        public ProductController()
        {
            repository = new BaseRepository<Product>();
        }

        public ProductController(IBaseRepository<Product> repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        [Route("getAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            IList<ProductViewModel> Products = null;
            var result = repository.GetByAll();
           // var x=result.ToList<Product>();

            Products = result.Select(s => new ProductViewModel() {
                Productid = s.Productid, name = s.name, lastupdated = s.lastupdated, photo = s.photo, price = s.price
                        }).ToList<ProductViewModel>();

            if (Products.Count == 0)
            {
                return NotFound();
            }

            return Ok(Products);

           
        }

        [HttpGet()]
        [Route("api/GetAllProductsById/{id:int}")]
        public IHttpActionResult GetAllProductsById(int id)
        {
            var result = repository.GetById(id);
            ProductViewModel PVM = new ProductViewModel();
            if (result != null)
            {
                
                PVM.Productid = result.Productid;
                PVM.name = result.name;
                PVM.lastupdated = result.lastupdated;
                PVM.photo = result.photo;
                PVM.price = result.price;
            }
            if (PVM == null)
            {
                return NotFound();
               // return Enumerable.Empty<object>();
            }
            return Ok(PVM);
        }

        [HttpPost]
        [Route("postNewProduct")]
        public IHttpActionResult PostNewProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var result = repository.Add(new Product()
            {
                name = product.name,
                price = product.price,
                lastupdated =product.lastupdated,
                photo =product.photo
            });
            repository.Save();
            return Ok();
        }

        [HttpPost]
        [Route("api/UpdateProduct/{id:int}")]
        public IHttpActionResult Put(ProductViewModel product,int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var existingproduct = repository.GetById(id);

            if (existingproduct != null)
            {
                existingproduct.name = product.name;
                existingproduct.price = product.price;
                existingproduct.lastupdated = product.lastupdated;
                existingproduct.photo = product.photo;
                // });
                repository.Save();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet()]
        [Route("api/Delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            var existingproduct = repository.GetById(id);

            repository.RemoveById(id);
            repository.Save();
            
            return Ok();
        }

        [HttpGet] 
        [Route("downloadexcel")]
        public HttpResponseMessage Get()
        {
            var resultProduct = repository.GetByAll().ToList();


            StringBuilder str = new StringBuilder();
            str.Append("<table border=`" + "1px" + "`b>");
            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3>Productid</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>name</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>price</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>lastupdated</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>photo</font></b></td>");
            str.Append("</tr>");
            foreach (Product val in resultProduct)
            {
                str.Append("<tr>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.Productid.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.name.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.price.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.lastupdated.ToString() + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + val.photo.ToString() + "</font></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            //result.Content = new StringContent(str);
            result.Content = new StringContent(str.ToString());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment"); //attachment will force download
            result.Content.Headers.ContentDisposition.FileName = "data.xlsx";
            return result;
        }

        [HttpGet]//http get as it return file 
        [Route("download")]
        public HttpResponseMessage GetTestFile()
        {
            //below code locate physcial file on server 
            var localFilePath = HttpContext.Current.Server.MapPath("~/timetable.zip");
            HttpResponseMessage response = null;
            if (!File.Exists(localFilePath))
            {
                //if file not found than return response as resource not present 
                response = Request.CreateResponse(HttpStatusCode.Gone);
            }
            else
            {
                //if file present than read file 
                var fStream = new FileStream(localFilePath, FileMode.Open, FileAccess.Read);
                //compose response and include file as content in it
                response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StreamContent(fStream)
                };
                //set content header of reponse as file attached in reponse
                response.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment")
                {
                    FileName = Path.GetFileName(fStream.Name)
                };
                //set the content header content type as application/octet-stream as it returning file as reponse 
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            }
            return response;
        }
    }
}