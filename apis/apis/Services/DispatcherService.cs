using apis.IRepository;
using apis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Drawing.Printing;

namespace apis.Services
{
    public class DispatcherService : IDispatcherRepo
    {
        private readonly DatabaseContext _db;

        public DispatcherService(DatabaseContext db)
        {
            _db = db;
        }



        public async Task<Dispatcher> Create(Dispatcher dispatcher)
        {
            if (await _db.dispatchers.SingleOrDefaultAsync(x => x.phone_number == dispatcher.phone_number) == null)
            {
                try
                {
                    var createdEntity = await _db.dispatchers.AddAsync(dispatcher);
                    await _db.SaveChangesAsync();
                    return dispatcher;
                }
                catch { throw new HttpException(500, "Create Dispatcher Fail."); }
            }
            else { throw new HttpException(409, "Phone number already exists."); }
        }

        public async Task<Dispatcher> Delete(int id)
        {
            Dispatcher dispatcherExisting = await Get(id);
                using (IDbContextTransaction transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        _db.dispatchers.Remove(dispatcherExisting);
                        await _db.SaveChangesAsync();
                        transaction.Commit();
                        return dispatcherExisting;
                    }
                    catch 
                    {
                        transaction.Rollback();
                        throw new HttpException(500, "Delete Dispatcher error.");
                    }
                }
        }

        public async Task<IEnumerable<Dispatcher>> Get()
        {
            var data =await _db.dispatchers.ToListAsync();
            if (data.Count() > 0)
            {
                return data;
            }
            else { throw new HttpException(404, "No data available, please add data."); }
        }

        public async Task<Dispatcher> Get(int id)
        {
            var data = await _db.dispatchers.FindAsync(id);
            if (data !=null)
            {
                return data;
            }
            else { throw new HttpException(404, "No Data in Database."); }
        }

        public async Task<Dispatcher> Put(int id, Dispatcher dispatcher)
        {
            try
            {
                Dispatcher dispatcherExisting = await Get(id);
                dispatcherExisting.email = dispatcher.email;
                dispatcherExisting.name = dispatcher.name;
                dispatcherExisting.avatar = dispatcher.avatar;
                dispatcherExisting.phone_number = dispatcher.phone_number;
                await _db.SaveChangesAsync();

                return dispatcher;
            }
            catch { throw new HttpException(500, "Update data Fail. Please try again!!"); }
        }


    }
}
