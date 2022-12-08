﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "LibroAdd";

                    context.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = libro.Nombre;

                        collection[1] = new SqlParameter("IdAutor", System.Data.SqlDbType.Int);
                        collection[1].Value = libro.Autor.IdAutor;

                        collection[2] = new SqlParameter("NumeroPaginas", System.Data.SqlDbType.Int);
                        collection[2].Value = libro.NumeroPaginas;

                        collection[3] = new SqlParameter("FechaPublicacion", System.Data.SqlDbType.VarChar);
                        collection[3].Value = libro.FechaPublicacion;

                        collection[4] = new SqlParameter("IdEditorial", System.Data.SqlDbType.Int);
                        collection[4].Value = libro.Editorial.IdEditorial;

                        collection[5] = new SqlParameter("Edicion", System.Data.SqlDbType.VarChar);
                        collection[5].Value = libro.Edicion;

                        collection[6] = new SqlParameter("IdGenero", System.Data.SqlDbType.Int);
                        collection[6].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection);

                        var rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se añadieron registros.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "LibroUpdate";

                    context.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("IdLibro", System.Data.SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;

                        collection[1] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = libro.Nombre;

                        collection[2] = new SqlParameter("IdAutor", System.Data.SqlDbType.Int);
                        collection[2].Value = libro.Autor.IdAutor;

                        collection[3] = new SqlParameter("NumeroPaginas", System.Data.SqlDbType.Int);
                        collection[3].Value = libro.NumeroPaginas;

                        collection[4] = new SqlParameter("FechaPublicacion", System.Data.SqlDbType.VarChar);
                        collection[4].Value = libro.FechaPublicacion;

                        collection[5] = new SqlParameter("IdEditorial", System.Data.SqlDbType.Int);
                        collection[5].Value = libro.Editorial.IdEditorial;

                        collection[6] = new SqlParameter("Edicion", System.Data.SqlDbType.VarChar);
                        collection[6].Value = libro.Edicion;

                        collection[7] = new SqlParameter("IdGenero", System.Data.SqlDbType.Int);
                        collection[7].Value = libro.Genero.IdGenero;

                        cmd.Parameters.AddRange(collection);

                        var rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se modificaron registros.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Delete(int idLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "LibroDelete";

                    context.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter parametro = new SqlParameter("IdLibro", System.Data.SqlDbType.Int);
                        parametro.Value = idLibro;

                        cmd.Parameters.Add(parametro);

                        var rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se eliminaron registros.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "LibroGetAll";

                    context.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable tablaLibro = new DataTable();

                        adapter.Fill(tablaLibro);

                        if (tablaLibro.Rows.Count >= 1)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow fila in tablaLibro.Rows)
                            {
                                ML.Libro libro = new ML.Libro();

                                //cachar del DataRow al objeto Libro
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se encontraron registros.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
