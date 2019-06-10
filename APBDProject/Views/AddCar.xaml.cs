using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace APBDProject.Views
{
    public partial class AddCar : Window
    {
        IEnumerable<CarOwner> carOwners;
        IEnumerable<CarType> carTypes;
        public Car car;
        public AddCar()
        {
            InitializeComponent();
            var context = new DatabaseModel();
            carOwners = context.CarOwners.ToList();
            owners_list.ItemsSource = carOwners;

            carTypes = context.CarTypes.ToList();
            car_types_list.ItemsSource = carTypes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Add new car       
            CarOwner carOwner = (CarOwner) owners_list.SelectedItem;
            CarType carType = (CarType) car_types_list.SelectedItem;

            string manuf = carName.Text;
            string model = carModel.Text;
            string review = carShortReview.Text;
            string color = carColor.Text;
            string image = carImage.Text;
            string yearString = carYear.Text;
            int typeID = carType.IdCarType;
            int ownerID = carOwner.IdOwner;
            int carProductionYear;

            //Production year is not required
            //So, if it is empty - replace with 2019
            if(string.IsNullOrEmpty(yearString))
            {
                carProductionYear = 2019;
            } else
            {
                carProductionYear = Int32.Parse(yearString);
            }

            Car carToCheck = new Car { Manufacturer = manuf, Model = model, Review = review, Color = color, Image = image, ProductionYear = carProductionYear, IdCarType = typeID, IdOwner = ownerID };
            if (carToCheck.CheckCredentials())
            {
                car = carToCheck;
                Close();
            }
            else
            {
                if (string.IsNullOrEmpty(carName.Text) || string.IsNullOrWhiteSpace(carName.Text))
                {
                    carName.Background = Brushes.Red;
                }
                else
                {
                    carName.Background = Brushes.White;
                }

                if (string.IsNullOrEmpty(carModel.Text) || string.IsNullOrWhiteSpace(carModel.Text))
                {
                    carModel.Background = Brushes.Red;
                }
                else
                {
                    carModel.Background = Brushes.White;
                }

                if (string.IsNullOrEmpty(carShortReview.Text) || string.IsNullOrWhiteSpace(carShortReview.Text))
                {
                    carShortReview.Background = Brushes.Red;
                }
                else
                {
                    carShortReview.Background = Brushes.White;
                }

                if (string.IsNullOrEmpty(carColor.Text) || string.IsNullOrWhiteSpace(carColor.Text))
                {
                    carColor.Background = Brushes.Red;
                }
                else
                {
                    carColor.Background = Brushes.White;
                }

                if (string.IsNullOrEmpty(carImage.Text) || string.IsNullOrWhiteSpace(carImage.Text))
                {
                    carImage.Background = Brushes.Red;
                }
                else
                {
                    carImage.Background = Brushes.White;
                }
            }
        }

        public Car GetCar
        {
            get { return car; }
        }
    }
}
