using Benchmarking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prototype
{
    [Serializable()] // Serialization is used for the deep copy option
    public abstract class IPrototype<T>
    {
        public T Clone()
        {
            return (T)this.MemberwiseClone(); // Shallow copy
        }

        public T DeepCopy()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            T copy = (T)formatter.Deserialize(stream);
            stream.Close();
            return copy;
        }
    }

    [Serializable()]
    class DeeperData
    {
        public string Data { get; set; }
        public DeeperData(string s)
        {
            Data = s;
        }

        public override string ToString()
        {
            return Data;
        }
    }

    [Serializable()]
    class Prototype: IPrototype<Prototype>
    {
        public Prototype(Prototype source, bool deep=false)
        {
            //Deep copy via constructor
            Country = source.Country;
            Capital = source.Capital;
            Language = deep?new DeeperData(source.Language.Data):source.Language;
        }

        // Content members
        public string Country { get; set; }
        public string Capital { get; set; }
        public DeeperData Language { get; set; }
        public Prototype(string country, string capital, string language)
        {
            Country = country;
            Capital = capital;
            Language = new DeeperData(language);
        }

        public override string ToString()
        {
            return Country + "\t\t" + Capital + "\t\t->" + Language;
        }
    }

    class PrototypeManager
    {
        public Dictionary<string, Prototype> prototypes =
            new Dictionary<string, Prototype>
            {
                {"Germany", new Prototype("Germany", "Berlin", "German") },
                {"Italy", new Prototype("Italy", "Rome", "Italian") },
                {"Australia", new Prototype("Australia", "Canberra", "English") },
            };

        public Prototype this[string country]
        {
            get
            {
                return prototypes[country];
            }
            set
            {
                prototypes[country] = value;
            }
        }
    }

    class Program
    {
        static void Report(string s, Prototype a, Prototype b)
        {
            Console.WriteLine("\n{0}\nPrototype  {1}\nClone      {2}", s, a, b);
        }

        static void Main()
        {
            PrototypeManager manager = new PrototypeManager();
            Prototype c2, c3;

            // Make a copy of Australia's data
            c2 = manager["Australia"].Clone();
            Report("Shallow cloning Australia\n===============",
                  manager["Australia"], c2);

            // Change the capital of Australia to Sydney
            c2.Capital = "Sydney";
            Report("Altered Clone's shallow state, prototype unaffected",
                  manager["Australia"], c2);

            // Change the language of Australia (deep data)
            c2.Language.Data = "Chinese";
            Report("Altering Clone deep state: prototype affected *****",
                  manager["Australia"], c2);

            // Make a copy of Germany's data
            c3 = manager.prototypes["Germany"].DeepCopy();
            Report("Deep cloning Germany\n============",
                  manager["Germany"], c3);

            // Change the capital of Germany
            c3.Capital = "Munich";
            Report("Altering Clone shallow state, prototype unaffected",
                  manager["Germany"], c3);

            // Change the language of Germany (deep data)
            c3.Language.Data = "Turkish";
            Report("Altering Clone deep state, prototype unaffected",
                  manager["Germany"], c3);


            const uint NoOfIteration = 1_000;
            
            Profiler.Profile("Deep Copy via Serialization", NoOfIteration, () =>
            {
                var x = manager["Australia"].DeepCopy();
            });

            Profiler.Profile("Deep Copy via Constructor", NoOfIteration, () =>
            {
                var x = new Prototype(manager["Australia"], true);
            });
            
            Profiler.Profile("Shallow Copy via Serialization", NoOfIteration, () =>
            {
                var x = manager["Australia"].Clone();
            });

            Profiler.Profile("Shallow Copy via Constructor", NoOfIteration, () =>
            {
                var x = new Prototype(manager["Australia"], false);
            });
        }
    }
}
