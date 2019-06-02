using System;
using System.Windows;
using System.Windows.Media.Imaging;
namespace APBDProject
{

    public partial class CarReview : Window
    {

        DatabaseModel context;
        public CarReview(string carName, int year, string ownerReview, string imageLink, int? ownerID)
        {
            InitializeComponent();
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
    }
}
