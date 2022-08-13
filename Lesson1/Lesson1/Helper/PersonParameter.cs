using Lesson1.DataValidator;

namespace Lesson1.Helper
{
    public struct PersonParameter
    {
        public string Name { get; init; }
        public string? Value { get; set; }
        public ValidateMethod ValidateMethod { get; init; }
        public int Position { get; init; }
    }

    
}
