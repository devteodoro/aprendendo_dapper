using Blog.Models;
using Blog.Repositories;
using Microsoft.IdentityModel.Protocols;

namespace Blog.Screens.UserScreens
{
    public static class ListUserScreens
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de usuários");
            Console.WriteLine("-----------------");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }
        private static void List()
        {
            var repository = new Repository<User>(Database.Connection);
            var tags = repository.Get();
            foreach (var item in tags)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}