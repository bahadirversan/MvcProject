using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetContentList();
        List<Content> GetContentListByAuthor(int id);
        List<Content> GetContentListByHeadingId(int id);
        void AddContent(Content content);
        Content GetById(int id);
        void DeleteContent(Content content);
        void UpdateContent(Content content);
    }
}
