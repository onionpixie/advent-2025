namespace AdventOfCode
{
    public class Day
    {
        public static string[] InputLines(int day)
        {
            return File.ReadAllLines($"./Files/Day{day}.txt");
        }

        /// <summary>
        /// returns first line of input file as a char array
        /// </summary>
        public static char[] GetInputAsCharArray(int day)
        {
            return InputLines(day)[0].ToCharArray();
        }

        /// <summary>
        /// returns lines of input files as char matrix
        /// </summary>
        public static char[][] GetInputAsCharMatrix(int day)
        {
            var inputLines = InputLines(day);
            var matrix = new char[inputLines.Length][];
            for (int i = 0; i < inputLines.Length; i++)
            {
                matrix[i] = inputLines[i].ToCharArray();
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < inputLines.Length; j++)
                {
                    matrix[i] = inputLines[i].ToCharArray();
                }
            }

            return matrix;
        }

        /// <summary>
        /// returns first line of input file as an int array
        /// </summary>
        public static int[] GetInputAsIntArray(int day)
        {
            return InputLines(day)[0].Where(char.IsDigit).Select(x => int.Parse(x.ToString())).ToArray();
        }
    }
}