using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace APBDProject.Views
{
    public partial class AddNewOwner : Window
    {
        public CarOwner owner;
        public AddNewOwner()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = ownerName.Text;
            string surname = ownerLastName.Text;
            string location = ownerLocation.Text;
            string imageLink = ownerImage.Text;
            CarOwner ownerToCheck = new CarOwner { FirstName = name, LastName = surname, Location = location, Image = imageLink };
            if (ownerToCheck.CheckCredentials())
             {
                owner = new CarOwner { FirstName = name, LastName = surname, Location = location, Image = imageLink };
                Close();
             } else {
                if(string.IsNullOrEmpty(ownerName.Text) || string.IsNullOrWhiteSpace(ownerName.Text)) 
                {
                    ownerName.Background = Brushes.Red;
                } else
                {
                    ownerName.Background = Brushes.White;
                }

                if (string.IsNullOrEmpty(ownerLastName.Text) || string.IsNullOrWhiteSpace(ownerLastName.Text))
                {
                    ownerLastName.Background = Brushes.Red;
                } else
                {
                    ownerLastName.Background = Brushes.White;
                }

                if (string.IsNullOrEmpty(ownerImage.Text) || string.IsNullOrWhiteSpace(ownerImage.Text) || !ownerImage.Text.StartsWith("http"))
                {
                    ownerImage.Background = Brushes.Red;
                } else
                {
                    ownerImage.Background = Brushes.White;
                }

                if (string.IsNullOrEmpty(ownerLocation.Text) || string.IsNullOrWhiteSpace(ownerLocation.Text))
                {
                    ownerLocation.Background = Brushes.Red;
                }
                else
                {
                    ownerLocation.Background = Brushes.White;
                }
            }
        }

        public CarOwner GetOwner
        {
            get { return owner; }
        }
    }

    
}
