using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
                Name = name_textBox.Text,
                Age = age_textBox.Text,
                Work_Years = years_textBox.Text
            };
            workers.Add(work);
        }

        private async void change_bt_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (workers.Count > 0 )
            {
                foreach (var item in workers)
                {
                    if (item.Name.ToLower() == search_textBox.Text.ToLower())
                    {
                        item.Work_Years = newYears_textBox.Text;
                    }
                    else
                    {
                        var message = new MessageDialog("Check no such person!");
                        await message.ShowAsync();
                    }
                }
            }
        }
    }
}
