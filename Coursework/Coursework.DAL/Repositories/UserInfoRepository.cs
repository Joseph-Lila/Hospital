using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.Domain;

namespace Coursework.DAL.Repositories;

public class UserInfoRepository : IRepository<UserInfo>
{
    private readonly string _connectionString;

    public UserInfoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<UserInfo> GetCollection()
    {
        List<UserInfo> collection = new List<UserInfo>();
        string sqlExpression = "SELECT * FROM UserInfo";
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
                        int age = reader.GetInt32(1);
                        string? name = reader.GetString(2);
                        string? lastname = reader.GetString(3);
                        string? surname = reader.GetString(4);
                        string? passportData = reader.GetString(5);
                        string? country = reader.GetString(6);
                        string? city = reader.GetString(7);
                        string? street = reader.GetString(8);
                        string? homeNumber = reader.GetString(9);
                        string? flatNumber = reader.GetString(10);
                        string? sex = reader.GetString(11);
                        int? experience = reader.GetInt32(12);
                        double? salary = reader.GetDouble(13);
                        collection.Add(new UserInfo
                        {
                            Id = id, Age = age, Name = name, Lastname = lastname,
                            Surname = surname, PassportData = passportData, Country = country,
                            City = city, Street = street, HomeNumber = homeNumber,
                            FlatNumber = flatNumber, Sex = sex, Experience = experience, Salary = salary
                        });
                    }
                }
            }
        }

        return collection;
    }

    public UserInfo? GetItem(int id)
    {
        return GetCollection().FirstOrDefault(item => item.Id == id);
    }

    public void Create(UserInfo item)
    {
        string sqlExpression = "INSERT INTO Contract (TenantId, PlaceId, TotalCost, Start, Finish, Debt) VALUES (@tenantId, @placeId, @totalCost, @start, @finish, @debt)";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            SQLiteParameter tenantIdParam = new SQLiteParameter("@tenantId", item.TenantId);
            SQLiteParameter placeIdParam = new SQLiteParameter("@placeId", item.PlaceId);
            SQLiteParameter totalCostParam = new SQLiteParameter("@totalCost", item.TotalCost);
            string start = item.Start.ToString("yyyy-MM-dd HH:mm:ss");
            SQLiteParameter startParam = new SQLiteParameter("@start", start);
            string finish = item.Finish.ToString("yyyy-MM-dd HH:mm:ss");
            SQLiteParameter finishParam = new SQLiteParameter("@finish", finish);
            SQLiteParameter debtParam = new SQLiteParameter("@debt", item.Debt);
            command.Parameters.Add(tenantIdParam);
            command.Parameters.Add(placeIdParam);
            command.Parameters.Add(totalCostParam);
            command.Parameters.Add(startParam);
            command.Parameters.Add(finishParam);
            command.Parameters.Add(debtParam);
            command.ExecuteNonQuery();
        }
    }

    public void Update(UserInfo old, UserInfo @new)
    {
        string startOld = old.Start.ToString("yyyy-MM-dd HH:mm:ss");
        string finishOld = old.Finish.ToString("yyyy-MM-dd HH:mm:ss");
        string startNew = @new.Start.ToString("yyyy-MM-dd HH:mm:ss");
        string finishNew = @new.Finish.ToString("yyyy-MM-dd HH:mm:ss");
        string sqlExpression = 
            $"UPDATE Contract SET TenantId={@new.TenantId}, PlaceId={@new.PlaceId}, TotalCost={@new.TotalCost.ToString().Replace(',', '.')}, Start='{startNew}', Finish='{finishNew}', Debt={@new.Debt.ToString().Replace(',', '.')} WHERE TenantId={old.TenantId} and PlaceId={old.PlaceId} and TotalCost={old.TotalCost.ToString().Replace(',', '.')} and Start='{startOld}' and Finish='{finishOld}' and Debt={old.Debt.ToString().Replace(',', '.')}";

        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string sqlExpression = $"DELETE FROM Contract WHERE Id={id}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }
}