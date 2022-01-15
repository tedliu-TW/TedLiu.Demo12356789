using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TedLiu.Demo.Models.Repository;

namespace TedLiu.Demo.Models.Service
{
    public class DemoService
    {
       DemoRepository repo = new DemoRepository();


        public IEnumerable<AddressBook> Getall()
        {
            return repo.getall();
        }
        public void Create(AddressBook Model)
        {
            repo.Create(Model);       
        }


        public AddressBook getId(int id)
        {
            return repo.getId(id);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }
        public void Edit(int id,AddressBook model)
        {
           repo.Edit(id,model);
        }


    }
}