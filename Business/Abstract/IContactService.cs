using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetContactList();
        void AddContact(Contact contact);
        Contact GetById(int id);
        void DeleteContact(Contact contact);
        void UpdateContact(Contact contact);
    }
}
