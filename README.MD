# productar-csharp-sdk

# 安装
Install-Package MalongTech.ProductAI.API 

# 快速入门

## Setup your account
```csharp
        static string accessKeyId = "your access key id";                        //require: 你的用户配置access_key_id
        static string secretKey =  "your secret key";                            //require: 你的用户配置secret_key 
        static ProductAIService api =
                new ProductAIService(
                    accessKeyId,                                                 //require: 你的用户配置access_key_id
                    secretKey                                                    //require: 你的用户配置secret_key
                    );        
```

## Search image using image file path
```csharp
        string imagePath;

        Dictionary<string,string> options = new Dictionary<string, string>();
        options.Add("loc","0-0-1-1");                                           //option: 图片标框的位置信息
        options.Add("count","1");

        bool isError = true;
        string respContent = "";//option: 设置总数限制

        isError =
        api.SubmitFileToSearch(
                serviceType,                                                    //require: 你的服务类型
                serviveId,                                                      //require: 你的服务ID
                imagePath,                                                      //require: 你的本地图片本地路径
                options,
                out respContent                                                 //请求返回结果获取错误数据
                );

        if (isError) {
        System.Console.WriteLine("request failed!");
        } else {
        System.Console.WriteLine("request success!");
        }
```

## Search image async using image file path
```csharp

        string imagePath ";

        Dictionary<string,string> options = new Dictionary<string, string>();
        options.Add("loc", "0-0-1-1");                                          //option: 图片标框的位置信息
        options.Add("count", "1");                                              //option: 设置总数限制

        api.BeginSubmitFileToSearch(
        serviceType,                                                            //require: 你的服务类型
        serviveId,                                                              //require: 你的服务ID
        imagePath,                                                              //require: 你的本地图片的路径
        options,
        RespCallback                                                            //你的异步回调函数
        );
```

## Search image using image binary file
```csharp
        Dictionary<string,string> options = new Dictionary<string, string>(); 
        byte[] fileBytes;                                                       
        options.Add("loc", "0-0-1-1");                                          //option: 图片标框的位置信息
        options.Add("count", "1");                                              //option: 设置总数限制

        bool isError = true;
        string respContent = "";

        isError =
        api.SubmitFileToSearch(
                serviceType,                                                    //require: 你的服务类型
                serviveId,                                                      //require: 你的服务ID
                fileBytes,                                                      //require: 你的本地图片二进制数据
                options ,
                out respContent
                );

        if (isError) {
        System.Console.WriteLine("request failed!");
        } else {
        System.Console.WriteLine("request success!");
        }
        System.Console.WriteLine(respContent);
```

## Search image async using image binary file
```csharp
        Dictionary<string,string> options = new Dictionary<string, string>();
        byte[] fileBytes;
        options.Add("loc", "0-0-1-1");                                          //option: 图片标框的位置信息
        options.Add("count", "1");                                              //option: 设置总数限制

        api.BeginSubmitFileToSearch(
        serviceType,                                                            //require: 你的服务类型
        serviveId,                                                              //require: 你的服务ID
        fileBytes,                                                              //require: 你的本地图片二进制数据
        options,
        RespCallback
        );
```

## Search image using image url
```csharp
        string imageUrl;

        Dictionary<string,string> options = new Dictionary<string, string>();
        options.Add("loc", "0-0-1-1");                                          //option:  图片标框的位置信息

        bool isError = true;
        string respContent = "";

        isError = api.SubmitFormToSearch(
        serviceType,                                                           //require: 你的服务类型
        serviveId,                                                             //require: 你的服务ID
        imageUrl,                                                              //require: 你的图片链接
        options,
        out respContent
        );

        if (isError) {
        System.Console.WriteLine("request failed!");
        } else {
        System.Console.WriteLine("request success!");
        }
        System.Console.WriteLine(respContent);
```

## Search image async using image url
```csharp
        string imageUrl;

        Dictionary<string,string> options = new Dictionary<string, string>();
        options.Add("loc", "0-0-1-1");                                          //option:  图片标框的位置信息                                                                              

        api.BeginSubmitFormToSearch(
        serviceType,                                                            //require: 你的服务类型
        serviveId,                                                              //require: 你的服务ID
        imageUrl,                                                               //require: 你的图片链接
        options,
        RespCallback                                                            //你的异步回调函数
        );
```

## Upload images to image set using url
```csharp
        string imageUrl;

        Dictionary<string,string>  options = new Dictionary<string, string>();
        options.Add("meta","My Test");                                          //option: 附加信息

        bool isError = true;
        string respContent = "";

        isError = api.AddImageToImageSet(
        imageSetId,                                                             //require: 你的数据集ID
        imageUrl,                                                               //require: 你的图片链接
        options,
        out respContent
        );

        if (isError) {
        System.Console.WriteLine("request failed!");
        } else {
        System.Console.WriteLine("request success!");
        }
        System.Console.WriteLine(respContent);
```

## Upload images to image set async using url
```csharp
        string imageUrl;

        Dictionary<string,string>  options = new Dictionary<string, string>();
        options.Add("meta", "My Test");                                          //option: 附加信息 

        api.BeginAddImageToImageSet(
        imageSetId,                                                              //require: 你的数据集ID
        imageUrl,                                                                //require: 你的图片链接
        options,
        RespCallback                                                             //你的异步回调函数
        );
```

## Upload images to image set using a csv file
```csharp
        string csvPath;

        Dictionary<string ,string> options = new Dictionary<string, string>();

        bool isError = true;
        string respContent = "";

        isError = api.AddImageByFile(
        imageSetId,                                                              //require: 你的数据集ID
        csvPath,                                                                 //require: 你的CSV文件的路径
        options,
        out respContent
        );

        if (isError) {
        System.Console.WriteLine("request failed!");
        } else {
        System.Console.WriteLine("request success!");
        }

        System.Console.WriteLine(respContent);
```

## Upload images to image set async using a csv file
```csharp
        string csvPath;
            
        Dictionary<string ,string> options = new Dictionary<string, string>();

        api.BeginAddImageByFile(
        imageSetId,                                                              //require: 你的数据集ID                                                    
        csvPath,                                                                 //require: 你的CSV文件的路径
        options,
        RespCallback                                                             //你的异步回调函数
        );
```

## Remove images from image set using a csv file
```csharp
        string csvPath;

        Dictionary<string ,string> options = new Dictionary<string, string>();

        bool isError = true;
        string respContent = "";

        isError = api.DeleteImageByFile(
        imageSetId,                                                              //require: 你的数据集ID
        csvPath,                                                                 //require: 你的CSV文件的路径
        options,
        out respContent
        );

        if (isError) {
        System.Console.WriteLine("request failed!");
        } else {
        System.Console.WriteLine("request success!");
        }
        System.Console.WriteLine(respContent);
```

## Remove images from image set async using a csv file
```csharp
        string csvPath;

        Dictionary<string ,string> options = new Dictionary<string, string>();

        api.BeginDeleteImageByFile(
        imageSetId,                                                              //require: 你的数据集ID                                                    
        csvPath,                                                                 //require: 你的CSV文件的路径
        options,
        RespCallback                                                             //你的异步回调函数
        ); 
```

## request async callback function
```csharp
        static void RespCallback(IAsyncResult result) {
                string respContent =  "";
                ProductAIService.ProductAIAsyncResult pAIRes=  
                result.AsyncState as ProductAIService.ProductAIAsyncResult;
                bool isError = pAIRes.APIInstance.EndRequest(pAIRes, out respContent);

                if (isError) {
                System.Console.WriteLine("request failed!");
                } else {
                System.Console.WriteLine("request success!");
                }
                System.Console.WriteLine(respContent);

        }  
```



