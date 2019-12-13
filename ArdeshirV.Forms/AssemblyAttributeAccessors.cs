#region Header

///////////////////////////////////////////////////////////////////////////////
//                                                                           //
//    File: AssemblyAttributeAccessors.cs                                    //
//    Provides access to assembly attributes.                                //
//                                                                           //
// Copyright© 2002-2019 ardeshirv@protonmail.com, Licensed under GPLv3+      //
//                                                                           //
///////////////////////////////////////////////////////////////////////////////

using System.Reflection;

#endregion
//-----------------------------------------------------------------------------
namespace ArdeshirV.Utilities
{
    public class AssemblyAttributeAccessors
    {
        #region Variables

        private readonly Assembly m_asmExcuting = null;

        #endregion Variables
        //---------------------------------------------------------------------
        public AssemblyAttributeAccessors(Assembly asmExcuting)
        {
            m_asmExcuting = asmExcuting;
        }
        //---------------------------------------------------------------------
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = m_asmExcuting.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];

                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }

                return System.IO.Path.GetFileNameWithoutExtension(m_asmExcuting.CodeBase);
            }
        }
        //---------------------------------------------------------------------
        public string AssemblyVersion
        {
            get
            {
                return m_asmExcuting.GetName().Version.ToString();
            }
        }
        //---------------------------------------------------------------------
        public string AssemblyDescription
        {
            get
            {
                object[] attributes = m_asmExcuting.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);

                if (attributes.Length == 0)
                    return "";

                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        //---------------------------------------------------------------------
        public string AssemblyProduct
        {
            get
            {
                object[] attributes = m_asmExcuting.GetCustomAttributes(typeof(AssemblyProductAttribute), false);

                if (attributes.Length == 0)
                    return "";

                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        //---------------------------------------------------------------------
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = m_asmExcuting.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

                if (attributes.Length == 0)
                    return "";

                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        //---------------------------------------------------------------------
        public string AssemblyCompany
        {
            get
            {
                object[] attributes = m_asmExcuting.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);

                if (attributes.Length == 0)
                    return "";

                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        //---------------------------------------------------------------------
    }
}
//-----------------------------------------------------------------------------






















