using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;


namespace EjemploWebService
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*WSEjemplo.Service1SoapClient wsconexion = new WSEjemplo.Service1SoapClient();

            string error = "";

            bool conectado = wsconexion.ProbarConexion(ref error);

            if (conectado == true)
            {
                Label1.Text = "Conexion Exitosa";
            }
            else
            {
                Label1.Text = error;
            }*/


            //Probar Web Service

            /*WebService1.Service1 servicio = new WebService1.Service1();
            string nom = TextBox1.Text;
            DataSet custDS = new DataSet();
            custDS = servicio.getEncontrar(nom);
            this.Label1.Text = custDS.Tables.Count.ToString();*/

            //=====================================================================

            /*Sample proxySample = new DsSample.Sample();  // Proxy object.
            DataSet customersDataSet = proxySample.GetCustomers();
            DataTable customersTable = customersDataSet.Tables["Customers"];

            DataRow row = customersTable.NewRow();
            row["CustomerID"] = ."ABCDE";
            row["CompanyName"] = "New Company Name";
            customersTable.Rows.Add(row);

            DataSet updateDataSet = new DataSet();

            updateDataSet =
              proxySample.UpdateCustomers(customersDataSet.GetChanges());

            customersDataSet.Merge(updateDataSet);
            customersDataSet.AcceptChanges();
            */

            string strHostName = string.Empty;
// Getting Ip address of local machine…
// First get the host name of local machine.
strHostName = Dns.GetHostName();
// Then using host name, get the IP address list..
IPAddress[] hostIPs = Dns.GetHostAddresses(strHostName);
for (int i = 0; i < hostIPs.Length; i++)
{
Label1.Text = hostIPs[i].ToString();
}
Label2.Text = "123"+strHostName;
}
}
        }
    

