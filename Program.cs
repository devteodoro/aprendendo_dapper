using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Microsoft.Data.SqlClient;

namespace Blog
{
    public static class Program
    {
        private const string CONNECTION_STRING = @"Data Source=DESKTOP-NBS1IAP\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True;TrustServerCertificate=True";
        public static void Main(string[] args)
        {
            try
            {
                Database.Connection = new SqlConnection(CONNECTION_STRING);
                Database.Connection.Open();
                Load();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro inexperado!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Database.Connection.Close();
            }
        }

        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("------------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuários");
            //Console.WriteLine("2 - Gestão de perfil");
            //Console.WriteLine("3 - Gestão de categoria");
            Console.WriteLine("4 - Gestão de tag");
            //Console.WriteLine("5 - Vincular perfil/usuário");
            //Console.WriteLine("6 - Vincular post/tag");
            //Console.WriteLine("7 - Relatórios");
            Console.WriteLine("0 - Encerrar");
            Console.WriteLine();
            Console.WriteLine();

            var option = int.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 0:
                    encerrar();
                    break;
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
                default: Load(); break;
            }
        }

        public static void encerrar()
        {
            Database.Connection.Close();
            Console.WriteLine("Obrigado por usuar o sistema!");
            Console.ReadKey();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}



