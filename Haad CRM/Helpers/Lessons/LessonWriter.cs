using Haad_CRM.Models.Lesson;
using System.Data.SqlClient;

namespace Haad_CRM.Helpers.Lessons;

public class LessonWriter
{
    public void UpdateLessonList(List<Lesson> newLessonList)
    {
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Step 1: Delete all records from the Lesson table
            string deleteQuery = "DELETE FROM Lesson";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.ExecuteNonQuery();

            // Step 2: Insert new records from the newLessonList
            foreach (Lesson lesson in newLessonList)
            {
                string insertQuery = "INSERT INTO Lesson (Name, GroupId, LFromDate, LToDate, IsDeleted, CreatedAt, UpdatedAt, DeletedAt) " +
                                     "VALUES (@Name, @GroupId, @LFromDate, @LToDate, @IsDeleted, @CreatedAt, @UpdatedAt, @DeletedAt)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@Name", lesson.Name);
                insertCommand.Parameters.AddWithValue("@GroupId", lesson.GroupId);
                insertCommand.Parameters.AddWithValue("@LFromDate", lesson.LFromDate);
                insertCommand.Parameters.AddWithValue("@LToDate", lesson.LToDate);
                // Auditable properties
                insertCommand.Parameters.AddWithValue("@IsDeleted", lesson.IsDeleted);
                insertCommand.Parameters.AddWithValue("@CreatedAt", lesson.CreatAt.ToString());
                insertCommand.Parameters.AddWithValue("@UpdatedAt", lesson.UpdateAt.ToString());
                insertCommand.Parameters.AddWithValue("@DeletedAt", lesson.DeletedAd.ToString());

                insertCommand.ExecuteNonQuery();
            }
        }
    }

}


