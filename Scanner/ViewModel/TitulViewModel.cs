using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Scanner.Model;
using System.ComponentModel;
namespace Scanner.ViewModel
{
    public class TitulViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        /*
        TitulService ObjTitulService;
        
        public TitulViewModel()
        {
            ObjTitulService = new TitulService();
            LoadData();
        }
        
        private List<Titul> _tituls;
        public List<Titul> Tituls
        {
            get { return _tituls; }
            set { _tituls = value; OnPropertyChanged("Tituls"); }
        }
        private void LoadData()
        {
            Tituls = ObjTitulService.GetTituls();
        }
        */
    }
}
