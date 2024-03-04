using Haad_CRM.Models.Course;
using System.Data.SqlClient;


public class CourseReader
{
    public List<Course> GetCourseList()
    {
        List<Course> courseList = new List<Course>();
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Name, Description, Duration, StartDate, Price, EndDate, MaxEnrollment, IsDeleted, CreatedAt, UpdatedAt, DeletedAt FROM Course";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Course course = new Course
                {
                    Id = reader.GetInt64(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Duration = reader.GetInt32(3),
                    StartDate = reader.GetDateTime(4),
                    Price = reader.GetInt32(5),
                    EndDate = reader.GetDateTime(6),
                    MaxEnrollment = reader.GetInt32(7),
                    // Auditable properties
                    IsDeleted = reader.GetBoolean(8),
                    CreatAt = reader.GetDateTime(9),
                    UpdateAt = reader.GetDateTime(10),
                    DeletedAt = reader.GetDateTime(11)
                };

                courseList.Add(course);
            }

            reader.Close();
        }

        return courseList;
    }

}


