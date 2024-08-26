using Bazar.Domain.Entities.Taxi;
using Bazar.Domain.Entities.Users;
using Bazar.Service.DTOs.Cars;
using Bazar.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.IService
{
    public interface ICarService
    {
        IEnumerable<CarForViewDto> GetAll(Expression<Func<Car, bool>> expression = null, string[] includes = null);
        ValueTask<CarForViewDto> GetAsync(Expression<Func<Car, bool>> expression, string[] includes = null);
        ValueTask<CarForViewDto> CreateAsync(CarForCreationDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<Car, bool>> expression);
        ValueTask<CarForViewDto> Update(long id, CarForUpdateDto entity);
    }
}
