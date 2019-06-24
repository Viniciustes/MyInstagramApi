using MongoDB.Driver;
using MyInstagramApi.Contexts;
using MyInstagramApi.Interfaces;
using MyInstagramApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyInstagramApi.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly IMongoCollection<TEntity> mongoCollection;

        public Repository(MyInstagramContextDb context, string nameColection)
        {
            mongoCollection = context.MongoDatabase.GetCollection<TEntity>(nameColection);
        }

        public IQueryable<TEntity> GetAll()
        {
            return mongoCollection.AsQueryable();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await mongoCollection.AsQueryable().ToListAsync();
        }

        public TEntity GetById(Guid guid)
        {
            return mongoCollection.Find(x => x.Id == guid).FirstOrDefault();
        }

        public async Task<TEntity> GetByIdAsync(Guid guid)
        {
            return await mongoCollection.Find(x => x.Id == guid).FirstOrDefaultAsync();
        }

        public void Create(TEntity entity)
        {
            mongoCollection.InsertOne(entity);
        }

        public void Delete(Guid guid)
        {
            mongoCollection.DeleteOne(x => x.Id == guid);
        }

        public void Update(TEntity entity)
        {
            mongoCollection.ReplaceOne(x => x.Id == entity.Id, entity);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return mongoCollection.AsQueryable().Where(expression);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await mongoCollection.InsertOneAsync(entity);

            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await mongoCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public async Task DeleteAsync(Guid guid)
        {
            await mongoCollection.DeleteOneAsync(x => x.Id == guid);
        }
    }
}
