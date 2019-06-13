using APBDProject.Views;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace APBDProject
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Car> listOfCars;
        DatabaseModel context;

        public MainWindow()
        {
            InitializeComponent();
            context = new DatabaseModel();
            if (CheckConnection())
            {
                GetCars(context);
            } else
            {
                MessageBox.Show("Database is not available at the moment. Check your connection");
            }
               
        }

        public void GetCars(DatabaseModel context)
        {
            var cars = context.Cars.ToList();
            listOfCars = new ObservableCollection<Car>(cars);
            carsListBox.ItemsSource = listOfCars;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                if(CheckConnection())
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
                } else
                {
                    MessageBox.Show("Sorry, seems like it is not possible to connect to DB at the moment");
                }
     
               
            }
        }

        private void MenuItem_Add_Car_Click(object sender, RoutedEventArgs e)
        {
            if (CheckConnection())
            {
                AddCar addCarWindow = new AddCar();
                Car car = null;
                if (addCarWindow.ShowDialog() == false)
                {
                    if (addCarWindow.car != null)
                    {
                        car = addCarWindow.GetCar;
                        listOfCars.Add(car);
                        AddCarToDB(car);
                    }
                }
            } else
            {
                MessageBox.Show("Sorry, seems like it is not possible to connect to DB at the moment");
            }
        }

        private void MenuItem_Add_Owner_Click(object sender, RoutedEventArgs e)
        {
            if (CheckConnection())
            {
                AddNewOwner addOwnerWindow = new AddNewOwner();
                CarOwner owner = null;
                if (addOwnerWindow.ShowDialog() == false)
                {
                    if (addOwnerWindow.owner != null)
                    {
                        owner = addOwnerWindow.GetOwner;
                        AddOwnerToDB(owner);
                    }
                }
            }
            else
            {
                MessageBox.Show("Sorry, seems like it is not possible to connect to DB at the moment");
            }
        }

        private void AddCarToDB(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();   
        }

        private void AddOwnerToDB(CarOwner carOwner)
        {
            context.CarOwners.Add(carOwner);
            context.SaveChanges();
        }

        public bool CheckConnection()
        {
            try
            {
                context.Database.Connection.Open();
                context.Database.Connection.Close();
            }
            catch (SqlException)
            {
                return false;
            }
            return true;
        }
    }


}