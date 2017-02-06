﻿#pragma checksum "C:\Users\TalMars\Documents\Visual Studio 2015\Projects\CourseWork_2\CourseWork_2\Pages\ResultScreensPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0274A96BA562C6233D67BEB2E9F6A357"
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
    partial class ResultScreensPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_Image_Source(global::Windows.UI.Xaml.Controls.Image obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
            public static void Set_Windows_UI_Xaml_UIElement_Visibility(global::Windows.UI.Xaml.UIElement obj, global::Windows.UI.Xaml.Visibility value)
            {
                obj.Visibility = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_ProgressRing_IsActive(global::Windows.UI.Xaml.Controls.ProgressRing obj, global::System.Boolean value)
            {
                obj.IsActive = value;
            }
        };

        private class ResultScreensPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IResultScreensPage_Bindings
        {
            private global::CourseWork_2.Pages.ResultScreensPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Windows.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement> converterLookupRoot;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Image obj2;
            private global::Windows.UI.Xaml.Controls.GridView obj3;
            private global::Windows.UI.Xaml.Controls.ProgressRing obj4;

            private ResultScreensPage_obj1_BindingsTracking bindingsTracking;

            public ResultScreensPage_obj1_Bindings()
            {
                this.bindingsTracking = new ResultScreensPage_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2:
                        this.obj2 = (global::Windows.UI.Xaml.Controls.Image)target;
                        ((global::Windows.UI.Xaml.Controls.Image)target).DoubleTapped += (global::System.Object param0, global::Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs param1) =>
                        {
                        this.dataRoot.ViewModel.SelectScreen_DoubleTapped(param0, param1);
                        };
                        break;
                    case 3:
                        this.obj3 = (global::Windows.UI.Xaml.Controls.GridView)target;
                        ((global::Windows.UI.Xaml.Controls.GridView)target).SelectionChanged += (global::System.Object param0, global::Windows.UI.Xaml.Controls.SelectionChangedEventArgs param1) =>
                        {
                        this.dataRoot.ViewModel.GridView_SelectionChanged(param0, param1);
                        };
                        break;
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.ProgressRing)target;
                        break;
                    default:
                        break;
                }
            }

            // IResultScreensPage_Bindings

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

            // ResultScreensPage_obj1_Bindings

            public void SetDataRoot(global::CourseWork_2.Pages.ResultScreensPage newDataRoot)
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
            private void Update_(global::CourseWork_2.Pages.ResultScreensPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::CourseWork_2.ViewModel.ResultScreensViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_SelectedScreen(obj.SelectedScreen, phase);
                        this.Update_ViewModel_SelectVisibility(obj.SelectVisibility, phase);
                        this.Update_ViewModel_Screens(obj.Screens, phase);
                        this.Update_ViewModel_RingContentVisibility(obj.RingContentVisibility, phase);
                    }
                }
            }
            private void Update_ViewModel_SelectedScreen(global::Windows.UI.Xaml.Media.Imaging.WriteableBitmap obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Image_Source(this.obj2, obj, null);
                }
            }
            private void Update_ViewModel_SelectVisibility(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj2, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("ringConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), null, null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj3, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("ringConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "content", null));
                }
            }
            private void Update_ViewModel_Screens(global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.Model.ReviewPrototypeModel> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj3, obj, null);
                }
            }
            private void Update_ViewModel_RingContentVisibility(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj4, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("ringConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), null, null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ProgressRing_IsActive(this.obj4, obj);
                }
            }

            private class ResultScreensPage_obj1_BindingsTracking
            {
                global::System.WeakReference<ResultScreensPage_obj1_Bindings> WeakRefToBindingObj; 

                public ResultScreensPage_obj1_BindingsTracking(ResultScreensPage_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<ResultScreensPage_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ResultScreensPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::CourseWork_2.ViewModel.ResultScreensViewModel obj = sender as global::CourseWork_2.ViewModel.ResultScreensViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_ViewModel_SelectedScreen(obj.SelectedScreen, DATA_CHANGED);
                                    bindings.Update_ViewModel_SelectVisibility(obj.SelectVisibility, DATA_CHANGED);
                                    bindings.Update_ViewModel_Screens(obj.Screens, DATA_CHANGED);
                                    bindings.Update_ViewModel_RingContentVisibility(obj.RingContentVisibility, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "SelectedScreen":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_SelectedScreen(obj.SelectedScreen, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "SelectVisibility":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_SelectVisibility(obj.SelectVisibility, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Screens":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Screens(obj.Screens, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "RingContentVisibility":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_RingContentVisibility(obj.RingContentVisibility, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::CourseWork_2.ViewModel.ResultScreensViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::CourseWork_2.ViewModel.ResultScreensViewModel obj)
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
                public void PropertyChanged_ViewModel_Screens(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ResultScreensPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.Model.ReviewPrototypeModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.Model.ReviewPrototypeModel>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_ViewModel_Screens(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    ResultScreensPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.Model.ReviewPrototypeModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.Model.ReviewPrototypeModel>;
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
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.Image element2 = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.GridView element3 = (global::Windows.UI.Xaml.Controls.GridView)(target);
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
                    ResultScreensPage_obj1_Bindings bindings = new ResultScreensPage_obj1_Bindings();
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

