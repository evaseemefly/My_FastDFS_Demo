using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Result
{
    /// <summary>
    /// 上传结果父类
    /// </summary>
    public class BaseUploadResult
    {
        /// <summary>
        /// 返回文件地址
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 错误消息列表
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 是否上传成功
        /// </summary>
        public bool IsValid { get { return string.IsNullOrWhiteSpace(ErrorMessage); } }
    }
}
