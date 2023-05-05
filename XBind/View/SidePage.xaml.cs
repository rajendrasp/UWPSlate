using SDKTemplate;
using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace XBind.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SidePage : Page
    {
        public SidePage()
        {
            this.InitializeComponent();
            ContactsCVS.Source = Contact.GetContactsGrouped(25);
        }

        public List<Control> AllChildren(DependencyObject parent)
        {
            var _List = new List<Control>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _Child = VisualTreeHelper.GetChild(parent, i);
                if (_Child is Control)
                    _List.Add(_Child as Control);
                _List.AddRange(AllChildren(_Child));
            }
            return _List;
        }

        //private void gird_view_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        //{
        //    GridViewItem item = args.ItemContainer as GridViewItem;

        //    Random rand = new Random();
        //    int randomNum = rand.Next(10, 99);
        //    if (item != null && randomNum > 50)
        //    {
        //        item.IsEnabled = false;
        //    }
        //    else
        //    {
        //        item.IsEnabled = true;
        //    }





        //    //await Task.Delay(5000);
        //    //var _Container = gird_view.ContainerFromItem(item);
        //    //if (_Container == null)
        //    //{
        //    //    return;
        //    //}





        //    //var _Children = AllChildren(item);
        //    //if (_Children == null)
        //    //{
        //    //    return;
        //    //}

        //    //var itemsToDisable = _Children
        //    //        .FindAll(x => x.Name.Equals("MyContentContact") || x.Name.Equals("MyRPanel"));

        //    //Random rand = new Random();
        //    //int randomNum = rand.Next(10, 99);
        //    //if (item != null && randomNum > 50)
        //    //{
        //    //    foreach (var itemToDisable in itemsToDisable)
        //    //    {
        //    //        itemToDisable.IsEnabled = false;
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    foreach (var itemToDisable in itemsToDisable)
        //    //    {
        //    //        itemToDisable.IsEnabled = true;
        //    //    }
        //    //}
        //}
    }
}
