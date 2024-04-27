using apis.Models;

namespace apis.IRepository
{
    public interface ICustomerRepo
    {
        Task<CustomerDTO> OptionsAsDesired(string phone_number,OptionsAsDesiredByPhone optionsAsDesiredByPhone);
    }
}
