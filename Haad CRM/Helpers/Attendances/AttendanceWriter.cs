using Haad_CRM.Models.Attendances;
using System.Data.SqlClient;


public class AttendanceWriter
{
    public void UpdateAttendanceList(List<Attendance> newAttendanceList)
    {
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Step 1: Delete all records from the Attendance table
            string deleteQuery = "DELETE FROM Attendance";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.ExecuteNonQuery();

            // Step 2: Insert new records from the newAttendanceList
            foreach (Attendance attendance in newAttendanceList)
            {
                string insertQuery = "INSERT INTO Attendance (StudentId, GroupId, AttendanceDate, Status, IsDeleted, CreatedAt, UpdatedAt, DeletedAt) " +
                                     "VALUES (@StudentId, @GroupId, @AttendanceDate, @Status, @IsDeleted, @CreatedAt, @UpdatedAt, @DeletedAt)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@StudentId", attendance.StudentId);
                insertCommand.Parameters.AddWithValue("@GroupId", attendance.GroupId);
                insertCommand.Parameters.AddWithValue("@AttendanceDate", attendance.AttendanceDate);
                insertCommand.Parameters.AddWithValue("@Status", attendance.Status);
                // Auditable properties
                insertCommand.Parameters.AddWithValue("@IsDeleted", attendance.IsDeleted);
                insertCommand.Parameters.AddWithValue("@CreatedAt", attendance.CreatAt.ToString());
                insertCommand.Parameters.AddWithValue("@UpdatedAt", attendance.UpdateAt.ToString());
                insertCommand.Parameters.AddWithValue("@DeletedAt", attendance.DeletedAd.ToString());

                insertCommand.ExecuteNonQuery();
            }
        }
    }

}


