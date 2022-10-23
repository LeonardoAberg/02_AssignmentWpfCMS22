using _02_AssignmentWpfCMS22.Models;
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

namespace _02_AssignmentWpfCMS22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Min lista som kontakterna ska sparas i
        private ObservableCollection<ContactPerson> contacts;
        public MainWindow()
        {
            InitializeComponent();
            // Instansiering av listan när programmet startar
            contacts = new ObservableCollection<ContactPerson>();
            // Listan = källan av objekt som skall visas
            lv_Contacts.ItemsSource = contacts;
        }

        // En metod som tömmer alla fält så man enkelt kan addera nästa/en till kontakt.
        private void EmptyField()
        {
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_Address.Text = "";
            tb_PostalCode.Text = "";
            tb_City.Text = "";
            tb_PhoneNumber.Text = "";
        }

        // En knapp där du lägger till kontakt och fyller vår lista ContactPerson med information (värde)
        // Kontroll för om kontaktperson finns med en firstordefault
        // If-sats för att inte kunna spara en kontaktperson med samma/likadan email
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var contact = contacts.FirstOrDefault(x => x.Email == tb_Email.Text);
            if (contact == null)
            {
                contacts.Add(new ContactPerson
                {
                    FirstName = tb_FirstName.Text,
                    LastName = tb_LastName.Text,
                    Email = tb_Email.Text,
                    Address = tb_Address.Text,
                    PostalCode = tb_PostalCode.Text,
                    City = tb_City.Text,
                    PhoneNumber = tb_PhoneNumber.Text,
                });
            }
            else
            {
                MessageBox.Show("A contact with that email already exists");
            }
            EmptyField();
        }

        // En knapp som tar bort kontakt. Objektet/kontakten tas bort (och knappen är endast synlig när objektet har ett värde)
        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var contact = (ContactPerson)button!.DataContext;
            contacts.Remove(contact);
        }

        // Här hämtar min listview mina värden i listan ContactPerson och visar den i fönstret.
        private void Lv_Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var contact = (ContactPerson)lv_Contacts.SelectedItems[0]!;
            tb_FirstName.Text = contact.FirstName;
            tb_LastName.Text = contact.LastName;
            tb_Email.Text = contact.Email;
            tb_Address.Text = contact.Address;
            tb_PostalCode.Text = contact.PostalCode;
            tb_City.Text = contact.City;
            tb_PhoneNumber.Text = contact.PhoneNumber;
        }
    }
}
