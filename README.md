# My_FastDFS_Demo
evaseemefly的FastDfs的操作封装类 
-------

注意fastDFSClient文件夹中为项目所在位置<br>
本demo主要配合短信系统使用<br>
https://github.com/evaseemefly/PMS++<br>
本demo中FastDFS.Client.Demo为程序入口，测试代码见其中<br>
02Service为业务层（之后会再修改）<br>
其中包含上传与下载操作类，以及他们的父类BaseFdfs。<br>
上传及下载均有其定义的接口IDownload与IUpload；上传与下载使用单例工厂的方式创建。<br>
04Intrastructure为定义的一些上传与下载的参数对象，以及结果对象。<br>
Common中定义了配置文件对象，但此实例中最终未使用此种方式。<br>
注意在app.config中定义了fastdfs配置节，其中定义的配置项示例如下：<br>
```java
  <FastDfsConfig GroupName="group1">
      <FastDfsServer IpAddress="192.168.0.113" Port="22122" FailCount="10" MaxFailCount="50"/>
      <!--<FastDfsServer IpAddress="192.168.1.117" Port="22122" FailCount="10" MaxFailCount="50"/>-->
    </FastDfsConfig> 
