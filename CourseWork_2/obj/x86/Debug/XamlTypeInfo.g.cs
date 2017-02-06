﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace CourseWork_2
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
    private global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlTypeInfoProvider _provider;

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        /// <summary>
        /// GetXamlType(String)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            if(_provider == null)
            {
                _provider = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        /// <summary>
        /// GetXmlnsDefinitions()
        /// </summary>
        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace CourseWork_2.CourseWork_2_XamlTypeInfo
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByType(type);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByName(typeName);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[18];
            _typeNameTable[0] = "CourseWork_2.MainPage";
            _typeNameTable[1] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[2] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[3] = "CourseWork_2.Converters.RingConverter";
            _typeNameTable[4] = "Object";
            _typeNameTable[5] = "CourseWork_2.Pages.ResultScreensPage";
            _typeNameTable[6] = "CourseWork_2.ViewModel.ResultScreensViewModel";
            _typeNameTable[7] = "CourseWork_2.ViewModel.NotifyPropertyChanged";
            _typeNameTable[8] = "CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView";
            _typeNameTable[9] = "Windows.UI.Xaml.Controls.SplitView";
            _typeNameTable[10] = "Boolean";
            _typeNameTable[11] = "Double";
            _typeNameTable[12] = "CourseWork_2.Converters.IconStartStopConverter";
            _typeNameTable[13] = "CourseWork_2.Extensions_Folder.WebViewExtensions";
            _typeNameTable[14] = "String";
            _typeNameTable[15] = "Windows.UI.Xaml.DependencyObject";
            _typeNameTable[16] = "CourseWork_2.Pages.ReviewPrototypePage";
            _typeNameTable[17] = "CourseWork_2.ViewModel.ReviewPrototypeViewModel";

            _typeTable = new global::System.Type[18];
            _typeTable[0] = typeof(global::CourseWork_2.MainPage);
            _typeTable[1] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[2] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[3] = typeof(global::CourseWork_2.Converters.RingConverter);
            _typeTable[4] = typeof(global::System.Object);
            _typeTable[5] = typeof(global::CourseWork_2.Pages.ResultScreensPage);
            _typeTable[6] = typeof(global::CourseWork_2.ViewModel.ResultScreensViewModel);
            _typeTable[7] = typeof(global::CourseWork_2.ViewModel.NotifyPropertyChanged);
            _typeTable[8] = typeof(global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView);
            _typeTable[9] = typeof(global::Windows.UI.Xaml.Controls.SplitView);
            _typeTable[10] = typeof(global::System.Boolean);
            _typeTable[11] = typeof(global::System.Double);
            _typeTable[12] = typeof(global::CourseWork_2.Converters.IconStartStopConverter);
            _typeTable[13] = typeof(global::CourseWork_2.Extensions_Folder.WebViewExtensions);
            _typeTable[14] = typeof(global::System.String);
            _typeTable[15] = typeof(global::Windows.UI.Xaml.DependencyObject);
            _typeTable[16] = typeof(global::CourseWork_2.Pages.ReviewPrototypePage);
            _typeTable[17] = typeof(global::CourseWork_2.ViewModel.ReviewPrototypeViewModel);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_0_MainPage() { return new global::CourseWork_2.MainPage(); }
        private object Activate_3_RingConverter() { return new global::CourseWork_2.Converters.RingConverter(); }
        private object Activate_5_ResultScreensPage() { return new global::CourseWork_2.Pages.ResultScreensPage(); }
        private object Activate_6_ResultScreensViewModel() { return new global::CourseWork_2.ViewModel.ResultScreensViewModel(); }
        private object Activate_8_SwipeableSplitView() { return new global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView(); }
        private object Activate_12_IconStartStopConverter() { return new global::CourseWork_2.Converters.IconStartStopConverter(); }
        private object Activate_16_ReviewPrototypePage() { return new global::CourseWork_2.Pages.ReviewPrototypePage(); }
        private object Activate_17_ReviewPrototypeViewModel() { return new global::CourseWork_2.ViewModel.ReviewPrototypeViewModel(); }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  CourseWork_2.MainPage
                userType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_0_MainPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 3:   //  CourseWork_2.Converters.RingConverter
                userType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_3_RingConverter;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 4:   //  Object
                xamlType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 5:   //  CourseWork_2.Pages.ResultScreensPage
                userType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_5_ResultScreensPage;
                userType.AddMemberName("ViewModel");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 6:   //  CourseWork_2.ViewModel.ResultScreensViewModel
                userType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("CourseWork_2.ViewModel.NotifyPropertyChanged"));
                userType.SetIsReturnTypeStub();
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 7:   //  CourseWork_2.ViewModel.NotifyPropertyChanged
                userType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 8:   //  CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView
                userType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.SplitView"));
                userType.Activator = Activate_8_SwipeableSplitView;
                userType.AddMemberName("IsSwipeablePaneOpen");
                userType.AddMemberName("PanAreaInitialTranslateX");
                userType.AddMemberName("PanAreaThreshold");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 9:   //  Windows.UI.Xaml.Controls.SplitView
                xamlType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 10:   //  Boolean
                xamlType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 11:   //  Double
                xamlType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 12:   //  CourseWork_2.Converters.IconStartStopConverter
                userType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_12_IconStartStopConverter;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 13:   //  CourseWork_2.Extensions_Folder.WebViewExtensions
                userType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.AddMemberName("UriSource");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 14:   //  String
                xamlType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 15:   //  Windows.UI.Xaml.DependencyObject
                xamlType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 16:   //  CourseWork_2.Pages.ReviewPrototypePage
                userType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_16_ReviewPrototypePage;
                userType.AddMemberName("ViewModel");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 17:   //  CourseWork_2.ViewModel.ReviewPrototypeViewModel
                userType = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("CourseWork_2.ViewModel.NotifyPropertyChanged"));
                userType.SetIsReturnTypeStub();
                userType.SetIsLocalType();
                xamlType = userType;
                break;
            }
            return xamlType;
        }


        private object get_0_ResultScreensPage_ViewModel(object instance)
        {
            var that = (global::CourseWork_2.Pages.ResultScreensPage)instance;
            return that.ViewModel;
        }
        private object get_1_SwipeableSplitView_IsSwipeablePaneOpen(object instance)
        {
            var that = (global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView)instance;
            return that.IsSwipeablePaneOpen;
        }
        private void set_1_SwipeableSplitView_IsSwipeablePaneOpen(object instance, object Value)
        {
            var that = (global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView)instance;
            that.IsSwipeablePaneOpen = (global::System.Boolean)Value;
        }
        private object get_2_SwipeableSplitView_PanAreaInitialTranslateX(object instance)
        {
            var that = (global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView)instance;
            return that.PanAreaInitialTranslateX;
        }
        private void set_2_SwipeableSplitView_PanAreaInitialTranslateX(object instance, object Value)
        {
            var that = (global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView)instance;
            that.PanAreaInitialTranslateX = (global::System.Double)Value;
        }
        private object get_3_SwipeableSplitView_PanAreaThreshold(object instance)
        {
            var that = (global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView)instance;
            return that.PanAreaThreshold;
        }
        private void set_3_SwipeableSplitView_PanAreaThreshold(object instance, object Value)
        {
            var that = (global::CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView)instance;
            that.PanAreaThreshold = (global::System.Double)Value;
        }
        private object get_4_WebViewExtensions_UriSource(object instance)
        {
            return global::CourseWork_2.Extensions_Folder.WebViewExtensions.GetUriSource((global::Windows.UI.Xaml.DependencyObject)instance);
        }
        private void set_4_WebViewExtensions_UriSource(object instance, object Value)
        {
            global::CourseWork_2.Extensions_Folder.WebViewExtensions.SetUriSource((global::Windows.UI.Xaml.DependencyObject)instance, (global::System.String)Value);
        }
        private object get_5_ReviewPrototypePage_ViewModel(object instance)
        {
            var that = (global::CourseWork_2.Pages.ReviewPrototypePage)instance;
            return that.ViewModel;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlMember xamlMember = null;
            global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "CourseWork_2.Pages.ResultScreensPage.ViewModel":
                userType = (global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CourseWork_2.Pages.ResultScreensPage");
                xamlMember = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlMember(this, "ViewModel", "CourseWork_2.ViewModel.ResultScreensViewModel");
                xamlMember.Getter = get_0_ResultScreensPage_ViewModel;
                xamlMember.SetIsReadOnly();
                break;
            case "CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView.IsSwipeablePaneOpen":
                userType = (global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView");
                xamlMember = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlMember(this, "IsSwipeablePaneOpen", "Boolean");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_1_SwipeableSplitView_IsSwipeablePaneOpen;
                xamlMember.Setter = set_1_SwipeableSplitView_IsSwipeablePaneOpen;
                break;
            case "CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView.PanAreaInitialTranslateX":
                userType = (global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView");
                xamlMember = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlMember(this, "PanAreaInitialTranslateX", "Double");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_2_SwipeableSplitView_PanAreaInitialTranslateX;
                xamlMember.Setter = set_2_SwipeableSplitView_PanAreaInitialTranslateX;
                break;
            case "CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView.PanAreaThreshold":
                userType = (global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CourseWork_2.SwipeableSplitViewControl_Folder.SwipeableSplitView");
                xamlMember = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlMember(this, "PanAreaThreshold", "Double");
                xamlMember.SetIsDependencyProperty();
                xamlMember.Getter = get_3_SwipeableSplitView_PanAreaThreshold;
                xamlMember.Setter = set_3_SwipeableSplitView_PanAreaThreshold;
                break;
            case "CourseWork_2.Extensions_Folder.WebViewExtensions.UriSource":
                userType = (global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CourseWork_2.Extensions_Folder.WebViewExtensions");
                xamlMember = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlMember(this, "UriSource", "String");
                xamlMember.SetTargetTypeName("Windows.UI.Xaml.DependencyObject");
                xamlMember.SetIsAttachable();
                xamlMember.Getter = get_4_WebViewExtensions_UriSource;
                xamlMember.Setter = set_4_WebViewExtensions_UriSource;
                break;
            case "CourseWork_2.Pages.ReviewPrototypePage.ViewModel":
                userType = (global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CourseWork_2.Pages.ReviewPrototypePage");
                xamlMember = new global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlMember(this, "ViewModel", "CourseWork_2.ViewModel.ReviewPrototypeViewModel");
                xamlMember.Getter = get_5_ReviewPrototypePage_ViewModel;
                xamlMember.SetIsReadOnly();
                break;
            }
            return xamlMember;
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlSystemBaseType
    {
        global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::CourseWork_2.CourseWork_2_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}

