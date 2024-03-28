using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.AppServices.Users.Repositories;
using SolarLab.Academy.Contracts.Users;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.User.Repository;

/// <inheritdoc />
public class UserRepository : IUserRepository
{
    private readonly IMapper _mapper;
    private readonly IRepository<Domain.Users.Entity.User> _repository;

    public UserRepository(IRepository<Domain.Users.Entity.User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<ResultWithPagination<UserDto>> GetAll(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var result = new ResultWithPagination<UserDto>();
        
        var query = _repository.GetAll();

        var elementsCount = await query.CountAsync(cancellationToken);
        result.AvailablePages = elementsCount / request.Batchsize;

        var paginationQuery = await query
            .OrderBy(user => user.Id)
            .Skip(request.Batchsize * (request.PageNumber - 1))
            .Take(request.Batchsize)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);

        result.Result = paginationQuery;

        return result;
    }

    public async Task<IEnumerable<UserDto>> GetAllBySpecification(Specification<Domain.Users.Entity.User> specification, CancellationToken cancellationToken)
    {
        return await _repository.GetAll()
            .Where(specification.ToExpression())
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
    }

    public Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.GetAll().Where(s => s.Id == id)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(Domain.Users.Entity.User entity, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(UserDto model, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(model.Id);
        await _repository.UpdateAsync(user, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(id, cancellationToken);
    }
}