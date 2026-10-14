using GastroAPI.Domain.Entities;

namespace GastroAPI.Application.Interfaces
{
    public interface IOrderedProductsRepository
    {
        Task<OrderedProducts> AddProductAsync(OrderedProducts orderedproduct);
    }
}
