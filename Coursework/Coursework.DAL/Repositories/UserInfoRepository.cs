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
                        string? name = null;
                        if (!reader.IsDBNull(2))
                            name = reader.GetString(2);
                        string? lastname = null;
                        if (!reader.IsDBNull(3))
                            lastname = reader.GetString(3);
                        string? surname = null;
                        if (!reader.IsDBNull(4))
                            surname = reader.GetString(4);
                        string? passportData = null;
                        if (!reader.IsDBNull(5))
                            passportData = reader.GetString(5);
                        string? country = null;
                        if (!reader.IsDBNull(6))
                            country = reader.GetString(6);
                        string? city = null;
                        if (!reader.IsDBNull(7))
                            city = reader.GetString(7);
                        string? street = null;
                        if (!reader.IsDBNull(8))
                            street = reader.GetString(8);
                        string? homeNumber = null;
                        if (!reader.IsDBNull(9))
                            homeNumber = reader.GetString(9);
                        string? flatNumber = null;
                        if (!reader.IsDBNull(10))
                            flatNumber = reader.GetString(10);
                        string? sex = null;
                        if (!reader.IsDBNull(11))
                            sex = reader.GetString(11);
                        int? experience = null;
                        if (!reader.IsDBNull(12))
                            experience = reader.GetInt32(12);
                        double? salary = null;
                        if (!reader.IsDBNull(13))
                            salary = reader.GetDouble(13);
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
        string sqlExpression = 
            "INSERT INTO UserInfo (Age, Name, Lastname, Surname, PassportData, Country, City, Street, HomeNumber, " +
            "FlatNumber, Sex, Experience, Salary) " +
            "VALUES (@Age, @Name, @Lastname, @Surname, @PassportData, @Country, @City, @Street, @HomeNumber, " +
            "@FlatNumber, @Sex, @Experience, @Salary)";
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

    public void Update(UserInfo old, UserInfo @new)
    {
        string sqlExpression = 
            $"UPDATE UserInfo SET Age=@newAge, Name=@newName, Lastname=@newLastname, Surname=@newSurname, " +
            $"PassportData=@newPassportData, Country=@newCountry, City=@newCity, Street=@newStreet, " +
            $"HomeNumber=@newHomeNumber, FlatNumber=@newFlatNumber, Sex=@newSex, Experience=@newExperience, " +
            $"Salary=@newSalary " +
            $"WHERE Age=@oldAge and Name=@oldName and Lastname=@oldLastname and Surname=@oldSurname " +
            $"and PassportData=@oldPassportData and Country=@oldCountry and City=@oldCity and Street=@oldStreet" +
            $"and HomeNumber=@oldHomeNumber and FlatNumber=@oldFlatNumber and Sex=@oldSex and Experience=@oldExperience" +
            $"and Salary=@oldSalary";
        
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            List<SQLiteParameter> parameters = GetOldNewParameters(old, @new);
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            command.ExecuteNonQuery();
        }
    }

    public void Delete(int id)
    {
        string sqlExpression = $"DELETE FROM UserInfo WHERE Id={id}";
 
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();
 
            SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
        }
    }

    private List<SQLiteParameter> GetItemParameters(UserInfo item)
    {
        List<SQLiteParameter> parameters = new List<SQLiteParameter>
        {
            new SQLiteParameter("@Id", item.Id),
            new SQLiteParameter("@Age", item.Age),
            new SQLiteParameter("@Name", item.Name),
            new SQLiteParameter("@Lastname", item.Lastname),
            new SQLiteParameter("@Surname", item.Surname),
            new SQLiteParameter("@PassportData", item.PassportData),
            new SQLiteParameter("@Country", item.Country),
            new SQLiteParameter("@City", item.City),
            new SQLiteParameter("@Street", item.Street),
            new SQLiteParameter("@HomeNumber", item.HomeNumber),
            new SQLiteParameter("@FlatNumber", item.FlatNumber),
            new SQLiteParameter("@Sex", item.Sex),
            new SQLiteParameter("@Experience", item.Experience),
            new SQLiteParameter("@Salary", item.Salary)
        };
        return parameters;
    }
    private List<SQLiteParameter> GetOldNewParameters(UserInfo old, UserInfo @new)
    {
        List<SQLiteParameter> parameters = new List<SQLiteParameter>
        {
            new SQLiteParameter("@oldId", old.Id),
            new SQLiteParameter("@oldAge", old.Age),
            new SQLiteParameter("@oldName", old.Name),
            new SQLiteParameter("@oldLastname", old.Lastname),
            new SQLiteParameter("@oldSurname", old.Surname),
            new SQLiteParameter("@oldPassportData", old.PassportData),
            new SQLiteParameter("@oldCountry", old.Country),
            new SQLiteParameter("@oldCity", old.City),
            new SQLiteParameter("@oldStreet", old.Street),
            new SQLiteParameter("@oldHomeNumber", old.HomeNumber),
            new SQLiteParameter("@oldFlatNumber", old.FlatNumber),
            new SQLiteParameter("@oldSex", old.Sex),
            new SQLiteParameter("@oldExperience", old.Experience),
            new SQLiteParameter("@oldSalary", old.Salary),
            new SQLiteParameter("@newId", @new.Id),
            new SQLiteParameter("@newAge", @new.Age),
            new SQLiteParameter("@newName", @new.Name),
            new SQLiteParameter("@newLastname", @new.Lastname),
            new SQLiteParameter("@newSurname", @new.Surname),
            new SQLiteParameter("@newPassportData", @new.PassportData),
            new SQLiteParameter("@newCountry", @new.Country),
            new SQLiteParameter("@newCity", @new.City),
            new SQLiteParameter("@newStreet", @new.Street),
            new SQLiteParameter("@newHomeNumber", @new.HomeNumber),
            new SQLiteParameter("@newFlatNumber", @new.FlatNumber),
            new SQLiteParameter("@newSex", @new.Sex),
            new SQLiteParameter("@newExperience", @new.Experience),
            new SQLiteParameter("@newSalary", @new.Salary)
        };
        return parameters;
    }
}