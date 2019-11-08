using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPractice.Dbcontext;
using UPractice.Model;

namespace UPractice.ViewModel
{
    class AddFacultyVM : BindableBase
    {
        private AddFacultyModel _model = new AddFacultyModel();
        public ReadOnlyObservableCollection<Teacher> Teachers => _model.Teachers;
        public string NameFaculty { get; set; }
        public string ShortNameFaculty { get; set; }
        public Teacher SelectedTeacher { get; set; }

        public DelegateCommand AddFaculty { get; }

        public AddFacultyVM()
        {
            _model.PropertyChanged += (sender, args) => { RaisePropertyChanged(args.PropertyName); };
            AddFaculty = new DelegateCommand(() =>
            {
                try
                {
                    _model.AddFaculty(NameFaculty, ShortNameFaculty, SelectedTeacher);
                }
                catch (InvalidOperationException)
                {
                    System.Windows.MessageBox.Show("Поля необходимо заполнить", "Ошибка");
                }
            });
        }
    }
}
