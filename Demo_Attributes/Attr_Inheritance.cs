using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

/*
Здравствуйте!

Спасибо за внимание к деталям, но вынужден Вас поправить.
Все атрибуты, действительно, как было упомянуто в лекции, принято объявлять sealed, соответственно сами они не могут быть базой для других классов-атрибутов. Однако, на приведенном Вами слайде речь шла о порядке ПРИМЕНЕНИЯ атрибутов к полям данных. Для задания этого поведения используется атрибут AttributeUsage (см. слайды 12-15 в презентации 01_ReflectionAttributes_Part2) уже перед объявлением класса NonSerializedAttribute. Посмотрите описание (https://docs.microsoft.com/ru-ru/dotnet/api/system.nonserializedattribute?view=netframework-4.8):
[System.AttributeUsage(System.AttributeTargets.Field, Inherited=true)]
public sealed class NonSerializedAttribute : Attribute

Другими словами, если в базовом классе поле помечено [NonSerialized], тогда при сериализации объекта производного класса это поле не будет сохранено. В этом контексте поведение, задаваемое атрибутом, наследуется. В этом несложно убедиться (не забудьте подключить сборку System.Runtime.Serialization.Formatters.Soap):
=================================
   [Serializable]
    public class Base {
        [NonSerialized]
        public int privateBaseInfo = 13;
        public int publicBaseInfo = 15;
    }

    [Serializable]
    public class Derived: Base
    {
        public int derivedInfo = 115;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Derived obj = new Derived();
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream("ser.xml", FileMode.Create)) {
                formatter.Serialize(fs, obj);
            }
            Console.WriteLine("Смотрим  файл ser.xml и не видим там privateBaseInfo! (т.к. в базовом классе это поле [NonSerialized])");
        }
    }

=================================
*/



namespace Demo_Attributes
{
    public class Attr_Inheritance
    {
        [Serializable]
        public class Base
        {
            // [NonSerialized]
            public int PrivateBaseInfo = 13;
            public int PublicBaseInfo { get; set; } = 15;
        }

        [Serializable]
        public class Derived : Base
        {
            public int DerivedInfo { get; set; } = 115;
        }


        public static void Demo_AttrInheritance()
        {
            Derived obj = new Derived();
            string json = JsonSerializer.Serialize(obj);
            Console.WriteLine("Результат сериализации: " + json);
            //File.WriteAllText("ser.json", json);
            //Console.WriteLine("Смотрим файл ser.json и не видим там privateBaseInfo! (т.к. в базовом классе это поле [NonSerialized])");
        }

    }
}
