using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DatabaseAccessManagement.Utilities
{
    public static class TypeExtension
    {

        public static Boolean IsAnonymousType(this Type type)
        {
            Boolean hasCompilerGeneratedAttribute = type.GetCustomAttributes(typeof(CompilerGeneratedAttribute), false).Count() > 0;
            Boolean nameContainsAnonymousType = type.FullName.Contains("AnonymousType");
            Boolean isAnonymousType = hasCompilerGeneratedAttribute && nameContainsAnonymousType;

            return isAnonymousType;
        }
    }
    //https://stackoverflow.com/questions/1650681/determining-whether-a-type-is-an-anonymous-type
    //References to check AnonymousType

    public interface ICustomType
    {
        object? GetValue();
    }

    class Converter
    {

        public static ICustomType[] getFieldsList(object obj)
        {
            if (obj.GetType().IsAnonymousType())
            {
                return obj.GetType().GetProperties();
            }
            return 
        }
    }
}
