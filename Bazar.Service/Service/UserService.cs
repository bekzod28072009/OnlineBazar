using AutoMapper;
using Bazar.DataAcces.IRepository;
using Bazar.Domain.Entities.Users;
using Bazar.Service.DTOs.Users;
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

            createdUser.Password = createdUser.Password.

            await repository.SaveChangesAsync();

            return mapper.Map<UserForViewDto>(createdUser);
        }

        public ValueTask<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserForViewDto> GetAll(Expression<Func<User, bool>> expression = null, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<UserForViewDto> GetAsync(Expression<Func<User, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<UserForViewDto> Update(long id, UserForUpdateDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
