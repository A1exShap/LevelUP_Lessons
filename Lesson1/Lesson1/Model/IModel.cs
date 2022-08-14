using Lesson1.Helper;

namespace Lesson1.Model
{
    public interface IModel
    {
        public List<PersonParameter> PersonParameters { get; }

        public Dictionary<int, List<PersonParameter>>? Persons { get; set; }

        public void SetEmptyJson();
    }
}