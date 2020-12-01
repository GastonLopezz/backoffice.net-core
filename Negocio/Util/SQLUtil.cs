using Datos.Context;
using Microsoft.EntityFrameworkCore;
using Negocio.Services.Interfaces;
using Npgsql;
using System;
using System.IO;

namespace Negocio.Util{
    public class SQLUtil : ISQLUtil
    {
        private readonly ContextoParticular _context;

        public SQLUtil(ContextoParticular ctx)
        {
            _context = ctx;
        }

        public string CrearSchema(string nombre)
        {
            string ret = "";
            try
            {
                string connStr = "Server=localhost;Port=5432;UserId=postgres;Password=root;Database=facultades";
                var m_conn = new NpgsqlConnection(connStr);
                if (m_conn != null)
                {
                    var m_createdb_cmd = new NpgsqlCommand(@"CREATE SCHEMA IF NOT EXISTS " + nombre, m_conn);
                    m_conn.Open();
                    m_createdb_cmd.ExecuteNonQuery();

                    FileInfo file = new FileInfo(Path.GetFullPath("Datos/schema.sql"));
                    string script = file.OpenText().ReadToEnd();
                    script = script.Replace("bdARemplazar", nombre);
                    var createschema = new NpgsqlCommand(script, m_conn);
                    createschema.ExecuteNonQuery();
                    
                    file.OpenText().Close();

                    m_conn.Close();
                    return ret;

                }

                return ret = "No existe la base de datos.";

            }
            catch (Exception ex)
            {
                return ret = ex.Message;
            }

        }

        public string BorrarSchema(string nombre)
        {
            string ret = "";
            try
            {
                string connStr = "Server=localhost;Port=5432;UserId=postgres;Password=root;Database=facultades";
                var m_conn = new NpgsqlConnection(connStr);
                if (m_conn != null)
                {
                    var m_createdb_cmd = new NpgsqlCommand(@"DROP SCHEMA IF EXISTS " + nombre + " CASCADE", m_conn);
                    m_conn.Open();
                    m_createdb_cmd.ExecuteNonQuery();
                    m_conn.Close();
                    ret = "Se ha creado el Schema: " + nombre;
                    return ret;

                }

                return ret = "No existe la base de datos.";

            }
            catch (Exception ex)
            {
                return ret = ex.Message;
            }

        }
    }
}