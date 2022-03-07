using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using Scanner.Model;
using System.Windows.Input;
using System.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace Scanner.ViewModel
{
    public class ScannerViewModel : INotifyPropertyChanged
    {
        private CollectionViewSource ScannerItemsCollection;
        public ICollectionView ScannerSourceCollection => ScannerItemsCollection.View;

        TitulService ObjTitulService;
        ObservableCollection<Titul> _collection;
        public ObservableCollection<Titul> Collection { get { return _collection; } set { _collection = value; OnPropertyChanged(nameof(Collection)); } }
        public ScannerViewModel()
        {
            ObjTitulService = new TitulService();
            LoadData();
            //collection = new ObservableCollection<Titul>(ObjTitulService.GetTituls());
            Collection = new ObservableCollection<Titul>(Tituls);
            ScannerItemsCollection = new CollectionViewSource { Source = Collection };
            MessageBox.Show(Collection[0].FirstMainScienceQuestions[0].KeyA.ToString(), "ScannerView");
            LoadData();
        }

        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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

        // DeleteAll button Command
        private ICommand _deleteAllTitulsCommand;
        public ICommand DeleteAllTitulsCommand
        {
            get
            {
                if (_deleteAllTitulsCommand == null)
                {
                    //MessageBox.Show("_deleteAllCommand == null");
                    _deleteAllTitulsCommand = new RelayCommand(param => { ShowDeleteAll(); });
                }
                OnPropertyChanged("Tituls");
                return _deleteAllTitulsCommand;
            }
        }

        private void ShowDeleteAll()
        {
            MessageBox.Show("DeleteAll in ScannerViewModel");
        }

        // Delete button Command
        private ICommand _deleteTitulCommand;
        public ICommand DeleteTitulCommand
        {
            get
            {
                if (_deleteTitulCommand == null)
                {
                    _deleteTitulCommand = new RelayCommand(param => { ShowDelete(param); });
                }
                return _deleteTitulCommand;
            }
        }

        private void ShowDelete(object param)
        {
            MessageBox.Show(_selectedIndexCommand.ToString() + " " + Tituls.Count.ToString(), "Delete in ScannerViewModel");
            if (_selectedIndexCommand != null && Tituls.Count != 0)
            {
                string buff = string.Empty;
                foreach (Titul titul in Tituls)
                {
                    buff += titul.FileName + " " + titul.TitulId + " " + titul.StudentId + " " + titul.AddedDateTime + " " + titul.TitulScanStatus + "\n";
                }
                MessageBox.Show(buff, "Jami Element(Delete in ScannerViewModel)");
                buff = String.Empty;

                Collection.Remove((Titul)param);

                //ObjTitulService.DeleteTitul((int)_selectedIndexCommand);
                foreach (Titul titul in Tituls)
                {
                    buff += titul.FileName + " " + titul.TitulId + " " + titul.StudentId + " " + titul.AddedDateTime + " " + titul.TitulScanStatus + "\n";
                }
                ScannerItemsCollection.View.Refresh();
                MessageBox.Show(buff, "Qolgan Element(Delete in ScannerViewModel)");
            }
            ScannerItemsCollection.View.Refresh();
        }


        private int _selectedIndexCommand;
        public int SelectedIndexCommand
        {
            get { return (int)_selectedIndexCommand; }
            set { _selectedIndexCommand = value; }
        }

        private void ShowSelectedItems()
        {
            MessageBox.Show("SelectedItemsFunc");
        }
    }
}
