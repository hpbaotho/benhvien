﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiabetesDido.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public string positiveString {
            get {
                return ((string)(this["positiveString"]));
            }
            set {
                this["positiveString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public string negativeString {
            get {
                return ((string)(this["negativeString"]));
            }
            set {
                this["negativeString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int negativeValue {
            get {
                return ((int)(this["negativeValue"]));
            }
            set {
                this["negativeValue"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\sqlexpress;Initial Catalog=BenhVien;Integrated Security=True")]
        public string testConnectionString {
            get {
                return ((string)(this["testConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("TieuDuong")]
        public string ClassColumnName {
            get {
                return ((string)(this["ClassColumnName"]));
            }
            set {
                this["ClassColumnName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Tuoi,GioiTinh,Cholesterol,HDL_Cholesterol,Triglyceride,LDL_Cholesterol,Glucose,SG" +
            "OT,SGPT,Urea,WBC,LYM,MONO,TyLeLYM,TyLeMONO,HGB,RBC,HTC,MCV,MCH,MCHC,RDW_CV,PLT,M" +
            "PV,PDW,PCT")]
        public string AttributeColumnNames {
            get {
                return ((string)(this["AttributeColumnNames"]));
            }
            set {
                this["AttributeColumnNames"] = value;
            }
        }
    }
}
