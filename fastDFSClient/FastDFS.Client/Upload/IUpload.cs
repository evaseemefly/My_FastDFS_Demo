using Model.FdfsParameters;
using Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upload
{
    public interface IUpload
    {
        /// <summary>
        /// 上传普通文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        FileUploadResult UploadFile(FileUploadParameter param);

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <remarks>Update:cyr(Ben) 20150317</remarks>
        ImageUploadResult UploadImage(ImageUploadParameter param);
    }
}
