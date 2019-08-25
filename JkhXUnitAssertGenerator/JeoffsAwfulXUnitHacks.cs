using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace JkhXUnitAssertGenerator
{
    public static class JeoffsAwfulXUnitHacks
    {
        public static string Indentation { get; set; } = "\t\t";

        public static string GenerateXUnitAssertsForPoco(string name, object thingToWriteAssertsFor)
        {
            StringBuilder sourceCodeCs = new StringBuilder();

            var props = thingToWriteAssertsFor.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var prop in props)
            {
                if (prop.PropertyType.IsEnum)
                {
                    sourceCodeCs.AppendLine($"{Indentation}Assert.Equal({prop.PropertyType.Name}.{prop.GetValue(thingToWriteAssertsFor)}, {name}.{prop.Name});");
                }
                else
                {
                    switch (Type.GetTypeCode(prop.PropertyType))
                    {
                        case TypeCode.Char:
                            sourceCodeCs.AppendLine($"{Indentation}Assert.Equal('{prop.GetValue(thingToWriteAssertsFor)}', {name}.{prop.Name});");
                            break;
                        case TypeCode.Boolean:
                            var boolValue = (bool)prop.GetValue(thingToWriteAssertsFor);
                            sourceCodeCs.AppendLine($"{Indentation}Assert.{boolValue}({name}.{prop.Name});");
                            break;
                        case TypeCode.SByte:
                        case TypeCode.Byte:
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            sourceCodeCs.AppendLine($"{Indentation}Assert.Equal({prop.GetValue(thingToWriteAssertsFor)}, {name}.{prop.Name});");
                            break;
                        case TypeCode.UInt16:
                        case TypeCode.UInt32:
                        case TypeCode.UInt64:
                            sourceCodeCs.AppendLine($"{Indentation}Assert.Equal({prop.GetValue(thingToWriteAssertsFor)}U, {name}.{prop.Name});");
                            break;
                        case TypeCode.DateTime:
                            DateTime dateTimeValue = (DateTime)prop.GetValue(thingToWriteAssertsFor);
                            sourceCodeCs.AppendLine($"{Indentation}Assert.Equal(DateTime.Parse(\"{dateTimeValue.ToString("o")}\"), {name}.{prop.Name});");
                            break;
                        case TypeCode.String:
                            string stringValue = (string)prop.GetValue(thingToWriteAssertsFor);
                            if (stringValue == null)
                                sourceCodeCs.AppendLine($"{Indentation}Assert.Null({name}.{prop.Name});");
                            else
                                sourceCodeCs.AppendLine($"{Indentation}Assert.Equal(\"{stringValue}\", {name}.{prop.Name});");
                            break;
                        case TypeCode.Object:
                            sourceCodeCs.Append(DrillDeeper($"{name}.{prop.Name}", prop.GetValue(thingToWriteAssertsFor)));
                            break;
                    }
                }
            }
            return sourceCodeCs.ToString();
        }

        private static string DrillDeeper(string name, object subProperty)
        {
            StringBuilder sourceCodeCs = new StringBuilder();

            IPAddress addr = subProperty as IPAddress;
            if (addr != null)
            {
                sourceCodeCs.AppendLine($"{Indentation}Assert.Equal(\"{addr.ToString()}\", {name}.ToString());");
            }
            else
            {
                IEnumerable enu = subProperty as IEnumerable;
                if (enu != null)
                {
                    IEnumerable<object> e1 = enu.Cast<object>();
                    //if (e1.Any())
                    {
                        if (Type.GetTypeCode(e1.First()?.GetType()) != TypeCode.Object)
                            sourceCodeCs.AppendLine("");    //line break between each GROUP of array/list item when they are NOT a complex type

                        for (int i = 0; i < e1.Count(); i++)
                        {
                            object obj = e1.Skip(i).First();
                            if (obj == null)
                            {
                                sourceCodeCs.AppendLine($"{Indentation}Assert.Null({name}[{i}]);");
                            }
                            else
                            {   //TODO: probably going to need some kind of ".ToList()" call here for types that are actually IEnumerable et al...
                                sourceCodeCs.Append(GenerateXUnitAssertsForChildPoco($"{name}[{i}]", obj));
                                if (Type.GetTypeCode(obj.GetType()) == TypeCode.Object)
                                    sourceCodeCs.AppendLine("");    //line break between each array/list item when they are a complex type
                            }
                        }
                    }
                }
                else
                {
                    if (subProperty != null)
                        sourceCodeCs.AppendLine(GenerateXUnitAssertsForChildPoco(name, subProperty));
                }
            }

            return sourceCodeCs.ToString();
        }

        private static string GenerateXUnitAssertsForChildPoco(string name, object thingToWriteAssertsFor)
        {
            StringBuilder sourceCodeCs = new StringBuilder();

            if (thingToWriteAssertsFor != null)
            {
                switch (Type.GetTypeCode(thingToWriteAssertsFor.GetType()))
                {
                    case TypeCode.Char:
                        sourceCodeCs.AppendLine($"{Indentation}Assert.Equal('{thingToWriteAssertsFor}', {name});");
                        break;
                    case TypeCode.Boolean:
                        var boolValue = (bool)thingToWriteAssertsFor;
                        sourceCodeCs.AppendLine($"{Indentation}Assert.{boolValue}({name});");
                        break;
                    case TypeCode.SByte:
                    case TypeCode.Byte:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.Single:
                    case TypeCode.Double:
                    case TypeCode.Decimal:
                    case TypeCode.DateTime:
                        sourceCodeCs.AppendLine($"{Indentation}Assert.Equal({thingToWriteAssertsFor}, {name});");
                        break;
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        sourceCodeCs.AppendLine($"{Indentation}Assert.Equal({thingToWriteAssertsFor}U, {name});");
                        break;
                    case TypeCode.String:
                        sourceCodeCs.AppendLine($"{Indentation}Assert.Equal(\"{thingToWriteAssertsFor}\", {name});");
                        break;
                    case TypeCode.Object:
                        sourceCodeCs.Append(GenerateXUnitAssertsForPoco(name, thingToWriteAssertsFor));
                        break;
                }
            }
            else
            {
                sourceCodeCs.AppendLine($"{Indentation}Assert.Null({name});");
            }
            return sourceCodeCs.ToString();
        }
    }
}
