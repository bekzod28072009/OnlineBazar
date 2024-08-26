using Bazar.Domain.Entities.Others;
using Bazar.Service.DTOs.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.IService
{
    public interface IAddressService
    {
        IEnumerable<AddressForCreationDto> GetAll(Expression<Func<Address, bool>> expression = null, string[] includes = null);
        ValueTask<AddressForCreationDto> GetAsync(Expression<Func<Address, bool>> expression, string[] includes = null);
        ValueTask<AddressForCreationDto> CreateAsync(AddressForCreationDto entity);
        ValueTask<bool> DeleteAsync(Expression<Func<Address, bool>> expression);
        ValueTask<AddressForCreationDto> Update(long id, AddressForCreationDto entity);
    }
}
