using Villa_Web.Models;

namespace Villa_Web.Services.IServices
{
    // will make the API request and fetch the response (instead of the individual create, update, put, delete)
    // one base service for all the requests to make things much cleaner
    public interface IBaseService
    {
        APIResponse ResponseModel { get; set; }
        Task <T> SendAsync<T>(ApiRequest apiRequest);// will send API calls to call the API. will pass an ApiTRequest model and the return type will be generic Task
    }
}
