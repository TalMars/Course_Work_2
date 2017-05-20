using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace CourseWork_2.ViewModel
{
    public class AddPrototypeViewModel : NotifyPropertyChanged
    {
        private string _headerText;
        private string _urlText;
        private string _nameText;
        private string _descriptionText;
        private ICommand _createCommand;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;
        private bool _isEdit;
        private Prototype prototype = null;

        private EventHandler<Windows.UI.Core.BackRequestedEventArgs> requestHandler;
        private EventHandler<Windows.Phone.UI.Input.BackPressedEventArgs> pressedHandler;

        public AddPrototypeViewModel()
        {
            HeaderText = "Add prototype";
            _urlText = "";
            _nameText = "";
            _descriptionText = "";

            //GoBack Navigation
            RegisterGoBackEventHandlers();
        }

        public void LoadPrototype(Prototype _prototype)
        {
            HeaderText = "Edit prototype";
            IsEdit = true;
            UrlText = _prototype.Url;
            NameText = _prototype.Name;
            DescriptionText = _prototype.Description;
            prototype = _prototype;
        }

        public void LoadPrototype(int _prototypeId)
        {
            HeaderText = "Edit prototype";
            IsEdit = true;
            using (var db = new PrototypingContext())
            {
                Prototype _prototype = db.Prototypes.Single(p => p.PrototypeId == _prototypeId);
                UrlText = _prototype.Url;
                NameText = _prototype.Name;
                DescriptionText = _prototype.Description;
            }
            prototype = new Prototype() { PrototypeId = _prototypeId };
        }

        #region back event
        private void RegisterGoBackEventHandlers()
        {
            requestHandler = (o, ea) =>
            {
                ea.Handled = true;
                GoBackFunc();
            };
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += requestHandler;

            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                pressedHandler = (o, ea) =>
                {
                    ea.Handled = true;
                    GoBackFunc();
                };
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += pressedHandler;
            }
        }

        public void UnregisterRequestEventHander()
        {
            if (requestHandler != null)
            {
                Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= requestHandler;
            }
        }

        public void UnregisterPressedEventHadler()
        {
            if (pressedHandler != null)
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed -= pressedHandler;
            }
        }
        #endregion

        #region properties
        public string HeaderText
        {
            get { return _headerText; }
            set { Set(ref _headerText, value); }
        }

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

        private async void CreateFunc()
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
                GoBackFunc();
            }
            else
            {
                var message = new MessageDialog("Please fill in all the fields.");
                await message.ShowAsync();
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(() => SaveFunc()));
            }
        }

        private async void SaveFunc()
        {
            if (!UrlText.Equals("") && !NameText.Equals("") && !DescriptionText.Equals(""))
            {
                using (var db = new PrototypingContext())
                {
                    Prototype findPrototype = db.Prototypes.Single(p => p.PrototypeId == prototype.PrototypeId);
                    findPrototype.Url = UrlText;
                    findPrototype.Name = NameText;
                    findPrototype.Description = DescriptionText;
                    db.Prototypes.Update(findPrototype);
                    db.SaveChanges();
                }
                GoBackFunc();
            }
            else
            {
                var message = new MessageDialog("Please fill in all the fields.");
                await message.ShowAsync();
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
            if (prototype != null && prototype.Name != null)
                frame.Navigate(typeof(DetailsPrototypePage), prototype.PrototypeId);
            else
                frame.Navigate(typeof(PrototypesPage));
        }
        #endregion
    }
}
