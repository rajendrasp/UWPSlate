using SDKTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using XBind.Models;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace XBind.View
{
    public sealed partial class ContactControl : UserControl, System.ComponentModel.INotifyPropertyChanged
    {
        public ContactControl()
        {
            this.InitializeComponent();
        }

        private Contact _ViewModel;

        public Contact ViewModel
        {
            get { return _ViewModel; }
            set
            {
                _ViewModel = value;
                // Call NotifyPropertyChanged when the source property 
                // is updated.
                NotifyPropertyChanged("ViewModel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // NotifyPropertyChanged will fire the PropertyChanged event, 
        // passing the source property that is being updated.
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
