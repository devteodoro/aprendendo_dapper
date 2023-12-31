using Blog.Models;
using Blog.Repositories;
using Microsoft.Identity.Client;

namespace Blog.Screens.TagScreens
{
    public static class UpdateTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma tag");
            Console.WriteLine("-----------------");

            Console.WriteLine("Id: ");
            var id = Console.ReadLine();
            Console.WriteLine("Nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            update(new Tag
            {
                Id = int.Parse(id),
                Name = nome,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}