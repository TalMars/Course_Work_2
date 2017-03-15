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
        private ICommand _createCommand;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;
        private bool _isEdit;
        private Prototype prototype;

        public AddPrototypeViewModel()
        {
            _urlText = "";
            _nameText = "";
            _descriptionText = "";
        }

        public AddPrototypeViewModel(Prototype _prototype)
        {
            IsEdit = true;
            UrlText = _prototype.Url;
            NameText = _prototype.Name;
            DescriptionText = _prototype.Description;
            prototype = _prototype;
        }

        #region properties
        public string UrlText
        {
            get { return _urlText; }
            set { Set(ref _urlText, value); }
        }

        public string NameText
        {
            get { return _nameText; }
            set { Set(ref _nameText, value); }
        }

        public string DescriptionText
        {
            get { return _descriptionText; }
            set { Set(ref _descriptionText, value); }
        }

        public bool IsEdit
        {
            get { return _isEdit; }
            set { Set(ref _isEdit, value); }
        }

        #endregion

        #region events
        public ICommand CreateCommand
        {
            get
            {
                return _createCommand ?? (_createCommand = new Command(() => CreateFunc()));
            }
        }

        private void CreateFunc()
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
        }

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(() => SaveFunc()));
            }
        }

        private void SaveFunc()
        {
            if (!UrlText.Equals("") && !NameText.Equals("") && !DescriptionText.Equals(""))
            {
                using (var db = new PrototypingContext())
                {
                    prototype.Url = UrlText;
                    prototype.Name = NameText;
                    prototype.Description = DescriptionText;
                    db.Prototypes.Update(prototype);
                    db.SaveChanges();
                }
                GoBackFunc();
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new Command(() => GoBackFunc()));
            }
        }

        private void GoBackFunc()
        {
            Windows.UI.Xaml.Controls.Frame frame = (Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content;
            frame.BackStack.Clear();
            frame.Navigate(typeof(DetailsPrototypePage), prototype.PrototypeId);
        }
        #endregion
    }
}
