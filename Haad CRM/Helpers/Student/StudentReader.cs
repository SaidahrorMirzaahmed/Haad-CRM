using Haad_CRM.Models.Student;
using System.Data.SqlClient;

namespace Haad_CRM.Helpers;

public class StudentReader
{
    public List<Student> GetStudentList()
    {
        List<Student> studentList = new List<Student>();
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, FirstName, LastName, DateOfBirth, ParentPhoneNumber, Email, CoinId, CourseId, Phone, Address, IsDeleted, CreatedAt, UpdatedAt, DeletedAt FROM Student";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Student student = new Student
                {
                    Id = reader.GetInt64(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    DateOfBirth = DateTime.Parse(reader.GetString(3)),
                    ParentPhoneNumber = reader.GetString(4),
                    Email = reader.GetString(5),
                    CoinId = reader.GetInt32(6),
                    CourseId = reader.GetInt32(7),
                    Phone = reader.GetString(8),
                    Address = reader.GetString(9),
                    // Auditable properties
                    IsDeleted = reader.GetBoolean(10),
                    CreatAt = DateTime.Parse(reader.GetString(11)),
                    UpdateAt = DateTime.Parse(reader.GetString(12)),
                    DeletedAt = DateTime.Parse(reader.GetString(13))
                };

                studentList.Add(student);
            }

            reader.Close();
        }

        return studentList;
    }

}


