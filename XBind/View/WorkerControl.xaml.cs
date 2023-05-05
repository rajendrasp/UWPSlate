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
    public sealed partial class WorkerControl : UserControl, System.ComponentModel.INotifyPropertyChanged
    {
        public WorkerControl()
        {
            this.InitializeComponent();
        }

        private Worker _ViewModel;

        public Worker ViewModel
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

    public sealed partial class DevicesGridItemContainerStyleSelector : Windows.UI.Xaml.Controls.StyleSelector
    {
        public Style EnabledDevicesStyle { get; set; }
        public Style DisabledDevicesStyle { get; set; }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            Contact contact = item as Contact;
            if (contact != null)
            {
                if (contact.IsShownAsEnabled)
                {
                    return EnabledDevicesStyle;
                }
                else
                {
                    return DisabledDevicesStyle;
                }
            }
            return EnabledDevicesStyle;
        }
    }
}
