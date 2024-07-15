using Mango.Services.ProductAPI.Models.DTO;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductApiController : Controller
    {

        private IProductRepository _productRepository;
        private ResponseDto _responseDTO;

        public ProductApiController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _responseDTO = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var products = await _productRepository.GetProducts();
                _responseDTO.Result = products;
            }
            catch (Exception e)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _responseDTO;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetById(ProductDto id) 
        {   
            try
            {
                var productId = Convert.ToInt32(id);
                var product = await _productRepository.GetProductById(productId);
                _responseDTO.Result = product;
            }
            catch (Exception e)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _responseDTO;
           
        }

        [HttpPost]
        public async Task<object> Post(ProductDto productDto)
        {
            try
            {
                var product = await _productRepository.CreateUpdateProduct(productDto);
                _responseDTO.Result = product;
            }
            catch (Exception e)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _responseDTO;
        }

        [HttpPut]
        public async Task<object> Put(ProductDto productDto)
        {
            try
            {
                var product = await _productRepository.CreateUpdateProduct(productDto);
                _responseDTO.Result = product;
            }
            catch (Exception e)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _responseDTO;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var status = await _productRepository.DeleteProduct(id);
                _responseDTO.Result = status;
            }
            catch (Exception e)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _responseDTO;
        }
    }
}
