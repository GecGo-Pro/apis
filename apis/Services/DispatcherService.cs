using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace apis.Services
{
    public class DispatcherService : IDispatcherRepo
    {
        private readonly DatabaseContext _db;
        private readonly IWebHostEnvironment _env;

        public DispatcherService(DatabaseContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<Dispatcher> Create(Dispatcher dispatcher)
        {
            bool checkPhoneInvalid = !MyRegex.RegexPhone().IsMatch(dispatcher.phone_number);
            if (checkPhoneInvalid)
            {
                throw new HttpException(400, "Invalid phone number. Please enter a phone number that contains only digits, starts with 0, and has a length from 9 to 11 characters. Ex:0367977xxx");
            }
            bool checkEmaiInValid = dispatcher.email != null && !MyRegex.RegexEmail().IsMatch(dispatcher.email);
            if (checkEmaiInValid)
            {
                throw new HttpException(400, "Invalid Email. Please try again. Ex: xxx@xxx.xxx");
            }
            bool checkPhoneExist = await _db.dispatchers.SingleOrDefaultAsync(x => x.phone_number == dispatcher.phone_number) != null;
            if (checkPhoneExist)
            {
                throw new HttpException(409, "Phone number already exists. Please try again with a different phone number.");
            }
            try
            {
                if (dispatcher.upload_image != null)
                {
                    UploadImage ul = new UploadImage(_env);
                    string nameImage = await ul.Upload(dispatcher.upload_image, "Customer");
                    dispatcher.avatar = nameImage;
                }
                await _db.dispatchers.AddAsync(dispatcher);
                await _db.SaveChangesAsync();
                return dispatcher;
            }
            catch
            {
                throw new HttpException(500, "Create Dispatcher Fail. Please try again.");
            }

        }

        public async Task<Dispatcher> Delete(int id)
        {
            Dispatcher dispatcherExisting = await Get(id);
            try
            {
                dispatcherExisting.deleted = 1;
                await _db.SaveChangesAsync();
                return dispatcherExisting;
            }
            catch { throw new HttpException(500, "Delete Dispatcher error."); }
        }

        public async Task<IEnumerable<Dispatcher>> Get()
        {
            var dispatchers = await _db.dispatchers.Where(d => d.deleted == 0).ToListAsync();
            return dispatchers;
        }

        public async Task<Dispatcher> Get(int id)
        {
            var dispatcher = await _db.dispatchers.FindAsync(id);
            if (dispatcher == null || dispatcher.deleted != 0)
            {
                throw new HttpException(404, "No Data in Database.");
            }
            return dispatcher;
        }

        public async Task<Dispatcher> Put(int id, Dispatcher dispatcher)
        {
            bool checkPhoneInvalid = !MyRegex.RegexPhone().IsMatch(dispatcher.phone_number);
            if (checkPhoneInvalid)
            {
                throw new HttpException(400, "Invalid phone number. Please enter a phone number that contains only digits, starts with 0, and has a length from 9 to 11 characters.");
            }
            bool checkEmailInValid = dispatcher.email != null ? !MyRegex.RegexEmail().IsMatch(dispatcher.email) : false;
            if (checkEmailInValid)
            {
                throw new HttpException(400, "Invalid Email. Please try again. VD: xxx@xxx.xxx");
            }
            Dispatcher dispatcherExisting = await Get(id);
            bool checkNumberExist = await _db.dispatchers.SingleOrDefaultAsync(x => x.phone_number == dispatcher.phone_number) != null
                                              && dispatcherExisting.phone_number != dispatcher.phone_number;

            if (checkNumberExist)
            {
                throw new HttpException(409, "Phone number already exists. Please try again with a different phone number.");
            }
            try
            {
                dispatcherExisting.email = dispatcher.email != null ? dispatcher.email : dispatcherExisting.email;
                dispatcherExisting.name = dispatcher.name;

                if (dispatcher.upload_image != null && dispatcherExisting.avatar!=null)
                {
                    UploadImage ul = new UploadImage(_env);
                    ul.Delete(dispatcherExisting.avatar, "Customer");
                }

                if(dispatcher.upload_image != null)
                {
                    UploadImage ul = new UploadImage(_env);
                    string nameImage = await ul.Upload(dispatcher.upload_image, "Customer");
                    dispatcherExisting.avatar = nameImage;
                }

                dispatcherExisting.avatar = dispatcher.avatar != null ? dispatcher.avatar : dispatcherExisting.avatar;
                if (dispatcherExisting.phone_number != dispatcher.phone_number)
                {
                    dispatcherExisting.phone_number = dispatcher.phone_number;
                }

                await _db.SaveChangesAsync();
                return dispatcherExisting;
            }
            catch { throw new HttpException(500, "Update data Fail. Please try again!!"); }
        }


    }
}
