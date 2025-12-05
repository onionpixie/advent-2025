namespace AdventOfCode
{
    public class Day5 : Day, IDay
    {
        public string SolveA()
        {
            var input = InputLines(5);
            var freshIngredientRanges = new List<IngredientRange>();
            var freshIngredientCount = 0;
            foreach (var line in input)
            {
                if (line.Contains('-'))
                {
                    freshIngredientRanges.Add(new IngredientRange(long.Parse(line.Split('-')[0]), long.Parse(line.Split('-')[1])));
                }
                else if (!string.IsNullOrWhiteSpace(line))
                {
                    var ingredient = long.Parse(line);
                    foreach(var freshIngredientRange in freshIngredientRanges)
                    {
                        if (freshIngredientRange.Contains(ingredient))
                        {
                            freshIngredientCount += 1;
                            break;
                        }
                    }
                }
            }

            return freshIngredientCount.ToString();
        }

        public string SolveB()
        {
            var input = InputLines(5);
            var freshIngredientRanges = new List<IngredientRange>();
            var freshIngredientValidRanges = 0L;
            foreach (var line in input)
            {
                if (line.Contains('-'))
                {
                    var start = long.Parse(line.Split('-')[0]);
                    var end = long.Parse(line.Split('-')[1]);
                    freshIngredientRanges.Add(new IngredientRange(start, end));
                }
            }

            freshIngredientRanges = freshIngredientRanges.OrderBy(x => x.Start).ToList();
            var validRanges = new List<IngredientRange>();
            for (int i = 0; i < freshIngredientRanges.Count; i++)
            {
                var startToTest = freshIngredientRanges[i].Start;
                var endToTest = freshIngredientRanges[i].End;
                var covered = false;
                for (int j = 0; j < freshIngredientRanges.Count; j++)
                {
                    if (i == j) break;

                    if (freshIngredientRanges[j].Contains(startToTest))
                    {
                        if (freshIngredientRanges[j].Contains(endToTest)) {
                            covered = true;
                            break;
                        }

                        startToTest = freshIngredientRanges[j].End + 1;
                    }
                    else if (freshIngredientRanges[j].Contains(endToTest))
                    {
                        endToTest = freshIngredientRanges[j].Start - 1;
                    }
                }

                if (!covered)
                {
                    freshIngredientRanges[i].Start = startToTest;
                    freshIngredientRanges[i].End = endToTest;
                    validRanges.Add(freshIngredientRanges[i]);
                }
            }
            
            foreach(var validRange in validRanges.OrderBy(x => x.Start))
            {
                Console.WriteLine($"{validRange.Start} {validRange.End} {validRange.Size}");
                 
                freshIngredientValidRanges += validRange.Size;
            }


            return freshIngredientValidRanges.ToString();
        }
    }

    public class IngredientRange
    {
        public long Start { get; set;}

        public long End { get; set;}

        public IngredientRange(long start, long end) {
            this.Start = start;
            this.End = end;
        }

        public bool Contains(long test)
        {
            return test >= Start && test <= End;
        }

        public long Size => End - Start + 1;
    }
}