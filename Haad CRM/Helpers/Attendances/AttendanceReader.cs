using Haad_CRM.Models.Attendances;
using System.Data.SqlClient;

public class AttendanceReader
{
    public List<Attendance> GetAttendanceList()
    {
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        List<Attendance> attendanceList = new List<Attendance>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, StudentId, GroupId, AttendanceDate, Status, IsDeleted, CreatedAt, UpdatedAt, DeletedAt FROM Attendance";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Attendance attendance = new Attendance
                {
                    Id = reader.GetInt64(0),
                    StudentId = reader.GetInt32(1),
                    GroupId = reader.GetInt32(2),
                    AttendanceDate = reader.GetDateTime(3),
                    Status = reader.GetString(4),
                    // Auditable properties
                    IsDeleted = reader.GetBoolean(5),
                    CreatAt = DateTime.Parse(reader.GetString(6)),
                    UpdateAt = DateTime.Parse(reader.GetString(7)),
                    DeletedAt = DateTime.Parse(reader.GetString(8))
                };

                attendanceList.Add(attendance);
            }

            reader.Close();
        }

        return attendanceList;
    }

}


