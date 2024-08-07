using AutoMapper;
using Bazar.DataAcces.IRepository;
using Bazar.Domain.Entities.Users;
using Bazar.Service.DTOs.Users;
using Bazar.Service.Exeptions;
using Bazar.Service.Extensions;
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
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> repository;
        private readonly IMapper mapper;

        public UserService(IGenericRepository<User> repository,
            IMapper mapper)
        {
            this.repository = repository;   
            this.mapper = mapper;
        }
        public async ValueTask<UserForViewDto> CreateAsync(UseerForCreateDto entity)
        {
            if (entity.Password != entity.ConfirmPassword)
                throw new OnlineBazarExeption(404, "Passwords are different");

            var existEmail = await repository.GetAsync(u => u.Email == entity.Email);


            if (existEmail != null)
                throw new OnlineBazarExeption(400, "This email is already taken");

            var createdUser = await repository.CreateAsync(mapper.Map<User>(entity));

            createdUser.Password = createdUser.Password.Ecrypt();

            await repository.SaveChangesAsync();

            return mapper.Map<UserForViewDto>(createdUser);
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var isDeleted = await repository.DeleteAsync(expression);

            if (!isDeleted)
                throw new OnlineBazarExeption(404, "User not found");

            await repository.SaveChangesAsync();
            return isDeleted;
        }

        public IEnumerable<UserForViewDto> GetAll(Expression<Func<User, bool>> expression = null, string[] includes = null)
        {
            var users = repository.GetAll(expression: expression, includes: ["Image"]);

            return mapper.Map<List<UserForViewDto>>(users);
        }

        public async ValueTask<UserForViewDto> GetAsync(Expression<Func<User, bool>> expression, string[] includes = null)
        {
            var user = await repository.GetAsync(expression, ["Image"]);

            if (user is null)
                throw new OnlineBazarExeption(404, "User not found");

            return mapper.Map<UserForViewDto>(user);
        }

        public async ValueTask<UserForViewDto> Update(long id, UserForUpdateDto entity)
        {
            var existUser = await repository.GetAsync(
               u => u.Id == id);

            if (existUser == null)
                throw new OnlineBazarExeption(404, "User not found");

            var alreadyExistUser = await repository.GetAsync(
                u => u.Email == entity.Email && u.Id != HttpContextHelper.UserId);

            if (alreadyExistUser != null)
                throw new OnlineBazarExeption(400, "User with such email already exists");


            existUser.UpdatedAt = DateTime.UtcNow;
            existUser.UpdatedBy = existUser.UpdatedBy is null ? 1 : existUser.UpdatedBy++;
            existUser = repository.Update(mapper.Map(entity, existUser));
            await repository.SaveChangesAsync();

            return mapper.Map<UserForViewDto>(existUser);
        }
    }
}
