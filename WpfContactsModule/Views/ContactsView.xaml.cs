using System.Windows.Controls;
using WpfContactsModule.ViewModels;

namespace WpfContactsModule.Views
{
    public partial class ContactsView : UserControl
    {
        public ContactsView(ContactsViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
