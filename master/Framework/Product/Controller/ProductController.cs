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

namespace Wings.Framework.Product.Controllers
{
    ///
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
        public object productTagQuery(DataSourceLoadOptions loadOptions)
        {
            var data = DataSourceLoader.Load(this.productContext.ProductTags, loadOptions);
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
            var productTag = new ProductTag();
            JsonConvert.PopulateObject(bodyData.values, productTag);
            //Validate(order);
            if (!ModelState.IsValid)
                return false;
            this.productContext.ProductTags.Add(productTag);
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

            var menu = this.productContext.ProductTags.Find(key);
            this.productContext.ProductTags.Remove(menu);
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
            var productTag = this.productContext.ProductTags.Find(key);
            JsonConvert.PopulateObject(bodyData.values, productTag);
            this.productContext.SaveChanges();
            return true;
        }
    }
}