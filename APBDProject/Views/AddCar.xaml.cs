using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
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
            CarOwner carOwner = (CarOwner)owners_list.SelectedItem;
            CarType carType = (CarType)car_types_list.SelectedItem;

            car = new Car { Manufacturer = carName.Text, Model = carModel.Text, Review = carShortReview.Text, Color = carColor.Text, Image = carImage.Text, ProductionYear = Int32.Parse(carYear.Text), IdCarType = carType.IdCarType, IdOwner = carOwner.IdOwner };
            Close();
        }

        public Car GetCar
        {
            get { return car; }
        }
    }
}
