﻿#pragma checksum "C:\Users\TalMars\Documents\Visual Studio 2015\Projects\Course_Work_2\CourseWork_2\Pages\DetailsUserPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A2D9BFAB53DA58662D1C5F0ADBEE402A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseWork_2.Pages
{
    partial class DetailsUserPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_AppBar_IsOpen(global::Windows.UI.Xaml.Controls.AppBar obj, global::System.Boolean value)
            {
                obj.IsOpen = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(global::Windows.UI.Xaml.Controls.Primitives.ButtonBase obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
            public static void Set_Windows_UI_Xaml_FrameworkElement_DataContext(global::Windows.UI.Xaml.FrameworkElement obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.DataContext = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(global::Windows.UI.Xaml.Controls.Primitives.Selector obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.SelectedItem = value;
            }
        };

        private class DetailsUserPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IDetailsUserPage_Bindings
        {
            private global::CourseWork_2.Pages.DetailsUserPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Windows.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement> converterLookupRoot;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.AppBar obj2;
            private global::Windows.UI.Xaml.Controls.AppBarButton obj3;
            private global::Windows.UI.Xaml.Controls.AppBarButton obj4;
            private global::Windows.UI.Xaml.Controls.AppBarButton obj5;
            private global::Windows.UI.Xaml.Controls.Grid obj6;
            private global::Windows.UI.Xaml.Controls.Button obj8;
            private global::Windows.UI.Xaml.Controls.ListView obj9;
            private global::Windows.UI.Xaml.Controls.Button obj10;
            private global::Windows.UI.Xaml.Controls.Button obj11;

            private DetailsUserPage_obj1_BindingsTracking bindingsTracking;

            public DetailsUserPage_obj1_Bindings()
            {
                this.bindingsTracking = new DetailsUserPage_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2:
                        this.obj2 = (global::Windows.UI.Xaml.Controls.AppBar)target;
                        break;
                    case 3:
                        this.obj3 = (global::Windows.UI.Xaml.Controls.AppBarButton)target;
                        break;
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.AppBarButton)target;
                        break;
                    case 5:
                        this.obj5 = (global::Windows.UI.Xaml.Controls.AppBarButton)target;
                        break;
                    case 6:
                        this.obj6 = (global::Windows.UI.Xaml.Controls.Grid)target;
                        break;
                    case 8:
                        this.obj8 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 9:
                        this.obj9 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        (this.obj9).RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty,
                            (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
                            {
                                if (this.initialized)
                                {
                                    // Update Two Way binding
                                    this.dataRoot.ViewModel.SelectedItem = (global::CourseWork_2.DataBase.DBModels.RecordPrototype)this.LookupConverter("itemConverter").ConvertBack((this.obj9).SelectedItem, typeof(global::CourseWork_2.DataBase.DBModels.RecordPrototype), null, null);
                                }
                            });
                        break;
                    case 10:
                        this.obj10 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 11:
                        this.obj11 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    default:
                        break;
                }
            }

            // IDetailsUserPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            // DetailsUserPage_obj1_Bindings

            public void SetDataRoot(global::CourseWork_2.Pages.DetailsUserPage newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }
            public void SetConverterLookupRoot(global::Windows.UI.Xaml.FrameworkElement rootElement)
            {
                this.converterLookupRoot = new global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement>(rootElement);
            }

            public global::Windows.UI.Xaml.Data.IValueConverter LookupConverter(string key)
            {
                if (this.localResources == null)
                {
                    global::Windows.UI.Xaml.FrameworkElement rootElement;
                    this.converterLookupRoot.TryGetTarget(out rootElement);
                    this.localResources = rootElement.Resources;
                    this.converterLookupRoot = null;
                }
                return (global::Windows.UI.Xaml.Data.IValueConverter) (this.localResources.ContainsKey(key) ? this.localResources[key] : global::Windows.UI.Xaml.Application.Current.Resources[key]);
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::CourseWork_2.Pages.DetailsUserPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::CourseWork_2.ViewModel.DetailsUserViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_IsOpenCommandBar(obj.IsOpenCommandBar, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_AddCommand(obj.AddCommand, phase);
                        this.Update_ViewModel_EditCommand(obj.EditCommand, phase);
                        this.Update_ViewModel_RemoveCommand(obj.RemoveCommand, phase);
                        this.Update_ViewModel_UserModel(obj.UserModel, phase);
                        this.Update_ViewModel_ResultScreensCommand(obj.ResultScreensCommand, phase);
                        this.Update_ViewModel_Records(obj.Records, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_SelectedItem(obj.SelectedItem, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_GoBackCommand(obj.GoBackCommand, phase);
                        this.Update_ViewModel_OpenAppBarCommand(obj.OpenAppBarCommand, phase);
                    }
                }
            }
            private void Update_ViewModel_IsOpenCommandBar(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_AppBar_IsOpen(this.obj2, obj);
                }
            }
            private void Update_ViewModel_AddCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj3, obj, null);
                }
            }
            private void Update_ViewModel_EditCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj4, obj, null);
                }
            }
            private void Update_ViewModel_RemoveCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj5, obj, null);
                }
            }
            private void Update_ViewModel_UserModel(global::CourseWork_2.DataBase.DBModels.UserPrototype obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_FrameworkElement_DataContext(this.obj6, obj, null);
                }
            }
            private void Update_ViewModel_ResultScreensCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj8, obj, null);
                }
            }
            private void Update_ViewModel_Records(global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.DataBase.DBModels.RecordPrototype> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj9, obj, null);
                }
            }
            private void Update_ViewModel_SelectedItem(global::CourseWork_2.DataBase.DBModels.RecordPrototype obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj9, (global::System.Object)this.LookupConverter("itemConverter").Convert(obj, typeof(global::System.Object), null, null), null);
                }
            }
            private void Update_ViewModel_GoBackCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj10, obj, null);
                }
            }
            private void Update_ViewModel_OpenAppBarCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj11, obj, null);
                }
            }

            private class DetailsUserPage_obj1_BindingsTracking
            {
                global::System.WeakReference<DetailsUserPage_obj1_Bindings> WeakRefToBindingObj; 

                public DetailsUserPage_obj1_BindingsTracking(DetailsUserPage_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<DetailsUserPage_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    DetailsUserPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::CourseWork_2.ViewModel.DetailsUserViewModel obj = sender as global::CourseWork_2.ViewModel.DetailsUserViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_ViewModel_IsOpenCommandBar(obj.IsOpenCommandBar, DATA_CHANGED);
                                    bindings.Update_ViewModel_SelectedItem(obj.SelectedItem, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "IsOpenCommandBar":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_IsOpenCommandBar(obj.IsOpenCommandBar, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "SelectedItem":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_SelectedItem(obj.SelectedItem, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::CourseWork_2.ViewModel.DetailsUserViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::CourseWork_2.ViewModel.DetailsUserViewModel obj)
                {
                    if (obj != cache_ViewModel)
                    {
                        if (cache_ViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel).PropertyChanged -= PropertyChanged_ViewModel;
                            cache_ViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 7:
                {
                    this.VBSymbol = (global::Windows.UI.Xaml.Controls.Viewbox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    DetailsUserPage_obj1_Bindings bindings = new DetailsUserPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    bindings.SetConverterLookupRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}
