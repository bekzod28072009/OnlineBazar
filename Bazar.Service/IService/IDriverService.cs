using Bazar.Domain.Entities.Collectors;
using Bazar.Domain.Entities.Taxi;
using Bazar.Service.DTOs.Collectors;
using Bazar.Service.DTOs.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.IService
{
    public interface IDriverService
    {
        IEnumerable<DriverForViewDto> GetAll(Expression<Func<Driver, bool>> expression = null, string[] includes = null);
        ValueTask<DriverForViewDto> GetAsync(Expression<Func<Driver, bool>> expression, string[] includes = null);
        ValueTask<DriverForViewDto> CreateAsync(DriverForCreationDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<Driver, bool>> expression);
        ValueTask<DriverForViewDto> Update(long id, DriverForUpdateDto entity);
    }
}
