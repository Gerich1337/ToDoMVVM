using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ToDo.Model;
using ToDo.View;

namespace ToDo.ViewModel
{
    public class ApplesListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ApplesViewModel> Apples { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateApplesCommand { protected set; get; }
        public ICommand DeleteApplesCommand { protected set; get; }
        public ICommand SaveApplesCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        ApplesViewModel selectedApple;

        public INavigation Navigation { get; set; }

        public ApplesListViewModel()
        {
            Apples = new ObservableCollection<ApplesViewModel>();
            CreateApplesCommand = new Command(CreateApples);
            DeleteApplesCommand = new Command(DeleteApples);
            SaveApplesCommand = new Command(SaveApples);
            BackCommand = new Command(Back);
        }
        public ApplesViewModel SelectedApple
        {
            get { return selectedApple; }
            set
            {
                if (selectedApple != value)
                {
                    ApplesViewModel tempStudent = value;
                    selectedApple = null;
                    OnPropertyChanged("SelectedApple");
                    Navigation.PushAsync(new ApplesPage(tempStudent));
                }
            }
        }

        private void CreateApples()
        {
            Navigation.PushAsync(new ApplesPage(new ApplesViewModel() { ListViewModel = this }));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private void SaveApples(object applesObj)
        {
            ApplesViewModel apples = applesObj as ApplesViewModel;
            if (apples != null && apples.IsValid && !Apples.Contains(apples))
            {
                Apples.Add(apples);
                Back();
            }
        }

        private void DeleteApples(object ApplesObject)
        {
            ApplesViewModel apples = ApplesObject as ApplesViewModel;
            if (apples != null)
            {
                Apples.Remove(apples);
                Back();
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
