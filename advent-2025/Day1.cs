namespace AdventOfCode;

public class Day1 : Day, IDay
{
    public string SolveA()
    {
        var inputLines = InputLines(1);
        var instructions = inputLines.Select(inputLine => new KeyValuePair<char, int>(inputLine[0], int.Parse(inputLine.TrimStart('R').TrimStart('L')))).ToList();
        var currentPoint = 50;
        var timesAtZero = 0;

        foreach (var instruction in instructions)
        {
            var turns = instruction.Value;
            if (instruction.Key == 'R')
            {
                while (currentPoint + turns > 99)
                {
                    turns -= 100 - currentPoint;
                    currentPoint = 0;
                        
                }

                currentPoint += turns;
            }
            else
            {
                while (currentPoint - turns < 0) {
                    turns -= currentPoint + 1;
                    currentPoint = 99;
                        
                }

                currentPoint -= turns;
            }

            if (currentPoint == 0) timesAtZero += 1;
        }

        return timesAtZero.ToString();
    }

    public string SolveB()
    {
        var inputLines = InputLines(1);
        var instructions = inputLines.Select(inputLine => new KeyValuePair<char, int>(inputLine[0], int.Parse(inputLine.TrimStart('R').TrimStart('L')))).ToList();
        var currentPoint = 50;
        var timesAtZero = 0;

        foreach (var instruction in instructions) {
            var turns = instruction.Value;
            if (instruction.Key == 'R') {
                while (currentPoint + turns > 99) {
                    turns -= 100 - currentPoint;
                    currentPoint = 0;
                    timesAtZero += 1;
                }
                      
                currentPoint += turns;
            }
            else {
                while (currentPoint - turns < 0) {
                    if (currentPoint != 0)
                    {
                        timesAtZero += 1;
                    }

                    turns -= currentPoint + 1;
                    currentPoint = 99;
                        
                }

                currentPoint -= turns;
                if (currentPoint == 0)
                {
                    timesAtZero += 1;
                }
            }
        }

        return timesAtZero.ToString();
    }
}