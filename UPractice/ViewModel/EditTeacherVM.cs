using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPractice.Model;

namespace UPractice.ViewModel
{
    class EditTeacherVM : BindableBase
    {
        private EditTeacherModel _model = new EditTeacherModel();
        public DelegateCommand EditCitizen { get; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public EditTeacherVM()
        {
            _model.PropertyChanged += (sender, args) => { RaisePropertyChanged(args.PropertyName); };
        }
    }
}
