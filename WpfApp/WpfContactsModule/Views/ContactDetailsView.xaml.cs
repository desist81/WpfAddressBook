using System.Windows.Controls;
using WpfContactsModule.ViewModels;

namespace WpfContactsModule.Views
{
    public partial class ContactDetailsView : UserControl
    {
        public ContactDetailsView(ContactDetailsViewModel viewModel) 
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
