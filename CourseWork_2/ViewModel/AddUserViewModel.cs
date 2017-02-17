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

        public AddUserViewModel(int prototypeId)
        {
            _nameText = "";
            _biographyText = "";

            CreateCommand = new Command(() =>
            {
                if (!NameText.Equals("") && !BiographyText.Equals(""))
                {
                    using (var db = new PrototypingContext())
                    {
                        //List<UserPrototype> users = db.Prototypes.Single(p => p.PrototypeId == prototypeId).Users;
                        //if (users == null)
                        //    db.Prototypes.Single(p => p.PrototypeId == prototypeId).Users = new List<UserPrototype>();

                        //db.Prototypes.Single(p => p.PrototypeId == prototypeId).Users.Add(new UserPrototype()
                        //{
                        //    Name = NameText,
                        //    Biography = BiographyText,
                        //    AddedDate = DateTime.Now,
                        //    PrototypeId = prototypeId
                        //});
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
            });

            GoBackCommand = new Command(() =>
            {
                ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).GoBack();
            });
        }

        #region properties
        public string NameText
        {
            get { return _nameText; }
            set { _nameText = value; OnPropertyChanged("NameText"); }
        }

        public string BiographyText
        {
            get { return _biographyText; }
            set { _biographyText = value; OnPropertyChanged("BiographyText"); }
        }
        #endregion

        #region events
        public ICommand CreateCommand { get; private set; }

        public ICommand GoBackCommand { get; private set; }
        #endregion
    }
}
