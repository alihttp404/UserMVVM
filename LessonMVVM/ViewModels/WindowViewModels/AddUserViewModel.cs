using LessonMVVM.Commands;
using LessonMVVM.Models;
using LessonMVVM.Services;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace LessonMVVM.ViewModels.WindowViewModels;

public class AddUserViewModel : NotificationService
{
    private User? user1;
    public User? user { get => user1; set { user1 = value; OnPropertyChanged(); } }

    public ObservableCollection<User> users { get; set; }

    public ICommand? SaveCommand{ get; set; }
    public ICommand? CancelCommand{ get; set; }

    public AddUserViewModel()
    {
        
    }

    public AddUserViewModel(ObservableCollection<User> Users)
    {
        users = Users;
        user = new();
        user.Address = new();
        user.Company = new Company();

        if (users.Count > 0) user.Id = users[users.Count-1].Id+1;
        else user.Id = 0;

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
        users.Add(user!);
        user = new();
        user.Address = new();
        user.Company = new Company();

        string json = JsonConvert.SerializeObject(users);
        File.WriteAllText("..\\..\\..\\DataBase\\Users.json", json);
    }

    public bool CanSave(object? parameter)
    {
        return !string.IsNullOrEmpty(user!.Name) &&
               !string.IsNullOrEmpty(user!.Username) &&
               !string.IsNullOrEmpty(user!.Email) &&
               !string.IsNullOrEmpty(user!.Website) &&
               !string.IsNullOrEmpty(user!.Address.City) &&
               !string.IsNullOrEmpty(user!.Address.Street) &&
               !string.IsNullOrEmpty(user!.Company.Name) &&
               !string.IsNullOrEmpty(user!.Company.Bs);
    }
}
