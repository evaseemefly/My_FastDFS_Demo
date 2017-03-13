using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Result;
using Model.FdfsParameters;

namespace Download
{
    public interface IDownload
    {
        FileDownloadResult GetTargetFile(FileDownParameter param);
    }
}
