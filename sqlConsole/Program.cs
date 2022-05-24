using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using sqlConsole.Class;
using System.Data;

namespace sqlConsole
{
    class Program
    {
        static int tableWidth = 73;
        static void Main(string[] args)
        {

          Console.WriteLine(  get_List(1));




            //Console.ReadLine();
            //string conexionSql = "Data Source =(localDB)\\localDBDemo; Initial Catalog = tienda; Integrated Security = True";
            //SqlConnection conn = new SqlConnection(conexionSql);
            //string query = "INSERT INTO Producto (Nombre, Precio) VALUES(@Name, @Salary)";
            //SqlCommand command = new SqlCommand(query, conn);
            //command.Parameters.AddWithValue("@Name", "Max");
            //command.Parameters.AddWithValue("@Salary", 1200);
            //try
            //{
            //    conn.Open();
            //    command.ExecuteNonQuery();
            //    Console.WriteLine("SE INSERTO CORRECTAMENTE EL REGISTRO");
            //}
            //catch (SqlException e)
            //{
            //    Console.WriteLine("Error Generated. Details: " + e.ToString());
            //}
            //finally
            //{
            //    conn.Close();
            //}
            //DataTable workTable = new DataTable("Customers");
            //DataColumn column1 = new DataColumn("Column1");
            //DataColumn column2 = new DataColumn("Column2");
            //workTable.Columns.Add(column1);
            //workTable.Columns.Add(column2);

            //Console.WriteLine(workTable);
            ////***************        

            //{//SEGUIMIENTO\SQLEXPRESS
            //    string sConnectionString = "Data Source =(localDB)\\localDBDemo; Initial Catalog = tienda; Integrated Security = True";
            //    //string sConnectionString;
            //    //sConnectionString = "Password=myPassword;User ID=myUserID;"
            //    //                       + "Initial Catalog=BDGASTRONOMIA;"
            //    //                        + "Data Source=(SEGUIMIENTO)";
            //    SqlConnection ObjConeccion = new SqlConnection(sConnectionString);
            //    ObjConeccion.Open();
            //    SqlDataAdapter ObjAdapter = new SqlDataAdapter("Select * from Producto", sConnectionString);
            //    DataSet ObjDataset = new DataSet("Secciondatos");
            //    //ObjAdapter.FillSchema(ObjDataset, SchemaType.Source, "Alumnos");
            //    ObjAdapter.Fill(ObjDataset, "Producto");
            //    DataTable DTAlumnos;
            //    DTAlumnos = ObjDataset.Tables["Producto"];


            //    foreach (DataRow item in DTAlumnos.Rows)
            //    {
            //        String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|", item["Id_Producto"].ToString(), item["Id_Producto"].ToString(), item["Id_Producto"].ToString(), item["Id_Producto"].ToString());
            //        //Console.WriteLine("{0}{1}{2}", item["Id_Producto"].ToString(), item["Nombre"].ToString(), item["Precio"].ToString());

            //    }
            //    Console.ReadLine();
            //}
            //***************
            //obtenerResultados("Producto");



            //string queryInsert = "INSERT INTO tienda..Producto (Nombre,Precio) values (@Name,@Precio)";

            Console.Read();


        }

        public  static Producto get_List(int id)
        {
            Producto productoDto = new Producto();
            string conexionSql = "Data Source =(localDB)\\localDBDemo; Initial Catalog = tienda; Integrated Security = True";


            SqlConnection con = new SqlConnection(conexionSql);

            SqlCommand cmd = null;

            SqlDataReader dr = null;

            try
            {
               

                con.Open();

                cmd = new SqlCommand("SELECT * FROM Producto WHERE Id_Producto = @Id_Producto", con);

                cmd.Parameters.AddWithValue("@Id_Producto",id);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // Crear objetos de tipo Paciente

                    productoDto.Id = Convert.ToInt32(dr["Id_Producto"].ToString());
                    productoDto.Nombre = dr["Nombre"].ToString();
                    productoDto.Precio = Convert.ToInt16(dr["Precio"].ToString());
                  

                    // añadir a la lista de objetos

                }
              

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return  productoDto;

        }
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        public static List<Producto> obtenerResultados(string tabla)
        {
            List<Producto> List = new List<Producto>();
            string conexionSql = "Data Source =(localDB)\\localDBDemo; Initial Catalog = tienda; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conexionSql);
            conn.Open();
            string sqlConsulta = "select * from  " + tabla + " ";
            SqlCommand command = new SqlCommand(sqlConsulta, conn);
            
            
            SqlDataReader dr = command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    List.Add( new Producto 
                    {
                      Id =  Int32.Parse( dr["Id_Producto"].ToString()),
                     Nombre =  dr["Nombre"].ToString(),
                       Precio= Int32.Parse(dr["Precio"].ToString())
                    });
                }

            }
            

            foreach (var item in List)
            {
                Console.WriteLine(item.Id.ToString(), item.Nombre);
                Console.WriteLine(item.Nombre);
                Console.WriteLine(item.Precio);
                Console.Clear();
                PrintLine();
                PrintRow("Id", "Column 2", "Column 3", "Column 4");
                PrintLine();
                PrintRow(item.Id.ToString(), item.Nombre, "", "");
                PrintLine();
                PrintRow("que hay", "", "", "");
                PrintLine();
               
                

            }
            conn.Close();

            return
                List;
             
        }

      

        //public static string conexionSql()
        //{
        //    string con = string.Empty;
        //    //string conexionSql = "Data Source =192.168.2.119,1433; Initial Catalog = ISS;User Id=itapia; Password=tivanTapia12#; Integrated Security = True";

        //    string conexionSql = "Data Source =(localDB)\\localDBDemo; Initial Catalog = tienda; Integrated Security = True";

        //    using (SqlConnection conn = new SqlConnection(conexionSql))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            con = "conexion exitosa";
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(con = "No se pudo conectar a la base de datos "+ ex.Message);
        //        }

        //    }
        //    return con;

        //}
    }
}
