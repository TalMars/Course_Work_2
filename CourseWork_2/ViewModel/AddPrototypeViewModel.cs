using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork_2.ViewModel
{
    public class AddPrototypeViewModel : NotifyPropertyChanged
    {
        private string _urlText;
        private string _nameText;
        private string _descriptionText;

        public AddPrototypeViewModel()
        {
            _urlText = "";
            _nameText = "";
            _descriptionText = "";

            CreateCommand = new Command(() =>
            {
                if (!UrlText.Equals("") && !NameText.Equals("") && !DescriptionText.Equals(""))
                {
                    using (var db = new PrototypingContext())
                    {
                        db.Prototypes.Add(new Prototype()
                        {
                            Name = NameText,
                            Url = UrlText,
                            Description = DescriptionText,
                            CreatedDate = DateTime.Now
                        });
                        db.SaveChanges();
                    }
                    ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(PrototypesPage));
                }
            });

            CancelCommand = new Command(() => 
            {
                ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).GoBack();
            });
        }

        #region properties
        public string UrlText
        {
            get { return _urlText; }
            set { _urlText = value; OnPropertyChanged("UrlText"); }
        }

        public string NameText
        {
            get { return _nameText; }
            set { _nameText = value; OnPropertyChanged("NameText"); }
        }

        public string DescriptionText
        {
            get { return _descriptionText; }
            set { _descriptionText = value; OnPropertyChanged("DescriptionText"); }
        }

        #endregion

        #region events
        public ICommand CreateCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }
        #endregion
    }
}
