﻿namespace HomeBrokerSimulator.Domain.Model.Request.User
{
    public class UserRegisterRequest
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
