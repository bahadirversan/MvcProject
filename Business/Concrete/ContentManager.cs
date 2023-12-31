﻿using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void AddContent(Content content)
        {
            _contentDal.Insert(content);
        }

        public void DeleteContent(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetContentList(string p)
        {
            return _contentDal.List(x => x.ContentValue.Contains(p));
        }

        public List<Content> GetContentListByAuthor(int id)
        {
            return _contentDal.List(x => x.AuthorId == id);
        }

        public List<Content> GetContentListByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public void UpdateContent(Content content)
        {
            throw new NotImplementedException();
        }
    }
}
