namespace Lesson7
{
    public static class Concatenator
    {
        private static string _dirPath;
        private static string _concatFileName;

        public static async void Concat()
        {
            GetPath();

            Console.WriteLine("Please enter the concat file name:");
            _concatFileName = $"{Console.ReadLine()}.txt";
        
            var files = Directory.GetFiles(_dirPath);

            foreach(var file in files)
            {
                await WriteAsync(Read(file));
            }

            Console.WriteLine("Concatenation succesful");
        }

        private static void GetPath()
        {
            while (true)
            {
                Console.WriteLine("Please enter the directory path:");
                _dirPath = Console.ReadLine();

                if (Directory.Exists(_dirPath)) break;
                else Console.WriteLine("Directory does not exist at specified path");
            }
        }

        private static string Read(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                return streamReader.ReadToEnd();
            }
        }

        private static async Task WriteAsync(string str)
        {
            using (var streamWriter = new StreamWriter($@"{_dirPath}\{_concatFileName}", true))
            {
                await streamWriter.WriteLineAsync(str);
            }
        }
    }
}
