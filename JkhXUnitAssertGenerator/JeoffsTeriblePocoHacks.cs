using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace JkhXUnitAssertGenerator
{
    public static class JeoffsTeriblePocoHacks
    {
        public static string GenerateCsPoco<T>(List<T> listOfThings)
        {
            StringBuilder retval = new StringBuilder();
            retval.AppendLine("{");

            var objectType = typeof(T);
            var props = objectType.GetProperties();
            foreach (T item in listOfThings)
            {
                retval.Append($"new {item.GetType().Name} {{ ");
                foreach (var prop in props)
                {
                    retval.Append($"{prop.Name} = {GetQuotedValue(prop.GetValue(item))}, ");
                }
                retval.AppendLine(" },");
            }
            retval.AppendLine("};");

            return retval.ToString();
        }

        public static string GetQuotedValue(object value)
        {
            string retval;

            if (value != null)
            {
                TypeCode typeCode = Type.GetTypeCode(value.GetType());
                switch (typeCode)
                {
                    case TypeCode.Char:
                        retval = $"'{value}'";
                        break;
                    case TypeCode.Boolean:
                        retval = value.ToString().ToLower();    //its kinda weird, right?
                        break;
                    case TypeCode.SByte:
                    case TypeCode.Byte:
                    case TypeCode.Int16:
                    case TypeCode.UInt16:
                    case TypeCode.Int32:
                    case TypeCode.UInt32:
                    case TypeCode.Int64:
                    case TypeCode.UInt64:
                    case TypeCode.Single:
                    case TypeCode.Double:
                    case TypeCode.Decimal:
                        retval = $"{value}";
                        break;
                    case TypeCode.DateTime:
                        DateTime dateTimeValue = (DateTime)value;
                        retval = $"DateTime.Parse(\"{dateTimeValue.ToString("o")}\")";
                        break;
                    case TypeCode.String:
                        retval = $"\"{value}\"";
                        break;
                    case TypeCode.Object:
                    default:
                        {
                            switch (value)
                            {
                                case IPAddress addr:
                                    retval = $"IPAddress.Parse(\"{addr}\")";
                                    break;
                                case IEnumerable enu:
                                    {
                                        StringBuilder bigOldRetval = new StringBuilder();
                                        IEnumerable<object> e1 = enu.Cast<object>();
                                        object o = e1.First();
                                        if(value.GetType().IsArray)
                                            bigOldRetval.Append($"new {GetCSharpTypeName(o.GetType())}[] {{");
                                        else
                                            bigOldRetval.Append($"new List<{GetCSharpTypeName(o.GetType())}> {{");
                                        for (int i = 0; i < e1.Count(); i++)
                                        {
                                            object obj = e1.Skip(i).First();
                                            if(i > 0)
                                                bigOldRetval.Append(",");
                                            bigOldRetval.Append($"{GetQuotedValue(obj)}");
                                        }
                                        bigOldRetval.Append("}");
                                        retval = bigOldRetval.ToString();
                                    }
                                    break;
                                default:
                                    //return GetQuotedValue(value);
                                    throw new Exception($"{value.GetType()} not supported by {nameof(GetQuotedValue)}");
                            }
                        }
                        break;
                }
            }
            else
            {
                retval = "null";
            }
            return retval;
        }

        public static string GetCSharpTypeName(Type type)
        {
            switch (type.Name)
            {
                case "Boolean": return "bool";
                case "String": return "string";
                case "Int32": return "int";
                case "UInt32": return "uint";
                case "Char": return "char";
                default: throw new Exception($"{nameof(GetCSharpTypeName)} doesn't do {type.Name} = FIX ME!!");
            }
        }
    }
}
