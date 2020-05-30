using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace receivePixel.Services
{
    public class StorageService<T> : IStorageService<T>
    {
        private readonly IMongoCollection<T> _mongoCollection;

        public StorageService(
            IStorageConfig storageConfig
        )
        {
            var dbClient = new MongoClient(storageConfig.ConnectionString());
            var database = dbClient.GetDatabase(storageConfig.DatabaseName());

            _mongoCollection = database.GetCollection<T>(typeof(T).FullName);
        }

        /// <summary>
        /// Return top N ordered records
        /// </summary>
        /// <param name="top">Top N records to return</param>
        /// <param name="orderBy">Name of the atribute</param>
        /// <param name="ascendingOrDescending">1 = Ascending, -1 = Descending</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> ReadTopAsync(int top, string orderBy, OrderByDirection ascendingOrDescending)
        {
            var sortBy = @"{
    $sort: {
        " + orderBy + @": " + ((int)ascendingOrDescending).ToString() + @"
    }
}";
            var pipelineDefinition = PipelineDefinition<T, T>
                                        .Create(sortBy)
                                        .Limit(top);

            var asyncCursor = await _mongoCollection.AggregateAsync<T>(pipelineDefinition);
            return asyncCursor.ToEnumerable<T>();
        }

        public Task SaveAsync(T data)
        {
            return _mongoCollection.InsertOneAsync(data);
        }
    }
}