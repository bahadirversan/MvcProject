﻿using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class AuthorRepository : IAuthorDal
    {
        Context context = new Context();
        DbSet<Author> _object;

        public void Delete(Author p)
        {
            throw new NotImplementedException();
        }

        public Author Get(Expression<Func<Author, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Author p)
        {
            throw new NotImplementedException();
        }

        public List<Author> List()
        {
            throw new NotImplementedException();
        }

        public List<Author> List(Expression<Func<Author, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Author p)
        {
            throw new NotImplementedException();
        }
    }
}
