using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace apis.Services
{
    public class DispatchJobService : IDispatchJobRepo
    {
        private readonly DatabaseContext _db;
        private readonly IWebHostEnvironment _env;

        public DispatchJobService(DatabaseContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<DispatchJob> Create(DispatchJobDTO dispatchJobDTO)
        {

            DispatchJob dispatchJob = DataInput(dispatchJobDTO);
            // bool checkPhoneInvalid = !MyRegex.RegexPhone().IsMatch(dispatchJob.phone_number);
            // if (checkPhoneInvalid)
            // {
            //     throw new HttpException(400, "Invalid phone number. Please enter a phone number that contains only digits, starts with 0, and has a length from 9 to 11 characters. Ex:0367977xxx");
            // }
            await _db.dispatch_jobs.AddAsync(dispatchJob);
            await _db.SaveChangesAsync();
            return dispatchJob;

        }

        public async Task<DispatchJob> Delete(int id)
        {
            DispatchJob dispatchJobExisting = await Get(id);
            try
            {
                _db.Remove(dispatchJobExisting);
                await _db.SaveChangesAsync();
                return dispatchJobExisting;
            }
            catch { throw new HttpException(500, "Delete Dispatcher error."); }
        }

        public async Task<IEnumerable<DispatchJob>> Get()
        {
            var dispatchJobs = await _db.dispatch_jobs.ToListAsync();
            return dispatchJobs;
        }

        public async Task<DispatchJob> Get(int id)
        {
            var dispatchJob = await _db.dispatch_jobs.FindAsync(id);
            if (dispatchJob == null)
            {
                throw new HttpException(404, "No Data in Database.");
            }
            return dispatchJob;
        }

        public async Task<DispatchJob> Put(int id, DispatchJobDTO dispatchJobDTO)
        {
            DispatchJob getDispatchJob = await Get(id);

            getDispatchJob.start_longitude = dispatchJobDTO.start_longitude;
            getDispatchJob.start_latitude = dispatchJobDTO.start_latitude;
            getDispatchJob.end_longitude = dispatchJobDTO.end_longitude;
            getDispatchJob.end_latitude = dispatchJobDTO.end_latitude;
            getDispatchJob.start_address = dispatchJobDTO.start_address;
            getDispatchJob.end_address = dispatchJobDTO.end_address;
            if (dispatchJobDTO.start_date != null)
            {
                getDispatchJob.start_date = dispatchJobDTO.start_date;
            }
            if (dispatchJobDTO.end_date != null)
            {
                getDispatchJob.end_date = dispatchJobDTO.end_date;
            }
            if (dispatchJobDTO.note != null)
            {
                getDispatchJob.note = dispatchJobDTO.note;
            }
            if (dispatchJobDTO.cancell_reason != null)
            {
                getDispatchJob.cancell_reason = dispatchJobDTO.cancell_reason;
            }
            if (dispatchJobDTO.customer_id != 0)
            {
                getDispatchJob.customer_id = dispatchJobDTO.customer_id;
            }
            if (dispatchJobDTO.dispatcher_id != 0)
            {
                getDispatchJob.dispatcher_id = dispatchJobDTO.dispatcher_id;
            }
            if (dispatchJobDTO.driver_id != 0)
            {
                getDispatchJob.driver_id = dispatchJobDTO.driver_id;
            }
            if (dispatchJobDTO.car_id != 0)
            {
                getDispatchJob.car_id = dispatchJobDTO.car_id;
            }
            await _db.SaveChangesAsync();
            return getDispatchJob;
        }

        public DispatchJob DataInput(DispatchJobDTO dispatchJobDTO)
        {
            return new DispatchJob
            {
                start_longitude = dispatchJobDTO.start_longitude,
                start_latitude = dispatchJobDTO.start_latitude,
                end_longitude = dispatchJobDTO.end_longitude,
                end_latitude = dispatchJobDTO.end_latitude,
                start_address = dispatchJobDTO.start_address,
                end_address = dispatchJobDTO.end_address,
                start_date = dispatchJobDTO.start_date,
                end_date = dispatchJobDTO.end_date,
                note = dispatchJobDTO.note,
                cancell_reason = dispatchJobDTO.cancell_reason,
                customer_id = dispatchJobDTO.customer_id,
                dispatcher_id = dispatchJobDTO.dispatcher_id,
                driver_id = dispatchJobDTO.driver_id,
                car_id = dispatchJobDTO.car_id,
            };
        }

    }
}
