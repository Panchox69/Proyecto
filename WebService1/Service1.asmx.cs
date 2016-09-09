using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
//using Oracle.DataAccess.Client;
using System.Collections;
using System.Data.OracleClient;

namespace WebService1
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://localhost/WebService", Name = "WebServicePrueba", Description = "Servicio Prueba")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        public OracleConnection conn = new OracleConnection("User Id=FRUTOS;Password=frutos;Data Source=XE");

        
        [WebMethod]
        public DataSet Productos_Sel_All()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "productos_tapi.sel_all";
            cmd.Parameters.Add("cur_Productos", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "PRODUCTOS");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        [WebMethod]
        public DataSet Imagenes_Sel_All()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "imagenes_tapi.sel_all";
            cmd.Parameters.Add("cur_Imagen", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "IMAGENES");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        
        [WebMethod]
        public DataSet Productor_Sel(int rut)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "productor_tapi.sel";
            cmd.Parameters.Add("cur_Productor", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.Parameters.Add("p_RUT", OracleType.Int32).Value = rut;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "PRODUCTORES");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        [WebMethod]
        public DataSet Productor_Sel_All()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "productor_tapi.sel_all";
            cmd.Parameters.Add("cur_Productor", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "PRODUCTORES");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        
        [WebMethod]
        public void Imagenes_Ins(int id_producto, String nombre, String descripcion, int orden, DateTime fecha, String ubicacion)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "imagenes_tapi.ins";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_id_producto", OracleType.Int32).Value = id_producto;
            cmd.Parameters.Add("p_nombre", OracleType.VarChar).Value = nombre;
            cmd.Parameters.Add("p_descripcion", OracleType.VarChar).Value = descripcion;
            cmd.Parameters.Add("p_orden", OracleType.Int32).Value = orden;
            cmd.Parameters.Add("p_fecha", OracleType.DateTime).Value = fecha;
            cmd.Parameters.Add("p_ubicacion", OracleType.VarChar).Value = ubicacion;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        [WebMethod]
        public int Productos_Ins(int rut_productor, int id_tipo_producto, int oferta, String descripcion_elaboracion, int id_direccion, String zona_cultivo, int stock, int precio_unitario, int id_medida, int id_tipo_cultivo, int activo)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "productos_tapi.ins";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_ID_PRODUCTO", OracleType.Number).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_rut_productor", OracleType.Int32).Value = rut_productor;
            cmd.Parameters.Add("p_id_tipo_producto", OracleType.Int32).Value = id_tipo_producto;
            cmd.Parameters.Add("p_oferta", OracleType.Int32).Value = oferta;
            cmd.Parameters.Add("p_descripcion_elaboracion", OracleType.VarChar).Value = descripcion_elaboracion;
            cmd.Parameters.Add("p_id_direccion", OracleType.Int32).Value = id_direccion;
            cmd.Parameters.Add("p_zona_cultivo", OracleType.VarChar).Value = zona_cultivo;
            cmd.Parameters.Add("p_stock", OracleType.Int32).Value = stock;
            cmd.Parameters.Add("p_precio_unitario", OracleType.Int32).Value = precio_unitario;
            cmd.Parameters.Add("p_id_medida", OracleType.Int32).Value = id_medida;
            cmd.Parameters.Add("p_id_tipo_cultivo", OracleType.Int32).Value = id_tipo_cultivo;
            cmd.Parameters.Add("p_activo", OracleType.Int32).Value = activo;
            OracleString rowId;
            conn.Open();
            int rowsAffected = cmd.ExecuteOracleNonQuery(out rowId);
            conn.Close();
            return Convert.ToInt32(cmd.Parameters["p_ID_PRODUCTO"].Value);
        }

        [WebMethod]
        public DataSet Tipo_Producto_Sel_All()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "tipo_producto_tapi.sel_all";
            cmd.Parameters.Add("cur_TipoPro", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "TipoProducto");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        [WebMethod]
        public DataSet Tipo_Medida_Sel_All()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "tipo_medidas_tapi.sel_all";
            cmd.Parameters.Add("cur_TipoMed", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "TipoMedida");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        [WebMethod]
        public DataSet Tipo_Cultivo_Sel_All()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "tipo_cultivo_tapi.sel_all";
            cmd.Parameters.Add("cur_TipoCul", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "TipoCultivo");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        

        [WebMethod]
        public int Direccion_Ins(string nombre, int numero, int id_comuna, int coordenada_x, int coordenada_y)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "direcciones_tapi.ins";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_ID_DIRECCION", OracleType.Number).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_id_comuna", OracleType.Int32).Value = id_comuna;
            cmd.Parameters.Add("p_corrdenada_y", OracleType.Double).Value = coordenada_y;
            cmd.Parameters.Add("p_nombre", OracleType.VarChar).Value = nombre;
            cmd.Parameters.Add("p_numero", OracleType.Int32).Value = numero;
            cmd.Parameters.Add("p_coordenada_x", OracleType.Double).Value = coordenada_x;
            OracleString rowId;
            conn.Open();
            int rowsAffected = cmd.ExecuteOracleNonQuery(out rowId);
            conn.Close();
            return Convert.ToInt32(cmd.Parameters["p_ID_DIRECCION"].Value);
        }


        [WebMethod]
        public DataSet Usuario_Sel(int rut, string pas)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "usuarios_tapi.sel";
            cmd.Parameters.Add("p_rut", OracleType.Int32).Value = rut;
            cmd.Parameters.Add("p_contrasena", OracleType.VarChar).Value = pas;
            cmd.Parameters.Add("cur_Usuarios", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "Usuarios");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        [WebMethod]
        public DataSet Usuario_Sel_All()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "usuarios_tapi.sel_all";
            cmd.Parameters.Add("cur_Usuarios", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "Usuarios");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        [WebMethod]
        public DataSet Productores_Hab_Sel_All()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "productores_hab_tapi.sel_all";
            cmd.Parameters.Add("cur_ProductorH", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "Productores_Hab");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        [WebMethod]
        public DataSet Productores_Hab_Sel(int rut)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "productores_hab_tapi.sel";
            cmd.Parameters.Add("cur_ProductorH", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.Parameters.Add("p_rut", OracleType.VarChar).Value = rut;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "Productores_Hab");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        [WebMethod]
        public DataSet Regiones_Sel_All()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "regiones_tapi.sel_all";
            cmd.Parameters.Add("cur_Regiones", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "REGIONES");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        [WebMethod]
        public DataSet Comunas_Sel(int idregion, int idcomuna)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "comunas_tapi.sel";
            cmd.Parameters.Add("cur_Comunas", OracleType.Cursor).Direction =
            ParameterDirection.Output;
            cmd.Parameters.Add("p_id_comuna", OracleType.Int32).Value = idcomuna;
            cmd.Parameters.Add("p_id_region", OracleType.Int32).Value = idregion;
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.TableMappings.Add("Table", "COMUNAS");
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }


        [WebMethod]
        public void Usuario_Ins(int rut, string contrasena, int id_tipo_perfil)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "usuarios_tapi.ins";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_rut", OracleType.Int32).Value = rut;
            cmd.Parameters.Add("p_contrasena", OracleType.VarChar).Value = contrasena;
            cmd.Parameters.Add("p_id_tipo_perfil", OracleType.Int32).Value = id_tipo_perfil;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        [WebMethod]
        public void Productor_Ins(int rut, char dv, string nombre, string apellido, char sexo, int id_direccionparticular, int telefono, string correo, int id_direccionnegocio, int mismadireccion)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "productor_tapi.ins";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_rut", OracleType.Int32).Value = rut;
            cmd.Parameters.Add("p_dv", OracleType.Char).Value = dv;
            cmd.Parameters.Add("p_nombre", OracleType.VarChar).Value = nombre;
            cmd.Parameters.Add("p_apellido", OracleType.VarChar).Value = apellido;
            cmd.Parameters.Add("p_sexo", OracleType.Char).Value = sexo;
            cmd.Parameters.Add("p_id_direccionparticular", OracleType.Int32).Value = id_direccionparticular;
            cmd.Parameters.Add("p_telefono", OracleType.Int32).Value = telefono;
            cmd.Parameters.Add("p_correo", OracleType.VarChar).Value = correo;
            cmd.Parameters.Add("p_id_direccionnegocio", OracleType.Int32).Value = id_direccionnegocio;
            cmd.Parameters.Add("p_mismadireccion", OracleType.Int32).Value = mismadireccion;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        [WebMethod]
        public void Clientes_Ins(int rut, char dv, string nombre, string apellido, char sexo, string correo, int telefono, int bloqueado)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "clientes_tapi.ins";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_rut", OracleType.Int32).Value = rut;
            cmd.Parameters.Add("p_dv", OracleType.Char).Value = dv;
            cmd.Parameters.Add("p_nombre", OracleType.VarChar).Value = nombre;
            cmd.Parameters.Add("p_apellido", OracleType.VarChar).Value = apellido;
            cmd.Parameters.Add("p_sexo", OracleType.Char).Value = sexo;
            cmd.Parameters.Add("p_correo", OracleType.VarChar).Value = correo;
            cmd.Parameters.Add("p_telefono", OracleType.Int32).Value = telefono;
            cmd.Parameters.Add("p_bloqueado", OracleType.Int32).Value = bloqueado;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        [WebMethod]
        public void Usuarios_Perfiles_Ins(int rut, int id_tipo_perfil)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "usuarios_perfiles_tapi.ins";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_rut", OracleType.Int32).Value = rut;
            cmd.Parameters.Add("p_id_tipo_perfil", OracleType.Int32).Value = id_tipo_perfil;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        [WebMethod]
        public void Cliente_Direcciones_Ins(int rut, int id_direccion, char primaria)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "cliente_direcciones_tapi.ins";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_rut_cliente", OracleType.Int32).Value = rut;
            cmd.Parameters.Add("p_id_direccion", OracleType.Int32).Value = id_direccion;
            cmd.Parameters.Add("p_primaria", OracleType.Char).Value = primaria;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
              


            /*
            string consta = "User Id=DBFRUTOS;Password=dbfrutos;Data Source=XE";
            
            using(var con=new OracleConnection(consta))
            {
                      con.Open();
                     var sql = "insert into CLIENTES values (:rut,:dv,:nombre,:apellido,:sexo,:correo,:telefono,:id_direccionparticular,:id_comuna)";

        using(var cmd = new OracleCommand(sql,con)
             {
                 OracleParameter[] parameters;
                 parameters = new OracleParameter[4] 
                 {
             new OracleParameter("id",1234),
             new OracleParameter("name","John"),
             new OracleParameter("surname","Doe"),
             new OracleParameter("username","johnd")
                };

                cmd.Parameters.AddRange(parameters);
             cmd.ExecuteNonQuery();
        }
        }*/

            /*
            //public OracleConnection constr = new OracleConnection("User Id=DBFRUTOS;Password=dbfrutos;Data Source=XE");
            //OracleConnection constr = new OracleConnection("User Id=DBFRUTOS;Password=dbfrutos;Data Source=XE");
            string ConStr = "User Id=DBFRUTOS;Password=dbfrutos;Data Source=XE";
            OracleConnection con = new OracleConnection(ConStr);
            con.Open();

            //Create an OracleCommand object using the connection object
            OracleCommand cmd = new OracleCommand("", con);

            // Start a transaction
            OracleTransaction txn = con.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                cmd.CommandText = "insert into CLIENTES values ('" + rut + "','" + dv + "','" + nombre + "','" + apellido + "',''" + sexo + "'','" + correo + "','" + telefono + "','" + id_direccionparticular + "','" + id_comuna + "')";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                txn.Commit();
                //Console.WriteLine("One record is inserted into the database table.");
            }
            catch (Exception e)
            {
                txn.Rollback();
                //Console.WriteLine("No record was inserted into the database table.");
            }

        }*/

            /*
            OracleConnection oraConn = new OracleConnection();

        string connString = "User Id=DBFRUTOS;Password=dbfrutos;Data Source=XE";
        if (oraConn.State != ConnectionState.Open)
        {
            try
            {
                oraConn.ConnectionString = connString;

                oraConn.Open();

                //MessageBox.Show(oraConn.ConnectionString, "Successful Connection");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Exception Caught");
            }
        }

        if (oraConn.State == ConnectionState.Open)
        {
            //cmd.CommandText = "INSERT INTO CLIENTES (RUT,DV,NOMBRE,APELLIDO,SEXO,CORREO,TELEFONO,ID_DIRECCIONPARTICULAR,ID_COMUNA)" +
              //  "VALUES (rut,'dv','nombre','apellido','sexo','correo',telefono,id_direccionparticular,id_comuna)";

           // string sqlInsert = "insert into PlayerTable (player_num, last_name, first_name, position, club) ";
            //sqlInsert += "values (:p_num, :p_last, :p_first, :p_pos, :p_club)";

            string sqlInsert = "INSERT INTO CLIENTES (RUT,DV,NOMBRE,APELLIDO,SEXO,CORREO,TELEFONO,ID_DIRECCIONPARTICULAR,ID_COMUNA)";
            sqlInsert += "VALUES (:rut,:dv,:nombre,:apellido,:sexo,:correo,:telefono,:id_direccionparticular,:id_comuna)";

            OracleCommand cmdInsert = new OracleCommand();
            cmdInsert.CommandText = sqlInsert;
            cmdInsert.Connection = oraConn;

            OracleParameter PRUT = new OracleParameter();
            //RUT.DbType = DbType.Int32;
            PRUT.Value = rut;
            PRUT.ParameterName = ":rut";

            OracleParameter PDV = new OracleParameter();
            //DV.DbType = DbType.String;
            PDV.Value = dv;
            PDV.ParameterName = ":dv";

            OracleParameter PNOMBRE = new OracleParameter();
            PNOMBRE.Value = nombre;
            PNOMBRE.ParameterName = ":nombre";

            OracleParameter PAPELLIDO = new OracleParameter();
            PAPELLIDO.Value = apellido;
            PAPELLIDO.ParameterName = ":apellido";

            OracleParameter PSEXO = new OracleParameter();
            PSEXO.Value = sexo;
            PSEXO.ParameterName = ":sexo";

            OracleParameter PCORREO = new OracleParameter();
            PCORREO.Value = correo;
            PCORREO.ParameterName = ":correo";

            OracleParameter PTELEFONO = new OracleParameter();
            PTELEFONO.Value = telefono;
            PTELEFONO.ParameterName = ":telefono";

            OracleParameter PID_DIRECCIONPARTICULAR = new OracleParameter();
            PID_DIRECCIONPARTICULAR.Value = id_direccionparticular;
            PID_DIRECCIONPARTICULAR.ParameterName = ":id_direccionparticular";

            OracleParameter PID_COMUNA = new OracleParameter();
            PID_COMUNA.Value = id_comuna;
            PID_COMUNA.ParameterName = ":id_comuna";

            cmdInsert.Parameters.Add(PRUT);
            cmdInsert.Parameters.Add(PDV);
            cmdInsert.Parameters.Add(PNOMBRE);
            cmdInsert.Parameters.Add(PAPELLIDO);
            cmdInsert.Parameters.Add(PSEXO);
            cmdInsert.Parameters.Add(PCORREO);
            cmdInsert.Parameters.Add(PTELEFONO);
            cmdInsert.Parameters.Add(PID_COMUNA);
            cmdInsert.Parameters.Add(PSEXO);

            cmdInsert.ExecuteNonQuery();

            cmdInsert.Dispose();
        }
    }
    }*/

            /*
            //OracleConnection conn = new OracleConnection(constr);
            constr.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = constr;
            cmd.CommandText = "INSERT INTO CLIENTES (RUT,DV,NOMBRE,APELLIDO,SEXO,CORREO,TELEFONO,ID_DIRECCIONPARTICULAR,ID_COMUNA)" +
                "VALUES (rut,'dv','nombre','apellido','sexo','correo',telefono,id_direccionparticular,id_comuna)";
            int rowsUpdated = cmd.ExecuteNonQuery();
            if (rowsUpdated == 0)
                return 1;
            else
                return 0;
            cmd.Dispose();
            constr.Close();*/

            /* constr.Open();
             using (OracleCommand cmd = new OracleCommand("INSERT INTO CLIENTES (RUT,DV,NOMBRE,APELLIDO,SEXO,CORREO,TELEFONO,ID_DIRECCIONPARTICULAR,ID_COMUNA)" +
                    "VALUES(@rutnew,@dvnew,@nombrenew,@apellidonew,@sexonew,@correonew,@telefononew,@direccionnew,@comunanew)", constr))
                 {

                     //cmd.Parameters.AddWithValue("EmpId", 1);
                    //We can use Add, AddWithValue, and AddRange methods in Oracle also
                    // cmd.Connection.Open();
                     cmd.Parameters.Add("@rutnew",rut);
                     cmd.Parameters.Add("@dvnew", "dv");
                     cmd.Parameters.Add("@nombrenew", "nombre");
                     cmd.Parameters.Add("@apellidonew", "apellido");
                     cmd.Parameters.Add("@sexonew", "sexo");
                     cmd.Parameters.Add("@correonew", "correo");
                     cmd.Parameters.Add("@telefononew", telefono);
                     cmd.Parameters.Add("@direccionnew", id_direccionparticular);
                     cmd.Parameters.Add("@comunanew", id_comuna);
                     cmd.Connection.Open();
                 OracleDataReader reader = cmd.ExecuteReader();    
                
                     cmd.ExecuteNonQuery();
                     cmd.Connection.Close();
                 }
             }

         /*[WebMethod]
         public int registrarUsuario(string rut, int id_tipo_perfil, char dv, string nombre, string apellido, char sexo,string correo, int telefono, int id_direccionparticular, int comuna,string nombred, int numerod, int coorx, int coory)
         {
            
             using (OracleCommand cmd = new OracleCommand("INSERT INTO iAuditoria(ip,host,fechaHora,idRecinto,idEdificio,resultadoBusqueda)" +
                    "VALUES(@ipnew,@hostnew,@fechanew,@recintonew,@edificionew,@busquedanew)", constr))
                 {
                     cmd.Parameters.Add(new OracleParameter("@ipnew", rut));
                     cmd.Parameters.Add(new OracleParameter("@ipnew", rut);
                     cmd.Parameters.Add(new OracleParameter("@hostnew", id_tipo_perfil);
                     cmd.Parameters.Add(new OracleParameter("@fechanew", dv);
                     cmd.Parameters.Add(new OracleParameter("@recintonew", nombre);
                     ccmd.Parameters.Add(new OracleParameter("@edificionew", apellido);
                     ccmd.Parameters.Add(new OracleParameter("@busquedanew", sexo);
                     constr.Open();
                     int modified = cmd.ExecuteNonQuery();

                     if (constr.State == System.Data.ConnectionState.Open) constr.Close();
                     return modified;
                 }
             }

         [WebMethod]
         public int registrarDireccion(string rut, int id_tipo_perfil, char dv, string nombre, string apellido, char sexo,string correo, int telefono, int id_direccionparticular, int comuna,string nombred, int numerod, int coorx, int coory)
         {
            
             using (OracleCommand cmd = new OracleCommand("INSERT INTO iAuditoria(ip,host,fechaHora,idRecinto,idEdificio,resultadoBusqueda)" +
                    "VALUES(@ipnew,@hostnew,@fechanew,@recintonew,@edificionew,@busquedanew)", constr))
                 {
                     cmd.Parameters.Add(new OracleParameter("@ipnew", rut));
                     cmd.Parameters.Add(new OracleParameter("@ipnew", rut);
                     cmd.Parameters.Add(new OracleParameter("@hostnew", id_tipo_perfil);
                     cmd.Parameters.Add(new OracleParameter("@fechanew", dv);
                     cmd.Parameters.Add(new OracleParameter("@recintonew", nombre);
                     ccmd.Parameters.Add(new OracleParameter("@edificionew", apellido);
                     ccmd.Parameters.Add(new OracleParameter("@busquedanew", sexo);
                     constr.Open();
                     int modified = cmd.ExecuteNonQuery();

                     if (constr.State == System.Data.ConnectionState.Open) constr.Close();
                     return modified;
                 }
             }
         */

            /*
            [WebMethod]
            public DataSet getEncontrar(string codigo)
            {

                SqlDataAdapter adapter = new SqlDataAdapter("select * from iRecinto where idRecinto ='" + codigo + "'", connection);
                DataSet custDS = new DataSet();
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                adapter.Fill(custDS, "DATOS");

                return custDS;
            }

            [WebMethod]
            public int getLdap(string user, string pass)
            {
                String uid = "userid=" + user + ",ou=ejemplo,dc=test,dc=com";
                String password = pass;
                DirectoryEntry root = new DirectoryEntry("LDAP://192.168.234.131", uid, password, AuthenticationTypes.None);
                try
                {
                    object nativeObject = root.NativeObject;
                    return 1;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }

            [WebMethod]
            public int getAuditoria(string ip, string host, DateTime fechaHora, string idRecinto, int idEdificio, int resultadoBusqueda)
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO iAuditoria(ip,host,fechaHora,idRecinto,idEdificio,resultadoBusqueda)" +
                       "VALUES(@ipnew,@hostnew,@fechanew,@recintonew,@edificionew,@busquedanew)", connection))
                    {
                        cmd.Parameters.AddWithValue("@ipnew", ip);
                        cmd.Parameters.AddWithValue("@hostnew", host);
                        cmd.Parameters.AddWithValue("@fechanew", fechaHora);
                        cmd.Parameters.AddWithValue("@recintonew", idRecinto);
                        cmd.Parameters.AddWithValue("@edificionew", idEdificio);
                        cmd.Parameters.AddWithValue("@busquedanew", resultadoBusqueda);
                        connection.Open();
                        int modified = cmd.ExecuteNonQuery();

                        if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                        return modified;
                    }
                }*/
        }
    }

    
