using Microsoft.EntityFrameworkCore;

using Homies.Data;
using Homies.DataTransferObjects.Type;
using Homies.Services.Core.Contracts;

namespace Homies.Services.Core.Services;

public class TypeService : ITypeService
{
    private readonly HomiesDbContext _dbContext;

    public TypeService(HomiesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TypeViewModel>> GetTypesAsync()
    {
        IEnumerable<TypeViewModel> typeDropdownEntries = await _dbContext.Types
            .OrderBy(t => t.Name)
            .Select(t => new TypeViewModel
            {
                Id = t.Id,
                Name = t.Name,
            })
            .ToArrayAsync();

        return typeDropdownEntries;
    }
}
