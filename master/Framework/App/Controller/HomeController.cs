using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wings.Framework.Common.DTO;
using Wings.Framework.Common.Service;
using Wings.Framework.Product.Model;
using Microsoft.EntityFrameworkCore;
namespace Wings.Framework.App.Controller
{

    /// <summary>
    /// App主模块
    /// </summary>
    [ApiController]
    [Route("api/App/[controller]")]
    public class HomeController
    {
        /// <summary>
        /// 产品数据上下文
        /// </summary>
        public ProductContext productContext { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_productContext"></param>
        public HomeController(ProductContext _productContext) { this.productContext = _productContext; }

        /// <summary>
        /// 广告展示
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public Object bannerList(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(this.productContext.Banners, loadOptions);
        }

        /// <summary>
        /// 根据产品标签获取产品
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public Object productTag(DataSourceLoadOptions loadOptions)
        {
            var query = (from productTag in this.productContext.ProductTags select productTag)

                .Include(pTag => pTag.products)
                    .ThenInclude(p => p.subProducts)
                .Include(pTag => pTag.products)
                .ThenInclude(p2=>p2.productImages);
             
            return DataSourceLoader.Load(query, loadOptions);
        }
    }
}
