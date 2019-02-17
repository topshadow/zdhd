using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Wings.Framework.Product.Model
{

    /// <summary>
    /// 角色权限模块
    /// </summary>
    public class ProductContext : DbContext
    { /// <summary>
      /// 
      /// </summary>
      /// <param name="options"></param>
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        /// <summary>
        /// 组织: 不同组织的角色不同
        /// </summary>
        public DbSet<ProductTag> ProductTags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }

    /// <summary>
    /// 组织表
    /// </summary>
    [Table("ProductTag")]
    public class ProductTag
    {
        /// <summary>
        /// 组织Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productTagId { get; set; }
        /// <summary>
        /// 组织名字
        /// </summary>
        public string tagName { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 标签分组
        /// </summary>
        public string cate { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<DateTime> createTime { get; set; }
    }
    /// <summary>
    /// 产品表
    /// </summary>
    [Table("Product")]
    public class Product
    {
        /// <summary>
        /// 产品id
        /// </summary>
        public int productId { get; set; }
        public int productCode { get; set; }
    }

}