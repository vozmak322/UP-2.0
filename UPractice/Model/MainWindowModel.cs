using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UPractice.Dbcontext;

namespace UPractice.Model
{
    class MainWindowModel : BindableBase
    {
        private readonly ObservableCollection<Teacher> _Teachers = new ObservableCollection<Teacher>();
        public readonly ReadOnlyObservableCollection<Teacher> Teachers;
        private readonly ObservableCollection<Chair> _Chairs = new ObservableCollection<Chair>();
        public readonly ReadOnlyObservableCollection<Chair> Chairs;
        private readonly ObservableCollection<Faculty> _Facultys = new ObservableCollection<Faculty>();
        public readonly ReadOnlyObservableCollection<Faculty> Facultys;

        public MainWindowModel()
        {
            Teachers = new ReadOnlyObservableCollection<Teacher>(_Teachers);
            Chairs = new ReadOnlyObservableCollection<Chair>(_Chairs);
            Facultys = new ReadOnlyObservableCollection<Faculty>(_Facultys);

            using (var db = new MyDbcontext())
            {
                _Teachers.AddRange(db.Teachers);
                _Chairs.AddRange(db.Chairs);
                _Facultys.AddRange(db.Faculties);
            }
        }

        public void AddTeacher(Teacher ctz)
        {
            if (ctz != null)
            {
                _Teachers.Add(ctz);
                using (var db = new MyDbcontext())
                {
                    db.Teachers.Add(ctz);
                    db.SaveChanges();
                }
            }
        }

        public void SaveToJSON(ReadOnlyObservableCollection<Teacher> Teachers,
            ReadOnlyObservableCollection<Chair> Chairs, ReadOnlyObservableCollection<Faculty> Facultys)
        {
            if (!Directory.Exists("db"))
            {
                Directory.CreateDirectory("db");
            }
            XmlSerializer ser = new XmlSerializer(typeof(ComboTeacher));

            foreach (var ctz in Teachers)
            {
                try
                {
                    var Chair = (from i in Chairs where i.Id == ctz.Id select i).First();
                    var Teacher = (from i in Teachers where i.Id == ctz.Id select i).First();
                    var Faculty = (from i in Facultys where i.Id == ctz.Id select i).First();
                    ComboTeacher c = new ComboTeacher(Teacher, Chair, Faculty);
                    using (FileStream fs = new FileStream("db/" + ctz + ".json", FileMode.Create))
                    {
                        ser.Serialize(fs, c);
                    }
                }
                catch (Exception) { }
            }
        }

        public void RefreshTables()
        {
            _Teachers.Clear();
            _Chairs.Clear();
            _Facultys.Clear();

            using (var db = new MyDbcontext())
            {
                _Teachers.AddRange(db.Teachers);
                _Chairs.AddRange(db.Chairs);
                _Facultys.AddRange(db.Faculties);
            }
        }
    }
}
