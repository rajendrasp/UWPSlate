using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBind.Models
{
    public class Worker:INotifyPropertyChanged//继承属性通知接口
    {
        //Demo中，只实现Years的属性通知
        private string name;
        public string Name 
        {
            get { return name; }
            set {
                name = value;
                NotifyPropertyChanged("Name");
            }
            
        }

        private string age;
        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                NotifyPropertyChanged("Age");
            }
        }

        private string years;
        public string Work_Years
        {
            get => years;
            set
            {
                years = value;
                NotifyPropertyChanged("Work_Years");
            }
        }

        //实现属性通知
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
