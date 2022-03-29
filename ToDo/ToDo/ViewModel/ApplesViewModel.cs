using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ToDo.Model;
using ToDo.View;

namespace ToDo.ViewModel
{
    public class ApplesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ApplesListViewModel ApplesLVM;

        public Apples Apples { get; private set; }

        public ApplesViewModel() => Apples = new Apples();

        public ApplesListViewModel ListViewModel
        {
            get { return ApplesLVM; }
            set
            {
                if (ApplesLVM != value)
                {
                    ApplesLVM = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string Sort
        {
            get { return Apples.Sort; }
            set
            {
                if (Apples.Sort != value)
                {
                    Apples.Sort = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Color
        {
            get { return Apples.Color; }
            set
            {
                if (Apples.Color != value)
                {
                    Apples.Color = value;
                    OnPropertyChanged("Group");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Sort.Trim())) ||
                    (!string.IsNullOrEmpty(Color.Trim())));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
