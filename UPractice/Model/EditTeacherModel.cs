using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPractice.Dbcontext;

namespace UPractice.Model
{
    class EditTeacherModel : BindableBase
    {
        public void EditCitizen(string name, string secondname, string lastname, int phone, string email)
        {
            using (var db = new MyDbcontext())
            {
                Teacher tch = new Teacher()
                {
                    FirstName = name,
                    LastName = lastname,
                    SecondName = secondname,
                    Phone = phone,
                    Email = email
                    
                };
                var teacher = (from i in db.Teachers where i.Id == tch.Id select i).First();
                teacher.FirstName = tch.FirstName;
                teacher.LastName = tch.LastName;
                teacher.SecondName = tch.SecondName;
                teacher.Phone = tch.Phone;
                teacher.Email = tch.Email;
                db.SaveChanges();
                Debug.WriteLine("Изменение завершено");
            }
        }
    }
}
