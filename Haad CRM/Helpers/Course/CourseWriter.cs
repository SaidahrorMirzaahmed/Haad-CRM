using Haad_CRM.Models.Course;
using System.Data.SqlClient;


public class CourseWriter
{
    public void UpdateCourseList(List<Course> newCourseList)
    {
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Step 1: Delete all records from the Course table
            string deleteQuery = "DELETE FROM Course";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.ExecuteNonQuery();

            // Step 2: Insert new records from the newCourseList
            foreach (Course course in newCourseList)
            {
                string insertQuery = "INSERT INTO Course (Name, Description, Duration, StartDate, Price, EndDate, MaxEnrollment, IsDeleted, CreatedAt, UpdatedAt, DeletedAt) " +
                                     "VALUES (@Name, @Description, @Duration, @StartDate, @Price, @EndDate, @MaxEnrollment, @IsDeleted, @CreatedAt, @UpdatedAt, @DeletedAt)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@Name", course.Name);
                insertCommand.Parameters.AddWithValue("@Description", course.Description);
                insertCommand.Parameters.AddWithValue("@Duration", course.Duration);
                insertCommand.Parameters.AddWithValue("@StartDate", course.StartDate);
                insertCommand.Parameters.AddWithValue("@Price", course.Price);
                insertCommand.Parameters.AddWithValue("@EndDate", course.EndDate);
                insertCommand.Parameters.AddWithValue("@MaxEnrollment", course.MaxEnrollment);
                // Auditable properties
                insertCommand.Parameters.AddWithValue("@IsDeleted", course.IsDeleted);
                insertCommand.Parameters.AddWithValue("@CreatedAt", course.CreatAt.ToString());
                insertCommand.Parameters.AddWithValue("@UpdatedAt", course.UpdateAt.ToString());
                insertCommand.Parameters.AddWithValue("@DeletedAt", course.DeletedAd.ToString());

                insertCommand.ExecuteNonQuery();
            }
        }
    }

}


