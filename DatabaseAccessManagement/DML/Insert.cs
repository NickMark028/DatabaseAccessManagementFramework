using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement
{
    public class StudentA
    {public string Name;
        public int Id;

        public float Score;
        
    }



    public class DML
    {
        public string Insert<T>(Object[] obj)
        {
            string queryString = "INSERT INTO " + obj[0].GetType().Name + " ";
            string columnString = "(";
            foreach (var prop in obj[0].GetType().GetFields())
            {
                columnString += prop.Name + ", ";
            }
            columnString = columnString.Remove(columnString.Length - 2, 2);
            columnString += ")";

            string valuesString = "";

            foreach (var item in obj)
            {
                valuesString += "\n(";
                foreach (var prop in item.GetType().GetFields())
                {
                    if (prop.FieldType == typeof(string))
                        valuesString += "'" + prop.GetValue(item) + "'" + ", ";
                    else valuesString += prop.GetValue(item) + ", ";
                }
                valuesString = valuesString.Remove(valuesString.Length - 2, 2);
                valuesString += "), ";
            }
            valuesString = valuesString.Remove(valuesString.Length - 2, 2);
            queryString += columnString + " \nVALUES " + valuesString;
            return queryString;
        }
        public string Insert<T>(Object obj)
        {
            string queryString = "INSERT INTO " + obj.GetType().Name + " ";
            string columnString = "(";
            string valuesString = "(";
            foreach (var prop in obj.GetType().GetFields())
            {
                columnString += prop.Name + ", ";
                if (prop.FieldType == typeof(string))
                    valuesString += "'" + prop.GetValue(obj) + "'" + ", ";
                else valuesString += prop.GetValue(obj) + ", ";
            }
            columnString = columnString.Remove(columnString.Length - 2, 2);
            valuesString = valuesString.Remove(valuesString.Length - 2, 2);

            columnString += ")";
            valuesString += ")";

            queryString += columnString + " VALUES " + valuesString;
            return queryString;
        }
    }

    public class MainProgram
    {
        public static void MainTest()
        {
            var x = new DML();
            x.Insert<StudentA>(new StudentA { Id = 10, Name = "Nguye Van A", Score = 1.4f });
        }
    }
}
