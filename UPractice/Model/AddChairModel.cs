using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPractice.Dbcontext;

namespace UPractice.Model
{
    class AddChairModel : BindableBase
    {
        public ReadOnlyObservableCollection<Teacher> Teachers { get; }

        public AddChairModel()
        {
            using (var db = new MyDbcontext())
            {
                ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>(db.Teachers);
                Teachers = new ReadOnlyObservableCollection<Teacher>(teachers);
            }
        }

        public void AddChair(string name, string shortname, Teacher teacher)
        {
            Chair chair = new Chair()
            {
                NameChair = name,
                ShortNameChair = shortname,          
            };
            using (var db = new MyDbcontext())
            {
                db.Chairs.Add(chair);
                db.SaveChanges();
            }
        }
    }
}
