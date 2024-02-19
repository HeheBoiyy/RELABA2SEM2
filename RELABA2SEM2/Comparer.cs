using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RELABA2SEM2
{
    // Атрибут для пометки нечитаемых данных
    [AttributeUsage(AttributeTargets.Class)]
    public class NotComparableAttribute : Attribute { }

    // Атрибут для пометки данных, которые не передаются по сети
    [AttributeUsage(AttributeTargets.Property| AttributeTargets.Method)]
    public class UnreadableAttribute : Attribute { }
    public class Comparer
    {
        public List<object> ?data;
        public Comparer(List<object> Data)
        {
            data = Data;
        }

        public void Compare(List<object> controlList)
        {
            bool isequal = true;
            if (data.Count != controlList.Count) // СРАВНЕНИЕ ДЛИН
            {
                Console.WriteLine("Списки не равны");
            }
            else 
            {
                for (int i = 0; i < Math.Min(data.Count, controlList.Count); i++)
                {
                    Type initialType = data[i].GetType();
                    Type controlType = controlList[i].GetType();

                    if (HasNotComparableAttribute(controlType) || HasNotComparableAttribute(initialType)) // ИМЕЕТ НЕЧИТАЕМЫЙ АТРИБУТ
                    {
                        Console.WriteLine($"Найден нечитаемый тип {initialType.Name}\nВ позиции: {i}\n");
                        isequal = false;
                        continue;
                    }

                    if (initialType != controlType) // РАСХОЖДЕНИЕ В ТИПАХ
                    {
                        Console.WriteLine($"Расхождение типов в позиции: {i}\nОжидалось: {initialType.Name}\nПолучено: {controlType.Name}\n");
                        isequal= false;
                        continue;
                    }

                    PropertyInfo[] initialProperties = initialType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    PropertyInfo[] controlProperties = controlType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                    foreach (var initialProperty in initialProperties) // РАСХОЖДЕНИЕ В ЗНАЧЕНИЯХ ПОЛЕЙ/НЕЧИТАЕМЫЕ ПОЛЯ
                    {
                        
                        var controlProperty = controlProperties.FirstOrDefault(p => p.Name == initialProperty.Name); // Ищет первое же свойство в списке с таким же именем как и у
                                                                                                                     // initialproperty

                        if (HasUnreadableAttribute(initialProperty) || HasUnreadableAttribute(controlProperty))  // Ищем нечитаемые поля и пропускаем их
                        {
                            continue;
                        }                                                                                          
                        object initialValue = initialProperty.GetValue(data[i]);
                        object controlValue = controlProperty.GetValue(controlList[i]);

                        if (!Equals(initialValue, controlValue))// РАСХОЖДЕНИЕ ЗНАЧЕНИЙ
                        {
                            Console.WriteLine($"Расхождение значений!\nВ позиции: {i} В поле: {initialProperty.Name}\nПолучено : {controlValue}\nОжидалось : {initialValue}\n"); 
                            isequal= false;
                        }
                    }
                }
                if (isequal)
                {
                    Console.WriteLine("Списки равны");
                }
            }
        }
        private bool HasNotComparableAttribute(Type type) // метод с возвращаемым Bool для того чтобы проверить есть ли Артибут NotComparable
        {
            return Attribute.IsDefined(type, typeof(NotComparableAttribute));
        }

        private bool HasUnreadableAttribute(PropertyInfo obj) // метод с возвращаемым Bool для того чтобы проверить есть ли Артибут HasReadable
        {
            return Attribute.IsDefined(obj, typeof(UnreadableAttribute));
        }
    }
}
