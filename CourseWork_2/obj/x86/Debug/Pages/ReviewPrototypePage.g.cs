﻿#pragma checksum "C:\Users\TalMars\Documents\Visual Studio 2015\Projects\CourseWork_2\CourseWork_2\Pages\ReviewPrototypePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "17E2A052BC88AED601361FF1FE553DFB"
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
    partial class ReviewPrototypePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_CourseWork_2_SwipeableSplitViewControl_Folder_SwipeableSplitView_IsSwipeablePaneOpen(global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView obj, global::System.Boolean value)
            {
                obj.IsSwipeablePaneOpen = value;
            }
            public static void Set_Windows_UI_Xaml_UIElement_Visibility(global::Windows.UI.Xaml.UIElement obj, global::Windows.UI.Xaml.Visibility value)
            {
                obj.Visibility = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_ProgressRing_IsActive(global::Windows.UI.Xaml.Controls.ProgressRing obj, global::System.Boolean value)
            {
                obj.IsActive = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_SymbolIcon_Symbol(global::Windows.UI.Xaml.Controls.SymbolIcon obj, global::Windows.UI.Xaml.Controls.Symbol value)
            {
                obj.Symbol = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_CourseWork_2_Extensions_Folder_WebViewExtensions_UriSource(global::Windows.UI.Xaml.FrameworkElement obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                global::CourseWork_2.Extensions_Folder.WebViewExtensions.SetUriSource(obj, value);
            }
        };

        private class ReviewPrototypePage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IReviewPrototypePage_Bindings
        {
            private global::CourseWork_2.Pages.ReviewPrototypePage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Windows.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement> converterLookupRoot;

            // Fields for each control that has bindings.
            private global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView obj2;
            private global::Windows.UI.Xaml.Controls.ProgressRing obj3;
            private global::Windows.UI.Xaml.Controls.Button obj4;
            private global::Windows.UI.Xaml.Controls.SymbolIcon obj5;
            private global::Windows.UI.Xaml.Controls.TextBlock obj6;
            private global::Windows.UI.Xaml.Controls.WebView obj7;

            private ReviewPrototypePage_obj1_BindingsTracking bindingsTracking;

            public ReviewPrototypePage_obj1_Bindings()
            {
                this.bindingsTracking = new ReviewPrototypePage_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2:
                        this.obj2 = (global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView)target;
                        (this.obj2).RegisterPropertyChangedCallback(global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView.IsSwipeablePaneOpenProperty,
                            (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
                            {
                                if (this.initialized)
                                {
                                    // Update Two Way binding
                                    this.dataRoot.ViewModel.IsSplitViewPaneOpen = (this.obj2).IsSwipeablePaneOpen;
                                }
                            });
                        break;
                    case 3:
                        this.obj3 = (global::Windows.UI.Xaml.Controls.ProgressRing)target;
                        break;
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.Button)target;
                        ((global::Windows.UI.Xaml.Controls.Button)target).Click += (global::System.Object param0, global::Windows.UI.Xaml.RoutedEventArgs param1) =>
                        {
                        this.dataRoot.ViewModel.StartStop_Click(param0, param1);
                        };
                        break;
                    case 5:
                        this.obj5 = (global::Windows.UI.Xaml.Controls.SymbolIcon)target;
                        break;
                    case 6:
                        this.obj6 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 7:
                        this.obj7 = (global::Windows.UI.Xaml.Controls.WebView)target;
                        ((global::Windows.UI.Xaml.Controls.WebView)target).ScriptNotify += (global::System.Object param0, global::Windows.UI.Xaml.Controls.NotifyEventArgs param1) =>
                        {
                        this.dataRoot.ViewModel.WebView_ScriptNotify(param0, param1);
                        };
                        ((global::Windows.UI.Xaml.Controls.WebView)target).NavigationStarting += (global::Windows.UI.Xaml.Controls.WebView param0, global::Windows.UI.Xaml.Controls.WebViewNavigationStartingEventArgs param1) =>
                        {
                        this.dataRoot.ViewModel.WebView_NavigationStarting(param0, param1);
                        };
                        ((global::Windows.UI.Xaml.Controls.WebView)target).NavigationCompleted += (global::Windows.UI.Xaml.Controls.WebView param0, global::Windows.UI.Xaml.Controls.WebViewNavigationCompletedEventArgs param1) =>
                        {
                        this.dataRoot.ViewModel.WebView_NavigationCompleted(param0, param1);
                        };
                        break;
                    default:
                        break;
                }
            }

            // IReviewPrototypePage_Bindings

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

            // ReviewPrototypePage_obj1_Bindings

            public void SetDataRoot(global::CourseWork_2.Pages.ReviewPrototypePage newDataRoot)
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
            private void Update_(global::CourseWork_2.Pages.ReviewPrototypePage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::CourseWork_2.ViewModel.ReviewPrototypeViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_IsSplitViewPaneOpen(obj.IsSplitViewPaneOpen, phase);
                        this.Update_ViewModel_RingContentVisibility(obj.RingContentVisibility, phase);
                        this.Update_ViewModel_IsOnStart(obj.IsOnStart, phase);
                        this.Update_ViewModel_TimerText(obj.TimerText, phase);
                        this.Update_ViewModel_SourceWebView(obj.SourceWebView, phase);
                    }
                }
            }
            private void Update_ViewModel_IsSplitViewPaneOpen(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_CourseWork_2_SwipeableSplitViewControl_Folder_SwipeableSplitView_IsSwipeablePaneOpen(this.obj2, obj);
                }
            }
            private void Update_ViewModel_RingContentVisibility(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj2, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("ringConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "content", null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj3, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("ringConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), null, null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ProgressRing_IsActive(this.obj3, obj);
                }
            }
            private void Update_ViewModel_IsOnStart(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_SymbolIcon_Symbol(this.obj5, (global::Windows.UI.Xaml.Controls.Symbol)this.LookupConverter("iconConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Controls.Symbol), null, null));
                }
            }
            private void Update_ViewModel_TimerText(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj6, obj, null);
                }
            }
            private void Update_ViewModel_SourceWebView(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_CourseWork_2_Extensions_Folder_WebViewExtensions_UriSource(this.obj7, obj, null);
                }
            }

            private class ReviewPrototypePage_obj1_BindingsTracking
            {
                global::System.WeakReference<ReviewPrototypePage_obj1_Bindings> WeakRefToBindingObj; 

                public ReviewPrototypePage_obj1_BindingsTracking(ReviewPrototypePage_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<ReviewPrototypePage_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ReviewPrototypePage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::CourseWork_2.ViewModel.ReviewPrototypeViewModel obj = sender as global::CourseWork_2.ViewModel.ReviewPrototypeViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_ViewModel_IsSplitViewPaneOpen(obj.IsSplitViewPaneOpen, DATA_CHANGED);
                                    bindings.Update_ViewModel_RingContentVisibility(obj.RingContentVisibility, DATA_CHANGED);
                                    bindings.Update_ViewModel_IsOnStart(obj.IsOnStart, DATA_CHANGED);
                                    bindings.Update_ViewModel_TimerText(obj.TimerText, DATA_CHANGED);
                                    bindings.Update_ViewModel_SourceWebView(obj.SourceWebView, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "IsSplitViewPaneOpen":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_IsSplitViewPaneOpen(obj.IsSplitViewPaneOpen, DATA_CHANGED);
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
                                case "IsOnStart":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_IsOnStart(obj.IsOnStart, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "TimerText":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_TimerText(obj.TimerText, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "SourceWebView":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_SourceWebView(obj.SourceWebView, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::CourseWork_2.ViewModel.ReviewPrototypeViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::CourseWork_2.ViewModel.ReviewPrototypeViewModel obj)
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
            case 2:
                {
                    this.SplitView = (global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView)(target);
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 7:
                {
                    global::Windows.UI.Xaml.Controls.WebView element7 = (global::Windows.UI.Xaml.Controls.WebView)(target);
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
                    ReviewPrototypePage_obj1_Bindings bindings = new ReviewPrototypePage_obj1_Bindings();
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

