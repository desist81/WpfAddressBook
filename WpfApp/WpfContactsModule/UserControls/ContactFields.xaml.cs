using ClientModel;
using DomainModel;
using Prism.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfContactsModule.UserControls
{
    /// <summary>
    /// Interaction logic for ContactFields.xaml
    /// </summary>
    public partial class ContactFields : UserControl, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<ContactFieldBindingEntity> _contactFieldCollection;
        public ContactFields()
        {
            this.DeleteContactFieldCommand = new DelegateCommand<object>(OnDeleteContactFieldExecute);
            this.AddContactFieldCommand = new DelegateCommand<object>(OnAddContactFieldExecute);
            InitializeComponent();

        }
        public DelegateCommand<object> AddContactFieldCommand { get; private set; }
        public DelegateCommand<object> DeleteContactFieldCommand { get; private set; }

        public static readonly DependencyProperty LabelStringProperty =
            DependencyProperty.Register(
            "LabelString",
            typeof(string),
            typeof(ContactFields));

        public static readonly DependencyProperty FieldTypeProperty =
           DependencyProperty.Register(
           "FieldType",
           typeof(string),
           typeof(ContactFields));

        public static readonly DependencyProperty DeleteFieldCommandProperty =
            DependencyProperty.Register(
            "DeleteFieldCommand",
            typeof(ICommand),
            typeof(ContactFields)
            );

        public static readonly DependencyProperty AddFieldCommandProperty =
           DependencyProperty.Register(
           "AddFieldCommand",
           typeof(ICommand),
           typeof(ContactFields)
           );


        public static readonly DependencyProperty ContactFieldSourceProperty =
        DependencyProperty.Register(
        "ContactFieldSource",
        typeof(ObservableCollection<ContactFieldBindingEntity>),
        typeof(ContactFields),
        new PropertyMetadata(null, OnContactFieldSourcePathPropertyChanged)
       );


        public string LabelString
        {
            get
            {
                return (string)this.GetValue(LabelStringProperty);
            }
            set
            {
                this.SetValue(LabelStringProperty, value);
            }
        }
        public string FieldType
        {
            get
            {
                return (string)this.GetValue(FieldTypeProperty);
            }
            set
            {
                this.SetValue(FieldTypeProperty, value);
            }
        }

        public ICommand DeleteFieldCommand
        {
            get
            {
                return (ICommand)this.GetValue(DeleteFieldCommandProperty);
            }
            set
            {
                this.SetValue(DeleteFieldCommandProperty, value);
            }
        }

        public ICommand AddFieldCommand
        {
            get
            {
                return (ICommand)this.GetValue(AddFieldCommandProperty);
            }
            set
            {
                this.SetValue(AddFieldCommandProperty, value);
            }
        }

        public ObservableCollection<ContactFieldBindingEntity> ContactFieldSource
        {
            get
            {
                return (ObservableCollection<ContactFieldBindingEntity>)this.GetValue(ContactFieldSourceProperty);
            }
            set
            {
                this.SetValue(ContactFieldSourceProperty, value);
            }
        }

        public ObservableCollection<ContactFieldBindingEntity> ContactFieldCollection
        {
            get
            {
                return (_contactFieldCollection);
            }
            set
            {

                _contactFieldCollection = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ContactFieldCollection)));
            }
        }

        private void OnDeleteContactFieldExecute(object selectedItem)
        {
            if (this.DeleteFieldCommand != null)
            {
                this.DeleteFieldCommand.Execute(selectedItem as ContactFieldBindingEntity);
            }
        }


        private void OnAddContactFieldExecute(object text)
        {
            if (text != null)
            {
                FieldType fieldType = DomainModel.FieldType.Undefined;
                if (FieldType == "Email")
                {
                    fieldType = DomainModel.FieldType.Email;
                }
                else if (FieldType == "Phone")
                {
                    fieldType = DomainModel.FieldType.Phone;
                }

                DomainModel.ContactField field = new DomainModel.ContactField()
                {
                    Id = Guid.NewGuid(),
                    Content = text.ToString(),
                    FieldType = fieldType
                };

                ContactFieldBindingEntity fieldBindingEntity = new ContactFieldBindingEntity(field);
                txtFieldContent.Text = String.Empty;
                if (this.AddFieldCommand != null)
                {
                    this.AddFieldCommand.Execute(fieldBindingEntity);
                }
            }
        }

        private static void OnContactFieldSourcePathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactFields contactFields = d as ContactFields;
            if (contactFields != null)
            {
                contactFields.ContactFieldCollection = e.NewValue as ObservableCollection<ContactFieldBindingEntity>;
            }
        }
    }
}