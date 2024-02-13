using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact
{
    interface IContactsRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int Contact_id);
        DataTable Search(string parameters);
        bool Insert(string Name, string Family, int Age, string Mobile, string Email);
        bool Update(int Contact_id, string Name, string Family, int Age, string Mobile, string Email);
        bool Delete(int Contact_id);
    }
}
