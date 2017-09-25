using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CloudManagement.Helper
{
    public class ExcelHelper
    {
        public static DataSet ReadExcel(string excelfilepath)
        {

            var excelConnectionString = @"provider=microsoft.jet.oledb.4.0;data source=" + excelfilepath + ";extended properties=\"excel 8.0;hdr=yes;\"";
            using (var conn = new OleDbConnection(excelConnectionString))
            {
                conn.Open();
                var command = new OleDbDataAdapter("Select * from [Sheet1$]", conn);
                var ds = new DataSet();
                command.Fill(ds);

                return ds;
            }
        }
    }
}