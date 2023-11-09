using LessonMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMVVM.ViewModels.WindowViewModels
{
    internal class GetAllViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public GetAllViewModel()
        {
            
        }

        public GetAllViewModel(ObservableCollection<User> users)
        {
            Users = users;
        }
    }
}
