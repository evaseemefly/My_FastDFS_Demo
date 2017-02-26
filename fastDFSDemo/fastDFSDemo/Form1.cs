using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using FastDFS.Client;
using FastDFS.Client.Common;
using FastDFS.Client.Config;
using FastDFS.Client.Storage;
using FastDFS.Client.Tracker;


namespace fastDFSDemo
{
    public partial class FastDF : Form
    {
        #region 公共变量
        private List<IPEndPoint> trackerIPs = new List<IPEndPoint>();
        private IPEndPoint endPoint;
        private StorageNode storageNode;
        #endregion
        public FastDF()
        {
            InitializeComponent();
            txtTracker.Text = "xxx.xxx.xxx.xxx";
            txtStorage.Text = "xxx.xxx.xxx.xxx";
        }
        /// <summary>
        /// 连接FASTDFS服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLinkFastDfs_Click(object sender, EventArgs e)
        {
            string[] trackers = txtTracker.Text.Replace("\r\n", ",").Split(new char[','], StringSplitOptions.RemoveEmptyEntries);
            string[] storages = txtTracker.Text.Replace("\r\n", ",").Split(new char[','], StringSplitOptions.RemoveEmptyEntries);
            foreach (var onetracker in trackers)
            {
                trackerIPs.Add(new IPEndPoint(IPAddress.Parse(onetracker), 22122));
            }
            ConnectionManager.Initialize(trackerIPs);
            storageNode = FastDFSClient.GetStorageNode("group1");
            label3.Text = "连接成功";
        }
        /// <summary>
        /// 浏览文件并上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "文本文件|*.*|png|*.png|JPG|*.jpg|JPEG|*.jpeg|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog.FileName;
                byte[] content = null;
                /*  FileInfo fileInfo = new FileInfo(filePath);
                  return fileInfo.Length;*/
                FileStream streamUpload = new FileStream(fName, FileMode.Open);
                using (BinaryReader reader = new BinaryReader(streamUpload))
                {
                    content = reader.ReadBytes((int)streamUpload.Length);
                }
                textBox1.Text = fName;
             
                //主文件
                string fileName = FastDFSClient.UploadFile(storageNode, content, "png");
                var info = FastDFSClient.GetFileInfo(storageNode, fileName);
                //从文件
                var slaveFileName = FastDFSClient.UploadSlaveFile("group1", content, fileName, "_120x120", "png");
                var slaveInfo = FastDFSClient.GetFileInfo(storageNode, slaveFileName);
                listBox1.Items.Add(string.Format("主文件：http://{0}:8080/group1/{1}", trackerIPs[0].Address, fileName));
                listBox1.Items.Add(string.Format("主文件大小：{0}KB,创建时间：{1}", info.FileSize, info.CreateTime));
                listBox1.Items.Add(string.Format("从文件：http://{0}:8080/group1/{1}", trackerIPs[0].Address, slaveFileName));
                listBox1.Items.Add(string.Format("从文件大小：{0}KB,创建时间：{1}", slaveInfo.FileSize, slaveInfo.CreateTime));


            }

        }
        #region

        private void DownloadFile1(string orgUrl, string targetPath)
        {
            using (WebClient web = new WebClient())
            {
                web.DownloadFile(orgUrl, targetPath);
            }
        }
        private void DownloadFile2(string fileName, string targetPath)
        {
            //  byte[] buffer = FastDFSClient.DownloadFile(node, fileName, 0L, 0L);
            targetPath = "d:\\" + Path.GetFileName(fileName);
            FDFSFileInfo fileInfo = FastDFSClient.GetFileInfo(storageNode, fileName);
            if (fileInfo.FileSize >= 1024)//如果文件大小大于1KB  分次写入
            {
                FileStream fs = new FileStream(targetPath, FileMode.OpenOrCreate, FileAccess.Write);
                long offset = 0;
                long len = 1024;
                while (len > 0)
                {
                    byte[] buffer = new byte[len];
                    buffer = FastDFSClient.DownloadFile(storageNode, fileName, offset, len);
                    fs.Write(buffer, 0, int.Parse(len.ToString()));
                    fs.Flush();
                    // setrichtext(name_ + "已经下载：" + (offset / fileInfo.FileSize) + "%");
                    offset = offset + len;
                    len = (fileInfo.FileSize - offset) >= 1024 ? 1024 : (fileInfo.FileSize - offset);
                }
                fs.Close();

            }
            else//如果文件大小小小于1KB  直接写入文件
            {
                byte[] buffer = new byte[fileInfo.FileSize];
                buffer = FastDFSClient.DownloadFile(storageNode, fileName);
                FileStream fs = new FileStream(targetPath, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
                fs.Close();
            }
        }

        #endregion

        private void FastDF_Load(object sender, EventArgs e)
        {

        }
    }
}

