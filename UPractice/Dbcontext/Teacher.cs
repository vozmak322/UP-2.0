using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPractice.Dbcontext
{
    [Serializable]
    public class Teacher
    {
        public int Id { get; set; }
        public int IdChair { get; set; }
        public int IdPost { get; set; }
        public Chair Chair { get; set; }
        public Post Post { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Имя: {FirstName}, Отчество: {SecondName}, Фамилия: {Phone}, Email: {Email} ";
        }
    }
}
