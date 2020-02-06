using APP_TestProgrammer.Model;
using APP_TestProgrammer.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace APP_TestProgrammer.ViewModel
{
    public class Dashboard_ViewModel : BaseViewModel
    {
        #region Service
        private readonly ApiService service;
        #endregion
        #region Atributos
        private bool isLoading;
        private double dato;
        private double Resultado;
        private ObservableCollection<Employees> listEmployees;
        private ObservableCollection<Profile> listProfile;
        private ObservableCollection<Position> listPosition;
        #endregion

        #region Propiedades
        public ObservableCollection<Employees> ListEmployees
        {
            get => listEmployees;
            set => this.SetValue(ref this.listEmployees, value);
        }public ObservableCollection<Profile> ListProfile
        {
            get => listProfile;
            set => this.SetValue(ref this.listProfile, value);
        }public ObservableCollection<Position> ListPosition
        {
            get => listPosition;
            set => this.SetValue(ref this.listPosition, value);
        }

        public bool IsLoading
        {
            get => this.isLoading;
            set => this.SetValue(ref this.isLoading, value);

        }
        public double Datos
        {
            get => this.dato;
            set => this.SetValue(ref this.dato, value);

        }
        public bool IsLoading
        {
            get => this.isLoading;
            set => this.SetValue(ref this.isLoading, value);

        }


        #endregion

        #region Constructor
        public Dashboard_ViewModel()
        {
            this.service = new ApiService();
            LoadPosition();
            LoadProfile();
            LoadEmployees();
            LoadList();

        }
        #endregion

        #region Method

        public  void LoadList()
        {
            this.ListEmployees = new ObservableCollection<Employees>();
           
            foreach (var item in this.ListEmployees)
            {
                var Position = MainViewModel.GetInstance().List_Position
                    .Where(I => I.positionID == item.positionID).FirstOrDefault();
                var Profile = MainViewModel.GetInstance().List_Profile
                    .Where(I => I.profileID == item.profileID).FirstOrDefault();
                if (Position != null && Profile != null)
                {
                    item.Profile = Profile;
                    item.Position = Position;
                }
            }
        }
        #region Employees
        public async void LoadEmployees()
        {
            try
            {
                this.IsLoading = true;
                var connetion = await this.service.CheckConnection();

                if (!connetion.IsSuccess)
                {
                    this.IsLoading = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "error",
                        connetion.Message,
                        "aceptar");
                    return;
                }

                var url = Application.Current.Resources["UrlAPI"].ToString();
                var prefix = Application.Current.Resources["UrlPrefix"].ToString();
                var response = await this.service.GetList<Employees>(url, prefix, "/API_Employees");

                if (!response.IsSuccess)
                {
                    this.isLoading = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "todo bien",
                        response.Message,
                        "Aceptar");
                    return;
                }
                MainViewModel.GetInstance().List_Employees = (List<Employees>)response.Result;
                this.ListEmployees = new ObservableCollection<Employees>(
                this.Employees_MV());

                this.IsLoading = false;
            }
            catch (Exception ex)
            {

                Application.Current.MainPage.DisplayAlert("Error", ex.ToString(), "Aceptar");
            }

            
        }
        private IEnumerable<Employees> Employees_MV()
        {
            return MainViewModel.GetInstance().List_Employees.Select(
                Emp => new Employees
                {
                    employeeID = Emp.employeeID,
                    employeeName = Emp.employeeName,
                    positionID = Emp.positionID,
                    profileID = Emp.profileID,
                     Position = Emp.Position,
                     Profile = Emp.Profile
                });

        }
        #endregion

        #region Profile
        public async void LoadProfile()
        {
            try
            {
                this.IsLoading = true;
                var connetion = await this.service.CheckConnection();

                if (!connetion.IsSuccess)
                {
                    this.IsLoading = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "error",
                        connetion.Message,
                        "aceptar");
                    return;
                }

                var url = Application.Current.Resources["UrlAPI"].ToString();
                var prefix = Application.Current.Resources["UrlPrefix"].ToString();
                var response = await this.service.GetList<Profile>(url, prefix, "/API_Employees");

                if (!response.IsSuccess)
                {
                    this.isLoading = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "todo bien",
                        response.Message,
                        "Aceptar");
                    return;
                }
                MainViewModel.GetInstance().List_Profile = (List<Profile>)response.Result;
                this.ListProfile = new ObservableCollection<Profile>(
                this.Profile_MV());

                this.IsLoading = false;
            }
            catch (Exception ex)
            {

                Application.Current.MainPage.DisplayAlert("Error", ex.ToString(), "Aceptar");
            }


        }
        private IEnumerable<Profile>Profile_MV()
        {
            return MainViewModel.GetInstance().List_Profile.Select(
                Pf => new Profile
                {
                    profileID = Pf.profileID,
                     profileName = Pf.profileName
                    
                });

        }
        #endregion

        #region Profile
        public async void LoadPosition()
        {
            try
            {
                this.IsLoading = true;
                var connetion = await this.service.CheckConnection();

                if (!connetion.IsSuccess)
                {
                    this.IsLoading = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "error",
                        connetion.Message,
                        "aceptar");
                    return;
                }

                var url = Application.Current.Resources["UrlAPI"].ToString();
                var prefix = Application.Current.Resources["UrlPrefix"].ToString();
                var response = await this.service.GetList<Position>(url, prefix, "/API_Employees");

                if (!response.IsSuccess)
                {
                    this.isLoading = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "todo bien",
                        response.Message,
                        "Aceptar");
                    return;
                }
                MainViewModel.GetInstance().List_Position = (List<Position>)response.Result;
                this.ListPosition = new ObservableCollection<Position>(
                this.Position_MV());

                this.IsLoading = false;
            }
            catch (Exception ex)
            {

                Application.Current.MainPage.DisplayAlert("Error", ex.ToString(), "Aceptar");
            }


        }
        private IEnumerable<Position> Position_MV()
        {
            return MainViewModel.GetInstance().List_Position.Select(
                PS => new Position
                {
                     positionID = PS.positionID,
                     positionName = PS.positionName

                });

        }
        #endregion

        #endregion
        #region Command

        #endregion
    }
}
