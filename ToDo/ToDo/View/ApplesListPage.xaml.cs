using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDo.Model;
using ToDo.ViewModel;

namespace ToDo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplesListPage : ContentPage
    {
        public ApplesListPage()
        {
            InitializeComponent();
            BindingContext = new ApplesListViewModel { Navigation = this.Navigation };
        }
    }
}