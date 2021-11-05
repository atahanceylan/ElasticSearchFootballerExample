using ElasticSearchFootballerExample.Models;
using System;
using System.Threading.Tasks;

namespace ElasticSearchFootballerExample.Services
{
    public interface IFootballerService
    {
        Task<Footballer> GetProductById(Guid id);

        Task DeleteAsync(Footballer footballer);
        Task SaveSingleAsync(Footballer footballer);
        Task SaveManyAsync(Footballer[] footballer);
        Task SaveBulkAsync(Footballer[] footballer);

    }
}
