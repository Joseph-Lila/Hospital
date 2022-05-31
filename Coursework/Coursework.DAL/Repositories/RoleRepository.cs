using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.Domain;

namespace Coursework.DAL.Repositories;

public class RoleRepository : IRepository<Role>
{
    private readonly string _connectionString;

    public RoleRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Role> GetCollection()
    {
        List<Role> collection = new List<Role>();
        string sqlExpression = "SELECT * FROM Role";
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
                        string title = reader.GetString(1);
                        string duties = reader.GetString(2);
                        string requirements = reader.GetString(3);
                        string description = reader.GetString(4);
                        collection.Add(new Role
                            { Id = id, Title = title, Duties = duties, Requirements = requirements,
                                Description = description});
                    }
                }
            }
        }

        return collection;
    }

    public Role? GetItem(int id)
    {
        return GetCollection().FirstOrDefault(item => item.Id == id);
    }

    public void Create(Role item)
    {
        string sqlExpression = "INSERT INTO Role (Title, Duties, Requirements, Description) VALUES (@Title, @Duties, @Requirements, @Description)";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            SQLiteParameter titleParameter = new SQLiteParameter("@Title", item.Title);
            SQLiteParameter dutiesParameter = new SQLiteParameter("@Duties", item.Duties);
            SQLiteParameter requirementSqLiteParameter = new SQLiteParameter("@Requirements", item.Requirements);
            SQLiteParameter descriptionParameter = new SQLiteParameter("@Description", item.Description);
            command.Parameters.Add(titleParameter);
            command.Parameters.Add(dutiesParameter);
            command.Parameters.Add(requirementSqLiteParameter);
            command.Parameters.Add(descriptionParameter);
            command.ExecuteNonQuery();
        }
    }

    public void Update(Role old, Role @new)
    {
        string sqlExpression = 
            $"UPDATE Role SET Title='{@new.Title}', Duties='{@new.Duties}', Requirements='{@new.Requirements}', Description='{@new.Description}' WHERE Title='{old.Title}' and Duties='{old.Duties}' and Requirements='{old.Requirements}' and Description='{old.Description}'";

        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string sqlExpression = $"DELETE FROM Role WHERE Id={id}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }
}