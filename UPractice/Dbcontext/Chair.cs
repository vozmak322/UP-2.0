using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPractice.Dbcontext
{
    [Serializable]
    public class Chair
    {
        public int Id { get; set; }
        public int IdFaculty { get; set; }
        public Faculty Faculty { get; set; }
        public string NameChair { get; set; }
        public List<Teacher> Teachers { get; set; }
        public string ShortNameChair { get; set; }

        public override string ToString()
        {
            return NameChair + " " + ShortNameChair + " ";
        }
    }
}
