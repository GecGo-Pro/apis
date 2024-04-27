using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;

namespace apis.Services
{
    public class CustomerService : ICustomerRepo
    {
        private readonly DatabaseContext _db;

        public CustomerService(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<CustomerDTO> OptionsAsDesired(string phone_number, OptionsAsDesiredByPhone optionsAsDesiredByPhone)
        {

            bool checkPhoneInvalid = !MyRegex.RegexPhone().IsMatch(phone_number);
            if (checkPhoneInvalid)
            {
                throw new HttpException(400, Variable.PhoneInValid);
            }
            Customer? customer = _db.customers.Include(x => x.dispatch_jobs).Where(x => x.phone_number == phone_number).Select(d => new Customer
            {
                id = d.id,
                phone_number = d.phone_number,
                name = d.name,
                avatar = d.avatar,
                longitude = d.longitude,
                latitude = d.latitude,
                otp = d.otp,
                otp_life = d.otp_life,
                created_at = d.created_at,
                dispatch_jobs = d.dispatch_jobs
            }).SingleOrDefault();

            bool phoneNotExist = customer == null;
            if (phoneNotExist)
            {
                throw new HttpException(409, Variable.NoData);
            }
           
            bool checkInputPage = optionsAsDesiredByPhone?.page > 0 && optionsAsDesiredByPhone.limit>0;
            if (checkInputPage&&customer?.dispatch_jobs?.Count() >0)
            {
                customer.dispatch_jobs =(customer.dispatch_jobs?.Skip((int)((optionsAsDesiredByPhone.page - 1) * optionsAsDesiredByPhone.limit)).Take((int)optionsAsDesiredByPhone.limit)).ToList();
            }
            bool checkInputSort = !string.IsNullOrEmpty(optionsAsDesiredByPhone.sort_by) || customer != null;
            if (checkInputSort && customer?.dispatch_jobs?.Count() > 0)
            {
                switch (optionsAsDesiredByPhone.sort_by)
                {
                    case "lowest_id":
                        customer.dispatch_jobs = customer.dispatch_jobs.OrderBy(d => d.id).ToList();
                        break;
                    case "highest_id":
                        customer.dispatch_jobs = customer.dispatch_jobs.OrderByDescending(d => d.id).ToList();
                        break;
                }
            }
            return new CustomerDTO(){ 
            id = customer.id,
            phone_number = customer.phone_number,
            name = customer.name,
            avatar=customer.avatar,
            longitude= customer.longitude,
            latitude= customer.latitude,
            created_at=customer.created_at,
            dispatch_jobs=customer.dispatch_jobs,
            page= optionsAsDesiredByPhone.page,
            limit=optionsAsDesiredByPhone.limit,
            sort=optionsAsDesiredByPhone.sort_by
            };
        }


    }
}
