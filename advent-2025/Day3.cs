namespace AdventOfCode
{
    public class Day3 : Day, IDay
    {
        public string SolveA()
        {
            var inputLines = InputLines(3);
            var batteryLines = new List<List<int>>();

            foreach (var line in inputLines)
            {
                batteryLines.Add(line.Where(char.IsDigit).Select(x => int.Parse(x.ToString())).ToList());
            }

            var totalMaxValue = 0;
            foreach (var line in batteryLines)
            {
                // find biggest available first digit.
                var firstDigit = 9;
                while (!line.Take(line.Count() - 1).Contains(firstDigit))
                {
                    firstDigit -= 1;
                    if (firstDigit == 0) throw new ArgumentException("while loop error!");
                }

                var maxValue = firstDigit * 10;
                var startingValue = maxValue;

                for (int i = 0; i < line.Count - 1; i++)
                {
                    if (line[i] != firstDigit) continue;

                    for (int j = 1; j < line.Count - i; j++)
                    {
                        if (startingValue + line[i + j] > maxValue)
                        {
                            maxValue = startingValue + line[i + j];
                        }
                    }
                }

                totalMaxValue += maxValue;
            }

            return totalMaxValue.ToString();
        }

        public string SolveB()
        {
            var inputLines = InputLines(3);
            var batteryLines = new List<List<int>>();

            foreach (var line in inputLines)
            {
                batteryLines.Add(line.Where(char.IsDigit).Select(x => int.Parse(x.ToString())).ToList());
            }

            var totalMaxValue = 0;
            foreach (var line in batteryLines)
            {
                // find biggest available first digit (number has to be 12 long so we dont'consider anything in last 11).
                var firstDigit = line.Take(line.Count() - 11).Max();
                
                var digits = new List<int>() {firstDigit};
                var digitCount = 10;
                
                
                for (int i = 0; i < 11; i++)
                {
                    if (line[i] != digits.Last()) continue;

                    var largestNumberToRight = line.Take(line.Count() - digitCount).Max();
                }

                for (int i = 0; i < line.Count - 1; i++)
                {
                    for (int j = 0; j < digitCount - 1; j++)
                    {
                        if (line[j] != currentDigit) continue;

                        for (int k = 1; k < line.Count - j; k++)
                        {
                            var potentialNextValue = startingValue + (line[k + j] * 10 * digitCount - 1);
                            if (potentialNextValue > maxValue)
                            {
                                maxValue = potentialNextValue;
                                nextDigit = line[k + j];
                            }
                        }

                        currentDigit = nextDigit;
                    }

                    totalMaxValue += maxValue;
                    digitCount = 12;
                }
            }

            return totalMaxValue.ToString();
        }
    }
}