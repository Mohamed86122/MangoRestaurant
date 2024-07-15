using Newtonsoft.Json;
using System.Text;
using VueApp1.Server.Models;
using VueApp1.Server.Services.IServices;

namespace VueApp1.Server.Services
{
    public class BaseService : IBaseService
    {
        
        public ResponseDto responseModel { get ; set; }

        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto();
            this.httpClient = httpClient;
        }

        
        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("Client");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if(apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiResponse = null;

                switch(apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<T>(apiContent);

                return response;

           
            }
            catch(Exception ex)
            {
                var dto = new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string>() { Convert.ToString(ex.Message) }

                };

                var res = JsonConvert.SerializeObject(dto);
                var obj = JsonConvert.DeserializeObject<T>(res);
                return obj;
           
            
            
            }
            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}
