using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.Domain;

namespace Coursework.DAL.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<User> GetCollection()
    {
        List<User> collection = new List<User>();
        string sqlExpression = "SELECT * FROM User";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        int userInfoId = reader.GetInt32(1);
                        int roleId = reader.GetInt32(2);
                        string login = reader.GetString(3);
                        string password = reader.GetString(4);
                        collection.Add(new User
                        {
                            Id = id, UserInfoId = userInfoId, RoleId = roleId,
                            Login = login, Password = password
                        });
                    }
                }
            }
        }

        return collection;
    }

    public User? GetItem(int id)
    {
        return GetCollection().FirstOrDefault(item => item.Id == id);
    }

    public void Create(User item)
    {
        string sqlExpression = 
            "INSERT INTO User (UserInfoId, RoleId, Login, Password) VALUES (@UserInfoId, @RoleId, @Login, @Password)";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            List<SQLiteParameter> parameters = GetItemParameters(item);
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            command.ExecuteNonQuery();
        }
    }

    public void Update(User old, User @new)
    {
        string sqlExpression = 
            $"UPDATE User SET UserInfoId=@newUserInfoId, RoleId=@newRoleId, Login=@newLogin, Password=@newPassword " +
            $"WHERE UserInfoId=@oldUserInfoId and RoleId=@oldRoleId and Login=@oldLogin and Password=@oldPassword";

        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            List<SQLiteParameter> parameters = GetOldNewParameters(old, @new);
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            int number = command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string sqlExpression = $"DELETE FROM User WHERE Id={id}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }
    
    private List<SQLiteParameter> GetItemParameters(User item)
    {
        List<SQLiteParameter> parameters = new List<SQLiteParameter>
        {
            new SQLiteParameter("@Id", item.Id),
            new SQLiteParameter("@UserInfoId", item.UserInfoId),
            new SQLiteParameter("@RoleId", item.RoleId),
            new SQLiteParameter("@Login", item.Login),
            new SQLiteParameter("@Password", item.Password)
        };
        return parameters;
    }
    private List<SQLiteParameter> GetOldNewParameters(User old, User @new)
    {
        List<SQLiteParameter> parameters = new List<SQLiteParameter>
        {
            new SQLiteParameter("@oldId", old.Id),
            new SQLiteParameter("@oldUserInfoId", old.UserInfoId),
            new SQLiteParameter("@oldRoleId", old.RoleId),
            new SQLiteParameter("@oldLogin", old.Login),
            new SQLiteParameter("@oldPassword", old.Password),
            new SQLiteParameter("@newId", @new.Id),
            new SQLiteParameter("@newUserInfoId", @new.UserInfoId),
            new SQLiteParameter("@newRoleId", @new.RoleId),
            new SQLiteParameter("@newLogin", @new.Login),
            new SQLiteParameter("@newPassword", @new.Password)
        };
        return parameters;
    }
}