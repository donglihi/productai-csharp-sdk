﻿using System;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 图像搜索
    /// <para>https://api-doc.productai.cn/doc/pai.html#创意图像精准匹配</para>
    /// </summary>
    public class ImageSearchByImageUrlRequest 
        : SearchByImageUrlBaseRequest<ImageSearchResponse>
    {
        public ImageSearchByImageUrlRequest(string serviceId, string loc = "0-0-1-1", ITag searchTag = null, int? count = null)
            : base("search", serviceId, loc, searchTag, count)
        {
            
        }

        public ImageSearchByImageUrlRequest(string serviceId, string url, string loc = "0-0-1-1", ITag searchTag = null, int? count = null)
            : this(serviceId, loc, searchTag, count)
        {
            this.Url = url;
        }
    }
}