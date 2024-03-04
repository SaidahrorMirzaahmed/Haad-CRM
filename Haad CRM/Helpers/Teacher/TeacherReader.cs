using Haad_CRM.Models.Teacher;
using System.Data.SqlClient;


public class TeacherReader
{
    public List<Teacher> GetTeacherList()
    {
        List<Teacher> teacherList = new List<Teacher>();
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT ID, FirstName, LastName, Phone, Email, IsDeleted, CreatedAt, UpdatedAt, DeletedAt FROM Teacher";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Teacher teacher = new Teacher
                {
                    Id = reader.GetInt64(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Phone = reader.GetString(3),
                    Email = reader.GetString(4),
                    // Auditable properties
                    IsDeleted = reader.GetBoolean(5),
                    CreatAt = DateTime.Parse(reader.GetString(6)),
                    UpdateAt = DateTime.Parse(reader.GetString(7)),
                    DeletedAt = DateTime.Parse(reader.GetString(8))
                };

                teacherList.Add(teacher);
            }

            reader.Close();
        }

        return teacherList;
    }

}

