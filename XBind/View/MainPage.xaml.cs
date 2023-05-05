using SDKTemplate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using XBind.Models;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace XBind
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Worker> workers;//之所以使用ObservableCollection而不是List，因为前者支持UI动态变化
        public MainPage()
        {
            this.InitializeComponent();
            workers = new ObservableCollection<Worker>();

        }

        private void add_bt_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var work = new Worker
            {
                MyName_First = name_textBox.Text,
                MyAge_Years = age_textBox.Text,
                MyWork_Years = years_textBox.Text
            };
            workers.Add(work);
        }

        private async void change_bt_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (workers.Count > 0)
            {
                foreach (var item in workers)
                {
                    if (item.MyName_First.ToLower() == search_textBox.Text.ToLower())
                    {
                        item.MyWork_Years = newYears_textBox.Text;
                    }
                    else
                    {
                        var message = new MessageDialog("Check no such person!");
                        await message.ShowAsync();
                    }
                }
            }
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

        private void gird_view_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            GridViewItem item = args.ItemContainer as GridViewItem;

            //Random rand = new Random();
            //int randomNum = rand.Next(10, 99);
            //if (item != null && randomNum > 50)
            //{
            //    item.IsEnabled = false;
            //}
            //else
            //{
            //    item.IsEnabled = true;
            //}

            //await Task.Delay(5000);
            //var _Container = gird_view.ContainerFromItem(item);
            //if (_Container == null)
            //{
            //    return;
            //}

            var _Children = AllChildren(item);
            if (_Children == null)
            {
                return;
            }

            var itemsToDisable = _Children
                    .FindAll(x => x.Name.Equals("MyWorker") || x.Name.Equals("MyRPanel"));

            Random rand = new Random();
            int randomNum = rand.Next(10, 99);
            if (item != null && randomNum > 50)
            {
                foreach (var itemToDisable in itemsToDisable)
                {
                    itemToDisable.IsEnabled = false;
                }
            }
            else
            {
                foreach (var itemToDisable in itemsToDisable)
                {
                    itemToDisable.IsEnabled = true;
                }
            }
        }
    }
}
