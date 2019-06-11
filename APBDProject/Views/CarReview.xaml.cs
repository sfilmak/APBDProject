using APBDProject.Views;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
namespace APBDProject
{

    public partial class CarReview : Window
    {
        int? ownerID;
        DatabaseModel context;
        public CarReview(string carName, int year, string ownerReview, string imageLink, int? ownerID)
        {
            InitializeComponent();
            this.ownerID = ownerID;
            OwnerReviewBox.Text = ownerReview;
            carTitleName.Content = carName;
            CarYear.Content = year;
            CarPhoto.Source = new BitmapImage(new Uri(imageLink));

            //Owner
            context = new DatabaseModel();
            CarOwner carOwner = context.CarOwners.Find(ownerID);
            ownerNameTitle.Content = $"{carOwner.FirstName} {carOwner.LastName}" ;
            ownerLocation.Content = carOwner.Location;
            ownerPhoto.Source = new BitmapImage(new Uri(carOwner.Image));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OwnerInformation_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                OwnerView ownerView = new OwnerView(ownerID);
                ownerView.Show();
            }
        }
    }
}
