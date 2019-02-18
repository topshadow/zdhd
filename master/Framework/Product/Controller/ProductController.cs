using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Wings.Framework.Controllers;
using Wings.Framework.Product.Model;
using Wings.Framework.RBAC.Model;
using Microsoft.EntityFrameworkCore;

namespace Wings.Framework.Product.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("api/Product/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductContext  productContext;
        ///
        public ProductController(ProductContext _productContext) { this.productContext  =_productContext; }
        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="loadOptions"></param>    
        [HttpGet]
        public object productQuery(DataSourceLoadOptions loadOptions)
        {
            var query = (from Product in this.productContext.Products select Product)
                .Include(p => p.productImages)
                .Include(p => p.subProducts);
            var data = DataSourceLoader.Load(  query, loadOptions);
            return data;
        }

        /// <summary>
        /// 创建组织
        /// </summary>
        /// <param name="bodyData"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Post([FromForm] BodyData bodyData)
        {
            var product = new Product.Model.Product();

            JsonConvert.PopulateObject(bodyData.values, product);

          
            //Validate(order);
            if (!ModelState.IsValid)
                return false;
            this.productContext.Products.Add(product);
            this.productContext.SaveChanges();
            return true;
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool Delete(int key)
        {

            var menu = this.productContext.Products.Find(key);
            this.productContext.Products.Remove(menu);
            this.productContext.SaveChanges();
            return true;
        }
        /// <summary>
        /// 更新组织
        /// </summary>
        /// <param name="key"></param>
        /// <param name="bodyData"></param>
        /// <returns></returns>
        [HttpPut]
        public bool Put(int key, BodyData bodyData)
        {
            var product = this.productContext.Products.Find(key);
            
            JsonConvert.PopulateObject(bodyData.values, product);
            this.productContext.SaveChanges();
            return true;
        }
    }
}