using System;
using System.IO;
using FastDFS.Client.Common;
using FastDFS.Client.Config;
using System.Configuration;
using Common.Config.Fdfs;
using Upload;
using Download;
using Model.FdfsParameters;

namespace FastDFS.Client.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            var config = FastDfsManager.GetConfigSection();
            //测试第二种方式
            //TrackerSection trackersSection = ConfigurationManager.GetSection("TrackerSection") as TrackerSection;
            //测试第三种方式
            //MyFastDFSClient.Test();           

            StorageNode storageNode = null;

            var fileName = "";
            if (!File.Exists("test.jpg"))
            {
                return;
            }
            FileStream streamUpload = new FileStream(@"test.jpg", FileMode.Open);
            Console.WriteLine("进行上传图片/文件 测试");
            IUpload uploadFile = UploadFactory.Instance;
            //1 测试上传文件（非图片）——可行
            var fileUploadPara = new FileUploadParameter()
            {
                FileName = "test.jpg",
                //Content= File.ReadAllBytes("test.jpg"),
                Stream = streamUpload
            };
            //uploadFile.UploadFile(fileUploadPara);
            //2 测试上传图片
            //**注意，maxSize以后改为读取配置文件
            var fileUploadImage = new ImageUploadParameter(streamUpload, "test.jpg",null, 2*1024*1024) { };
            //FilePath:http://192.168.0.113/group1/M00/00/00/wKgAcVjHVVKAGNhPAAInn_BrY3k026.jpg
            var result = uploadFile.UploadImage(fileUploadImage);
            Console.WriteLine("上传成功，上传图片为{0}",result.FullFilePath);
            Console.WriteLine("*******************************");
            Console.WriteLine("1.直接获取刚才上传的文件的名称");
            Console.WriteLine("2.手动收入文件名称");
            Console.Write("请输入命令：");
            var index = Console.ReadLine();
            string filename_console = null;
            switch (index)
            {
                case "1":
                    filename_console = result.FileName;
                    Console.WriteLine("刚才上传的文件名为：{0}",filename_console);
                    break;
                case "2":
                    Console.WriteLine("请输入命令：");
                    Console.WriteLine("请输入文件路径准备下载指定文件");
                    filename_console = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("输入有误！");
                    return;
            }           
            
            IDownload downloadFile = DownloadFactory.Instance;
            Console.WriteLine("*******************************");
            var result_download= downloadFile.GetTargetFile(new FileDownParameter() { FileName = filename_console });
            Console.WriteLine("下载成功");
            Console.ReadLine();
            do
            {
                Console.WriteLine("\r\n1.Init");
                Console.WriteLine("2.GetStorageNode");
                Console.WriteLine("3.UploadFile");
                Console.WriteLine("4.RemoveFile");

                Console.Write("请输入命令：");
                var cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        ConnectionManager.InitializeForConfigSection(config);
                        break;

                    case "2":
                        storageNode = MyFastDFSClient.GetStorageNode(config.GroupName);
                        Console.WriteLine(storageNode.EndPoint);
                        break;

                    case "3":
                       //暂时注释掉
                        fileName = MyFastDFSClient.UploadFile(storageNode, File.ReadAllBytes("test.jpg"), "jpg");

                                              
                        //此处不需要手动关闭了
                        //streamUpload.Close();
                        Console.WriteLine(fileName);
                        break;

                    case "4":
                        MyFastDFSClient.RemoveFile(config.GroupName, fileName);
                        break;
                }

            } while (true);

        }
    }
}
