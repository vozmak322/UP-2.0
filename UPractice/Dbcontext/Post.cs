using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPractice.Dbcontext
{
    [Serializable]
    public class Post
    {
        public int Id { get; set; }
        public string NamePost { get; set; }
        public List<Teacher> Teachers { get; set; }
        public override string ToString()
        {
            return NamePost + " ";
        }
    }
}
