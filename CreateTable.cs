using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreateTable //TODO: update namespace
{
    public class CreateTable
    {
        //Alternative to Entity Framework for SQLite. Need to add error handling.
        public static string AddTable(Type type)
        {
            StringBuilder query = new StringBuilder();

            query.Append($"CREATE TABLE IF NOT EXISTS '{type.Name}' (\n");
            query.Append($"_id INTEGER PRIMARY KEY NOT NULL AUTOINCREMENT,\n");
            var props = type.GetProperties();
            for(int i = 0; i < props.Count(); i++)
            {
               if(i == props.Count() - 1)
                {
                    query.Append($"{ReturnField(props[i])});");
                }
                else
                {
                    query.Append($"{ReturnField(props[i])},\n");
                }
            }

            return query.ToString();
            
        }

        private static string ReturnField(PropertyInfo i)
        {
            switch (i.PropertyType.Name)
            {
                case "String":
                    return $"{i.Name} TEXT";
                case "Int32":
                    return $"{i.Name} INTEGER";
                case "Int":
                    return $"{i.Name} INTEGER";
                case "Byte":
                    return $"{i.Name} BLOB";
                case "DateTime":
                    return $"{i.Name} DATETIME";
                case "double":
                    return $"{i.Name} REAL";
                case "Double":
                    return $"{i.Name} REAL";
                case "bool":
                    return $"{i.Name} INTEGER";
                default:
                    break;
            }

            return "";
        }
    }
}
