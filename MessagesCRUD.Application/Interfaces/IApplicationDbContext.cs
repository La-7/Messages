using MessagesCRUD.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MessagesCRUD.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Message> Messages { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancelletionToken);
    }
}
