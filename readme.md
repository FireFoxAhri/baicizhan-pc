[toc]

# 说明
2018年学英语的时候搞的小程序(感慨一下, 转眼3年过去了), 解析百词斩离线保存的单词文件(zpk文件), 保存为音频、图片、json等文件, 可以用来重组素材, 根据自己的情况针对性地练习英语; 

# 程序下载
https://github.com/qiaoxingxing/baicizhan-pc/tree/master/to-release

# 源码
代码有点烂, 凑合能用; 
https://github.com/qiaoxingxing/baicizhan-pc

# 视频演示
https://www.bilibili.com/video/BV1gv411M7fP/

# 界面、使用方法
## 句子听写练习
![](https://gitee.com/qiaoxingxing/blog-pic/raw/master/index_files/b27988d9-98f9-4cf4-96cf-3517f933c8cc.png)


## 单词提取
以下操作使用android版, ios版未测试; 
1. 使用百词斩官方app缓存单词, 缓存的位置在: `Android/data/com.jiongji.andriod.card/files/baicizhan/zpack/`, 缓存的文件是一堆zpk后缀的文件, 一个文件表示一个单词; 
2. 缓存成功后把缓存的文件拷贝到电脑, 
3. 打开菜单"解压zpk", 填写路径, 点击"提取"

![](https://gitee.com/qiaoxingxing/blog-pic/raw/master/index_files/c6c88a1e-5ef8-4567-8de7-6138e4908403.png)

## 配置
修改程序目录下的: BaiCiZhan.exe.config
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
  </startup>
  <appSettings>
    <!--单词文件夹, 以"WORDS_"开头,后面是单词名称, 可以添加多个-->
    <add key="WORDS_演示单词" value=".\data\demo\zpk_解压"/>
    <add key="WORDS_四级单词" value="D:\百词斩四级"/>

    <!--数据文件夹, 历史记录、收藏等-->
    <add key="DATA_DIR" value=".\data\"/>
  </appSettings>
</configuration>
```




