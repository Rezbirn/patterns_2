using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_2
{
    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Test,1,05.06.2024";
        }
    }
    public interface ITarget
    {
        Person GetRequest();
    }

    public class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateOnly Birthday { get; private set; }
        public Person(int id, string name, DateOnly birthday)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return $"{nameof(Id)} {Id} | {nameof(Name)} {Name} | {nameof(Birthday)} {Birthday}";
        }
    }
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public Person GetRequest()
        {
            var request = _adaptee.GetSpecificRequest();

            var requestParam = request.Split(',');
            var name = requestParam[0];
            var id = int.Parse(requestParam[1]);
            var dateBirthday = DateOnly.ParseExact(requestParam[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);

            return new Person(id, name, dateBirthday);
        }
    }

}
