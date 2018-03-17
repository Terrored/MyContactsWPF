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
using MyContactsBL;
using MyContactsDB;

namespace MyContacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Broker broker;
        Person person;
        public MainWindow()
        {
            InitializeComponent();
            broker = new Broker();

            ListBoxOfContacts.ItemsSource = broker.RetrievePersons();
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            person = new Person();
            person.FirstName = FirstNameTextBox.Text;
            person.LastName = LastNameTextBox.Text;
            person.EmailAddress = EmailTextBox.Text;
            person.Number = NumberTextBox.Text;

            broker.Insert(person);
            MessageBox.Show("New contact was added successfully");
            RefreshButton_Click(sender,e);
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxOfContacts.ItemsSource = broker.RetrievePersons();
        }

        private void RemoveContact_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person = ListBoxOfContacts.SelectedItem as Person;
            broker.Delete(person);
            MessageBox.Show("New contact was deleted successfully");
            RefreshButton_Click(sender, e);
        }
    }
}
