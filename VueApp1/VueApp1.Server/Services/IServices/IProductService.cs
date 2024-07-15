namespace VueApp1.Server.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(T obj);
        Task<T> UpdateProductAsync<T>(T obj);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
