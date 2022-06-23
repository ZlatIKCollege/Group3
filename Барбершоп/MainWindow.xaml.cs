using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Барбершоп
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private group_3_is_31Context _dbContext = new group_3_is_31Context();
        private string _currentTable;

        public MainWindow()
        {
            InitializeComponent();
   
            _currentTable = "Услуги";
            RefreshTable(_currentTable);
       
        }

        private void RefreshTable (string tableName)
        {
            switch (tableName)
            {
                case "Пользователи":
                    _dbContext.Users.Load();
                    users.ItemsSource = _dbContext.Users.Local.ToObservableCollection();
                    break;
                case "Роли":
                    _dbContext.Roles.Load();
                    roles.ItemsSource = _dbContext.Roles.Local.ToObservableCollection();
                    break;
                case "Услуги":
                    _dbContext.Services.Load();
                    services.ItemsSource = _dbContext.Services.Local.ToObservableCollection();
                    break;
                case "Барберы":
                    _dbContext.Barbers.Load();
                    barbers.ItemsSource = _dbContext.Barbers.Local.ToObservableCollection();
                    break;
                case "Клиенты":
                    _dbContext.Clients.Load();
                    clients.ItemsSource = _dbContext.Clients.Local.ToObservableCollection();
                    break;
                case "Проведение услуг":
                    _dbContext.ProvisionOfServices.Load();
                    provision_of_services.ItemsSource = _dbContext.ProvisionOfServices.Local.ToObservableCollection();
                    break;
                case "Склад":
                    _dbContext.Storages.Load();
                    storage.ItemsSource = _dbContext.Storages.Local.ToObservableCollection();
                    break;
            }
        }

        private void users_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString(); 
            switch (headerName)
            {
                case "Role":
                    e.Column.Visibility = Visibility.Collapsed;
                    _dbContext.Roles.Load();
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath("Role");
                    DataGridComboBoxColumn col = new DataGridComboBoxColumn
                    {
                        Header = "Роль",
                        DisplayMemberPath = "Role1",
                        SelectedValuePath = "Id",
                        ItemsSource = _dbContext.Roles.ToArray(),
                        SelectedValueBinding = binding
                    };
                    ((DataGrid)sender).Columns.Add(col);
                    e.Column.Header  = "Роль";
                    break;
                case "Surname":
                    e.Column.Header = "Фамилия";
                    break;
                case "Name":
                    e.Column.Header  = "Имя";
                    break;
                case "Patronymic":
                    e.Column.Header = "Отчество";
                    break;
                case "Login":
                    e.Column.Header = "Логин";
                    break;
                case "Password":
                    e.Column.Header = "Пароль";
                    break;
                case "Contact":
                    e.Column.Header = "Номер телефона";
                    break;
                case "RoleNavigation":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

            }  
        }
        private void roles_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();
            switch (headerName)
            {
              
                case "Role1":
                    e.Column.Header = "Роль";
                    break;
             
                case "Users":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

            }
        }

        private void services_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();
            switch (headerName)
            {

                case "Name":
                    e.Column.Header = "Имя";
                    break;

                case "Type":
                    e.Column.Header = "Тип";
                    break;

            }
        }
    }
}
