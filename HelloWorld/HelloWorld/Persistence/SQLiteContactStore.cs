using HelloWorld.Models;
using HelloWorld.ViewModels;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.Persistence
{
    public class SQLiteContactStore : IContactStore
    {
        private SQLiteAsyncConnection _connection;
        public SQLiteContactStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Contact>();
        }
        public async Task AddContactAsync(Contact contact)
        {
            await _connection.InsertAsync(contact);
        }

        public async Task DeleteContactAsync(Contact contact)
        {
            await _connection.DeleteAsync(contact);
        }

        public async Task<IEnumerable<Contact>> LoadContactsAsync()
        {
            return await _connection.Table<Contact>().ToListAsync();            
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            await _connection.UpdateAsync(contact);
        }
    }
}
