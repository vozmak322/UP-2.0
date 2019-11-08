using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPractice.Dbcontext;

namespace UPractice.Model
{
    class AddTeacherModel : BindableBase
    {
        public void AddTeacher(string FirstName, string SecondName, string LastName, int Phone, string Email)
        {
            if (!(string.IsNullOrEmpty(FirstName) && string.IsNullOrWhiteSpace(FirstName))
                &&
                !(string.IsNullOrEmpty(SecondName) && string.IsNullOrWhiteSpace(SecondName))
                &&
                !(string.IsNullOrEmpty(LastName) && string.IsNullOrWhiteSpace(LastName))
                &&
                !(string.IsNullOrEmpty(Email) && string.IsNullOrWhiteSpace(Email)))
            {
                Teacher teacher = new Teacher()
                {
                    FirstName = FirstName ,
                    SecondName = SecondName,
                    LastName = LastName,
                    Phone = Phone,
                    Email = Email
                };
                using (var db = new MyDbcontext())
                {
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new System.InvalidOperationException("Fields are empty");
            }
        }
    }
}
