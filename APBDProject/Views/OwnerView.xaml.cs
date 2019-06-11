using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace APBDProject.Views
{
    public partial class OwnerView : Window
    {
        private ObservableCollection<Car> listOfCars;
        DatabaseModel context;
        int? carOwnerID;
        public OwnerView(int? carOwnerID)
        {
            this.carOwnerID = carOwnerID;
            InitializeComponent();
            context = new DatabaseModel();
            GetOwnerCars(context);

            //Load info about owner
            CarOwner carOwner = context.CarOwners.Find(carOwnerID);
            ownerNameTitle.Content = $"{carOwner.FirstName} {carOwner.LastName}";
            ownerLocation.Content = carOwner.Location;
            ownerPhoto.Source = new BitmapImage(new Uri(carOwner.Image));
        }

        public void GetOwnerCars(DatabaseModel context)
        {
            var cars = context.Cars.Where(x => x.IdOwner == carOwnerID).ToList();
            listOfCars = new ObservableCollection<Car>(cars);
            carsListBox.ItemsSource = listOfCars;
        }

        private void TextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                if (carsListBox.SelectedItem == null) return;
                var selectedCar = carsListBox.SelectedItem as Car;
                if (selectedCar == null) return;

                string carName = selectedCar.Manufacturer + " " + selectedCar.Model;
                string carReview = selectedCar.Review;
                string carImage = selectedCar.Image;
                int? idOwner = selectedCar.IdOwner;
                int year = selectedCar.ProductionYear;
                CarReview ShowCarReview = new CarReview(carName, year, carReview, carImage, idOwner);
                ShowCarReview.ShowDialog();
            }
        }
    }

   
}
