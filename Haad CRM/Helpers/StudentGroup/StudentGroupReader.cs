using Haad_CRM.Models.StudentGroup;
using System.Data.SqlClient;

namespace Haad_CRM.Helpers;

public class StudentGroupReader
{
    public List<StudentGroup> GetStudentGroupList()
    {
        List<StudentGroup> studentGroupList = new List<StudentGroup>();
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, StudentId, GroupId FROM StudentGroup";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                StudentGroup studentGroup = new StudentGroup
                {
                    Id = reader.GetInt32(0),
                    StudentId = reader.GetInt32(1),
                    GroupId = reader.GetInt32(2)
                };

                studentGroupList.Add(studentGroup);
            }

            reader.Close();
        }

        return studentGroupList;
    }

}


