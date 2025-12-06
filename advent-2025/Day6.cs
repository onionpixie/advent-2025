namespace AdventOfCode
{
    public class Day6 : Day, IDay
    {
        public string SolveA()
        {
            var inputLines = InputLines(6);
            MathProblem[]? problems = null;
            foreach (var line in inputLines)
            {
                var columns = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                problems ??= new MathProblem[columns.Length];
                for (int i = 0; i < columns.Length; i++)
                {
                    if (long.TryParse(columns[i], out var number))
                    {
                        if (problems[i] == null)
                        {
                            problems[i] = new MathProblem();
                        }
                        
                        problems[i].Numbers.Add(number);
                    }
                    else
                    {
                        if (columns[i] == "+")
                        {
                            problems[i].IsAddition = true;
                        }
                        else
                        {
                            problems[i].IsMultiplication = true;
                        }
                    }
                }
            }

            var total = 0L;
            if (problems != null)
            {
                foreach (var problem in problems)
                {
                    total += problem.Answer();
                }
            }

            return total.ToString();
        }

        public string SolveB()
        {
            var inputLines = InputLines(6);
            var columns = inputLines.Last().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var problems = new MathProblem[columns.Length];

            for (int i = 0; i < columns.Length; i++)
            {
                problems[i] = new MathProblem();
                if (!long.TryParse(columns[i], out var number))
                {
                    if (columns[i] == "+")
                    {
                        problems[i].IsAddition = true;
                    }
                    else
                    {
                        problems[i].IsMultiplication = true;
                    }
                }
            }

            var numbersMatrix = GetInputAsCharMatrix(6);
            var problemIndex = problems.Length - 1;
            var row = numbersMatrix.Length - 2;
            for (int j = numbersMatrix[row].Length - 1; j >= 0 ; j--)
            { 
                if (j != numbersMatrix[row].Length - 1 && (numbersMatrix[row + 1][j + 1] == '+' || numbersMatrix[row + 1][j + 1] == '*' ))
                {
                    problemIndex -= 1;
                }
                else {
                    var numberToAdd = "";
                    for (int k = numbersMatrix.Length - 2; k >=0 ; k--)
                    {
                        if (numbersMatrix[row - k][j] == ' ') continue;

                        numberToAdd += numbersMatrix[row - k][j];

                    }

                    problems[problemIndex].Numbers.Add(long.Parse(numberToAdd));
                }
            }

            var total = 0L;
            foreach (var problem in problems)
            {
                total += problem.Answer();
            }

            return total.ToString();
        }
    }

    public class MathProblem
    {
        public List<long> Numbers {get; set;} = [];
        
        public bool IsAddition {get; set;}

        public bool IsMultiplication { get; set; }

        public long Answer()
        {
            if (this.IsAddition) return Numbers.Sum();

            return Numbers.Aggregate(1L, (x,y) => x * y);
        }
    }
}