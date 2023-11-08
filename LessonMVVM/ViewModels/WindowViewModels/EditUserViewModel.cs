using LessonMVVM.Commands;
using LessonMVVM.Models;
using LessonMVVM.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LessonMVVM.ViewModels.WindowViewModels
{
    public class EditUserViewModel : NotificationService
    {
        private User currUser;

        public User CurrUser { get => currUser; set { currUser = value; OnPropertyChanged(); } }
        public ObservableCollection<User> Users { get; set; }
        public ICommand? CancelCommand { get; set; }
        public ICommand? SaveCommand { get; set; }

        public EditUserViewModel()
        {
            CancelCommand = new RelayCommand(CancelWindow);
        }

        public EditUserViewModel(ObservableCollection<User> users, int selectedIndex)
        {
            CurrUser = new();
            CurrUser.Address = new();
            CurrUser.Company = new();
            Users = users;
            CurrUser = users[selectedIndex];
            SaveCommand = new RelayCommand(Save, CanSave);
            CancelCommand = new RelayCommand(CancelWindow);
        }

        public void CancelWindow(object? parameter)
        {
            var window = parameter as Window;
            if (window != null) window.Close();
        }

        public void Save(object? parameter)
        {
            CurrUser = new();
            CurrUser.Address = new();
            CurrUser.Company = new Company();

            string json = JsonConvert.SerializeObject(Users);
            File.WriteAllText("..\\..\\DataBase\\Users.json", json);
        }

        public bool CanSave(object? parameter)
        {
            return !string.IsNullOrEmpty(CurrUser!.Name) &&
                   !string.IsNullOrEmpty(CurrUser!.Username) &&
                   !string.IsNullOrEmpty(CurrUser!.Email) &&
                   !string.IsNullOrEmpty(CurrUser!.Website) &&
                   !string.IsNullOrEmpty(CurrUser!.Address.City) &&
                   !string.IsNullOrEmpty(CurrUser!.Address.Street) &&
                   !string.IsNullOrEmpty(CurrUser!.Company.Name) &&
                   !string.IsNullOrEmpty(CurrUser!.Company.Bs);
        }
    }
}
