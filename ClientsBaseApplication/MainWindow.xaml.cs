using ClientsBaseApplication.Data;
using System.Windows;

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

        /// <summary>
        /// Добавить клиента.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void AddPerson(object s, RoutedEventArgs e)
        {
            dbContext.Persons.Add(NewPerson);
            dbContext.SaveChanges();
            GetPerson();
            NewPerson = new Person();
            AddNewPersonGrid.DataContext = NewPerson;
        }

        /// <summary>
        /// Редактировать выбранного клиента.
        /// </summary>        
        private void UpdatePersonForEdit(object s, RoutedEventArgs e)
        {
            selectedPerson = (s as FrameworkElement).DataContext as Person;
            UpdatePersonGrid.DataContext = selectedPerson;
        }

        /// <summary>
        /// Записать новые данные о клиенте в базе данных.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void UpdatePerson(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedPerson);
            dbContext.SaveChanges();
            GetPerson();
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