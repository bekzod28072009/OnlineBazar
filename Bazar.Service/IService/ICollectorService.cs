using Bazar.Domain.Entities.Collectors;
using Bazar.Domain.Entities.Users;
using Bazar.Service.DTOs.Collectors;
using Bazar.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.IService
{
    public interface ICollectorService
    {
        IEnumerable<CollectorForViewDto> GetAll(Expression<Func<Collector, bool>> expression = null, string[] includes = null);
        ValueTask<CollectorForViewDto> GetAsync(Expression<Func<Collector, bool>> expression, string[] includes = null);
        ValueTask<CollectorForViewDto> CreateAsync(CollectorForCreationDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<User, bool>> expression);
        ValueTask<CollectorForViewDto> Update(long id, CollectorForUpdateDto entity);
    }
}
