using Microsoft.Win32;
using Scanner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Scanner.ViewModel
{
    public class NavigationViewModel : INotifyPropertyChanged
    {
        // CollectionViewSource enables XAML code to set the commonly used CollectionView properties,
        // passing these settings to the underlying view.
        private CollectionViewSource MenuItemsCollection;

        // ICollectionView enables collections to have the functionalities of current record management,
        // custom sorting, filtering, and grouping.
        public ICollectionView SourceCollection => MenuItemsCollection.View;

        public NavigationViewModel()
        {
            // ObservableCollection represents a dynamic data collection that provides notifications when items
            // get added, removed, or when the whole list is refreshed.
            ObservableCollection<MenuItems> menuItems = new ObservableCollection<MenuItems>
            {
                new MenuItems { MenuName = "Home", MenuImage = @"../Images/Home_Icon.png" }, // MenuImage = @"../Images/Home_Icon.png" bu Path Project folderdan o'qiydi
                new MenuItems { MenuName = "Settings", MenuImage = @"../Images/services_icon.png" } // MenuImage = @"Images/Home_Icon.png" bu esa Style qaysi papkadan bo'lsa ichidan qidiradi.
            };

            MenuItemsCollection = new CollectionViewSource { Source = menuItems };
            //MenuItemsCollection.Filter += MenuItems_Filter;

            // Set Startup Page
            SelectedViewModel = new TitulViewModel();
        }

        // Implement interface number for INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        // Select ViewModel
        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set { _selectedViewModel = value; OnPropertyChanged("SelectedViewModel");  }
        }

        // Switch Views
        public void SwitchViews(object parameter)
        {
            switch (parameter)
            {
                case "Home":
                    SelectedViewModel = new ScannerViewModel();
                    break;
                case "Settings":
                    SelectedViewModel = new SettingsViewModel();
                    break;
                default:
                    SelectedViewModel = new StartupViewModel();
                    break;
            }
        }

        
        // Menu Button Command
        private ICommand _menucommand;
        public ICommand MenuCommand
        {
            get
            {
                if (_menucommand == null)
                {
                    _menucommand = new RelayCommand(param => SwitchViews(param));
                }
                return _menucommand;
            }
        }
        
        // Show Home View
        private void ShowHome()
        {
            SelectedViewModel = new TitulViewModel();
        }

        
        // Show Setting View
        private void ShowSettings()
        {
            SelectedViewModel = new SettingsViewModel();
        }

        /*
        // Back button Command
        private ICommand _openFileDialogCommand;
        public ICommand OpenFileDialogCommand
        {
            get
            {
                if (_openFileDialogCommand == null)
                {
                    MessageBox.Show("_backHomeCommand == null");
                    _openFileDialogCommand = new RelayCommand(param => { ShowFileDialog(); });
                }
                return _openFileDialogCommand;
            }
        }

        private void ShowFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Image files (*.jpg)|*.jpg"
            };
            if (openFileDialog.ShowDialog() == true)
            {
            }
        }
        */

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
                return _deleteAllTitulsCommand;
            }
        }

        private void ShowDeleteAll()
        {
            MessageBox.Show("DeleteAll");
        }
    }
}
