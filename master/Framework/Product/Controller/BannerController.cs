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
    /// 产品标签管理
    /// </summary>
    [Route("api/Product/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        ProductContext productContext;
        ///
        public BannerController(ProductContext _productContext) { this.productContext = _productContext; }
        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="loadOptions"></param>    
        [HttpGet]
        public object productQuery(DataSourceLoadOptions loadOptions)
        {
            var data = DataSourceLoader.Load(this.productContext.Banners, loadOptions);
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
            var banner = new Product.Model.Banner();
            JsonConvert.PopulateObject(bodyData.values, banner);
            //Validate(order);
            if (!ModelState.IsValid)
                return false; 
            this.productContext.Banners.Add(banner);
            this.productContext.SaveChanges();
            return true;
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool Delete([FromForm]int key)
        {

            var banner = this.productContext.Banners.Find(key);
            this.productContext.Banners.Remove(banner);
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
        public bool Put(int key, [FromForm] BodyData bodyData)
        {
            var banner = this.productContext.Banners.Find(key);
            JsonConvert.PopulateObject(bodyData.values, banner);
            this.productContext.SaveChanges();
            return true;
        }
    }
}