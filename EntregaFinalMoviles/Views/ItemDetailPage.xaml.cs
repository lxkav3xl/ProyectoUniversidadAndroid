using appMoviles_Sabado.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace appMoviles_Sabado.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}