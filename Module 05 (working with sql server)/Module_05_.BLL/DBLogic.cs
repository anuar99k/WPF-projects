using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_05_.DAL;

namespace Module_05_.BLL
{
    class DBLogic<T> where T : class
    {
        public static List<T> GetAll(string tableName)
        {
            return DbContext<T>.GetAll(tableName);
        }

        public static T GetById(string tableName, int id)
        {
            return DbContext<T>.GetById(tableName, id);
        }

        public static bool Insert(string tableName, T data)
        {
            if (DbContext<T>.Insert(tableName, data))
                return true;
            else
                return false;
        }

        public static bool Update(string tableName, T data)
        {
            if (DbContext<T>.Update(tableName, data))
                return true;
            else
                return false;
        }

        public static bool Delete(string tableName, int id)
        {
            if (DbContext<T>.Delete(tableName, id))
                return true;
            else
                return false;
        }
    }
}
