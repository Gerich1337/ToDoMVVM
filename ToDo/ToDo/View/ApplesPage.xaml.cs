using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDo.ViewModel;

namespace ToDo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplesPage : ContentPage
    {
        public ApplesViewModel ViewModel { get; private set; }
        public ApplesPage(ApplesViewModel applesViewModel)
        {
            InitializeComponent();
            ViewModel = applesViewModel;
            this.BindingContext = ViewModel;
        }
    }
}