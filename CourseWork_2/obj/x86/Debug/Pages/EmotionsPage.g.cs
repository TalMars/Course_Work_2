﻿#pragma checksum "C:\Users\TalMars\Documents\Visual Studio 2015\Projects\Course_Work_2\CourseWork_2\Pages\EmotionsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E917174A5EFEADEFE3E2E48C9DA74AD3"
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
    partial class EmotionsPage : 
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
            public static void Set_Windows_UI_Xaml_Controls_ProgressRing_IsActive(global::Windows.UI.Xaml.Controls.ProgressRing obj, global::System.Boolean value)
            {
                obj.IsActive = value;
            }
            public static void Set_Windows_UI_Xaml_UIElement_IsHitTestVisible(global::Windows.UI.Xaml.UIElement obj, global::System.Boolean value)
            {
                obj.IsHitTestVisible = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBox_Text(global::Windows.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_ContentControl_Content(global::Windows.UI.Xaml.Controls.ContentControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.Content = value;
            }
            public static void Set_Windows_UI_Xaml_FrameworkElement_DataContext(global::Windows.UI.Xaml.FrameworkElement obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.DataContext = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(global::Windows.UI.Xaml.Controls.Primitives.ButtonBase obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
        };

        private class EmotionsPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IEmotionsPage_Bindings
        {
            private global::CourseWork_2.Pages.EmotionsPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Windows.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Windows.UI.Xaml.FrameworkElement> converterLookupRoot;

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Grid obj2;
            private global::Windows.UI.Xaml.Controls.StackPanel obj3;
            private global::Windows.UI.Xaml.Controls.ProgressRing obj4;
            private global::Windows.UI.Xaml.Controls.TextBlock obj5;
            private global::Windows.UI.Xaml.Controls.Grid obj6;
            private global::Windows.UI.Xaml.Controls.Grid obj7;
            private global::Windows.UI.Xaml.Controls.TextBox obj8;
            private global::Windows.UI.Xaml.Controls.ContentControl obj9;
            private global::Windows.UI.Xaml.Controls.Grid obj10;
            private global::Windows.UI.Xaml.Controls.Grid obj11;
            private global::Windows.UI.Xaml.Controls.Grid obj12;
            private global::Windows.UI.Xaml.Controls.Button obj13;
            private global::Windows.UI.Xaml.Controls.Button obj14;
            private global::Windows.UI.Xaml.Controls.Button obj15;

            private EmotionsPage_obj1_BindingsTracking bindingsTracking;

            public EmotionsPage_obj1_Bindings()
            {
                this.bindingsTracking = new EmotionsPage_obj1_BindingsTracking(this);
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
                        this.obj3 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                        break;
                    case 4:
                        this.obj4 = (global::Windows.UI.Xaml.Controls.ProgressRing)target;
                        break;
                    case 5:
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 6:
                        this.obj6 = (global::Windows.UI.Xaml.Controls.Grid)target;
                        break;
                    case 7:
                        this.obj7 = (global::Windows.UI.Xaml.Controls.Grid)target;
                        break;
                    case 8:
                        this.obj8 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        (this.obj8).LostFocus += (global::System.Object sender, global::Windows.UI.Xaml.RoutedEventArgs e) =>
                            {
                                if (this.initialized)
                                {
                                    // Update Two Way binding
                                    this.dataRoot.ViewModel.SubscriptionKey = (this.obj8).Text;
                                }
                            };
                        break;
                    case 9:
                        this.obj9 = (global::Windows.UI.Xaml.Controls.ContentControl)target;
                        break;
                    case 10:
                        this.obj10 = (global::Windows.UI.Xaml.Controls.Grid)target;
                        break;
                    case 11:
                        this.obj11 = (global::Windows.UI.Xaml.Controls.Grid)target;
                        break;
                    case 12:
                        this.obj12 = (global::Windows.UI.Xaml.Controls.Grid)target;
                        break;
                    case 13:
                        this.obj13 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 14:
                        this.obj14 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 15:
                        this.obj15 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    default:
                        break;
                }
            }

            // IEmotionsPage_Bindings

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

            // EmotionsPage_obj1_Bindings

            public void SetDataRoot(global::CourseWork_2.Pages.EmotionsPage newDataRoot)
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
            private void Update_(global::CourseWork_2.Pages.EmotionsPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::CourseWork_2.ViewModel.EmotionsViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_RingContentVisibility(obj.RingContentVisibility, phase);
                        this.Update_ViewModel_RingText(obj.RingText, phase);
                        this.Update_ViewModel_CheckSubKeyVisibility(obj.CheckSubKeyVisibility, phase);
                        this.Update_ViewModel_SubscriptionKey(obj.SubscriptionKey, phase);
                        this.Update_ViewModel_VideoPlayer(obj.VideoPlayer, phase);
                        this.Update_ViewModel_Emotion1(obj.Emotion1, phase);
                        this.Update_ViewModel_Emotion2(obj.Emotion2, phase);
                        this.Update_ViewModel_Emotion3(obj.Emotion3, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_GoBackCommand(obj.GoBackCommand, phase);
                        this.Update_ViewModel_SaveKeyCommand(obj.SaveKeyCommand, phase);
                        this.Update_ViewModel_GoToSummaryEmotionsCommand(obj.GoToSummaryEmotionsCommand, phase);
                    }
                }
            }
            private void Update_ViewModel_RingContentVisibility(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj2, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("BoolToVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "right", null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj3, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("BoolToVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "inverse", null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ProgressRing_IsActive(this.obj4, obj);
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_IsHitTestVisible(this.obj13, (global::System.Boolean)this.LookupConverter("inverseBoolConverter").Convert(obj, typeof(global::System.Boolean), null, null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_IsHitTestVisible(this.obj15, (global::System.Boolean)this.LookupConverter("inverseBoolConverter").Convert(obj, typeof(global::System.Boolean), null, null));
                }
            }
            private void Update_ViewModel_RingText(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj5, obj, null);
                }
            }
            private void Update_ViewModel_CheckSubKeyVisibility(global::System.Boolean obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj6, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("BoolToVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "right", null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj7, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("BoolToVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "inverse", null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj14, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("BoolToVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "inverse", null));
                    XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj15, (global::Windows.UI.Xaml.Visibility)this.LookupConverter("BoolToVisibilityConverter").Convert(obj, typeof(global::Windows.UI.Xaml.Visibility), "right", null));
                }
            }
            private void Update_ViewModel_SubscriptionKey(global::System.String obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj8, obj, null);
                }
            }
            private void Update_ViewModel_VideoPlayer(global::Windows.UI.Xaml.Controls.MediaPlayerElement obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ContentControl_Content(this.obj9, obj, null);
                }
            }
            private void Update_ViewModel_Emotion1(global::CourseWork_2.Emotions.EmotionResultDisplayItem obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_FrameworkElement_DataContext(this.obj10, obj, null);
                }
            }
            private void Update_ViewModel_Emotion2(global::CourseWork_2.Emotions.EmotionResultDisplayItem obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_FrameworkElement_DataContext(this.obj11, obj, null);
                }
            }
            private void Update_ViewModel_Emotion3(global::CourseWork_2.Emotions.EmotionResultDisplayItem obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_FrameworkElement_DataContext(this.obj12, obj, null);
                }
            }
            private void Update_ViewModel_GoBackCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj13, obj, null);
                }
            }
            private void Update_ViewModel_SaveKeyCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj14, obj, null);
                }
            }
            private void Update_ViewModel_GoToSummaryEmotionsCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj15, obj, null);
                }
            }

            private class EmotionsPage_obj1_BindingsTracking
            {
                global::System.WeakReference<EmotionsPage_obj1_Bindings> WeakRefToBindingObj; 

                public EmotionsPage_obj1_BindingsTracking(EmotionsPage_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<EmotionsPage_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    EmotionsPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::CourseWork_2.ViewModel.EmotionsViewModel obj = sender as global::CourseWork_2.ViewModel.EmotionsViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                    bindings.Update_ViewModel_RingContentVisibility(obj.RingContentVisibility, DATA_CHANGED);
                                    bindings.Update_ViewModel_RingText(obj.RingText, DATA_CHANGED);
                                    bindings.Update_ViewModel_CheckSubKeyVisibility(obj.CheckSubKeyVisibility, DATA_CHANGED);
                                    bindings.Update_ViewModel_SubscriptionKey(obj.SubscriptionKey, DATA_CHANGED);
                                    bindings.Update_ViewModel_VideoPlayer(obj.VideoPlayer, DATA_CHANGED);
                                    bindings.Update_ViewModel_Emotion1(obj.Emotion1, DATA_CHANGED);
                                    bindings.Update_ViewModel_Emotion2(obj.Emotion2, DATA_CHANGED);
                                    bindings.Update_ViewModel_Emotion3(obj.Emotion3, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "RingContentVisibility":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_RingContentVisibility(obj.RingContentVisibility, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "RingText":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_RingText(obj.RingText, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "CheckSubKeyVisibility":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_CheckSubKeyVisibility(obj.CheckSubKeyVisibility, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "SubscriptionKey":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_SubscriptionKey(obj.SubscriptionKey, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "VideoPlayer":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_VideoPlayer(obj.VideoPlayer, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Emotion1":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Emotion1(obj.Emotion1, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Emotion2":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Emotion2(obj.Emotion2, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Emotion3":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Emotion3(obj.Emotion3, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::CourseWork_2.ViewModel.EmotionsViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::CourseWork_2.ViewModel.EmotionsViewModel obj)
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
            case 13:
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
                    EmotionsPage_obj1_Bindings bindings = new EmotionsPage_obj1_Bindings();
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

