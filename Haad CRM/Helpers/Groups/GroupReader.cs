using Haad_CRM.Models.Group;
using System.Data.SqlClient;
namespace Haad_CRM.Helpers.Courses;

public class GroupReader
{
    public List<Group> GetGroupList()
    {
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        List<Group> groupList = new List<Group>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Name, CourseId, TeacherID, ResourceId, StartDate, EndDate, DaysOfWeek, StartTime, EndTime, IsDeleted, CreatedAt, UpdatedAt, DeletedAt FROM [Group]";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Group group = new Group
                {
                    Id = reader.GetInt64(0),
                    Name = reader.GetString(1),
                    CourseId = reader.GetInt32(2),
                    TeacherID = reader.GetInt32(3),
                    ResourceId = reader.GetInt32(4),
                    StartDate = DateTime.Parse(reader.GetString(5)),
                    EndDate = DateTime.Parse(reader.GetString(6)),
                    DaysOfWeek = reader.GetString(7),
                    StartTime = TimeSpan.Parse(reader.GetString(8)),
                    EndTime = TimeSpan.Parse(reader.GetString(9)),
                    // Auditable properties
                    IsDeleted = reader.GetBoolean(10),
                    CreatAt = DateTime.Parse(reader.GetString(11)),
                    UpdateAt = DateTime.Parse(reader.GetString(12)),
                    DeletedAt = DateTime.Parse(reader.GetString(13))
                };

                groupList.Add(group);
            }

            reader.Close();
        }

        return groupList;
    }

}


