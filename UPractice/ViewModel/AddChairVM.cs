using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPractice.Dbcontext;
using UPractice.Model;

namespace UPractice.ViewModel
{
    class AddChairVM : BindableBase
    {
        private AddChairModel _model = new AddChairModel();
        public ReadOnlyObservableCollection<Teacher> Teachers => _model.Teachers;
        public string NameChair { get; set; }
        public string ShortNameChair { get; set; }
        public Teacher SelectedTeacher { get; set; }

        public DelegateCommand AddChair { get; }

        public AddChairVM()
        {
            _model.PropertyChanged += (sender, args) => { RaisePropertyChanged(args.PropertyName); };
            AddChair = new DelegateCommand(() =>
            {
                try
                {
                    _model.AddChair(NameChair, ShortNameChair, SelectedTeacher);
                }
                catch (InvalidOperationException)
                {
                    System.Windows.MessageBox.Show("Поля необходимо заполнить", "Ошибка");
                }
            });
        }
    }
}
