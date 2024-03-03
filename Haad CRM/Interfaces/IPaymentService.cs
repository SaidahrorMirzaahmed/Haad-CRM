using Haad_CRM.Models.New;
using Haad_CRM.Models.Payment;

namespace Haad_CRM.Interfaces;

public interface IPaymentService
{
    Task<PaymentViewModel> CreateAsync(PaymentCreation payment);

    Task<bool> DeleteAsync(long id);

    Task<PaymentViewModel> GetByIdAsync(long id);

    Task<PaymentViewModel> UpdateAsync(PaymentUpdate payment, long id);

    Task<List<PaymentViewModel>> GetAllAsync();
}
