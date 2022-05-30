using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Coursework.DAL.Interfaces;
using Coursework.Domain;

namespace Coursework.DAL.Repositories;

public class ChamberRepository : IRepository<Chamber>
{
    private readonly string _connectionString;

    public ChamberRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Chamber> GetCollection()
    {
        List<Chamber> collection = new List<Chamber>();
        string sqlExpression = "SELECT * FROM Chamber";
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
                        int chamberNumber = reader.GetInt32(1);
                        int hospitalNumber = reader.GetInt32(2);
                        string department = reader.GetString(3);
                        int  isFree = reader.GetInt32(4);
                        bool isFreeBool = isFree == 1;
                        collection.Add(new Chamber
                            { Id = id, ChamberNumber = chamberNumber, HospitalNumber = hospitalNumber, Department = department, IsFree = isFreeBool});
                    }
                }
            }
        }

        return collection;
    }

    public Chamber? GetItem(int id)
    {
        return GetCollection().FirstOrDefault(item => item.Id == id);
    }

    public void Create(Chamber item)
    {
        string sqlExpression = "INSERT INTO Chamber (ChamberNumber, HospitalNumber, Department, IsFree) VALUES (@ChamberNumber, @HospitalNumber, @Department, @IsFree)";
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            SQLiteParameter chamberNumberParameter = new SQLiteParameter("@ChamberNumber", item.ChamberNumber);
            SQLiteParameter hospitalNumberParameter = new SQLiteParameter("@HospitalNumber", item.HospitalNumber);
            SQLiteParameter departmentParameter = new SQLiteParameter("@Department", item.Department);
            int isFree = 1;
            if (!item.IsFree)
                isFree = 0;
            SQLiteParameter isFreeParameter = new SQLiteParameter("@IsFree", isFree);
            command.Parameters.Add(chamberNumberParameter);
            command.Parameters.Add(hospitalNumberParameter);
            command.Parameters.Add(departmentParameter);
            command.Parameters.Add(isFreeParameter);
            command.ExecuteNonQuery();
        }
    }

    public void Update(Chamber old, Chamber @new)
    {
        int isFreeNew = 0, isFreeOld = 0;
        if (@new.IsFree)
            isFreeNew = 1;
        if (old.IsFree)
            isFreeOld = 1;
        string sqlExpression = 
            $"UPDATE Contract SET ChamberNumber={@new.ChamberNumber}, HospitalNumber={@new.HospitalNumber}, Department='{@new.Department}', IsFree={isFreeNew} WHERE ChamberNumber={old.ChamberNumber} and HospitalNumber={old.HospitalNumber} and Department='{old.Department}' and IsFree={isFreeOld}";

        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string sqlExpression = $"DELETE FROM Chamber WHERE Id={id}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }
}