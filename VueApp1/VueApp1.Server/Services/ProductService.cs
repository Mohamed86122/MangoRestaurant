using VueApp1.Server.Models;
using VueApp1.Server.Services.IServices;

namespace VueApp1.Server.Services
{
    public class ProductService:BaseService,IProductService
    {
    private readonly IHttpClientFactory _clientFactory;

            public ProductService(IHttpClientFactory clientFactory):base(clientFactory)
            {
                _clientFactory = clientFactory;
            }

            public async Task<T> CreateProductAsync<T>(T obj)
            {
                return await this.SendAsync<T>(new ApiRequest()
                {
                    ApiType = SD.ApiType.POST,
                    Data = obj,
                    Url = SD.ProductAPIBase
                });
            }

            public async Task<T> DeleteProductAsync<T>(int id)
            {
                return await this.SendAsync<T>(new ApiRequest()
                {
                    ApiType = SD.ApiType.DELETE,
                    Url = SD.ProductAPIBase + id
                });
            }

            public async Task<T> GetAllProductsAsync<T>()
            {
                return await this.SendAsync<T>(new ApiRequest()
                {
                    ApiType = SD.ApiType.GET,
                    Url = SD.ProductAPIBase
                });
            }

            public async Task<T> GetProductByIdAsync<T>(int id)
            {
                return await this.SendAsync<T>(new ApiRequest()
                {
                    ApiType = SD.ApiType.GET,
                    Url = SD.ProductAPIBase + id
                });
            }

            public async Task<T> UpdateProductAsync<T>(T obj)
            {
                return await this.SendAsync<T>(new ApiRequest()
                {
                    ApiType = SD.ApiType.PUT,
                    Data = obj,
                    Url = SD.ProductAPIBase
                });
            }
        }
}
