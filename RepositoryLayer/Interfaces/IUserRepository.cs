﻿using CommonLayer.RequestModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRepository
    {
        public user UserRegistration(RegisterModel model);
        public string Userlogin(login model);

        public string ForgetPassword(string email);

        public string GenerateToken(string email, int id);

        public bool UserResetPassword(string email, ResetPasswordModel model);
        // public user UserResetPassword(string email, ResetPasswordModel model);
        //review
        public user UserRegister(RegisterModel model);
    }
}
