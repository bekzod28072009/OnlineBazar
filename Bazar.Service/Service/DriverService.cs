using AutoMapper;
using Bazar.DataAcces.IRepository;
using Bazar.Domain.Entities.Collectors;
using Bazar.Domain.Entities.Taxi;
using Bazar.Service.DTOs.Collectors;
using Bazar.Service.DTOs.Drivers;
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
    public class DriverService : IDriverService
    {
        private readonly IGenericRepository<Driver> repository;
        private readonly IMapper mapper;

        public DriverService(IGenericRepository<Driver> repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async ValueTask<DriverForViewDto> CreateAsync(DriverForCreationDto entity)
        {
            if (entity.Email is null)
                throw new OnlineBazarExeption(404, "Not that the will be null");


            var newCTF = mapper.Map<Driver>(entity);
            newCTF = await repository.CreateAsync(newCTF);

            await repository.SaveChangesAsync();






            return mapper.Map<DriverForViewDto>(newCTF);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Driver, bool>> expression)
        {
            var isDeleted = await repository.DeleteAsync(expression);

            if (!isDeleted)
                throw new OnlineBazarExeption(404, "User not found");

            await repository.SaveChangesAsync();
            return isDeleted;
        }

        public IEnumerable<DriverForViewDto> GetAll(Expression<Func<Driver, bool>> expression = null, string[] includes = null)
        {
            var users = repository.GetAll(expression: expression, includes: ["Image"]);

            return mapper.Map<List<DriverForViewDto>>(users);
        }


        public async ValueTask<DriverForViewDto> GetAsync(Expression<Func<Driver, bool>> expression, string[] includes = null)
        {
            var user = await repository.GetAsync(expression, ["Image"]);

            if (user is null)
                throw new OnlineBazarExeption(404, "User not found");

            return mapper.Map<DriverForViewDto>(user);
        }

        public async ValueTask<DriverForViewDto> Update(long id, DriverForUpdateDto entity)
        {
            var existUser = await repository.GetAsync(
               u => u.Id == id);

            if (existUser == null)
                throw new OnlineBazarExeption(404, "User not found");


            existUser.UpdatedAt = DateTime.UtcNow;
            existUser.UpdatedBy = existUser.UpdatedBy is null ? 1 : existUser.UpdatedBy++;
            existUser = repository.Update(mapper.Map(entity, existUser));
            await repository.SaveChangesAsync();

            return mapper.Map<DriverForViewDto>(existUser);
        }
    }
}
