using System.Collections.Generic;
using System.Threading.Tasks;

namespace DetailsApp.Models
{
    public interface IUsers
    {
        Task<List<User>> Users();
        Task<IEnumerable<User>> Find(int? id);
    }
}
