using Haad_CRM.Models.Group;
using System.Data.SqlClient;



public class GroupWriter
{
    public void UpdateGroupList(List<Group> newGroupList)
    {
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Step 1: Delete all records from the Group table
            string deleteQuery = "DELETE FROM [Group]";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.ExecuteNonQuery();

            // Step 2: Insert new records from the newGroupList
            foreach (Group group in newGroupList)
            {
                string insertQuery = "INSERT INTO [Group] (Name, CourseId, TeacherID, ResourceId, StartDate, EndDate, DaysOfWeek, StartTime, EndTime, IsDeleted, CreatedAt, UpdatedAt, DeletedAt) " +
                                     "VALUES (@Name, @CourseId, @TeacherID, @ResourceId, @StartDate, @EndDate, @DaysOfWeek, @StartTime, @EndTime, @IsDeleted, @CreatedAt, @UpdatedAt, @DeletedAt)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@Name", group.Name);
                insertCommand.Parameters.AddWithValue("@CourseId", group.CourseId);
                insertCommand.Parameters.AddWithValue("@TeacherID", group.TeacherID);
                insertCommand.Parameters.AddWithValue("@ResourceId", group.ResourceId);
                insertCommand.Parameters.AddWithValue("@StartDate", group.StartDate.ToString());
                insertCommand.Parameters.AddWithValue("@EndDate", group.EndDate.ToString());
                insertCommand.Parameters.AddWithValue("@DaysOfWeek", group.DaysOfWeek);
                insertCommand.Parameters.AddWithValue("@StartTime", group.StartTime.ToString("hh\\:mm\\:ss"));
                insertCommand.Parameters.AddWithValue("@EndTime", group.EndTime.ToString("hh\\:mm\\:ss"));
                // Auditable properties
                insertCommand.Parameters.AddWithValue("@IsDeleted", group.IsDeleted);
                insertCommand.Parameters.AddWithValue("@CreatedAt", group.CreatAt.ToString());
                insertCommand.Parameters.AddWithValue("@UpdatedAt", group.UpdateAt.ToString());
                insertCommand.Parameters.AddWithValue("@DeletedAt", group.DeletedAd.ToString());

                insertCommand.ExecuteNonQuery();
            }
        }
    }

}


