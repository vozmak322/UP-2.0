using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UPractice.Dbcontext;
using UPractice.Model;
using UPractice.View;

namespace UPractice.ViewModel
{
    class MainWindowVM : BindableBase
    {
        readonly MainWindowModel _model = new MainWindowModel();
        public ReadOnlyObservableCollection<Teacher> Teachers => _model.Teachers;
        public ReadOnlyObservableCollection<Chair> Chairs => _model.Chairs;
        public ReadOnlyObservableCollection<Faculty> Faculties => _model.Facultys;

        public Teacher SelectedTeacher { get; set; }
        public Chair SelectedChair { get; set; }
        public Faculty SelectedFaculty { get; set; }

        public DelegateCommand RefreshTeacherTable { get; }
        public DelegateCommand AddTeacher { get; }
        public DelegateCommand EditTeacher { get; }
        public DelegateCommand DeleteTeacher { get; }
        public DelegateCommand AddChair { get; }
        public DelegateCommand EditChair { get; }
        public DelegateCommand DeleteChair { get; }
        public DelegateCommand AddFaculty { get; }
        public DelegateCommand EditFaculty { get; }
        public DelegateCommand DeleteFaculty { get; }
        public DelegateCommand FindByCypher { get; }
        public DelegateCommand SaveToJSON { get; }
        public DelegateCommand FindComplexSearch { get; }

        public MainWindowVM()
        {
            _model.PropertyChanged += (sender, args) => { RaisePropertyChanged(args.PropertyName); };

            FindComplexSearch = new DelegateCommand(() =>
            {
                Search cs = new Search();
                cs.Show();
            });

            RefreshTeacherTable = new DelegateCommand(() =>
            {
                _model.RefreshTables();
            });

            AddTeacher = new DelegateCommand(() =>
            {
                AddTeacherWindow atw = new AddTeacherWindow();
                atw.ShowDialog();
                _model.RefreshTables();
            });

            EditTeacher = new DelegateCommand(() =>
            {
                EditTeacherWindow ecw = new EditTeacherWindow();
                ecw.DataContext = SelectedTeacher;
                Teacher tch = SelectedTeacher;
                if (ecw.ShowDialog() == true)
                {
                    using (var db = new MyDbcontext())
                    {
                        var Teacher = (from i in db.Teachers where i.Id == tch.Id select i).First();
                        Teacher.FirstName = tch.FirstName;
                        Teacher.LastName = tch.LastName;
                        Teacher.SecondName = tch.SecondName;
                        db.SaveChanges();
                    }
                    _model.RefreshTables();
                }
            });

            DeleteTeacher = new DelegateCommand(() =>
            {
                using (var db = new MyDbcontext())
                {
                    var Teacher = (from i in db.Teachers where i.Id == SelectedTeacher.Id select i).First();
                    db.Teachers.Remove(Teacher);
                    db.SaveChanges();
                }
                _model.RefreshTables();
            });

            AddChair = new DelegateCommand(() =>
            {
                AddChairWindow apw = new AddChairWindow();
                apw.DataContext = new AddChairVM();
                apw.ShowDialog();
                _model.RefreshTables();
            });

            EditChair = new DelegateCommand(() =>
            {
                EditChairWindow epw = new EditChairWindow();
                Chair chr = SelectedChair;
                epw.DataContext = chr;
                if (epw.ShowDialog() == true)
                {
                    using (var db = new MyDbcontext())
                    {
                        var Chair = (from i in db.Chairs where i.Id == chr.Id select i).First();
                        Chair.NameChair = chr.NameChair;
                        Chair.ShortNameChair = chr.ShortNameChair;
                        db.SaveChanges();
                    }
                    _model.RefreshTables();
                }
            });

            DeleteChair = new DelegateCommand(() =>
            {
                using (var db = new MyDbcontext())
                {
                    var Chair = (from i in db.Chairs where i.Id == SelectedChair.Id select i).First();
                    db.Chairs.Remove(Chair);
                    db.SaveChanges();
                }
                _model.RefreshTables();
            });

            AddFaculty = new DelegateCommand(() =>
            {
                AddFacultyWindow adw = new AddFacultyWindow();
                adw.DataContext = new AddFacultyVM();
                adw.ShowDialog();
                _model.RefreshTables();
            });

            EditFaculty = new DelegateCommand(() =>
            {
                EditFacultyWindow edw = new EditFacultyWindow();
                Faculty fcl = SelectedFaculty;
                edw.DataContext = fcl;             
                if (edw.ShowDialog() == true)
                {
                    using (var db = new MyDbcontext())
                    {
                        var Faculty = (from i in db.Faculties where i.Id == fcl.Id select i).First();
                        Faculty.NameFaculty = fcl.NameFaculty;
                        Faculty.ShortNameFaculty = fcl.ShortNameFaculty;
                        db.SaveChanges();
                    }
                    _model.RefreshTables();
                }
            });

            DeleteFaculty = new DelegateCommand(() =>
            {
                using (var db = new MyDbcontext())
                {
                    var Faculty = (from i in db.Faculties where i.Id == SelectedFaculty.Id select i).First();
                    db.Faculties.Remove(Faculty);
                    db.SaveChanges();
                }
                _model.RefreshTables();
            });

            FindByCypher = new DelegateCommand(() =>
            {
                FindByCypherWindow fbc = new FindByCypherWindow();
                fbc.Show();
            });

            SaveToJSON = new DelegateCommand(() =>
            {
                _model.SaveToJSON(Teachers, Chairs, Faculties);
                MessageBox.Show("Все сохранено");
            });
        }
    }
}
