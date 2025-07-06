using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UnitsNet;

namespace MAUIVERTER.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ConverterViewModel
    {
        #region Consractors

        public ConverterViewModel(string quanityName)
        {
            QuanityName = quanityName; // Default quantity
            FromMeasures = loadMeasures();
            ToMeasures = loadMeasures();
            CurrentFromMeasure = FromMeasures.FirstOrDefault(); // Default from measure
            CurrentToMeasure = ToMeasures.Skip(1).FirstOrDefault(); // Default to measure
            Convert();
        }

        #endregion

        public string QuanityName { get; set; }

        public ObservableCollection<string> FromMeasures { get; set; }

        public ObservableCollection<string> ToMeasures { get; set; }

        public string CurrentFromMeasure { get; set; }

        public string CurrentToMeasure { get; set; }

        public double FromValue { get; set; } = 1;

        public double ToValue { get; set; }



        public ICommand ReturnCommand => new Command(() =>
        {
            Convert();
        });


        public void Convert()
        {
            var result = UnitConverter.ConvertByName(FromValue, QuanityName, CurrentFormMeasure, CurrentToMeasure);

            ToValue = result;
        }

        private ObservableCollection<string> loadMeasures()
        {
            var types = Quantity.Infos.FirstOrDefault(x => x.Name == QuanityName)
                .UnitInfos.Select(x => x.Name)
                .ToList();

            return new ObservableCollection<string>(types);
        }


    }
}
