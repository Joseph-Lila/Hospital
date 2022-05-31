using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.Domain;

namespace Coursework.DAL.Repositories;

public class IllnessRepository : IRepository<Illness>
{
    private readonly string _connectionString;

    public IllnessRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Illness> GetCollection()
    {
        List<Illness> collection = new List<Illness>();
        string sqlExpression = "SELECT * FROM Illness";
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
                        string treatment = reader.GetString(2);
                        string description = reader.GetString(3);
                        collection.Add(new Illness
                        { Id = id, Title = title, Treatment = treatment, Description = description});
                    }
                }
            }
        }

        return collection;
    }

    public Illness? GetItem(int id)
    {
        return GetCollection().FirstOrDefault(item => item.Id == id);
    }

    public void Create(Illness item)
    {
        string sqlExpression = "INSERT INTO Illness (Title, Treatment, Description) VALUES (@Title, @Treatment, @Description)";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            SQLiteParameter titleParameter = new SQLiteParameter("@Title", item.Title);
            SQLiteParameter treatmentParameter = new SQLiteParameter("@Treatment", item.Treatment);
            SQLiteParameter descriptionParameter = new SQLiteParameter("@Description", item.Description);
            command.Parameters.Add(titleParameter);
            command.Parameters.Add(treatmentParameter);
            command.Parameters.Add(descriptionParameter);
            command.ExecuteNonQuery();
        }
    }

    public void Update(Illness old, Illness @new)
    {
        string sqlExpression = 
            $"UPDATE Illness SET Title='{@new.Title}', Treatment='{@new.Treatment}', Description='{@new.Description}' WHERE Title='{old.Title}' and Treatment='{old.Treatment}' and Description='{old.Description}'";

        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string sqlExpression = $"DELETE FROM Illness WHERE Id={id}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }
}