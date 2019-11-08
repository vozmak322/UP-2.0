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
    class AddFacultyModel : BindableBase
    {
        public ReadOnlyObservableCollection<Teacher> Teachers { get; }

        public AddFacultyModel()
        {
            using (var db = new MyDbcontext())
            {
                ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>(db.Teachers);
                Teachers = new ReadOnlyObservableCollection<Teacher>(teachers);
            }
        }

        public void AddFaculty(string NameF, string ShortNameF, Teacher tch)
        {
            Faculty fcl = new Faculty()
            {
                NameFaculty = NameF,
                ShortNameFaculty = ShortNameF  
            };
            using (var db = new MyDbcontext())
            {
                db.Faculties.Add(fcl);
                db.SaveChanges();
            }
        }

    }
}
