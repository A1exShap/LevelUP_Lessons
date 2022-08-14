using Lesson1.DataValidator;
using Lesson1.Helper;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Lesson1.Model
{
    public sealed class Model : IModel
    {
        private readonly string _path;

        public Model()
        {
            _path = @$"{Directory.GetCurrentDirectory()}\Persons.json";

            if (!File.Exists(_path))
            {
                File.Create(_path);
                
                using (var sw = new StreamWriter(_path))
                {
                    sw.WriteLine("{\"0\":[]}");
                }
            }
        }

        public List<PersonParameter> PersonParameters =>
            new List<PersonParameter>
            {
                new PersonParameter { Name = "Firstname", Value = string.Empty, ValidateMethod = ValidateMethod.Name, Position = 0},
                new PersonParameter { Name = "Lastname", Value = string.Empty, ValidateMethod = ValidateMethod.Name, Position = 1},
                new PersonParameter { Name = "Age", Value = string.Empty, ValidateMethod = ValidateMethod.Age, Position = 2},
                new PersonParameter { Name = "Hobby", Value = string.Empty, ValidateMethod = ValidateMethod.None, Position = 3}
            };
        
        public Dictionary<int, List<PersonParameter>>? Persons
        {
            get
            {
                var str = string.Empty;

                using (var sr = new StreamReader(_path))
                {
                    str = sr.ReadToEnd();
                }

                var parameters = ReadToObject<Dictionary<int, List<PersonParameter>>>(str);

                return parameters;
            }


            set
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<int, List<PersonParameter>>));

                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, value);

                    using (var sw = new StreamWriter(_path))
                    {
                        sw.WriteLine(Encoding.Default.GetString(ms.ToArray()));
                    }
                }
            }
        }

        public void SetEmptyJson()
        {
            using var sw = new StreamWriter(_path);
            sw.Write("{\"0\":[]}");
        }

        public static T ReadToObject<T>(string json) where T : class, new()
        {
            T deserializedObject = new T();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {

                DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedObject.GetType());
                deserializedObject = ser.ReadObject(ms) as T;
                ms.Close();
            }
            return deserializedObject;
        }
    }
}
