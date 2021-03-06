﻿using Blog.DAL.ORM.Context;
using Blog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Repository.Entity
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private ProjectContext db;
        protected DbSet<T> table;

        public BaseRepository()
        {
            db = new ProjectContext();
            table = db.Set<T>();
        }
        public  List<T> GetAll(){
            return table.ToList();
        }
        public void Add(T item)
        {
            item.Status = Blog.DAL.ORM.Enum.Status.Active;
            table.Add(item);
            Save();
        }
        public void AddList(List<T>  items)
        {
            table.AddRange(items);
            Save();
        }
        public bool Any(Expression<Func<T, bool>> exp) => table.Any(exp); 

        public int Save()
        {
            return db.SaveChanges();
        }
        public List<T> GetActive() {
            return table.Where(a => a.Status == DAL.ORM.Enum.Status.Active).ToList();
        }

        public T GetByDefault(Expression<Func<T,bool>> exp)  // expression araştır 
        {
            return table.Where(exp).FirstOrDefault();
        }

        public List<T> GetDefault (Expression<Func<T,bool>> exp)
        {
            return table.Where(exp).ToList();
        }

        public T GetById(Guid id)
        {
            return table.Find(id);
        }

        public void Remove (Guid id)
        {
            T item = GetById(id);
            item.Status = DAL.ORM.Enum.Status.Deleted;

        }
        public void RemoveAll(Expression<Func<T,bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = DAL.ORM.Enum.Status.Deleted;
                Update(item);
            }
        }

        public void Update(T item)
        {
            T update = GetById(item.ID); 
            DbEntityEntry entry = db.Entry(update);  //dataentity araştır
            entry.CurrentValues.SetValues(item);
            Save();
        }
        

    }
}
