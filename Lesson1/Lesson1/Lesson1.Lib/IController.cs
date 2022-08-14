using Lesson1.Helper;

namespace Lesson1.Controller
{
    public interface IController
    {
        public bool Execute(string command, out string result, ref Dictionary<int, List<PersonParameter>>? personParameters);

        public List<PersonParameter> PersonParameters { get; }

        public Dictionary<string, string> Commands { get; }
    };
}
