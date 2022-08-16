namespace Lesson3
{
    internal class Program
    {
        private static SimpleGenericCache<string> _stringCache;

        static void Main(string[] args)
        {
            _stringCache = new SimpleGenericCache<string>();

            TestCache();

            Console.ReadKey();
        }

        private static void TestCache()
        {
            _stringCache.Store("FIRST", "OK");
            _stringCache.Store("SECOND", "NO_OK", 10);

            Thread.Sleep(15000);

            Console.WriteLine($"FIRST: {_stringCache.Fetch("FIRST")}");     // Should display a value
            Console.WriteLine($"SECOND: {_stringCache.Fetch("SECOND")}");   // Should display a default
        }
    }
}