﻿using Bazar.Domain.Entities.Users;
using Bazar.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public AddressDto Address { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<Order> Orders { get; set; }

        public int BankCardId { get; set; }

        public Gender Gender { get; set; }

        public UserRole UserRole { get; set; } = UserRole.User;

        public UserDto()
        {
            Orders = new List<Order>();
        }


    }
}
