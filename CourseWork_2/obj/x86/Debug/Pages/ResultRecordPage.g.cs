﻿#pragma checksum "C:\Users\TalMars\Documents\Visual Studio 2015\Projects\Course_Work_2\CourseWork_2\Pages\ResultRecordPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6D401CC3FFDA1981B2ECCD6A60EFE401"
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
    partial class ResultRecordPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_UIElement_Visibility(global::Windows.UI.Xaml.UIElement obj, global::Windows.UI.Xaml.Visibility value)
            {
                obj.Visibility = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_ContentControl_Content(global::Windows.UI.Xaml.Controls.ContentControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.Content = value;
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
            public static void Set_Windows_UI_Xaml_Controls_ProgressRing_IsActive(global::Windows.UI.Xaml.Controls.ProgressRing obj, global::System.Boolean value)
            {
                obj.IsActive = value;
            }
            public static void Set_Windows_UI_Xaml_UIElement_IsHitTestVisible(global::Windows.UI.Xaml.UIElement obj, global::System.Boolean value)
            {
                obj.IsHitTestVisible = value;
            }
            public static void Set_WinRT_Triggers_InvokeCommandAction_Command(global::WinRT.Triggers.InvokeCommandAction obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(global::Windows.UI.Xaml.Controls.Primitives.ButtonBase obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_SymbolIcon_Symbol(global::Windows.UI.Xaml.Controls.SymbolIcon obj, global::Windows.UI.Xaml.Controls.Symbol value)
            {
                obj.Symbol = value;
            }
        };

        private class ResultRecordPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IResultRecordPage_Bindings
        {
            private global::CourseWork_2.Pages.ResultRecordPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Windows.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement> converterLookupRoot;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Grid obj2;
            private global::Windows.UI.Xaml.Controls.Grid obj3;
            private global::Windows.UI.Xaml.Controls.ContentControl obj4;
            private global::Windows.UI.Xaml.Controls.ListView obj5;
            private global::Windows.UI.Xaml.Controls.GridView obj6;
            private global::Windows.UI.Xaml.Controls.FlipView obj7;
            private global::Windows.UI.Xaml.Controls.StackPanel obj8;
            private global::Windows.UI.Xaml.Controls.ProgressRing obj9;
            private global::WinRT.Triggers.InvokeCommandAction obj10;
            private global::Windows.UI.Xaml.Controls.Button obj11;
            private global::Windows.UI.Xaml.Controls.StackPanel obj12;
            private global::Windows.UI.Xaml.Controls.Button obj13;
            private global::Windows.UI.Xaml.Controls.Button obj14;
            private global::Windows.UI.Xaml.Controls.SymbolIcon obj15;

            private ResultRecordPage_obj1_BindingsTracking bindingsTracking;

            public ResultRecordPage_obj1_Bindings()
            {
                this.bindingsTracking = new ResultRecordPage_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2:
                        this.obj2 = (global::Windows.UI.Xaml.Controls.Grid)target;
                        break;
                    case 3:
                        this.obj3 = (global::Windows.UI.Xaml.Controls.Grid)target;
                        break;
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.ContentControl)target;
                        break;
                    case 5:
                        this.obj5 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        (this.obj5).RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty,
                            (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
                            {
                                if (this.initialized)
                                {
                                    // Update Two Way binding
                                    this.dataRoot.ViewModel.SelectedRecord = (global::CourseWork_2.DataBase.DBModels.Record)this.LookupConverter("itemConverter").ConvertBack((this.obj5).SelectedItem, typeof(global::CourseWork_2.DataBase.DBModels.Record), null, null);
                                }
                            });
                        break;
                    case 6:
                        this.obj6 = (global::Windows.UI.Xaml.Controls.GridView)target;
                        (this.obj6).RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Primitives.Selector.SelectedItemProperty,
                            (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
                            {
                                if (this.initialized)
                                {
                                    // Update Two Way binding
                                    this.dataRoot.ViewModel.SelectedItem = (global::CourseWork_2.Model.RecordScreenModel)this.LookupConverter("itemConverter").ConvertBack((this.obj6).SelectedItem, typeof(global::CourseWork_2.Model.RecordScreenModel), null, null);
                                }
                            });
                        break;
                    case 7:
                        this.obj7 = (global::Windows.UI.Xaml.Controls.FlipView)target;
                        break;
                    case 8:
                        this.obj8 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                        break;
                    case 9:
                        this.obj9 = (global::Windows.UI.Xaml.Controls.ProgressRing)target;
                        break;
                    case 10:
                        this.obj10 = (global::WinRT.Triggers.InvokeCommandAction)target;
                        break;
                    case 11:
                        this.obj11 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 12:
                        this.obj12 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                        break;
                    case 13:
                        this.obj13 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 14:
                        this.obj14 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 15:
                        this.obj15 = (global::Windows.UI.Xaml.Controls.SymbolIcon)target;
                        break;
                    default:
                        break;
                }
            }

            // IResultRecordPage_Bindings

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

            // ResultRecordPage_obj1_Bindings

            public void SetDataRoot(global::CourseWork_2.Pages.ResultRecordPage newDataRoot)
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
            private void Update_(global::CourseWork_2.Pages.ResultRecordPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::CourseWork_2.ViewModel.ResultRecordViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_VideoGridVisibility(obj.VideoGridVisibility, phase);
                        this.Update_ViewModel_RecordVideo(obj.RecordVideo, phase);
                        this.Update_ViewModel_Records(obj.Records, phase);
                        this.Update_ViewModel_SelectedRecord(obj.SelectedRecord, phase);
                        this.Update_ViewModel_Screens(obj.Screens, phase);
                        this.Update_ViewModel_SelectVisibility(obj.SelectVisibility, phase);
                        this.Update_ViewModel_SelectedItem(obj.SelectedItem, phase);
                        this.Update_ViewModel_RingContentVisibility(obj.RingContentVisibility, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_DoubleTapCommand(obj.DoubleTapCommand, phase);
                        this.Update_ViewModel_GoBackCommand(obj.GoBackCommand, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_VideoIconVisibility(obj.VideoIconVisibility, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_GoToLookEmotionsCommand(obj.GoToLookEmotionsCommand, phase);
                        this.Update_ViewModel_ShowVideoCommand(obj.ShowVideoCommand, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_ShowScreenVideoIcon(obj.ShowScreenVideoIcon, phase);
                    }
                }
            }
            private void Update_ViewModel_VideoGridVisibility(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj2, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("boolToVisConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "right", null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj3, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("boolToVisConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "inverse", null));
                }
            }
            private void Update_ViewModel_RecordVideo(global::Windows.UI.Xaml.Controls.MediaPlayerElement obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ContentControl_Content(this.obj4, obj, null);
                }
            }
            private void Update_ViewModel_Records(global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.DataBase.DBModels.Record> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj5, obj, null);
                }
            }
            private void Update_ViewModel_SelectedRecord(global::CourseWork_2.DataBase.DBModels.Record obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj5, (global::System.Object)this.LookupConverter("itemConverter").Convert(obj, typeof(global::System.Object), null, null), null);
                }
            }
            private void Update_ViewModel_Screens(global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.Model.RecordScreenModel> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj6, obj, null);
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj7, obj, null);
                }
            }
            private void Update_ViewModel_SelectVisibility(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj6, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("boolToVisConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "right", null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj7, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("boolToVisConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "inverse", null));
                }
            }
            private void Update_ViewModel_SelectedItem(global::CourseWork_2.Model.RecordScreenModel obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj6, (global::System.Object)this.LookupConverter("itemConverter").Convert(obj, typeof(global::System.Object), null, null), null);
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_Selector_SelectedItem(this.obj7, obj, null);
                }
            }
            private void Update_ViewModel_RingContentVisibility(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj8, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("boolToVisConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "inverse", null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ProgressRing_IsActive(this.obj9, obj);
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_IsHitTestVisible(this.obj11, (global::System.Boolean)this.LookupConverter("inverseBoolConverter").Convert(obj, typeof(global::System.Boolean), null, null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_IsHitTestVisible(this.obj13, (global::System.Boolean)this.LookupConverter("inverseBoolConverter").Convert(obj, typeof(global::System.Boolean), null, null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_IsHitTestVisible(this.obj14, (global::System.Boolean)this.LookupConverter("inverseBoolConverter").Convert(obj, typeof(global::System.Boolean), null, null));
                }
            }
            private void Update_ViewModel_DoubleTapCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_WinRT_Triggers_InvokeCommandAction_Command(this.obj10, obj, null);
                }
            }
            private void Update_ViewModel_GoBackCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj11, obj, null);
                }
            }
            private void Update_ViewModel_VideoIconVisibility(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj12, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("boolToVisConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "inverse", null));
                }
            }
            private void Update_ViewModel_GoToLookEmotionsCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj13, obj, null);
                }
            }
            private void Update_ViewModel_ShowVideoCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj14, obj, null);
                }
            }
            private void Update_ViewModel_ShowScreenVideoIcon(global::Windows.UI.Xaml.Controls.Symbol obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_SymbolIcon_Symbol(this.obj15, obj);
                }
            }

            private class ResultRecordPage_obj1_BindingsTracking
            {
                global::System.WeakReference<ResultRecordPage_obj1_Bindings> WeakRefToBindingObj; 

                public ResultRecordPage_obj1_BindingsTracking(ResultRecordPage_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<ResultRecordPage_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ResultRecordPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::CourseWork_2.ViewModel.ResultRecordViewModel obj = sender as global::CourseWork_2.ViewModel.ResultRecordViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_ViewModel_VideoGridVisibility(obj.VideoGridVisibility, DATA_CHANGED);
                                    bindings.Update_ViewModel_RecordVideo(obj.RecordVideo, DATA_CHANGED);
                                    bindings.Update_ViewModel_Records(obj.Records, DATA_CHANGED);
                                    bindings.Update_ViewModel_SelectedRecord(obj.SelectedRecord, DATA_CHANGED);
                                    bindings.Update_ViewModel_Screens(obj.Screens, DATA_CHANGED);
                                    bindings.Update_ViewModel_SelectVisibility(obj.SelectVisibility, DATA_CHANGED);
                                    bindings.Update_ViewModel_SelectedItem(obj.SelectedItem, DATA_CHANGED);
                                    bindings.Update_ViewModel_RingContentVisibility(obj.RingContentVisibility, DATA_CHANGED);
                                    bindings.Update_ViewModel_VideoIconVisibility(obj.VideoIconVisibility, DATA_CHANGED);
                                    bindings.Update_ViewModel_ShowScreenVideoIcon(obj.ShowScreenVideoIcon, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "VideoGridVisibility":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_VideoGridVisibility(obj.VideoGridVisibility, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "RecordVideo":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_RecordVideo(obj.RecordVideo, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Records":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Records(obj.Records, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "SelectedRecord":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_SelectedRecord(obj.SelectedRecord, DATA_CHANGED);
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
                                case "SelectVisibility":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_SelectVisibility(obj.SelectVisibility, DATA_CHANGED);
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
                                case "RingContentVisibility":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_RingContentVisibility(obj.RingContentVisibility, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "VideoIconVisibility":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_VideoIconVisibility(obj.VideoIconVisibility, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "ShowScreenVideoIcon":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_ShowScreenVideoIcon(obj.ShowScreenVideoIcon, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::CourseWork_2.ViewModel.ResultRecordViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::CourseWork_2.ViewModel.ResultRecordViewModel obj)
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
                public void PropertyChanged_ViewModel_Records(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ResultRecordPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.DataBase.DBModels.Record> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.DataBase.DBModels.Record>;
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
                public void CollectionChanged_ViewModel_Records(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    ResultRecordPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.DataBase.DBModels.Record> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.DataBase.DBModels.Record>;
                    }
                }
                public void PropertyChanged_ViewModel_Screens(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ResultRecordPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.Model.RecordScreenModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.Model.RecordScreenModel>;
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
                    ResultRecordPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.Model.RecordScreenModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::CourseWork_2.Model.RecordScreenModel>;
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
            case 11:
                {
                    this.DoneButton = (global::Windows.UI.Xaml.Controls.Button)(target);
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
                    ResultRecordPage_obj1_Bindings bindings = new ResultRecordPage_obj1_Bindings();
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
