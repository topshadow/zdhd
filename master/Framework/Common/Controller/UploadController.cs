using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wings.Framework.Common.DTO;
using Wings.Framework.Common.Service;

namespace Wings.Framework.Common.Controller
{

    /// <summary>
    /// 文件上传服务
    /// </summary>
    [ApiController]
    [Route("api/Common/[controller]")]
    public class UploadController
    {
        /// <summary>
        /// 图片上传
        /// base64格式
        /// </summary>
        /// <param name="imageUploadDTO"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Object uploadImage([FromBody]ImageUploadDTO imageUploadDTO)
        {
            // 删除非法base64字符
            string converted = imageUploadDTO.base64.Replace(@"data:image/png;base64,", "");
            converted = converted.Replace("data:image/jpeg;base64,", "");
            MemoryStream ms = new MemoryStream(System.Convert.FromBase64String(converted));
            var key = System.Guid.NewGuid().ToString() + ".png";
            var uploadResult = OSSService.uploadFile(key, ms);
            return new { url = OSSService.url + "/"+key, ok = uploadResult.HttpStatusCode == System.Net.HttpStatusCode.OK };
        }
    }
}
