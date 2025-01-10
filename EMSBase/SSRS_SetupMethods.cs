using ENV;
using ENV.Data;
using Firefly.Box;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace EMS
{
    public class SSRS_SetupMethods : BusinessProcessBase
    {
        // TODO: Add members Here

        public SSRS_SetupMethods()
        {
        }

        internal void setreport(Text ReportName, ReportParameter[] reportParameters, bool ShowParameterPrompts, ReportViewer TempReport)
        {
            // Setting Report Urls
            TempReport.ServerReport.ReportServerUrl = new Uri(ENV.UserSettings.Get("MAGIC_SERVERS", "ReportServerUrl").Trim());
            TempReport.ServerReport.ReportPath = ENV.UserSettings.Get("MAGIC_SERVERS", "ServerEMSReportsPath").Trim() + ReportName;

            // Setting Parameters          
            TempReport.ServerReport.SetParameters(reportParameters);
            TempReport.ShowParameterPrompts = ShowParameterPrompts;
            TempReport.RefreshReport();

            // return TempReport;
        }
    }
}
