using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            if (EmailTextBox.Text.Contains("@"))
            {
                person.EmailAddress = EmailTextBox.Text;
            }
            else
            {
                person.EmailAddress = "Invalid email address";
            }
            person.Number = NumberTextBox.Text;
            
                
            
            if (String.IsNullOrWhiteSpace(person.FirstName) && String.IsNullOrWhiteSpace(person.LastName)
                && String.IsNullOrWhiteSpace(person.Number))
            {
                 MessageBox.Show("First name, last name, and number are not valid data!", "Invalid data");
            }
            else
            {
               broker.Insert(person);
                MessageBox.Show("New contact was added successfully");
            }
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


            try
            {
                broker.Delete(person);
                MessageBox.Show("Contact was deleted successfully");
                RefreshButton_Click(sender, e);
            }
            catch (Exception exception)
            {
                
            }
            
           
        }

        private void detailsButton_Click(object sender, RoutedEventArgs e)
        {
            person = new Person();
            person = ListBoxOfContacts.SelectedItem as Person;

            try
            {
                DetailsTextBlock.Text = person.GetDetails();
            }
            catch (Exception exception)
            {
                
                
            }
        }

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            
            ListBoxOfContacts.ItemsSource = sortListByName(broker.RetrievePersons());

        }

        private IEnumerable<IContact> sortListByName(IEnumerable<IContact> list)
        {
            return list.OrderBy(c => c.Name);
        }

        private IEnumerable<IContact> sortListByEmailAddress(IEnumerable<IContact> list)
        {
            return list.OrderBy(c => c.EmailAddress);
        }
        private IEnumerable<IContact> sortListByNumber(IEnumerable<IContact> list)
        {
            return list.OrderBy(c => c.Number);
        }

        private void sortByEmailButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxOfContacts.ItemsSource = sortListByEmailAddress(broker.RetrievePersons());
        }

        private void sortByNumberButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxOfContacts.ItemsSource = sortListByNumber(broker.RetrievePersons());
        }
    }
}
