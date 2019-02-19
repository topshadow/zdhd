using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        /// 产品标签
        /// </summary>
        //public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// 产品图片
        /// </summary>
        public DbSet<ProductImage> ProductImages { get; set; }
        /// <summary>
        /// 子产品表
        /// </summary>
        public DbSet<SubProduct> SubProducts { get; set; }
        /// <summary>
        /// 产品标签表
        /// </summary>
        public DbSet<ProductTag> ProductTags { get; set; }
        /// <summary>
        /// 广告
        /// </summary>
        public DbSet<Banner> Banners { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 产品 一对多 产品图片
            modelBuilder.Entity<ProductImage>().HasOne(pImage => pImage.product).WithMany(p => p.productImages);
            // 产品 一对多 子产品
            modelBuilder.Entity<SubProduct>().HasOne(subP => subP.product).WithMany(p => p.subProducts);
            // 产品组
            modelBuilder.Entity<Product>().HasOne(p => p.productTag).WithMany(tag => tag.products);
        }
    }

    /// <summary>
    /// 组织表
    /// </summary>
    [Table("ProductTags")]
    public class ProductTag
    {
        /// <summary>
        /// 标签id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productTagId { get; set; }
        /// <summary>
        /// 标签标题
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 备足
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<DateTime> createTime { get; set; } = new DateTime();
        /// <summary>
        /// 产品,用于一对多
        /// </summary>
        public List<Product> products { get; set; }

    }
    /// <summary>
    /// 产品表
    /// </summary>
    [Table("Products")]
    public class Product
    {
        /// <summary>
        /// 产品id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 产品简介
        /// </summary>
        public string summary { get; set; }
        /// <summary>
        /// 产品代码
        /// P+发布日期(20180204)+ 6位编号000001
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 产品图文介绍
        /// </summary>
        public string html { get; set; }
        /// <summary>
        /// 产品创建日期
        /// </summary>
        public Nullable<DateTime> createTime { get; set; }
        /// <summary>
        /// 产品状态
        /// </summary>
        public ProductStatus status { get; set; } = ProductStatus.Submitted;
        /// <summary>
        /// 总销量
        /// </summary>
        public int totalSaleNum { get; set; }
        /// <summary>
        /// 总点击次数
        /// </summary>
        public int totalViewNum { get; set; }
        /// <summary>
        /// 产品图片组
        /// </summary>
        public List<ProductImage> productImages { get; set; }
        /// <summary>
        /// 子产品列表
        /// </summary>
        public List<SubProduct> subProducts { get; set; }

        /// <summary>
        /// 产品标签id
        /// </summary>
        public int productTagId { get; set; }
        /// <summary>
        /// 产品分类标签
        /// </summary>
        [JsonIgnore]
        [IgnoreDataMember]
        public ProductTag productTag { get; set; }

    }
    /// <summary>
    /// 产品状态
    /// </summary>
    public enum ProductStatus
    {
        /// <summary>
        /// 未提交
        /// </summary>
        UnSubmit,
        /// <summary>
        /// 已提交
        /// </summary>
        Submitted,
        /// <summary>
        /// 上架
        /// </summary>
        Active,
        /// <summary>
        /// 过期
        /// </summary>
        Disabled

    }

    /// <summary>
    /// 产品图片
    /// </summary>
    [Table("ProductImages")]
    public class ProductImage
    {
        /// <summary>
        /// 产品图片id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productImageId { get; set; }
        /// <summary>
        /// 指向的产品id
        /// </summary>
        public int productId { get; set; }
        /// <summary>
        /// 上传的图片地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public Nullable<DateTime> createTime { get; set; } = new DateTime();
        /// <summary>
        /// 用于建立一对多,多对一关系
        /// </summary>
        [JsonIgnore]
        [IgnoreDataMember]
        public Product product { get; set; }


    }

    /// <summary>
    /// 子产品
    /// 同一产品下有不同的子产品,
    /// 只允许购买子产品,不允许直接购买产品
    /// </summary>
    [Table("SubProduct")]
    public class SubProduct
    {
        /// <summary>
        /// 子产品id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int subProductId { get; set; }
        /// <summary>
        ///  分类的值
        /// </summary>
        public string cateValue { get; set; }
        /// <summary>
        /// 用于关联一对多,多对一
        /// </summary>
        [JsonIgnore]
        [IgnoreDataMember]
        public Product product { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int productId { get; set; }
        /// <summary>
        /// 子产品价格
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int storageNum { get; set; } = 0;
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<DateTime> createTime { get; set; } = new DateTime();


    }

    /// <summary>
    /// 广告
    /// </summary>
    [Table("Banner")]
    public class Banner
    {
        /// <summary>
        /// 广告Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bannerId { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string imageUrl { get; set; }

        /// <summary>
        /// 产品id
        /// </summary>
        public int productId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<DateTime> createTime { get; set; } = DateTime.Now;

    }

}