using ClientsBaseApplication.Data;
using Microsoft.Data.Sqlite;
using System.Windows;
using System.Windows.Controls;

namespace ClientsBaseApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PersonDBContext dbContext;
        Person NewPerson = new Person();
        Person selectedPerson = new Person();

        public MainWindow(PersonDBContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            GetPerson();

            AddNewPersonGrid.DataContext = NewPerson;
        }

        /// <summary>
        /// Получить данные о клиентах из базы данных.
        /// </summary>
        private void GetPerson()
        {
            PersonDG.ItemsSource = dbContext.Persons.ToList();
        }

        public bool isValid(TextBox FullNamePerson,
                            TextBox AgePerson,
                            TextBox GenderPerson,
                            TextBox PhonePerson)
        {
            if (FullNamePerson.Text == string.Empty)
            {
                MessageBox.Show("Введите полное имя клиента!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (AgePerson.Text == string.Empty)
            {
                MessageBox.Show("Введите возраст клиента!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (GenderPerson.Text == string.Empty)
            {
                MessageBox.Show("Введите пол клиента!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (PhonePerson.Text == string.Empty)
            {
                MessageBox.Show("Введите телефон клиента!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Добавить клиента.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void AddPerson(object s, RoutedEventArgs e)
        {
            try
            {
                if (isValid(FullNamePersonAdd_Text,
                            AgePersonAdd_Text,
                            GenderPersonAdd_Text,
                            PhonePersonAdd_Text))
                {
                    dbContext.Persons.Add(NewPerson);
                    dbContext.SaveChanges();
                    GetPerson();
                    NewPerson = new Person();
                    AddNewPersonGrid.DataContext = NewPerson;
                    MessageBox.Show("Успешное добавление!", "Сохранено!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (SqliteException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Редактировать выбранного клиента.
        /// </summary>        
        private void UpdatePersonForEdit(object s, RoutedEventArgs e)
        {
            selectedPerson = (s as FrameworkElement).DataContext as Person;
            SaveUpdate_Button.IsEnabled = true;
            UpdatePersonGrid.DataContext = selectedPerson;
        }

        /// <summary>
        /// Записать новые данные о клиенте в базе данных.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void UpdatePerson(object s, RoutedEventArgs e)
        {
            try
            {
                //if (isValid(FullNamePersonUpdate_Text,
                //            AgePersonUpdate_Text,
                //            GenderPersonUpdate_Text,
                //            PhonePersonUpdate_Text) && (selectedPerson != null))
                {
                    dbContext.Update(selectedPerson);
                    dbContext.SaveChanges();
                    GetPerson();
                    MessageBox.Show("Успешное изменение!", "Сохранено!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (SqliteException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Удалить запись о клиенте из базы данных.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void DeletePerson(object s, RoutedEventArgs e)
        {
            var personaToBeDeleted = (s as FrameworkElement).DataContext as Person;
            dbContext.Persons.Remove(personaToBeDeleted);
            dbContext.SaveChanges();
            GetPerson();
        }
    }
}