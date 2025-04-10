namespace Company.Application.Abstractions.Services;

public interface IServiceBase<TEntity,TResponseDTO,TRequestDTO> where TEntity : class
{
    Task<IEnumerable<TResponseDTO>> GetAllAsync();
    Task<TResponseDTO> GetByIdAsync(Guid id);
    Task<TResponseDTO> CreateAsync(TRequestDTO entityRequest);
    Task UpdateAsync(Guid id, TRequestDTO entityRequest);
    Task DeleteAsync(Guid id);
}
