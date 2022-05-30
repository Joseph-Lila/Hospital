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

    public void Update(Role old, Role @new)
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