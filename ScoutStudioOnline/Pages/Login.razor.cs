﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using ScoutStudioOnline.Core.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutStudioOnline.Pages
{
    public class LoginModel : ComponentBase
    {
        public LoginViewModel LoginData { get; set; }

        //[Inject] public ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected bool Loading;
        protected string Error;

        public LoginModel()
        {
            LoginData = new LoginViewModel();
        }

        protected async Task LoginAsync()
        {
            try
            {
                Loading = true;
                bool isSuccessAuth = await AuthenticationService.Login(LoginData.UserName, LoginData.Password);
                if (isSuccessAuth)
                {
                    NavigationManager.NavigateTo(uri: "/", forceLoad: true);
                }
                else
                {
                    Error = "not valid login or password";
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;               
                StateHasChanged();
            }
            finally
            {
                Loading = false;
            }
            //return await Task.CompletedTask;
        }
    }

    public class LoginViewModel
    { 
        [Required]
        [StringLength(50, ErrorMessage = "Too Long")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
