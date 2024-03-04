using Haad_CRM.Models.Lesson;
using System.Data.SqlClient;

namespace Haad_CRM.Helpers.Lessons;

public class LessonReader
{
    public List<Lesson> GetLessonList()
    {
        List<Lesson> lessonList = new List<Lesson>();
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Name, GroupId, LFromDate, LToDate, IsDeleted, CreatedAt, UpdatedAt, DeletedAt FROM Lesson";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Lesson lesson = new Lesson
                {
                    Id = reader.GetInt64(0),
                    Name = reader.GetString(1),
                    GroupId = reader.GetInt32(2),
                    LFromDate = DateTime.Parse(reader.GetString(3)),
                    LToDate = DateTime.Parse(reader.GetString(4)),
                    // Auditable properties
                    IsDeleted = reader.GetBoolean(5),
                    CreatAt = DateTime.Parse(reader.GetString(6)),
                    UpdateAt = DateTime.Parse(reader.GetString(7)),
                    DeletedAt = DateTime.Parse(reader.GetString(8))
                };

                lessonList.Add(lesson);
            }

            reader.Close();
        }

        return lessonList;
    }

}


