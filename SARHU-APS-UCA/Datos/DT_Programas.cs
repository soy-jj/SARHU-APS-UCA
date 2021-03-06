﻿using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Programas : I_CRUD<Programa>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<Programa> programas = new List<Programa>();

        private static DT_Programas dtProgramas = null;

        private DT_Programas()
        {
            //Singleton
        }

        public static DT_Programas Instanciar()
        {
            if (dtProgramas == null)
            {
                dtProgramas = new DT_Programas();
            }
            return dtProgramas;
        }

        // METODOS

        /// <summary>
        /// El método permite agregar un registro de la entidad [Programa].
        /// Recibe como parámetro un objeto [Programa] con la información a agregar a la base de datos (Nombre y Descripción).
        /// Devuelve un valor entero con el id generado.
        /// </summary>
        public int Agregar(Programa obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.ProgramasAgregar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@programa_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@programa_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            int idGenerado = int.Parse(comandoSql.ExecuteScalar().ToString());

            conexionSql.Close();

            return idGenerado;
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [Programa].
        /// Recibe como parámetro el id [int] del registro a borrar en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.ProgramasBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@programa_id", SqlDbType.Int).Value = id;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Programa].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Programa] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Programa Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.ProgramasConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@programa_id", SqlDbType.Int).Value = id;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            Programa programa = new Programa();

            while (reader.Read())
            {
                programa.Id = id;
                programa.Nombre = reader["programa_nombre"].ToString();
                programa.Descripcion = reader["programa_descripcion"].ToString();
                programa.Estado = bool.Parse(reader["programa_estado"].ToString());
            }

            reader.Close();

            conexionSql.Close();

            return programa;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Programa].
        /// Recibe como parámetro un objeto [Programa] con la información editada para actualizarse en la base de datos (Nombre y Descripción).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Programa obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.ProgramasEditar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@programa_id", SqlDbType.Int).Value = obj.Id;
            comandoSql.Parameters.Add("@programa_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@programa_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Programa] desde la base de datos.
        /// Los campos que se devuelven son: Id, Nombre y Descripción.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Programa> Listar()
        {
            List<Programa> listaProgramas = new List<Programa>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.ProgramasListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
           
            while (reader.Read())
            {
                Programa p = new Programa();
                
                p.Id = int.Parse(reader["programa_id"].ToString());
                p.Nombre = reader["programa_nombre"].ToString();
                p.Descripcion = reader["programa_descripcion"].ToString();
                p.Estado = bool.Parse(reader["programa_estado"].ToString());

                listaProgramas.Add(p);
            }

            reader.Close();

            conexionSql.Close();

            this.programas.Clear();
            this.programas = listaProgramas;

            return listaProgramas;
        }

        public List<Programa> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<Programa> listProgramas = new List<Programa>();

            foreach(Programa p in programas)
            {
                if(p.Estado == Estado)
                {
                    listProgramas.Add(p);
                }
            }

            return listProgramas;
        }
    }
}
