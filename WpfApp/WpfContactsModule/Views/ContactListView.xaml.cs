using System.Windows.Controls;
using WpfContactsModule.ViewModels;

namespace WpfContactsModule.Views
{
    public partial class ContactListView : UserControl
    {
        public ContactListView(ContactListViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
