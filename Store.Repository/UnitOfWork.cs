﻿using Store.Core;
using Store.Core.Entities;
using Store.Core.Repositories.Contract;
using Store.Repository.Data.Contexts;
using Store.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;

        private Hashtable _repository;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            _repository = new Hashtable();
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var type = typeof(TEntity).Name;
            if (!_repository.ContainsKey(type))
            {

                var repository = new GenericRepository<TEntity, TKey>(_context);
                _repository.Add(type, repository);
            }
            return _repository[type] as IGenericRepository<TEntity, TKey>;



        }
    }
}
