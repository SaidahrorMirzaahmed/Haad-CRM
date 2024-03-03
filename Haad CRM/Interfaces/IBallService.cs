using Haad_CRM.Models.Ball;
using Haad_CRM.Models.Student;

namespace Haad_CRM.Interfaces;

public interface IBallService
{
    Task<BallViewModel> CreateAsync(BallCreation ball);

    Task<bool> DeleteAsync(long id);

    Task<BallViewModel> GetByIdAsync(long id);

    Task<BallViewModel> UpdateAsync(BallUpdate ball, long id);

    Task<List<BallViewModel>> GetAllAsync();
}
