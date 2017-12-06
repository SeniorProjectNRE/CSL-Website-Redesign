using CSLDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CSL.Tests.DataAccess
{
    class MockDataAccess : IDataAccess
    {
        public DataTable GetAgencyCode(int year, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("ReportYear");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn y = new DataColumn("ReportAgencyCode");
            y.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(y);
            DataColumn l = new DataColumn("ReportAgencyName");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);

            DataRow testRow1 = myTable.NewRow();

            testRow1["ReportYear"] = year;
            testRow1["ReportAgencyCode"] = code;
            testRow1["ReportAgencyName"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetAllBroadband(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("LibraryName");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn h = new DataColumn("Jurisdiction");
            h.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(h);
            DataColumn i = new DataColumn("CLSA");
            i.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(i);
            DataColumn j = new DataColumn("City");
            j.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(j);
            DataColumn k = new DataColumn("County");
            k.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(k);
            DataColumn l = new DataColumn("Zip");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn m = new DataColumn("AssemblyDistrict");
            m.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(m);
            DataColumn n = new DataColumn("SenateDistrict");
            n.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(n);
            DataColumn o = new DataColumn("CongressionalDistrict");
            o.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(o);
            DataColumn p = new DataColumn("Status");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn q = new DataColumn("StatusCode");
            q.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(q);

            DataRow testRow1 = myTable.NewRow();

            testRow1["LibraryName"] = library;
            testRow1["Jurisdiction"] = jurisdiction;
            testRow1["CLSA"] = csla;
            testRow1["City"] = city;
            testRow1["County"] = county;
            testRow1["Zip"] = zip;
            testRow1["AssemblyDistrict"] = assembly;
            testRow1["SenateDistrict"] = senate;
            testRow1["CongressionalDistrict"] = congress;
            testRow1["Status"] = status;
            testRow1["StatusCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetAllGrants(string grantNum, string year, string library, string project, int award)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("GrantID");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn y = new DataColumn("Year");
            y.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(y);
            DataColumn l = new DataColumn("Library");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn p = new DataColumn("Project");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn a = new DataColumn("Award");
            a.DataType = System.Type.GetType("System.Int32");
            myTable.Columns.Add(a);

            DataRow testRow1 = myTable.NewRow();

            testRow1["GrantID"] = grantNum;
            testRow1["Year"] = year;
            testRow1["Library"] = library;
            testRow1["Project"] = project;
            testRow1["Award"] = award;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetAllSLAA(int year, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("ReportYear");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn y = new DataColumn("ReportAgencyCode");
            y.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(y);
            DataColumn l = new DataColumn("ReportAgencyName");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);

            DataRow testRow1 = myTable.NewRow();

            testRow1["ReportYear"] = year;
            testRow1["ReportAgencyCode"] = "1ba";
            testRow1["ReportAgencyName"] = "1ab";

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetAssembly(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("LibraryName");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn h = new DataColumn("Jurisdiction");
            h.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(h);
            DataColumn i = new DataColumn("CLSA");
            i.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(i);
            DataColumn j = new DataColumn("City");
            j.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(j);
            DataColumn k = new DataColumn("County");
            k.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(k);
            DataColumn l = new DataColumn("Zip");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn m = new DataColumn("AssemblyDistrict");
            m.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(m);
            DataColumn n = new DataColumn("SenateDistrict");
            n.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(n);
            DataColumn o = new DataColumn("CongressionalDistrict");
            o.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(o);
            DataColumn p = new DataColumn("Status");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn q = new DataColumn("StatusCode");
            q.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(q);

            DataRow testRow1 = myTable.NewRow();

            testRow1["LibraryName"] = library;
            testRow1["Jurisdiction"] = jurisdiction;
            testRow1["CLSA"] = csla;
            testRow1["City"] = city;
            testRow1["County"] = county;
            testRow1["Zip"] = zip;
            testRow1["AssemblyDistrict"] = assembly;
            testRow1["SenateDistrict"] = senate;
            testRow1["CongressionalDistrict"] = congress;
            testRow1["Status"] = status;
            testRow1["StatusCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetAward(string grantNum, string year, string library, string project, int award)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("GrantID");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn y = new DataColumn("Year");
            y.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(y);
            DataColumn l = new DataColumn("Library");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn p = new DataColumn("Project");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn a = new DataColumn("Award");
            a.DataType = System.Type.GetType("System.Int32");
            myTable.Columns.Add(a);

            DataRow testRow1 = myTable.NewRow();

            testRow1["GrantID"] = grantNum;
            testRow1["Year"] = year;
            testRow1["Library"] = library;
            testRow1["Project"] = project;
            testRow1["Award"] = award;

            myTable.Rows.Add(testRow1);

            return myTable;

        }

        public DataTable GetCity(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("LibraryName");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn h = new DataColumn("Jurisdiction");
            h.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(h);
            DataColumn i = new DataColumn("CLSA");
            i.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(i);
            DataColumn j = new DataColumn("City");
            j.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(j);
            DataColumn k = new DataColumn("County");
            k.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(k);
            DataColumn l = new DataColumn("Zip");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn m = new DataColumn("AssemblyDistrict");
            m.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(m);
            DataColumn n = new DataColumn("SenateDistrict");
            n.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(n);
            DataColumn o = new DataColumn("CongressionalDistrict");
            o.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(o);
            DataColumn p = new DataColumn("Status");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn q = new DataColumn("StatusCode");
            q.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(q);

            DataRow testRow1 = myTable.NewRow();

            testRow1["LibraryName"] = library;
            testRow1["Jurisdiction"] = jurisdiction;
            testRow1["CLSA"] = csla;
            testRow1["City"] = city;
            testRow1["County"] = county;
            testRow1["Zip"] = zip;
            testRow1["AssemblyDistrict"] = assembly;
            testRow1["SenateDistrict"] = senate;
            testRow1["CongressionalDistrict"] = congress;
            testRow1["Status"] = status;
            testRow1["StatusCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetCLSA(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("LibraryName");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn h = new DataColumn("Jurisdiction");
            h.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(h);
            DataColumn i = new DataColumn("CLSA");
            i.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(i);
            DataColumn j = new DataColumn("City");
            j.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(j);
            DataColumn k = new DataColumn("County");
            k.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(k);
            DataColumn l = new DataColumn("Zip");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn m = new DataColumn("AssemblyDistrict");
            m.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(m);
            DataColumn n = new DataColumn("SenateDistrict");
            n.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(n);
            DataColumn o = new DataColumn("CongressionalDistrict");
            o.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(o);
            DataColumn p = new DataColumn("Status");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn q = new DataColumn("StatusCode");
            q.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(q);

            DataRow testRow1 = myTable.NewRow();

            testRow1["LibraryName"] = library;
            testRow1["Jurisdiction"] = jurisdiction;
            testRow1["CLSA"] = csla;
            testRow1["City"] = city;
            testRow1["County"] = county;
            testRow1["Zip"] = zip;
            testRow1["AssemblyDistrict"] = assembly;
            testRow1["SenateDistrict"] = senate;
            testRow1["CongressionalDistrict"] = congress;
            testRow1["Status"] = status;
            testRow1["StatusCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetCode(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("LibraryName");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn h = new DataColumn("Jurisdiction");
            h.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(h);
            DataColumn i = new DataColumn("CLSA");
            i.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(i);
            DataColumn j = new DataColumn("City");
            j.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(j);
            DataColumn k = new DataColumn("County");
            k.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(k);
            DataColumn l = new DataColumn("Zip");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn m = new DataColumn("AssemblyDistrict");
            m.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(m);
            DataColumn n = new DataColumn("SenateDistrict");
            n.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(n);
            DataColumn o = new DataColumn("CongressionalDistrict");
            o.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(o);
            DataColumn p = new DataColumn("Status");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn q = new DataColumn("StatusCode");
            q.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(q);

            DataRow testRow1 = myTable.NewRow();

            testRow1["LibraryName"] = library;
            testRow1["Jurisdiction"] = jurisdiction;
            testRow1["CLSA"] = csla;
            testRow1["City"] = city;
            testRow1["County"] = county;
            testRow1["Zip"] = zip;
            testRow1["AssemblyDistrict"] = assembly;
            testRow1["SenateDistrict"] = senate;
            testRow1["CongressionalDistrict"] = congress;
            testRow1["Status"] = status;
            testRow1["StatusCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetCongress(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("LibraryName");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn h = new DataColumn("Jurisdiction");
            h.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(h);
            DataColumn i = new DataColumn("CLSA");
            i.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(i);
            DataColumn j = new DataColumn("City");
            j.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(j);
            DataColumn k = new DataColumn("County");
            k.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(k);
            DataColumn l = new DataColumn("Zip");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn m = new DataColumn("AssemblyDistrict");
            m.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(m);
            DataColumn n = new DataColumn("SenateDistrict");
            n.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(n);
            DataColumn o = new DataColumn("CongressionalDistrict");
            o.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(o);
            DataColumn p = new DataColumn("Status");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn q = new DataColumn("StatusCode");
            q.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(q);

            DataRow testRow1 = myTable.NewRow();

            testRow1["LibraryName"] = library;
            testRow1["Jurisdiction"] = jurisdiction;
            testRow1["CLSA"] = csla;
            testRow1["City"] = city;
            testRow1["County"] = county;
            testRow1["Zip"] = zip;
            testRow1["AssemblyDistrict"] = assembly;
            testRow1["SenateDistrict"] = senate;
            testRow1["CongressionalDistrict"] = congress;
            testRow1["Status"] = status;
            testRow1["StatusCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetCounty(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("LibraryName");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn h = new DataColumn("Jurisdiction");
            h.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(h);
            DataColumn i = new DataColumn("CLSA");
            i.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(i);
            DataColumn j = new DataColumn("City");
            j.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(j);
            DataColumn k = new DataColumn("County");
            k.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(k);
            DataColumn l = new DataColumn("Zip");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn m = new DataColumn("AssemblyDistrict");
            m.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(m);
            DataColumn n = new DataColumn("SenateDistrict");
            n.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(n);
            DataColumn o = new DataColumn("CongressionalDistrict");
            o.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(o);
            DataColumn p = new DataColumn("Status");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn q = new DataColumn("StatusCode");
            q.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(q);

            DataRow testRow1 = myTable.NewRow();

            testRow1["LibraryName"] = library;
            testRow1["Jurisdiction"] = jurisdiction;
            testRow1["CLSA"] = csla;
            testRow1["City"] = city;
            testRow1["County"] = county;
            testRow1["Zip"] = zip;
            testRow1["AssemblyDistrict"] = assembly;
            testRow1["SenateDistrict"] = senate;
            testRow1["CongressionalDistrict"] = congress;
            testRow1["Status"] = status;
            testRow1["StatusCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetGrantNumber(string grantNum, string year, string library, string project, int award)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("GrantID");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn y = new DataColumn("Year");
            y.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(y);
            DataColumn l = new DataColumn("Library");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn p = new DataColumn("Project");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn a = new DataColumn("Award");
            a.DataType = System.Type.GetType("System.Int32");
            myTable.Columns.Add(a);

            DataRow testRow1 = myTable.NewRow();

            testRow1["GrantID"] = grantNum;
            testRow1["Year"] = year;
            testRow1["Library"] = library;
            testRow1["Project"] = project;
            testRow1["Award"] = award;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetJurisdiction(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("LibraryName");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn h = new DataColumn("Jurisdiction");
            h.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(h);
            DataColumn i = new DataColumn("CLSA");
            i.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(i);
            DataColumn j = new DataColumn("City");
            j.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(j);
            DataColumn k = new DataColumn("County");
            k.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(k);
            DataColumn l = new DataColumn("Zip");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn m = new DataColumn("AssemblyDistrict");
            m.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(m);
            DataColumn n = new DataColumn("SenateDistrict");
            n.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(n);
            DataColumn o = new DataColumn("CongressionalDistrict");
            o.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(o);
            DataColumn p = new DataColumn("Status");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn q = new DataColumn("StatusCode");
            q.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(q);

            DataRow testRow1 = myTable.NewRow();

            testRow1["LibraryName"] = library;
            testRow1["Jurisdiction"] = jurisdiction;
            testRow1["CLSA"] = csla;
            testRow1["City"] = city;
            testRow1["County"] = county;
            testRow1["Zip"] = zip;
            testRow1["AssemblyDistrict"] = assembly;
            testRow1["SenateDistrict"] = senate;
            testRow1["CongressionalDistrict"] = congress;
            testRow1["Status"] = status;
            testRow1["StatusCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetLibrary(string grantNum, string year, string library, string project, int award)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("GrantID");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn y = new DataColumn("Year");
            y.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(y);
            DataColumn l = new DataColumn("Library");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn p = new DataColumn("Project");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn a = new DataColumn("Award");
            a.DataType = System.Type.GetType("System.Int32");
            myTable.Columns.Add(a);

            DataRow testRow1 = myTable.NewRow();

            testRow1["GrantID"] = grantNum;
            testRow1["Year"] = year;
            testRow1["Library"] = library;
            testRow1["Project"] = project;
            testRow1["Award"] = award;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetLibrary(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("LibraryName");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn h = new DataColumn("Jurisdiction");
            h.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(h);
            DataColumn i = new DataColumn("CLSA");
            i.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(i);
            DataColumn j = new DataColumn("City");
            j.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(j);
            DataColumn k = new DataColumn("County");
            k.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(k);
            DataColumn l = new DataColumn("Zip");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn m = new DataColumn("AssemblyDistrict");
            m.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(m);
            DataColumn n = new DataColumn("SenateDistrict");
            n.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(n);
            DataColumn o = new DataColumn("CongressionalDistrict");
            o.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(o);
            DataColumn p = new DataColumn("Status");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn q = new DataColumn("StatusCode");
            q.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(q);

            DataRow testRow1 = myTable.NewRow();

            testRow1["LibraryName"] = library;
            testRow1["Jurisdiction"] = jurisdiction;
            testRow1["CLSA"] = csla;
            testRow1["City"] = city;
            testRow1["County"] = county;
            testRow1["Zip"] = zip;
            testRow1["AssemblyDistrict"] = assembly;
            testRow1["SenateDistrict"] = senate;
            testRow1["CongressionalDistrict"] = congress;
            testRow1["Status"] = status;
            testRow1["StatusCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetProject(string grantNum, string year, string library, string project, int award)
        {

            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("GrantID");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn y = new DataColumn("Year");
            y.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(y);
            DataColumn l = new DataColumn("Library");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn p = new DataColumn("Project");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn a = new DataColumn("Award");
            a.DataType = System.Type.GetType("System.Int32");
            myTable.Columns.Add(a);

            DataRow testRow1 = myTable.NewRow();

            testRow1["GrantID"] = grantNum;
            testRow1["Year"] = year;
            testRow1["Library"] = library;
            testRow1["Project"] = project;
            testRow1["Award"] = award;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetSenate(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("LibraryName");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn h = new DataColumn("Jurisdiction");
            h.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(h);
            DataColumn i = new DataColumn("CLSA");
            i.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(i);
            DataColumn j = new DataColumn("City");
            j.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(j);
            DataColumn k = new DataColumn("County");
            k.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(k);
            DataColumn l = new DataColumn("Zip");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn m = new DataColumn("AssemblyDistrict");
            m.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(m);
            DataColumn n = new DataColumn("SenateDistrict");
            n.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(n);
            DataColumn o = new DataColumn("CongressionalDistrict");
            o.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(o);
            DataColumn p = new DataColumn("Status");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn q = new DataColumn("StatusCode");
            q.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(q);

            DataRow testRow1 = myTable.NewRow();

            testRow1["LibraryName"] = library;
            testRow1["Jurisdiction"] = jurisdiction;
            testRow1["CLSA"] = csla;
            testRow1["City"] = city;
            testRow1["County"] = county;
            testRow1["Zip"] = zip;
            testRow1["AssemblyDistrict"] = assembly;
            testRow1["SenateDistrict"] = senate;
            testRow1["CongressionalDistrict"] = congress;
            testRow1["Status"] = status;
            testRow1["StatusCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetStatus(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("LibraryName");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn h = new DataColumn("Jurisdiction");
            h.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(h);
            DataColumn i = new DataColumn("CLSA");
            i.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(i);
            DataColumn j = new DataColumn("City");
            j.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(j);
            DataColumn k = new DataColumn("County");
            k.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(k);
            DataColumn l = new DataColumn("Zip");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn m = new DataColumn("AssemblyDistrict");
            m.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(m);
            DataColumn n = new DataColumn("SenateDistrict");
            n.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(n);
            DataColumn o = new DataColumn("CongressionalDistrict");
            o.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(o);
            DataColumn p = new DataColumn("Status");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn q = new DataColumn("StatusCode");
            q.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(q);

            DataRow testRow1 = myTable.NewRow();

            testRow1["LibraryName"] = library;
            testRow1["Jurisdiction"] = jurisdiction;
            testRow1["CLSA"] = csla;
            testRow1["City"] = city;
            testRow1["County"] = county;
            testRow1["Zip"] = zip;
            testRow1["AssemblyDistrict"] = assembly;
            testRow1["SenateDistrict"] = senate;
            testRow1["CongressionalDistrict"] = congress;
            testRow1["Status"] = status;
            testRow1["StatusCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetYear(string grantNum, string year, string library, string project, int award)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("GrantID");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn y = new DataColumn("Year");
            y.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(y);
            DataColumn l = new DataColumn("Library");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn p = new DataColumn("Project");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn a = new DataColumn("Award");
            a.DataType = System.Type.GetType("System.Int32");
            myTable.Columns.Add(a);

            DataRow testRow1 = myTable.NewRow();

            testRow1["GrantID"] = grantNum;
            testRow1["Year"] = year;
            testRow1["Library"] = library;
            testRow1["Project"] = project;
            testRow1["Award"] = award;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetYear(int year, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("Year");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn y = new DataColumn("ReportAgencyCode");
            y.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(y);

            DataRow testRow1 = myTable.NewRow();

            testRow1["Year"] = year;
            testRow1["ReportAgencyCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }

        public DataTable GetZip(string library, string jurisdiction, string csla, string city, string county, int zip, int assembly, int senate, int congress, string status, string code)
        {
            DataTable myTable = new DataTable();
            DataColumn g = new DataColumn("LibraryName");
            g.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(g);
            DataColumn h = new DataColumn("Jurisdiction");
            h.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(h);
            DataColumn i = new DataColumn("CLSA");
            i.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(i);
            DataColumn j = new DataColumn("City");
            j.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(j);
            DataColumn k = new DataColumn("County");
            k.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(k);
            DataColumn l = new DataColumn("Zip");
            l.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(l);
            DataColumn m = new DataColumn("AssemblyDistrict");
            m.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(m);
            DataColumn n = new DataColumn("SenateDistrict");
            n.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(n);
            DataColumn o = new DataColumn("CongressionalDistrict");
            o.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(o);
            DataColumn p = new DataColumn("Status");
            p.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(p);
            DataColumn q = new DataColumn("StatusCode");
            q.DataType = System.Type.GetType("System.String");
            myTable.Columns.Add(q);

            DataRow testRow1 = myTable.NewRow();

            testRow1["LibraryName"] = library;
            testRow1["Jurisdiction"] = jurisdiction;
            testRow1["CLSA"] = csla;
            testRow1["City"] = city;
            testRow1["County"] = county;
            testRow1["Zip"] = zip;
            testRow1["AssemblyDistrict"] = assembly;
            testRow1["SenateDistrict"] = senate;
            testRow1["CongressionalDistrict"] = congress;
            testRow1["Status"] = status;
            testRow1["StatusCode"] = code;

            myTable.Rows.Add(testRow1);

            return myTable;
        }
    }
}
