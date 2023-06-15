<<<<<<< HEAD
﻿using HomeBrokerSimulator.Domain.Model.Entity;
using HomeBrokerSimulator.Domain.Model.Request;
using HomeBrokerSimulator.Domain.Model.Response;
using HomeBrokerSimulator.Domain.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBrokerSimulator.Service.Interface
{
    public interface IUserService
    {
        Task<UserResponse> RegisterUserAsync(UserRegisterRequest request);
        Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
        Task<byte[]> UpdateImageAsync(string idUser, IFormFile image);
        Task<User> GetUserByIdAsync(string idUser);
        Task<GenericResponse> DeleteUserByIdAsync(string idUser);
    }
}
=======
﻿using HomeBrokerSimulator.Domain.Model.Entity;
using HomeBrokerSimulator.Domain.Model.Request;
using HomeBrokerSimulator.Domain.Model.Response;
using HomeBrokerSimulator.Domain.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBrokerSimulator.Service.Interface
{
    public interface IUserService
    {
        Task<UserResponse> RegisterUserAsync(UserRegisterRequest request);
        Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
        Task<byte[]> UpdateImageAsync(string idUser, IFormFile image);
        Task<User> GetUserByIdAsync(string idUser);
        Task<GenericResponse> DeleteUserByIdAsync(string idUser);
    }
}
>>>>>>> 8c1722fb7e54a0ab0ffe4cbc56e972baaecbe9d5
