using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace apis.Services
{
    public class DriverService : IDriverRepo
    {

        private readonly DatabaseContext _db;
        private readonly IWebHostEnvironment _env;

        public DriverService(DatabaseContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<Driver> Create(Driver driver)
        {
            bool checkPhoneInvalid = !MyRegex.RegexPhone().IsMatch(driver.phone_number);
            if (checkPhoneInvalid)
            {
                throw new HttpException(400, "Invalid phone number. Please enter a phone number that contains only digits, starts with 0, and has a length from 9 to 11 characters. Ex:0367977xxx");
            }
            bool checkPhoneExist = await _db.drivers.SingleOrDefaultAsync(x => x.phone_number == driver.phone_number) != null;
            if (checkPhoneExist)
            {
                throw new HttpException(409, "Phone number already exists. Please try again with a different phone number.");
            }
            try
            {
                if (driver.upload_image != null)
                {
                    UploadImage ul = new UploadImage(_env);
                    string nameImage = await ul.Upload(driver.upload_image, "Driver");
                    driver.avatar = nameImage;
                }
                await _db.drivers.AddAsync(driver);
                await _db.SaveChangesAsync();
                return driver;
            }
            catch
            {
                throw new HttpException(500, "Create Driver Fail. Please try again.");
            }

        }

        public async Task<Driver> Delete(int id)
        {
            Driver driverExisting = await Get(id);
            try
            {
                driverExisting.deleted = 1;
                await _db.SaveChangesAsync();
                return driverExisting;
            }
            catch { throw new HttpException(500, "Delete Driver error."); }
        }

        public async Task<IEnumerable<Driver>> Get()
        {
            var getDriver = await _db.drivers.Where(d => d.deleted == 0).ToListAsync();
            if (getDriver.Count() == 0)
            {
                throw new HttpException(404, "Not found data available, please add data.");
            }
            return getDriver;
        }

        public async Task<Driver> Get(int id)
        {
            var getDriver = await _db.drivers.FindAsync(id);
            if (getDriver == null || getDriver.deleted != 0)
            {
                throw new HttpException(404, "No Data in Database.");
            }
            return getDriver;
        }

        public async Task<Driver> Put(int id, Driver driver)
        {
            bool checkPhoneInvalid = !MyRegex.RegexPhone().IsMatch(driver.phone_number);
            if (checkPhoneInvalid)
            {
                throw new HttpException(400, "Invalid phone number. Please enter a phone number that contains only digits, starts with 0, and has a length from 9 to 11 characters.");
            }

            Driver driverExisting = await Get(id);
            bool checkNumberExist = await _db.drivers.SingleOrDefaultAsync(x => x.phone_number == driver.phone_number) != null
                                                && driverExisting.phone_number != driver.phone_number;
            if (checkNumberExist)
            {
                throw new HttpException(409, "Phone number already exists. Please try again with a different phone number.");
            }
            try
            {
                driverExisting.name = driver.name;

                if (driver.upload_image != null && driverExisting.avatar != null)
                {
                    UploadImage ul = new UploadImage(_env);
                    ul.Delete(driverExisting.avatar, "Driver");
                }
                if (driver.upload_image != null)
                {
                    UploadImage ul = new UploadImage(_env);
                    string nameImage = await ul.Upload(driver.upload_image, "Driver");
                    driverExisting.avatar = nameImage;
                }

                if (driverExisting.phone_number != driver.phone_number)
                {
                    driverExisting.phone_number = driver.phone_number;
                }
                await _db.SaveChangesAsync();
                return driverExisting;
            }
            catch { throw new HttpException(500, "Update data Fail. Please try again!!"); }
        }


    }
}
