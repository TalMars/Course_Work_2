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
    public class AddUserViewModel : NotifyPropertyChanged
    {
        private string _nameText;
        private string _biographyText;
        private int prototypeId;
        private ICommand _createCommand;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;
        private bool _isEdit;
        private UserPrototype user;

        public AddUserViewModel(int _prototypeId)
        {
            _nameText = "";
            _biographyText = "";
            prototypeId = _prototypeId;
        }

        public AddUserViewModel(UserPrototype _user)
        {
            IsEdit = true;
            user = _user;
            NameText = user.Name;
            BiographyText = user.Biography;
        }

        #region properties
        public string NameText
        {
            get { return _nameText; }
            set { Set(ref _nameText, value); }
        }

        public string BiographyText
        {
            get { return _biographyText; }
            set { Set(ref _biographyText, value); }
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
            if (!NameText.Equals("") && !BiographyText.Equals(""))
            {
                using (var db = new PrototypingContext())
                {
                    db.Users.Add(new UserPrototype()
                    {
                        Name = NameText,
                        Biography = BiographyText,
                        AddedDate = DateTime.Now,
                        PrototypeId = prototypeId
                    });
                    db.SaveChanges();
                }
                ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(DetailsPrototypePage), prototypeId);
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
            if (!NameText.Equals("") && !BiographyText.Equals(""))
            {
                using (var db = new PrototypingContext())
                {
                    user.Name = NameText;
                    user.Biography = BiographyText;
                    db.Users.Update(user);
                    db.SaveChanges();
                }
                GoBackFunc();
            }
        }

        public ICommand GoBackCommand
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
            frame.Navigate(typeof(DetailsUserPage), user.PrototypeId);
        }
        #endregion
    }
}
