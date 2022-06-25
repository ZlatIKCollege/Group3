using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        private string _currentTable; //текущая таблица

        public MainWindow()
        {
            new LoginWindow().ShowDialog();

            InitializeComponent();
            CheckUser();
            _currentTable = "Пользователи";
            RefreshTable(_currentTable);
        }

        private void RefreshTable (string tableName) //обновление данных таблиц
        {
            switch (tableName)
            {
                case "Пользователи":
                    _dbContext.Users.Load(); //загрузка данных таблицы из БД
                    //вывод таблицы
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
            string headerName = e.Column.Header.ToString(); //имя столбца 
            switch (headerName)
            {
                case "Role":
                    e.Column.Visibility = Visibility.Collapsed; //скрытие столбца
                    _dbContext.Roles.Load(); //загрузка данных
                    Binding binding = new Binding(); //подвязка объекта Роль
                    binding.Path = new PropertyPath("Role"); //путь подвязки
                    DataGridComboBoxColumn col = new DataGridComboBoxColumn //создание столбца combobox для выборки определенной роли
                    {
                        Header = "Роль",
                        DisplayMemberPath = "Role1",
                        SelectedValuePath = "Id",
                        ItemsSource = _dbContext.Roles.ToArray(),
                        SelectedValueBinding = binding
                    };
                    ((DataGrid)sender).Columns.Add(col); //добавление столбца в datagrid
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
                case "Description":
                    e.Column.Header = "Описание";
                    break;
                case "Material":
                    e.Column.Visibility = Visibility.Collapsed;
                    _dbContext.Storages.Load();
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath("Material");
                    DataGridComboBoxColumn col = new DataGridComboBoxColumn
                    {
                        Header = "Материал",
                        DisplayMemberPath = "Material",
                        SelectedValuePath = "Id",
                        ItemsSource = _dbContext.Storages.ToArray(),
                        SelectedValueBinding = binding
                    };
                    ((DataGrid)sender).Columns.Add(col);
                    break;
                case "MaterialNavigation":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
                case "ProvisionOfServices":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void barbers_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();
            switch (headerName)
            {
                case "Surname":
                    e.Column.Header = "Фамилия";
                    break;
                case "Name":
                    e.Column.Header = "Имя";
                    break;
                case "Patronymic":
                    e.Column.Header = "Отчество";
                    break;
                case "Contact":
                    e.Column.Header = "Номер телефона";
                    break;
                case "ProvisionOfServices":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void clients_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();
            switch (headerName)
            {
                case "Surname":
                    e.Column.Header = "Фамилия";
                    break;
                case "Name":
                    e.Column.Header = "Имя";
                    break;
                case "Patronyimc":
                    e.Column.Header = "Отчество";
                    break;
                case "Contact":
                    e.Column.Header = "Номер телефона";
                    break;
                case "ProvisionOfServices":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void provision_of_services_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();
            switch (headerName)
            {
                case "date":
                    e.Column.Header = "Дата";
                    break;
                case "Service":
                    e.Column.Visibility = Visibility.Collapsed;
                    _dbContext.Services.Load();
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath("Service");
                    DataGridComboBoxColumn col = new DataGridComboBoxColumn
                    {
                        Header = "Услуга",
                        DisplayMemberPath = "Name",
                        SelectedValuePath = "Id",
                        ItemsSource = _dbContext.Services.ToArray(),
                        SelectedValueBinding = binding
                    };
                    ((DataGrid)sender).Columns.Add(col);
                    break;
                case "Price":
                    e.Column.Header = "Цена";
                    break;
                case "Barber":
                    e.Column.Visibility = Visibility.Collapsed;
                    _dbContext.Barbers.Load();
                    Binding binding1 = new Binding();
                    binding1.Path = new PropertyPath("Barber");
                    DataGridComboBoxColumn col1 = new DataGridComboBoxColumn
                    {
                        Header = "Барбер",
                        DisplayMemberPath = "Surname",
                        SelectedValuePath = "Id",
                        ItemsSource = _dbContext.Barbers.ToArray(),
                        SelectedValueBinding = binding1
                    };
                    ((DataGrid)sender).Columns.Add(col1);
                    break;
                case "Client":
                    e.Column.Visibility = Visibility.Collapsed;
                    _dbContext.Clients.Load();
                    Binding binding2 = new Binding();
                    binding2.Path = new PropertyPath("Client");
                    DataGridComboBoxColumn col2 = new DataGridComboBoxColumn
                    {
                        Header = "Клиент",
                        DisplayMemberPath = "Surname",
                        SelectedValuePath = "Id",
                        ItemsSource = _dbContext.Clients.ToArray(),
                        SelectedValueBinding = binding2
                    };
                    ((DataGrid)sender).Columns.Add(col2);
                    break;
                case "BarberNavigation":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
                case "ClientNavigation":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
                case "ServiceNavigation":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

            }
        }

        private void storage_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();
            switch (headerName)
            {
                case "Material":
                    e.Column.Header = "Материал";
                    break;
                case "Count":
                    e.Column.Header = "Количество";
                    break;
                case "Postav":
                    e.Column.Header = "Поставщик";
                    break;
                case "Services":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _dbContext.SaveChanges();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            switch (_currentTable)
            {
                case "Пользователи":
                    _dbContext.Users.Local.Remove(users.SelectedItem as User);
                    break;
                case "Роли":
                    _dbContext.Roles.Local.Remove(roles.SelectedItem as Role);
                    break;
                case "Услуги":
                    _dbContext.Services.Local.Remove(services.SelectedItem as Service);
                    break;
                case "Барберы":
                    _dbContext.Barbers.Local.Remove(barbers.SelectedItem as Barber);
                    break;
                case "Клиенты":
                    _dbContext.Clients.Local.Remove(clients.SelectedItem as Client);
                    break;
                case "Проведение услуг":
                    _dbContext.ProvisionOfServices.Local.Remove(provision_of_services.SelectedItem as ProvisionOfService);
                    break;
                case "Склад":
                    _dbContext.Storages.Local.Remove(storage.SelectedItem as Storage);
                    break;
            }
        }
        private void Tab_GotFocus(object sender, RoutedEventArgs e) //обновление таблицы при переключении вкладки
        {
            _currentTable = ((TabItem)sender).Header.ToString();
            RefreshTable(_currentTable);
        }
        private void CheckUser() //разграничение прав пользователей
        {
            switch (LoginWindow.CurrentUser.Role)
            {
                case 1: //если директор
                    break;
                case 2: //если администратор
                    break;
                case 3: //если кладовщик
                    clientsTab.Visibility = Visibility.Collapsed;
                    barbersTab.Visibility = Visibility.Collapsed;
                    userTab.Visibility = Visibility.Collapsed;
                    rolesTab.Visibility = Visibility.Collapsed;
                    servicesTab.Visibility = Visibility.Collapsed;
                    provision_of_servicesTab.Visibility = Visibility.Collapsed;
                    break;
                case 4: //если менеджер 
                    userTab.Visibility = Visibility.Collapsed;
                    rolesTab.Visibility = Visibility.Collapsed;
                    storageTab.Visibility = Visibility.Collapsed;
                    break;
                case 5: //если бухгалтер
                    clientsTab.Visibility = Visibility.Collapsed;
                    barbersTab.Visibility = Visibility.Collapsed;
                    userTab.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private string GetUserFile()
        {
            //выборка файла
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Файлы | *.csv"; //CSV формат
            ofd.Title = "Выберите файл для экспорта";
            if (ofd.ShowDialog() == true) //открытие и выбор файла
            {
                return ofd.FileName; //возврат имени файла
            }
            return null;
        }
        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = GetUserFile(); //получение файла
            if (filePath == null)
            {
                return;
            }
            StreamWriter file = new StreamWriter(filePath, false); //открытие потока на запись
            switch (_currentTable)
            {
                case "Пользователи":
                    //сохранение таблицы в коллекцию
                    ObservableCollection<User> tableUsers = _dbContext.Users.Local.ToObservableCollection();
                    foreach (User elem in tableUsers)
                    {
                        //запись элементов в CSV-файл
                        file.WriteLine($"{elem.Id};{elem.Role};{elem.Surname};{elem.Name};{elem.Patronymic};" +
                            $"{elem.Login};{elem.Password};{elem.Contact}");
                    }
                    break;
                case "Барберы":
                    ObservableCollection<Barber> tableBarbers = _dbContext.Barbers.Local.ToObservableCollection();
                    foreach (Barber elem in tableBarbers)
                    {
                        file.WriteLine($"{elem.Id};{elem.Surname};{elem.Name};{elem.Name};{elem.Patronymic};" +
                            $"{elem.Contact};{elem.ProvisionOfServices}");
                    }
                    break;
                case "Клиенты":
                    ObservableCollection<Client> tableClients = _dbContext.Clients.Local.ToObservableCollection();
                    foreach (Client elem in tableClients)
                    {
                        file.WriteLine($"{elem.Id};{elem.Surname};{elem.Name};{elem.Name};{elem.Patronymic};" +
                            $"{elem.Contact};{elem.ProvisionOfServices}");
                    }
                    break;
                case "Проведение услуг":
                    ObservableCollection<ProvisionOfService> tableProvisionOfServices = _dbContext.ProvisionOfServices.Local.ToObservableCollection();
                    foreach (ProvisionOfService elem in tableProvisionOfServices)
                    {
                        file.WriteLine($"{elem.Id};{elem.Date};{elem.Service};{elem.Price};{elem.Barber};" +
                            $"{elem.Client}");
                    }
                    break;
                case "Роли":
                    ObservableCollection<Role> tableRoles = _dbContext.Roles.Local.ToObservableCollection();
                    foreach (Role elem in tableRoles)
                    {
                        file.WriteLine($"{elem.Id};{elem.Role1};{elem.Users}");
                    }
                    break;
                case "Услуги":
                    ObservableCollection<Service> tableServices = _dbContext.Services.Local.ToObservableCollection();
                    foreach (Service elem in tableServices)
                    {
                        file.WriteLine($"{elem.Id};{elem.Name};{elem.Type};{elem.Description};{elem.Material};" +
                            $"{elem.ProvisionOfServices}");
                    }
                    break;
                case "Склад":
                    ObservableCollection<Storage> tableStorage = _dbContext.Storages.Local.ToObservableCollection();
                    foreach (Storage elem in tableStorage)
                    {
                        file.WriteLine($"{elem.Id};{elem.Material};{elem.Count};{elem.Postav};{elem.Services}");
                    }
                    break;
            }
            file.Close();
            MessageBox.Show("Экспорт успешно завершен!", "Успешно!");
        }

        private void ReportSalesMonthButton_Click(object sender, RoutedEventArgs e)
        {
            string reportName = ((Button)sender).Content.ToString();
            switch (reportName)
            {
                case "Продажи за текущий месяц":
                    ObservableCollection<ProvisionOfService> provisionOfServicesMonth = new ObservableCollection<ProvisionOfService>();
                    _dbContext.ProvisionOfServices.Load();
                    foreach (ProvisionOfService provisionOfService in _dbContext.ProvisionOfServices.Local.ToObservableCollection())
                        if (provisionOfService.Date.Month == DateTime.Now.Month)
                            provisionOfServicesMonth.Add(provisionOfService);
                    report.ItemsSource = provisionOfServicesMonth;
                    break;
            }
            
                
        }

        private void report_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headerName = e.Column.Header.ToString();
            e.Column.IsReadOnly = true;

            switch (headerName)
            {
                case "Date":
                    e.Column.Header = "Дата";
                    break;
                case "Service":
                    e.Column.Header = "Услуга";
                    break;
                case "Price":
                    e.Column.Header = "Цена";
                    break;
                case "Barber":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
                case "Client":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
                case "BarberNavigation":
                    e.Column.Visibility = Visibility.Collapsed;
                    _dbContext.Clients.Load();
                    Binding binding4 = new Binding();
                    binding4.Path = new PropertyPath("Barber");
                    DataGridComboBoxColumn col4 = new DataGridComboBoxColumn
                    {
                        Header = "Барберы",
                        DisplayMemberPath = "Surname",
                        SelectedValuePath = "Id",
                        ItemsSource = _dbContext.Clients.ToArray(),
                        SelectedValueBinding = binding4
                    };
                    ((DataGrid)sender).Columns.Add(col4);
                    break;
                case "ClientNavigation":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
                case "ServiceNavigation":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}
