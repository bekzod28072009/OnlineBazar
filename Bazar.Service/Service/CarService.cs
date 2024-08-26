using AutoMapper;
using Bazar.DataAcces.IRepository;
using Bazar.Domain.Entities.Taxi;
using Bazar.Domain.Entities.Users;
using Bazar.Service.DTOs.Cars;
using Bazar.Service.DTOs.Users;
using Bazar.Service.Exeptions;
using Bazar.Service.Helpers;
using Bazar.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.Service
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> repository;
        private readonly IMapper mapper;

        public async ValueTask<CarForViewDto> CreateAsync(CarForCreationDto entity)
        {
            if (entity.Description is null)
                throw new OnlineBazarExeption(404, "Not that the will be null");


            var newCTF = mapper.Map<Car>(entity);
            newCTF = await repository.CreateAsync(newCTF);

            await repository.SaveChangesAsync();






            return mapper.Map<CarForViewDto>(newCTF);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<Car, bool>> expression)
        {
            var isDeleted = await repository.DeleteAsync(expression);

            if (!isDeleted)
                throw new OnlineBazarExeption(404, "User not found");

            await repository.SaveChangesAsync();
            return isDeleted;
        }

        public IEnumerable<CarForViewDto> GetAll(Expression<Func<Car, bool>> expression = null, string[] includes = null)
        {
            var users = repository.GetAll(expression: expression, includes: ["Image"]);

            return mapper.Map<List<CarForViewDto>>(users);
        }


        public async ValueTask<CarForViewDto> GetAsync(Expression<Func<Car, bool>> expression, string[] includes = null)
        {
            var user = await repository.GetAsync(expression, ["Image"]);

            if (user is null)
                throw new OnlineBazarExeption(404, "User not found");

            return mapper.Map<CarForViewDto>(user);
        }

        public async ValueTask<CarForViewDto> Update(long id, CarForUpdateDto entity)
        {
            var existUser = await repository.GetAsync(
               u => u.Id == id);

            if (existUser == null)
                throw new OnlineBazarExeption(404, "User not found");


            existUser.UpdatedAt = DateTime.UtcNow;
            existUser.UpdatedBy = existUser.UpdatedBy is null ? 1 : existUser.UpdatedBy++;
            existUser = repository.Update(mapper.Map(entity, existUser));
            await repository.SaveChangesAsync();

            return mapper.Map<CarForViewDto>(existUser);
        }
    }
}
