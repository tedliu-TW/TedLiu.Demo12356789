using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace TedLiu.Demo.Models.Repository
{
    interface IDemoRepository
    {
        void Create(AddressBook Model);

        AddressBook getId(int id);

        List<AddressBook> getall();

        void Delete(int id);

        void Edit(int id, AddressBook model);
        
    }
    public class DemoRepository:IDemoRepository
    {
        private string conn = ConfigurationManager.ConnectionStrings["EFMode"].ConnectionString;

        public void Create(AddressBook Model)
        {
            using (var con = new SqlConnection(conn))
            {
                string sql = $"Insert into AddressBook(Name,Phone,Email,Address)VALUES(@Name,@Phone,@Email,@Address)";
                con.Execute(sql,Model);   
            }

        }

        public void Delete(int id)
        {
            using (var con = new SqlConnection(conn))
            {
                string sql = $"Delete from AddressBook where id=@id";
                con.Execute(sql, new{ id});
            }
        }

        public  void Edit(int id,AddressBook model)
        {
            using (var con = new SqlConnection(conn))
            {
                string sql = $"Update AddressBook SET Name=@Name,Phone=@Phone,Email=@Email,Address=@Address where id=@id";
                con.Execute(sql,model);
            }
        }

        public List<AddressBook> getall()
        {
            using (var con = new SqlConnection(conn))
            {
                string sql = $"select * from AddressBook";
                return con.Query<AddressBook>(sql).ToList();
            }
        }

        public AddressBook getId(int id)
        {
            using (var con = new SqlConnection(conn))
            {
                string sql = $"select * from AddressBook where id=@id";
                return con.QuerySingleOrDefault<AddressBook>(sql, new {id});
    
            }
        }
    }
}