using BAL.Interfaces;
using BBL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Util;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Input;
using View;

namespace Дизайн.ViewModel
{
    public class StatsViewModel : INotifyPropertyChanged
    {
        private readonly IDbCrud _crud;
        private readonly ICategoryService _categoryService;
        private readonly ICatalogService _catalogService;
        private readonly IDialogService _dialogService;
        private readonly IProfileService _profileService;
        private readonly int _userId;

        public StatsViewModel(IDbCrud dbCrud, ICategoryService categoryService, ICatalogService productCatalogService, IDialogService dialogService, IProfileService profileService, int userId)
        {
            _crud = dbCrud;
            _categoryService = categoryService;
            _catalogService = productCatalogService;
            _dialogService = dialogService;
            _profileService = profileService;
            _userId = userId;

            Year = 1;
            Statistic = new ChartValues<decimal>();

            Labels = new string[12] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

            Years = new List<string>();
            Years.Add("2020");
            Years.Add("2021");
            Years.Add("2022");

            Update(0);
        }

        public void Update(int nullable)
        {
            Statistic.Clear();
            var mon = _profileService.GetStats(_userId, Years[Year]);
            if (mon.Max() > 100)
            {
                Max = mon.Max();
            }
            else
            {
                Max = 100;
            }
            foreach (var i in mon)
            {
                Statistic.Add(i);
            }
        }

        private ICommand _changed;
        public ICommand Changed
        {
            get
            {
                if (_changed == null)
                    _changed = new RelayCommand(args => UpdateStat(0));
                return _changed;
            }
        }
        private void UpdateStat(object args)
        {
            Update(0);
        }

        private int _Year;
        public int Year
        {
            get
            {
                return _Year;
            }
            set
            {
                _Year = value;
                NotifyPropertyChanged("Year");
            }
        }

        public string[] Labels { get; set; }

        public List<string> Years { get; set; }

        private decimal _Max;
        public decimal Max
        {
            get
            {
                return _Max;
            }
            set
            {
                _Max = value;
                NotifyPropertyChanged("Max");
            }
        }

        private ChartValues<decimal> _Statistic;
        public ChartValues<decimal> Statistic
        {
            get
            {
                return _Statistic;
            }
            set
            {
                _Statistic = value;
                NotifyPropertyChanged("Statistics");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
