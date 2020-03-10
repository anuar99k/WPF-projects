using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Dapper;
using Module_05_.DAL.Models;

namespace Module_05_.DAL
{
    public class DbContext<T> where T : class
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static List<T> GetAll(string tableName)
        {
            List<T> data = new List<T>();
            using(IDbConnection db = new SqlConnection(connectionString))
            {
                data = db.Query<T>($"SELECT * FROM {tableName}").ToList();
            }
            return data;
        }

        public static T GetById(string tableName, int id)
        {
            string PK = "id";

            switch (tableName)
            {
                case "newEquipment":
                    PK = "intEquipmentID";
                    break;
                case "TablesManufacturer":
                    PK = "intManufacturerID";
                    break;
                case "TablesModel":
                    PK = "intModelID";
                    break;
            }

            T data = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                data = db.Query<T>($"SELECT * FROM {tableName} WHERE {PK} = {id}").FirstOrDefault();
            }
            return data;
        }

        public static bool Insert(string tableName, T data)
        {
            List<string> dataKeys = new List<string>();

            Type t = data.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (var prop in props)
            {
                if (prop.GetIndexParameters().Length == 0)
                    dataKeys.Add("@" + prop.Name);
            }
            string keyValues = string.Join(",", dataKeys);
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sqlQuery = $"INSERT INTO {tableName} VALUES ({keyValues})";
                db.Query<T>(sqlQuery, data);
            }
            return true;
        }

        public static bool Update(string tableName, T data)
        {
            List<string> keysAndValues = new List<string>();

            Type t = data.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (var prop in props)
            {
                if (prop.GetIndexParameters().Length == 0)
                    keysAndValues.Add(prop.Name + "=@" + prop.Name);
            }
            string values = string.Join(",", keysAndValues);

            string PK = "id";
            int id = -1;
            switch (tableName)
            {
                case "newEquipment":
                    PK = "intEquipmentID";
                    id = (data as Equipment).intEquipmentID;
                    break;
                case "TablesManufacturer":
                    PK = "intManufacturerID";
                    id = (data as Manufacturer).intManufacturerID;
                    break;
                case "TablesModel":
                    PK = "intModelID";
                    id = (data as Model).intModelID;
                    break;
            }
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = $"UPDATE {tableName} SET {values} WHERE {PK} = {id}";
                db.Execute(sqlQuery, data);
            }
            return true;
        }

        public static bool Delete(string tableName, int id)
        {
            string PK = "id";

            switch (tableName)
            {
                case "newEquipment":
                    PK = "intEquipmentID";
                    break;
                case "TablesManufacturer":
                    PK = "intManufacturerID";
                    break;
                case "TablesModel":
                    PK = "intModelID";
                    break;
            }

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = $"DELETE FROM {tableName} WHERE {PK} = {id}";
                db.Execute(sqlQuery);
            }
            return true;
        }
    }
}
