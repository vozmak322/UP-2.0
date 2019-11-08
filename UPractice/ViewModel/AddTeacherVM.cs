using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPractice.Model;

namespace UPractice.ViewModel
{
    class AddTeacherVM : BindableBase
    {
        readonly AddTeacherModel _model = new AddTeacherModel();

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public DelegateCommand AddTeacher { get; }
        public AddTeacherVM()
        {
            _model.PropertyChanged += (sender, args) => { RaisePropertyChanged(args.PropertyName); };

            AddTeacher = new DelegateCommand(() =>
            {
                if (!string.IsNullOrEmpty(FirstName))
                    _model.AddTeacher(FirstName, SecondName, LastName, Phone, Email);
                else
                    Debug.WriteLine("Строки пустые");
            });
        }
    }
}
