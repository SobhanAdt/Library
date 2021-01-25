using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Library.Context;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public  class EfRepository<T> : IRepository<T> where T : class, IHasIdetity
    {
        private readonly LibraryContext context;

        public EfRepository(LibraryContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            try
            {
                var item = context.Set<T>().FirstOrDefault(x => x.Id == id);
                context.Remove(item);
            }
            catch 

            {
                throw new Exception("Moshkel dar Delete");
            }
        
        }

        public  List<T> GetAll()
        {
            try
            {
                return  this.context.Set<T>().ToList();
            }
            catch
            {
                throw new Exception("Error Get All List");
            }
        }

        public T GetSingel(int id)
        {

            try
            {
                return this.context.Set<T>().FirstOrDefault(x => x.Id == id);
            }
            catch 
            {
            throw new Exception("Error Get Singel");
            }
        }
        
        public void Insert(T item)
        {
            try
            {
                context.Add<T>(item);
            }
            catch
            {
                throw new Exception("Error Insert");
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch
            {
                throw new Exception("Error Save");
            }
        }

        public T Update(T item)
        {
            try
            {
                context.Update<T>(item);
                return item;
            }
            catch
            {
                throw new Exception("Error Update");
            }
        }
    }
}
