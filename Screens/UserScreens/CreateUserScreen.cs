using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova Usuário");
            Console.WriteLine("-----------------");

            Console.WriteLine("Nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine("Senha: ");
            var senha = Console.ReadLine();
            Console.WriteLine("Email: ");
            var email = Console.ReadLine();
            Console.WriteLine("Bio: ");
            var bio = Console.ReadLine();
            Console.WriteLine("Url imagem: ");
            var imagem = Console.ReadLine();
            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            Create(new User
            {
                Name = nome,
                Email = email,
                PasswordHash = senha,
                Bio = bio,
                Image = imagem,
                Slug = slug
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}