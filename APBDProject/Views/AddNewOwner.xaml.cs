using System.Windows;

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
            owner = new CarOwner {FirstName = ownerName.Text, LastName = ownerLastName.Text, Location = ownerLocation.Text, Image = ownerImage.Text};
            Close();
        }

        public CarOwner GetOwner
        {
            get { return owner; }
        }
    }
}
