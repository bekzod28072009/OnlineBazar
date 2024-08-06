using Bazar.Domain.Entities.Users;
using Bazar.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.IService
{
    public interface IUserService
    {
        IEnumerable<UserForViewDto> GetAll(Expression<Func<User, bool>> expression = null, string[] includes = null);
        ValueTask<UserForViewDto> GetAsync(Expression<Func<User, bool>> expression, string[] includes = null);
        ValueTask<UserForViewDto> CreateAsync(UseerForCreateDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<User, bool>> expression);
        ValueTask<UserForViewDto> Update(long id, UserForUpdateDto entity);
    }
}
