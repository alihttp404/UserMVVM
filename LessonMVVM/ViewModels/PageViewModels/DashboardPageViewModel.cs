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
    public ICommand? RemoveCommand { get; set; }
    public ICommand? GetAllCommand { get; set; }

    public DashboardPageViewModel()
    {
        string jsonText = File.ReadAllText("..\\..\\..\\DataBase\\Users.json");
        Users = JsonConvert.DeserializeObject<ObservableCollection<User>>(jsonText);
        
        AddViewCommand = new RelayCommand(AddUserView, IsComboBoxNotEmpty);
        EditViewCommand = new RelayCommand(EditUserView, IsComboBoxNotEmpty);
        RemoveCommand = new RelayCommand(Remove, IsComboBoxNotEmpty);
        GetAllCommand = new RelayCommand(GetAll);
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

    public void Remove(object? parameter)
    {
        int index = Convert.ToInt32(parameter);
        Users.Remove(Users[index]).ToString();
        string json = JsonConvert.SerializeObject(Users);
        File.WriteAllText("..\\..\\..\\DataBase\\Users.json", json);
    }

    public void GetAll(object? parameter)
    {
        var addView = new GetAllView();
        addView.DataContext = new GetAllViewModel(Users);
        addView.ShowDialog();
    }

    public bool IsComboBoxNotEmpty(object? parameter)
    {
        int index = Convert.ToInt32(parameter);
        return (index != -1);
    }
}
