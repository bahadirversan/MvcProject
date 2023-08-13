using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetHeadingList();
        List<Heading> GetHeadingListByAuthorId(int id);
        void AddHeading(Heading heading);
        Heading GetById(int id);
        void DeleteHeading(Heading heading);
        void UpdateHeading(Heading heading);
    }
}
