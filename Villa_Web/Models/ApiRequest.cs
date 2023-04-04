using Microsoft.AspNetCore.Mvc;
using static Villa_Utility.SD;

namespace Villa_Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;  

        public string Url { get; set; } // url of api to call

        public object Data { get; set; }// when creating data, passing it to API
    }
}
