namespace AdventOfCode
{
    public class Day3 : Day, IDay
    {
        public string SolveA()
        {
           var inputLines = InputLines(3);
            long totalMaxValue = 0;
            foreach (var input in inputLines)
            {
                var line = input.ToCharArray();
                var digits = new List<char>();
                var digitCount = 2;
                var currentStartPoint = 0;

                while (digitCount > 0)
                {
                    var lineCount = line.Count();
                    var length = lineCount - currentStartPoint - digitCount + 1;
                    var viableRange = line.AsSpan(0 + currentStartPoint, length).ToArray();
                     // find biggest
                    var biggest = viableRange.Max();
                    digits.Add(biggest);
                    var index = Array.IndexOf(viableRange, biggest);
                    currentStartPoint = index + currentStartPoint + 1;
                    digitCount -= 1;
                }

                totalMaxValue +=  long.Parse(new string(digits.ToArray()));
            }

            return totalMaxValue.ToString();
        }

        public string SolveB()
        {
            var inputLines = InputLines(3);
            long totalMaxValue = 0;
            foreach (var input in inputLines)
            {
                var line = input.ToCharArray();
                var digits = new List<char>();
                var digitCount = 12;
                var currentStartPoint = 0;

                while (digitCount > 0)
                {
                    var lineCount = line.Count();
                    var length = lineCount - currentStartPoint - digitCount + 1;
                    var viableRange = line.AsSpan(0 + currentStartPoint, length).ToArray();
                     // find biggest
                    var biggest = viableRange.Max();
                    digits.Add(biggest);
                    var index = Array.IndexOf(viableRange, biggest);
                    currentStartPoint = index + currentStartPoint + 1;
                    digitCount -= 1;
                }

                totalMaxValue +=  long.Parse(new string(digits.ToArray()));
            }

            return totalMaxValue.ToString();
        }
    }
}