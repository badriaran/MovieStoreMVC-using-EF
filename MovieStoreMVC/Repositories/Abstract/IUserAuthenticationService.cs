﻿using MovieStoreMVC.Models.DTO;

namespace MovieStoreMVC.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(RegistrationModel model);

    }
}
