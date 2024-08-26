using AutoMapper;
using Bazar.DataAcces.IRepository;
using Bazar.Domain.Entities.Others;
using Bazar.Domain.Entities.Users;
using Bazar.Service.DTOs.Addresses;
using Bazar.Service.Exeptions;
using Bazar.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.Service
{
    public class AddressService : IAddressService
    {
        private readonly IGenericRepository<Address> repository;
        private readonly IGenericRepository<User> userRepository;
        
        private readonly IMapper mapper;

        public AddressService(IGenericRepository<Address> repository,
            IGenericRepository<User> userRepository, IMapper mapper)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async ValueTask<AddressForCreationDto> CreateAsync(AddressForCreationDto entity)
        {
            if (entity.Country is null || entity.Region is null || entity.District is null || entity.AddressLine is null)
                throw new OnlineBazarExeption(404, "Not that the will be null");


            var newAddress = mapper.Map<Address>(entity);
            newAddress = await repository.CreateAsync(newAddress);


            var user = await userRepository.GetAsync(user => user.Id == entity.UserId);
            if (user is null)
                throw new OnlineBazarExeption(404, "Not that the will be null");
            user.Address = newAddress;
            userRepository.Update(user);

            await repository.SaveChangesAsync();
            userRepository.SaveChangesAsync();

            return mapper.Map<AddressForCreationDto>(newAddress);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Address, bool>> expression)
        {
            bool isDeleted = await repository.DeleteAsync(expression);

            if (!isDeleted)
                throw new OnlineBazarExeption(404, "Address not found");

            await repository.SaveChangesAsync();
            return isDeleted;
        }

        public IEnumerable<AddressForCreationDto> GetAll(Expression<Func<Address, bool>> expression = null, string[] includes = null)
        {
            var address = repository.GetAll(expression: expression, includes: includes);

            return mapper.Map<List<AddressForCreationDto>>(address);
        }


        public async ValueTask<AddressForCreationDto> GetAsync(Expression<Func<Address, bool>> expression, string[] includes = null)
        {
            var address = await repository.GetAsync(expression);

            if (address is null)
                throw new OnlineBazarExeption(404, "Address not found");

            return mapper.Map<AddressForCreationDto>(address);
        }

        public async ValueTask<AddressForCreationDto> Update(long id, AddressForCreationDto entity)
        {
            var oldAddress = await repository.GetAsync(p => p.Id == id);

            if (oldAddress is null)
                throw new OnlineBazarExeption(404, "Address not found");


            oldAddress.UpdatedAt = DateTime.UtcNow;
            oldAddress.UpdatedBy = oldAddress.UpdatedBy is null ? 1 : oldAddress.UpdatedBy++;
            oldAddress = repository.Update(mapper.Map(entity, oldAddress));
            await repository.SaveChangesAsync();

            await repository.SaveChangesAsync();

            return mapper.Map<AddressForCreationDto>(oldAddress);
        }
    }
}
