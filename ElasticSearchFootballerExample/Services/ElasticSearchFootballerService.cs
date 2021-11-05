using ElasticSearchFootballerExample.Models;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchFootballerExample.Services
{
    public class ElasticSearchFootballerService : IFootballerService
    {
        private List<Footballer> _cache = new List<Footballer>();

        private readonly IElasticClient _elasticClient;
        private readonly ILogger _logger;

        public ElasticSearchFootballerService(IElasticClient elasticClient, ILogger<ElasticSearchFootballerService> logger)
        {
            _elasticClient = elasticClient;
            _logger = logger;
        }

        public async Task SaveSingleAsync(Footballer footballler)
        {
            if (_cache.Any(p => p.Id == footballler.Id))
            {
                await _elasticClient.UpdateAsync<Footballer>(footballler, u => u.Doc(footballler));
            }
            else
            {
                _cache.Add(footballler);
                await _elasticClient.IndexDocumentAsync<Footballer>(footballler);
            }
        }

        public async Task SaveManyAsync(Footballer[] footballers)
        {
            _cache.AddRange(footballers);
            var result = await _elasticClient.IndexManyAsync(footballers);
            if (result.Errors)
            {
                // the response can be inspected for errors
                foreach (var itemWithError in result.ItemsWithErrors)
                {
                    _logger.LogError("Failed to index document {0}: {1}",
                        itemWithError.Id, itemWithError.Error);
                }
            }
        }

        public async Task SaveBulkAsync(Footballer[] footballers)
        {
            _cache.AddRange(footballers);
            var result = await _elasticClient.BulkAsync(b => b.Index("products").IndexMany(footballers));
            if (result.Errors)
            {
                // the response can be inspected for errors
                foreach (var itemWithError in result.ItemsWithErrors)
                {
                    _logger.LogError("Failed to index document {0}: {1}",
                        itemWithError.Id, itemWithError.Error);
                }
            }
        }

        public async Task DeleteAsync(Footballer footballer)
        {
            await _elasticClient.DeleteAsync<Footballer>(footballer);

            if (_cache.Contains(footballer))
            {
                _cache.Remove(footballer);
            }
        }

        public virtual Task<Footballer> GetProductById(Guid id)
        {
            var product = _cache              
              .FirstOrDefault(p => p.Id == id);

            return Task.FromResult(product);
        }
    }
}
