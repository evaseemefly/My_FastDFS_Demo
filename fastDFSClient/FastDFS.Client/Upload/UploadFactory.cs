using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upload
{
    public class UploadFactory
    {
        /// <summary>
        /// 上传对象
        /// </summary>
        public readonly static IUpload Instance;

        private static object lockObj = new object();

        static UploadFactory()
        {
            if (Instance == null)
            {
                lock (lockObj)
                {
                    Instance = new Implements.FdfsUpload();
                }
            }
        }
    }
}
