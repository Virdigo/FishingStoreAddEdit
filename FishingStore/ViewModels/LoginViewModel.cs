using FishingStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingStore.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        public UserService _userService;
        public string Username { get; set; }
        public string Password { get; set; }
        public Users AuthenticatedUser { get; private set; }

        public LoginViewModel()
        {
            _userService = new UserService();
        }

        public bool Authenticate()
        {
            AuthenticatedUser = _userService.Authenticate(Username, Password);
            return AuthenticatedUser != null;
        }
    }
}
