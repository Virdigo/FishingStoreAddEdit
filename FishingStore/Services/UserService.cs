using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FishingStore.Services
{
    public class UserService
    {
        public Users Authenticate(string username, string password)
        {
            using (var context = new FishingStoreDBEntities())
            {
                return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }
        }
    }
}