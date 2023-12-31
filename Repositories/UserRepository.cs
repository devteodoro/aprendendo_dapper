using System.Reflection.Metadata;
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)
            => _connection = connection;


        public List<User> GetWithRoles()
        {
            var query = @"select 
                                [User].*, 
                                [Role].* 
                            from 
                                [User] 
                                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[id]
                                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[id]";

            var users = new List<User>();
            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                    {
                        if (role != null)
                            usr.Roles.Add(role);
                    }

                    return user;
                },
                splitOn: "Id");

            return users;
        }
    }
}