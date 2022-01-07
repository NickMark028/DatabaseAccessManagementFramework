using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement
{
    public class StudentA
    {
        public string Name;
        public int Id;
        public float Score;
    }


    public class DML
    {
        public string Insert<T>(object[] obj)
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
        public string Insert<T>(object obj)
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

        public string Update<T>(IExpression predicate, object obj)
        {
            string queryString = "UPDATE " + obj.GetType().Name + "\nSET ";

            string setString = "";

            foreach (var prop in obj.GetType().GetFields())
            {
                if (prop.FieldType == typeof(string))
                    setString += prop.Name + " = '" + prop.GetValue(obj) + "' ";
                else setString += prop.Name + " = " + prop.GetValue(obj);
                setString += ", ";
            }
            setString = setString.Remove(setString.Length - 2, 2);

            queryString += setString + "\nWHERE " + predicate.ToString();

            return queryString;
        }

        public string Delete<T>(IExpression predicate, object obj)
        {
            string queryString = "DELETE FROM " + obj.GetType().Name;
            queryString +=  "\nWHERE " + predicate.ToString();

            return queryString;
        }
        //public string Delete<T>(object obj)
        //{
        //    string queryString = "DELETE FROM " + obj.GetType().Name;

        //    return queryString;
        //}
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
