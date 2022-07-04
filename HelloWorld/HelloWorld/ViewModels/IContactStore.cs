using HelloWorld.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorld.ViewModels
{
    public interface IContactStore
    {
        Task UpdateContactAsync(Contact contact);

        Task AddContactAsync(Contact contact);

        Task DeleteContactAsync(Contact contact);

        Task<IEnumerable<Contact>> LoadContactsAsync();
    }
}
