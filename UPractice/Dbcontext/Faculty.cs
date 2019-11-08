using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPractice.Dbcontext
{
    [Serializable]
    public class Faculty
    {
        public int Id { get; set; }
        public string NameFaculty { get; set; }
        public string ShortNameFaculty { get; set; }
        public List<Chair> Chairs { get; set; }

        public override string ToString()
        {
            return NameFaculty + " " + ShortNameFaculty + " ";
        }
    }
}
