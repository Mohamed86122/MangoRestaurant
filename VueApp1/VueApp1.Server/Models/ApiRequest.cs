﻿using static VueApp1.Server.SD;

namespace VueApp1.Server.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;

        public string Url { get; set; }

        public object Data { get; set; }

        public string AccessToken { get; set; }

       
    }
}
