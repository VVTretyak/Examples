using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using WPF_MySql.Commands;
using WPF_MySql.DataWorkers;
using WPF_MySql.Model;
using WPF_MySql.View;

namespace WPF_MySql.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private List<Person> allPeople = MySqlDataWorker.GetAllPersons();
        public static string PersonName { get; set; }
        public static string PersonPhone { get; set; }
        public static string StateConnectionToDb { get; set; }
        public static bool FirstScan { get; set; } = false;

        public PersonViewModel()
        {

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            //UpdateView();
            StateConnectionToDb = ShowDbConnectView();
            MainWindow.StateConnection.Text = StateConnectionToDb;
        }

        private void SetNullValuesToProperties()
        {
            PersonName = null;
            PersonPhone = null;
        }

        public List<Person> AllPeople
        {
            get { return allPeople; }
            set
            {
                allPeople = value;
                NotifyPropertyChanged("AllPeople");
                NotifyPropertyChanged("StateConnectionToDb");

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Методы открытия окон редактирования
        private void OpenAddpersonWindow()
        {
            AddPerson addPerson = new AddPerson();
            SetCenterPositionOpen(addPerson);
        }
        private void EditPersonWindow(Person person)
        {
            EditPerson editPerson = new EditPerson(person);
            SetCenterPositionOpen(editPerson);
        }
        #endregion

        #region Команды открытия окон добавления и редактирования 
        private RelayCommand openAddPersonWindow;
        public RelayCommand OpenAddPersonWindow
        {
            get
            {
                return openAddPersonWindow ??= new RelayCommand(obj =>
                  {
                      OpenAddpersonWindow();
                  }
                );
            }
        }

        private RelayCommand openEditPersonWindow;
        public RelayCommand OpenEditPersonWindow
        {
            get
            {
                return openEditPersonWindow ??= new RelayCommand(obj =>
                {
                    string resultStr = "Не найден";
                    if (SelectedTabItem.Name == "PersonTab" && SelectedPerson != null)
                    {
                        EditPersonWindow(SelectedPerson);
                    }
                }

                );
            }
        }

        #endregion


        public static Person SelectedPerson { get; set; }
        public static TabItem SelectedTabItem { get; set; }

        #region Команды добавления
        private RelayCommand addPersonWindow;
        public RelayCommand AddPersonWindow// Команда добавления 
        {
            get
            {
                return addPersonWindow ??= new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "";

                    if (PersonName == null || PersonName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "NameBlock");
                    }
                    else if (PersonPhone == null || PersonPhone.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(window, "PhoneBlock");
                    }
                    else
                    {
                        resultStr = MySqlDataWorker.CreatePerson(PersonName, PersonPhone);
                        ShowMessageView(resultStr);
                        window.Close();
                        UpdateView();
                    }
                }
                );
            }
        }

        #endregion

        #region Команда удаления 
        private RelayCommand deletePersonWindow;
        public RelayCommand DeletePersonWindow
        {
            get
            {
                return deletePersonWindow ??= new RelayCommand(obj =>
                {

                    string resultStr = "Не выбран";
                    if (SelectedTabItem.Name == "PersonTab" && SelectedPerson != null)
                    {
                        resultStr = MySqlDataWorker.DeletePerson(SelectedPerson);
                        UpdateView();
                    }


                    SetNullValuesToProperties();
                    ShowMessageView(resultStr);
                }
                );
            }
        }
        #endregion

        #region Команда редактирования
        private RelayCommand editPerson;
        public RelayCommand EditPerson
        {
            get
            {
                return editPerson ??= new RelayCommand(obj =>
                {
                    string resultStr = "Не выбран";
                    Window window = obj as Window;
                    if (SelectedPerson != null)
                    {
                        SelectedPerson.Name = PersonName;
                        SelectedPerson.Phone = PersonPhone;
                        resultStr = MySqlDataWorker.EditPerson(SelectedPerson);
                        UpdateView();
                    }
                    SetNullValuesToProperties();
                    ShowMessageView(resultStr);
                    window.Close();
                }
                );
            }
        }
        #endregion

        #region Команда проверки связи с базой данных

        private RelayCommand checkConnectionToDb;
        public RelayCommand CheckConnectionToDb
        {
            get
            {
                return checkConnectionToDb ??= new RelayCommand(obj =>
                {
                    StateConnectionToDb = ShowDbConnectView();
                    MainWindow.StateConnection.Text = StateConnectionToDb;
                }
                );
            }
        }

        #endregion
        #region Вспомогательные методы 
        private void SetCenterPositionOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        private void SetRedBlockControl(Window window, string blockName)
        {
            Control block = window.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        private void ShowMessageView(string msq)
        {
            MessageView messageView = new MessageView(msq);
            SetCenterPositionOpen(messageView);
        }

        private void UpdateView()
        {
            AllPeople = MySqlDataWorker.GetAllPersons();
            MainWindow.AllPerson.ItemsSource = null;
            MainWindow.AllPerson.Items.Clear();
            MainWindow.AllPerson.ItemsSource = AllPeople;
            MainWindow.AllPerson.Items.Refresh();
            //StateConnectionToDb = ShowDbConnectView();
            //MainWindow.StateConnection.Text = StateConnectionToDb;
        }

        private string ShowDbConnectView()
        {
            string result = "Error";
            if (MySqlDataWorker.CheckConnectionToDb())
            {
                result = "Ok";
            }
            return result;
        }
        #endregion  
    }

}


