﻿using System;
using System.Configuration;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Examples
{
    class Useage
    {
        void FullFlowExample()
        {
            // step 1 - setup your account profile
            // get your accessKeyId & secretKey at https://console.productai.cn/main#/21/service_category_id=1
            IProfile profile = new DefaultProfile
            {
                Version = "1",
                AccessKeyId = ConfigurationManager.AppSettings["AccessKeyId"],
                SecretKey = ConfigurationManager.AppSettings["SecretKey"],

                // set this property = null if you want to control the language type of each request
                GlobalLanguage = LanguageType.Chinese
            };

            // step 2 - initialize your ProductAI client
            var client = new DefaultProductAIClient(profile);

            // step 3 - build your request
            // take image search as example
            var request = new ImageSearchByImageUrlRequest("<your service id>")
            {
                Url = "http://productai.cn/img/f10.jpg",

                // this value will be override because you had set the IProfile.GlobalLanguage = LanguageType.Chinese
                Language = LanguageType.English
            };

            //step 4 - send out the request、receive the response、catch the exceptions
            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                // access the reponse directly
                foreach (var r in response.Results)
                {
                    Console.WriteLine("{0}\t\t{1}", r.Url, r.Score);
                }
                Console.WriteLine("==========================Result==========================");
            }
            catch (ServerException ex)
            {
                Console.WriteLine("ServerException happened: \r\n\tErrorCode: {0}\r\n\tErrorMessage: {1}",
                    ex.ErrorCode,
                    ex.ErrorMessage);
            }
            catch (ClientException ex)
            {
                Console.WriteLine("ClientException happened: \r\n\tRequestId: {0}\r\n\tErrorCode:\r\n\t{1}\r\n\tErrorMessage: {2}",
                    ex.RequestId,
                    ex.ErrorCode,
                    ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown Exception happened: {0}\r\n{1}", ex.Message, ex.StackTrace);
            }

            // Congrats! Now you can build your smart AI service using ProductAI.
        }
    }
}