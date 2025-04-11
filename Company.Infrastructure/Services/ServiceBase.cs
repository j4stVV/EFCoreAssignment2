
using AutoMapper;
using Company.Application.Abstractions.Services;
using Company.Application.DTOs.DepartmentDTO;
using Company.Domain.Repositories;

namespace Company.Infrastructure.Services;

public class ServiceBase<TEntity, TResponseDTO, TRequestDTO> : IServiceBase
    <TEntity, TResponseDTO, TRequestDTO> where TEntity : class
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public ServiceBase(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TResponseDTO>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TResponseDTO>>(entities);
    }

    public async Task<TResponseDTO> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TResponseDTO>(entity);
    }

    public virtual async Task<TResponseDTO> CreateAsync(TRequestDTO entityRequest)
    {
        var entity = _mapper.Map<TEntity>(entityRequest);
        var idProperty = typeof(TEntity).GetProperty("Id");

        if (idProperty != null && idProperty.CanWrite)
        {
            var idValue = Guid.NewGuid();
            idProperty.SetValue(entity, idValue);
        }
        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return _mapper.Map<TResponseDTO>(entity);
    }

    public virtual async Task UpdateAsync(Guid id, TRequestDTO entityRequest)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"{typeof(TEntity).Name} with ID {id} not found.");
        }

        _mapper.Map(entityRequest, entity);
        _repository.Update(entity);
        await _repository.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"{typeof(TEntity).Name} with ID {id} not found.");
        }

        await _repository.DeleteAsync(entity);
        await _repository.SaveChangesAsync();
    }
}
