using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BAL.Interfaces;
using BAL.Models;
using Дизайн.Util;
using BBL.Interfaces;
using BAL.Servises;
using BBL.Servises;
using View.Util;
using Дизайн.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using View;
using BLL.Models;
using BBL.Models;

namespace View.ViewModel
{
    public class AuthViewModel : INotifyPropertyChanged
    {
        private readonly IDbCrud _crud;
        private readonly ICategoryService _categoryService;
        private readonly ICatalogService _catalogService;
        private readonly IOrderService _orderService;
        private readonly IDialogService _dialogService;
        private readonly IProfileService _profileService;

        public delegate void DialogHandler();
        public event DialogHandler Notify;

        public AuthViewModel(IDbCrud dbCrud, ICategoryService categoryService, ICatalogService productCatalogService, IOrderService orderService, IDialogService dialogService, IProfileService profileService)
        {
            _crud = dbCrud;
            _categoryService = categoryService;
            _catalogService = productCatalogService;
            _dialogService = dialogService;
            _profileService = profileService;
            _orderService = orderService;

            LoginColor = "#FF160025";
            UserLogin = "";
            PasswordColor = "#FF160025";
            UserPassword = "";

            FirstPageVisibility = "Hidden";
            SecondPageVisibility = "Hidden";
            MessageVisibility = "Hidden";

            NewUserPassword = "";
            NewPasswordColor = "#FF160025";
            NewUserLogin = "";
            NewLoginColor = "#FF160025";
            UserPasswordRepeat = "";
            PasswordColorRepeat = "#FF160025";
            Email = "";
            Name = "";
            Surname = "";
            EmailColor = "#FF160025";
            NameColor = "#FF160025";
            SurnameColor = "#FF160025";
        }

        #region Авторизация
        private ICommand _сheckLoginPassword;
        public ICommand CheckLoginPassword
        {
            get
            {
                if (_сheckLoginPassword == null)
                    _сheckLoginPassword = new RelayCommand(args => Check(args));
                return _сheckLoginPassword;
            }
        }
        private void Check(object args)
        {
            if (UserLogin == "")
            {
                LoginColor = "#D30028";
                LoginAssist = "Обязательное поле";
                return;
            }
            else
            {
                LoginColor = "#FF160025";
                LoginAssist = null;
            }

            if (_profileService.CheckLogin(UserLogin) == false)
            {
                LoginColor = "#D30028";
                LoginAssist = "Логин не существует";
                return;
            }
            else
            {
                LoginColor = "#FF160025";
                LoginAssist = null;
            }

            if (UserPassword == "")
            {
                PasswordColor = "#D30028";
                PasswordAssist = "Обязательное поле";
                return;
            }
            else
            {
                PasswordColor = "#FF160025";
                PasswordAssist = null;
            }

            if (_profileService.CheckPassword(UserLogin, UserPassword) == false)
            {
                PasswordColor = "#D30028";
                PasswordAssist = "Пароль неверный";
                return;
            }
            else
            {
                PasswordColor = "#FF160025";
                PasswordAssist = null;
            }

            int UserId = _profileService.GetUserId(UserLogin);
            _dialogService.OpenCatalogWindow(_crud, _categoryService, _catalogService, _orderService, _dialogService, _profileService, UserId);
            Notify?.Invoke();
        }

        private string _LoginAssist;
        public string LoginAssist
        {
            get
            {
                return _LoginAssist;
            }
            set
            {
                _LoginAssist = value;
                NotifyPropertyChanged("LoginAssist");
            }
        }

        private string _LoginColor;
        public string LoginColor
        {
            get
            {
                return _LoginColor;
            }
            set
            {
                _LoginColor = value;
                NotifyPropertyChanged("LoginColor");
            }
        }

        private string _UserLogin;
        public string UserLogin
        {
            get
            {
                return _UserLogin;
            }
            set
            {
                _UserLogin = value;
                NotifyPropertyChanged("UserLogin");
            }
        }

        private string _PasswordAssist;
        public string PasswordAssist
        {
            get
            {
                return _PasswordAssist;
            }
            set
            {
                _PasswordAssist = value;
                NotifyPropertyChanged("PasswordAssist");
            }
        }

        private string _PasswordColor;
        public string PasswordColor
        {
            get
            {
                return _PasswordColor;
            }
            set
            {
                _PasswordColor = value;
                NotifyPropertyChanged("PasswordColor");
            }
        }

        private string _UserPassword;
        public string UserPassword
        {
            get
            {
                return _UserPassword;
            }
            set
            {
                _UserPassword = value;
                NotifyPropertyChanged("UserPassword");
            }
        }
        #endregion

        #region Регистрация
        private ICommand _registerNewUser;
        public ICommand RegisterNewUser
        {
            get
            {
                if (_registerNewUser == null)
                    _registerNewUser = new RelayCommand(args => Continue(args));
                return _registerNewUser;
            }
        }
        private void Continue(object args)
        {
            if (NewUserLogin == "")
            {
                NewLoginColor = "#D30028";
                NewLoginAssist = "Обязательное поле";
                return;
            }
            else
            {
                NewLoginColor = "#FF160025";
                NewLoginAssist = null;
            }

            if (_profileService.CheckLogin(NewUserLogin) == true)
            {
                NewLoginColor = "#D30028";
                NewLoginAssist = "Логин уже используется";
                return;
            }
            else
            {
                NewLoginColor = "#FF160025";
                NewLoginAssist = null;
            }

            if (NewUserPassword == "")
            {
                NewPasswordColor = "#D30028";
                NewPasswordAssist = "Обязательное поле";
                return;
            }
            else
            {
                NewPasswordColor = "#FF160025";
                NewPasswordAssist = null;
            }

            if (NewUserPassword == "")
            {
                NewPasswordColor = "#D30028";
                NewPasswordAssist = "Обязательное поле";
                return;
            }
            else
            {
                NewPasswordColor = "#FF160025";
                NewPasswordAssist = null;
            }

            if (UserPasswordRepeat == "")
            {
                PasswordColorRepeat = "#D30028";
                PasswordAssistRepeat = "Обязательное поле";
                return;
            }
            else
            {
                PasswordColorRepeat = "#FF160025";
                PasswordAssistRepeat = null;
            }

            if (NewUserPassword != UserPasswordRepeat)
            {
                NewPasswordColor = "#D30028";
                NewPasswordAssist = "Пароли не совпадают";
                PasswordColorRepeat = "#D30028";
                PasswordAssistRepeat = "Пароли не совпадают";
                return;
            }
            else
            {
                NewPasswordColor = "#FF160025";
                NewPasswordAssist = null;
                PasswordColorRepeat = "#FF160025";
                PasswordAssistRepeat = null;
            }

            SecondPageVisibility = "Visible";
        }

        private ICommand _endRegisterNewUser;
        public ICommand EndRegisterNewUser
        {
            get
            {
                if (_endRegisterNewUser == null)
                    _endRegisterNewUser = new RelayCommand(args => EndRegister(args));
                return _endRegisterNewUser;
            }
        }
        private void EndRegister(object args)
        {
            if (Email == "")
            {
                EmailColor = "#D30028";
                EmailAssist = "Обязательное поле";
                return;
            }
            else
            {
                EmailColor = "#FF160025";
                EmailAssist = null;
            }

            if (Name == "")
            {
                NameColor = "#D30028";
                NameAssist = "Обязательное поле";
                return;
            }
            else
            {
                NameColor = "#FF160025";
                NameAssist = null;
            }

            if (Surname == "")
            {
                SurnameColor = "#D30028";
                SurnameAssist = "Обязательное поле";
                return;
            }
            else
            {
                SurnameColor = "#FF160025";
                SurnameAssist = null;
            }

            FirstPageVisibility = "Hidden";
            SecondPageVisibility = "Hidden";
            MessageVisibility = "Visible";

            _crud.CreateBuyer(new BuyerModel
            {

                Login = this.NewUserLogin,
                Name = this.Surname + " " + this.Name,
                Password = this.NewUserPassword,
                Email = this.Email
            })
            
               
             ;

            Email = "";
            NewUserLogin = "";
            NewUserPassword = "";
            Name = "";
        }

        private ICommand _registration;
        public ICommand Registration
        {
            get
            {
                if (_registration == null)
                    _registration = new RelayCommand(args => Registrate(args));
                return _registration;
            }
        }
        private void Registrate(object args)
        {
            FirstPageVisibility = "Visible";
        }

        private ICommand _backToAuth;
        public ICommand BackToAuth
        {
            get
            {
                if (_backToAuth == null)
                    _backToAuth = new RelayCommand(args => GoBack(args));
                return _backToAuth;
            }
        }
        private void GoBack(object args)
        {
            FirstPageVisibility = "Hidden";
        }

        private ICommand _backToFirst;
        public ICommand BackToFirst
        {
            get
            {
                if (_backToFirst == null)
                    _backToFirst = new RelayCommand(args => BackToFistPage(args));
                return _backToFirst;
            }
        }
        private void BackToFistPage(object args)
        {
            SecondPageVisibility = "Hidden";
        }

        private ICommand _back;
        public ICommand Back
        {
            get
            {
                if (_back == null)
                    _back = new RelayCommand(args => BackToAuthen(args));
                return _back;
            }
        }
        private void BackToAuthen(object args)
        {
            MessageVisibility = "Hidden";
        }

        private string _FirstPageVisibility;
        public string FirstPageVisibility
        {
            get
            {
                return _FirstPageVisibility;
            }
            set
            {
                _FirstPageVisibility = value;
                NotifyPropertyChanged("FirstPageVisibility");
            }
        }

        private string _MessageVisibility;
        public string MessageVisibility
        {
            get
            {
                return _MessageVisibility;
            }
            set
            {
                _MessageVisibility = value;
                NotifyPropertyChanged("MessageVisibility");
            }
        }
        private string _SecondPageVisibility;
        public string SecondPageVisibility
        {
            get
            {
                return _SecondPageVisibility;
            }
            set
            {
                _SecondPageVisibility = value;
                NotifyPropertyChanged("SecondPageVisibility");
            }
        }

        private string _NewLoginAssist;
        public string NewLoginAssist
        {
            get
            {
                return _NewLoginAssist;
            }
            set
            {
                _NewLoginAssist = value;
                NotifyPropertyChanged("NewLoginAssist");
            }
        }

        private string _NewLoginColor;
        public string NewLoginColor
        {
            get
            {
                return _NewLoginColor;
            }
            set
            {
                _NewLoginColor = value;
                NotifyPropertyChanged("NewLoginColor");
            }
        }

        private string _NewUserLogin;
        public string NewUserLogin
        {
            get
            {
                return _NewUserLogin;
            }
            set
            {
                _NewUserLogin = value;
                NotifyPropertyChanged("NewUserLogin");
            }
        }

        private string _NewPasswordAssist;
        public string NewPasswordAssist
        {
            get
            {
                return _NewPasswordAssist;
            }
            set
            {
                _NewPasswordAssist = value;
                NotifyPropertyChanged("NewPasswordAssist");
            }
        }

        private string _NewPasswordColor;
        public string NewPasswordColor
        {
            get
            {
                return _NewPasswordColor;
            }
            set
            {
                _NewPasswordColor = value;
                NotifyPropertyChanged("NewPasswordColor");
            }
        }

        private string _NewUserPassword;
        public string NewUserPassword
        {
            get
            {
                return _NewUserPassword;
            }
            set
            {
                _NewUserPassword = value;
                NotifyPropertyChanged("NewUserPassword");
            }
        }

        private string _PasswordAssistRepeat;
        public string PasswordAssistRepeat
        {
            get
            {
                return _PasswordAssistRepeat;
            }
            set
            {
                _PasswordAssistRepeat = value;
                NotifyPropertyChanged("PasswordAssistRepeat");
            }
        }

        private string _PasswordColorRepeat;
        public string PasswordColorRepeat
        {
            get
            {
                return _PasswordColorRepeat;
            }
            set
            {
                _PasswordColorRepeat = value;
                NotifyPropertyChanged("PasswordColorRepeat");
            }
        }

        private string _UserPasswordRepeat;
        public string UserPasswordRepeat
        {
            get
            {
                return _UserPasswordRepeat;
            }
            set
            {
                _UserPasswordRepeat = value;
                NotifyPropertyChanged("UserPasswordRepeat");
            }
        }

        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                NotifyPropertyChanged("Email");
            }
        }

        private string _EmailColor;
        public string EmailColor
        {
            get
            {
                return _EmailColor;
            }
            set
            {
                _EmailColor = value;
                NotifyPropertyChanged("EmailColor");
            }
        }

        private string _EmailAssist;
        public string EmailAssist
        {
            get
            {
                return _EmailAssist;
            }
            set
            {
                _EmailAssist = value;
                NotifyPropertyChanged("EmailAssist");
            }
        }

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string _NameColor;
        public string NameColor
        {
            get
            {
                return _NameColor;
            }
            set
            {
                _NameColor = value;
                NotifyPropertyChanged("NameColor");
            }
        }

        private string _NameAssist;
        public string NameAssist
        {
            get
            {
                return _NameAssist;
            }
            set
            {
                _NameAssist = value;
                NotifyPropertyChanged("NameAssist");
            }
        }

        private string _Surname;
        public string Surname
        {
            get
            {
                return _Surname;
            }
            set
            {
                _Surname = value;
                NotifyPropertyChanged("Surname");
            }
        }

        private string _SurnameColor;
        public string SurnameColor
        {
            get
            {
                return _SurnameColor;
            }
            set
            {
                _SurnameColor = value;
                NotifyPropertyChanged("SurnameColor");
            }
        }

        private string _SurnameAssist;
        public string SurnameAssist
        {
            get
            {
                return _SurnameAssist;
            }
            set
            {
                _SurnameAssist = value;
                NotifyPropertyChanged("SurnameAssist");
            }
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
