using LessonMVVM.Commands;
using LessonMVVM.Models;
using LessonMVVM.Services;
using LessonMVVM.ViewModels.WindowViewModels;
using LessonMVVM.Views.Windows;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LessonMVVM.ViewModels.PageViewModels;

public class DashboardPageViewModel : NotificationService
{
    public ObservableCollection<User> Users { get; set; }

    public ICommand? AddViewCommand { get; set; }
    public ICommand? EditViewCommand { get; set; }

    public DashboardPageViewModel()
    {
        string jsonText = File.ReadAllText("C:\\Users\\mamma_er07\\Downloads\\LessonMVVM (1)\\LessonMVVM\\DataBase\\Users.json");
        Users = JsonConvert.DeserializeObject<ObservableCollection<User>>(jsonText);

        Users.Add(new("Ali", "ali123", "ali@gmail.com", "https://www.ali.com", new Address("Hasan Salmani 1", "Baku"), new Company("STEP IT", "Hakuna Matata")));
        
        AddViewCommand = new RelayCommand(AddUserView);
        EditViewCommand = new RelayCommand(EditUserView);
    }

    public void AddUserView(object? parameter)
    {
        var addView = new AddUserView();
        addView.DataContext = new AddUserViewModel(Users);
        addView.ShowDialog();
    }

    public void EditUserView(object? parameter) 
    {
        int index = Convert.ToInt32(parameter);
        var editView = new EditUserView();
        editView.DataContext = new EditUserViewModel(Users, index);
        editView.ShowDialog();
    }
}
