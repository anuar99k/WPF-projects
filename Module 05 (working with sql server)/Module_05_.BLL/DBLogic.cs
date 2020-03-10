using System.Collections.Generic;
using Module_05_.DAL;
using Module_05_.DAL.Models;

namespace Module_05_.BLL
{
    public class DbLogic<T> where T : class
    {
        public static List<T> GetAll()
        {
            string tableName = string.Empty;
            switch (typeof(T).Name)
            {
                case "Equipment":
                    tableName = "newEquipment";
                    break;
                case "Manufacturer":
                    tableName = "TablesManufacturer";
                    break;
                case "Model":
                    tableName = "TablesModel";
                    break;
            }
            return DbContext<T>.GetAll(tableName);
        }

        public static T GetById(int id)
        {
            string tableName = string.Empty;
            switch (typeof(T).Name)
            {
                case "Equipment":
                    tableName = "newEquipment";
                    break;
                case "Manufacturer":
                    tableName = "TablesManufacturer";
                    break;
                case "Model":
                    tableName = "TablesModel";
                    break;
            }
            return DbContext<T>.GetById(tableName, id);
        }

        public static bool Insert(T data)
        {
            string tableName = string.Empty;
            switch (typeof(T).Name)
            {
                case "Equipment":
                    tableName = "newEquipment";
                    break;
                case "Manufacturer":
                    tableName = "TablesManufacturer";
                    break;
                case "Model":
                    tableName = "TablesModel";
                    break;
            }
            if (DbContext<T>.Insert(tableName, data))
                return true;
            else
                return false;
        }

        public static bool Update(T data)
        {
            string tableName = string.Empty;
            switch (typeof(T).Name)
            {
                case "Equipment":
                    tableName = "newEquipment";
                    break;
                case "Manufacturer":
                    tableName = "TablesManufacturer";
                    break;
                case "Model":
                    tableName = "TablesModel";
                    break;
            }
            if (DbContext<T>.Update(tableName, data))
                return true;
            else
                return false;
        }

        public static bool Delete(T data)
        {
            string tableName = string.Empty;
            int id = -1;
            switch (typeof(T).Name)
            {
                case "Equipment":
                    tableName = "newEquipment";
                    id = (data as Equipment).intEquipmentID;
                    break;
                case "Manufacturer":
                    tableName = "TablesManufacturer";
                    id = (data as Manufacturer).intManufacturerID;
                    break;
                case "Model":
                    tableName = "TablesModel";
                    id = (data as Model).intModelID;
                    break;
            }
            if (DbContext<T>.Delete(tableName, id))
                return true;
            else
                return false;
        }
    }
}
