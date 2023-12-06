using System.Data.SqlClient;
using System.Data;

using Biblioteca_uts.Models;

namespace Biblioteca_uts.Datos
{
    public class LibrosDatos
    {
        public List<LibrosModel> Listar()
        {
            List<LibrosModel> Lista = new List<LibrosModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar_Libro", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new LibrosModel()
                        {
                            No_Adquisicion = Convert.ToInt32(dr["No_Adquisicion"]),
                            Titulo = dr["Titulo"].ToString(),
                            Fecha_adquisicion = dr.GetDateTime(dr.GetOrdinal("Fecha_adquisicion")),
                            Ibsn = dr["IBSN"].ToString(),
                            Clasificacion = dr["Clasificacion"].ToString(),
                            No_Estante = Convert.ToInt32(dr["No_Estante"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Estatus = dr["Estatus"].ToString(),
                            Procedencia = dr["Procedencia"].ToString(),
                            No_factura = dr["No_factura"].ToString()
                        }
                        );
                    }
                }
            }
            return Lista;
        }
        public LibrosModel ObtenerLibro(int IdLibro)
        {
            LibrosModel _libro = new LibrosModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                //procedimiento almacenado que obtinene un libros mediante 
                //entre todos los registros de la tabla libro 
                SqlCommand cmd = new SqlCommand("Sp_Buscar_Libro", conexion);
                cmd.Parameters.AddWithValue("No_Adquisicion", IdLibro);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {   //Obtiene todos datos del libro   
                        _libro.No_Adquisicion = Convert.ToInt32(dr["No_Adquisicion"]);
                        _libro.Titulo = dr["Titulo"].ToString();
                        _libro.Fecha_adquisicion = dr.GetDateTime(dr.GetOrdinal("Fecha_adquisicion"));
                        _libro.Ibsn = dr["IBSN"].ToString();
                        _libro.Clasificacion = dr["Clasificacion"].ToString();
                        _libro.No_Estante = Convert.ToInt32(dr["No_Estante"]);
                        _libro.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        _libro.Estatus = dr["Estatus"].ToString();
                        _libro.Procedencia = dr["Procedencia"].ToString();
                        _libro.No_factura = dr["No_factura"].ToString();
                    }
                }
            }
            //retorna el libro
            return _libro;
        }
        //############################################################################
        public bool GuardarLibro(LibrosModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    //Procedimineto almacenados para guarda registros de libros  
                    SqlCommand cmd = new SqlCommand("SP_Registrar_Libro", conexion);

                    //resive datos de un todos los datos del libro registro
                    cmd.Parameters.AddWithValue("No_Adquisicion", model.No_Adquisicion);
                    cmd.Parameters.AddWithValue("Titulo", model.Titulo);
                    cmd.Parameters.AddWithValue("Fecha_adquisicion", model.Fecha_adquisicion);
                    cmd.Parameters.AddWithValue("IBSN", model.Ibsn);
                    cmd.Parameters.AddWithValue("Clasificacion", model.Clasificacion);
                    cmd.Parameters.AddWithValue("No_Estante", model.No_Estante);
                    cmd.Parameters.AddWithValue("Cantidad", "1");
                    cmd.Parameters.AddWithValue("Estatus", "Disponible");
                    cmd.Parameters.AddWithValue("Procedencia", model.Procedencia);
                    cmd.Parameters.AddWithValue("No_factura", model.No_factura);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool EditarLibro(LibrosModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    //Procedimineto almacenados para Editar registros de Libro  

                    SqlCommand cmd = new SqlCommand("Sp_Modificar_Libro", conexion);
                    //resive datos de un todos los datos del libro Libro
                    cmd.Parameters.AddWithValue("No_Adquisicion", model.No_Adquisicion);
                    cmd.Parameters.AddWithValue("Titulo", model.Titulo);
                    cmd.Parameters.AddWithValue("Fecha_adquisicion", model.Fecha_adquisicion);
                    cmd.Parameters.AddWithValue("IBSN", model.Ibsn);
                    cmd.Parameters.AddWithValue("Clasificacion", model.Clasificacion);
                    cmd.Parameters.AddWithValue("No_Estante", model.No_Estante);
                    cmd.Parameters.AddWithValue("Cantidad", model.Cantidad);
                    cmd.Parameters.AddWithValue("Estatus", model.Estatus);
                    cmd.Parameters.AddWithValue("Procedencia", model.Procedencia);
                    cmd.Parameters.AddWithValue("No_factura", model.No_factura);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
        /*####################################################*/
        public bool EliminarLibro(int No_Adquisicion)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    //procedimineto almacenado para eliminar registro de un libro 
                    //mediante su numero de adquisicion 
                    SqlCommand cmd = new SqlCommand("SP_Eliminar_Libro", conexion);
                    cmd.Parameters.AddWithValue("No_Adquisicion", No_Adquisicion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public List<CMT_LibroModels> Listar2(int Us_Identificador)
        {
            List<CMT_LibroModels> Lista = new List<CMT_LibroModels>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_Usuario_P", conexion);
                cmd.Parameters.AddWithValue("Identificador", Us_Identificador);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new CMT_LibroModels()
                        {

                            Us_Identificador = Convert.ToInt32(dr["Identificador"]),
                            Pre_Id_Prestamo = Convert.ToInt32(dr["Id_Prestamo"]),
                            Lib_NoAdquisicion = Convert.ToInt32(dr["No_Adquisicion"]),
                            Lib_Titulo = dr["Titulo"].ToString(),
                            Lib_IBSN = dr["IBSN"].ToString(),
                            Lib_Clasificacion = dr["Clasificacion"].ToString(),
                            Lib_No_Estante = dr["No_Estante"].ToString()


                        }
                        );
                    }
                }
            }
            return Lista;
        }
    }
}