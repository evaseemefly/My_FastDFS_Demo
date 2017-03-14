using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Download
{
    public class DownloadFactory
    {
        public readonly static IDownload Instance;

        private static object lockObj = new object();

        static DownloadFactory()
        {
            if (Instance == null)
            {
                lock (lockObj)
                {
                    Instance = new Download.Implements.FdfsDownload();
                }
            }
        }
    }
}
