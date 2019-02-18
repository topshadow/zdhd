using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wings
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class WebConfig
    {
        /// <summary>
        /// 数据库连接字符串
        /// 
        /// 本地连接请使用
        /// @"Server=localhost;Initial Catalog=shop;Integrated Security=True"
        /// 远程连接请使用
        /// @"Server=myServerAddress;Database=myDataBase;User Id=myUsername; Password=myPassword;"
        /// </summary>
        public static  string connectUrl { get; } = @"Server=47.105.58.115;Database=shop;User Id=sa; Password=704104;";

    }
}
