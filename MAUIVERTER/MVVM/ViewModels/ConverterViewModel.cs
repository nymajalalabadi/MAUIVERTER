using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace MAUIVERTER.MVVM.ViewModels
{
    public class ConverterViewModel
    {
        #region Consractors

        public ConverterViewModel()
        {
            QuanityName = "Length"; // Default quantity
            FormMeasures = loadMeasures();
            ToMeasures = loadMeasures();
            CurrentFormMeasure = "Meter"; // Default from measure
            CurrentToMeasure = "Centimeter"; // Default to measure
        }

        #endregion

        public string QuanityName { get; set; }

        public ObservableCollection<string> FormMeasures { get; set; }

        public ObservableCollection<string> ToMeasures { get; set; }

        public string CurrentFormMeasure { get; set; }

        public string CurrentToMeasure { get; set; }



        private ObservableCollection<string> loadMeasures()
        {
            var types = Quantity.Infos.FirstOrDefault(x => x.Name == QuanityName)
                .UnitInfos.Select(x => x.Name)
                .ToList();

            return new ObservableCollection<string>(types);
        }


    }
}
