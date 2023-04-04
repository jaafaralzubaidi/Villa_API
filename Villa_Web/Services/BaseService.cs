using Newtonsoft.Json;
using System.Text;
using Villa_Utility;
using Villa_Web.Models;
using Villa_Web.Services.IServices;

namespace Villa_Web.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse ResponseModel { get; set; }  // will use in the SendAsync, when receiving the response
        public IHttpClientFactory httpClientFactory { get; set; }   // In order to to call the api

        public BaseService(IHttpClientFactory httpClientFactory) 
        { 
            this.ResponseModel = new();
            this.httpClientFactory = httpClientFactory;
            
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {

                // Request configuration
                var client = httpClientFactory.CreateClient("MagicAPI");
                // message
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.Headers.Add("Accept", "application/json");
                httpRequestMessage.RequestUri = new Uri(apiRequest.Url); // url where to call the api


                // when updating data, need to serialize that. data will not be null in POST/PUT HTTP calls
                if (apiRequest.Data != null)
                {
                    httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                // method
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        httpRequestMessage.Method = HttpMethod.Post;
                        break;                    
                    case SD.ApiType.PUT:
                        httpRequestMessage.Method = HttpMethod.Put;
                        break;                   
                    case SD.ApiType.DELETE:
                        httpRequestMessage.Method = HttpMethod.Delete;
                        break;                    
                    default:
                        httpRequestMessage.Method = HttpMethod.Get;
                        break;
                }
                

                // Response 
                // Set response to null
                HttpResponseMessage apiResponse = null;
                //call api endpoint with created client
                apiResponse = await client.SendAsync(httpRequestMessage);
                // extract content from response
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                // Deserialize apiContent into the APIResponse model
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
                // serialize and deserialize the object to the generic type, => to return the deserialized object
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
        }
    }
}
