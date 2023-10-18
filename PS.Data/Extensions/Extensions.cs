
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace PS.Data.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Maps the IList&lt;toType, fromType&gt; of the current IList implemention into an List&lt;fromType&gt; implementation 
        /// </summary>
        /// <typeparam name="T">The type to convert the generic list to</typeparam>
        /// <typeparam name="T2">The current type of the IList</typeparam>
        /// <param name="fromObject"></param>
        /// <returns></returns>
        public static IList<T> Map<T,T2>(this IList<T2> fromObject ) where T : new ()
        {
            var newlist = new List<T>();

            // lets check if object passed in is of type list
            if (fromObject.GetType().GetInterface(typeof(IList<T2>).Name) == typeof(IList<T2>))
            {
                foreach (var item in (IList)fromObject)
                {
                    // Lets get the static method definitions
                    var methodInfo = GetExtensionMethods(typeof(object)).Single(x => x.Name == "Map");
                    // Configure the methodInfo to be generic type
                    var method = methodInfo.MakeGenericMethod(typeof(T));
                    // Invoke the method and pass in the required object.
                    var newItem = (T)method.Invoke(null, new[] {item});
                    // add the item to the new list to return.
                    newlist.Add(newItem);
                }
            }
            return newlist;
        }

        /// <summary>
        /// Maps the current object to the generic type passed into the method
        /// </summary>
        /// <typeparam name="T">The generic type to convert this object to</typeparam>
        /// <param name="fromObject">The object containing all of the original values</param>
        /// <returns>Object of generic type</returns>
        public static T Map<T>(this object fromObject) where T : new ()
        {
            if (fromObject == null)
                return default(T);

            var newObject = new T();
            
            var fromProperties = GetProperties(fromObject.GetType());
            var toProperties = GetProperties(newObject.GetType());

            // Loop through the new object properties
            foreach (var newObjectProperty in toProperties)
            {
                // Now lets loop through the fromObject to get the values
                foreach(var fromObjectProperty in fromProperties)
                {
                    // First lets check if the names match
                    if (newObjectProperty.Name != fromObjectProperty.Name)
                        continue;

                    // lets check the type of the current property.  If the property is a primitive time we can set
                    // the value.  If the property is not then we have to determine if it is a list or a class time and
                    // do a recursive call to map that data.

                    // Check for primitive
                    if (fromObjectProperty.PropertyType.IsPrimitive && newObjectProperty.PropertyType.IsPrimitive)
                    {
                        newObjectProperty.SetValue(newObject, fromObjectProperty.GetValue(fromObject,null), null);
                        // Since we have aready set the value , lets end execution of this loop
                        break;
                    }

                    // string is not a primitive type so we have to specifically check for that.
                    if (fromObjectProperty.PropertyType == typeof(String) && newObjectProperty.PropertyType == typeof(String))
                    {
                        newObjectProperty.SetValue(newObject, fromObjectProperty.GetValue(fromObject,null), null);
                        break;
                    }

                    // Lets check if the object is a list.  If so then we will need to iterate through the list and call map on every object.
                    if (fromObjectProperty.PropertyType.IsGenericType && newObjectProperty.PropertyType.IsGenericType)
                    {
                        //if (fromObjectProperty.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
                        if (fromObjectProperty.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
                        {
                            //var list = fromObjectProperty.GetGetMethod().Invoke(fromObject, null);
                            var list = fromObjectProperty.GetValue(fromObject, null);

                            if (list == null)
                                break;

                            var newlist = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(newObjectProperty.PropertyType.GetGenericArguments()[0]));

                            foreach (var item in (IList)list)
                            {
                                var methodInfo = GetExtensionMethods(typeof(object)).Single(x => x.Name == "Map");

                                var method = methodInfo.MakeGenericMethod(newObjectProperty.PropertyType.GetGenericArguments()[0]);

                                newlist.Add(method.Invoke(null, new[] {item}));
                            }

                            newObjectProperty.SetValue(newObject, newlist, null);
                            break;
                        }                        
                    }

                    // Lets check if the current property is a class
                    if (!fromObjectProperty.PropertyType.IsValueType && !newObjectProperty.PropertyType.IsValueType)
                    {
                        // lets get the value of the from object to pass into the function
                        var fromObjectPropertyValueClass = fromObjectProperty.GetValue(fromObject, null);

                        if (fromObjectPropertyValueClass == null)
                            break;

                        // I left the old code here in case we ever needed to update it.  I chained the below into one line of code
                        //var methodInfo = (fromObjectPropertyValueClass.GetType().GetMethod("Map", new Type[] {}));
                        var methodInfo = GetExtensionMethods(typeof (object)).ToList().Single(x => x.Name == "Map");

                        var method = methodInfo.MakeGenericMethod(new[] {newObjectProperty.PropertyType});
                        var obj = method.Invoke(null, new[] {fromObjectPropertyValueClass});

                        //var obj = (fromObjectPropertyValueClass.GetType().GetMethod("Map", new Type[] { })).MakeGenericMethod(newObjectProperty.GetType()).Invoke(null, null);

                        newObjectProperty.SetValue(newObject, obj, null);
                    }
                }
            }
            return newObject;
        }

        private static IEnumerable<MethodInfo> GetExtensionMethods(Type extendedType)
        {
            var assembly = typeof(Extensions).Assembly;

            var query = (from type in assembly.GetTypes()
                        where type.IsSealed && !type.IsGenericType && !type.IsNested
                        from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                            where method.IsDefined(typeof(ExtensionAttribute), false)
                            where method.GetParameters()[0].ParameterType == extendedType
                        select method).ToList();

            return query;
        }

        private static PropertyInfo[] GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public|BindingFlags.Instance);
        }


    }
}
