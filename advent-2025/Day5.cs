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
                    var duplicate = false;
                    var newRange = new IngredientRange(start, end);

                    foreach(var freshIngredientRange in freshIngredientRanges)
                    {
                        if (freshIngredientRange.Contains(start))
                        {
                            if (freshIngredientRange.Contains(end))
                            {
                                duplicate = true;
                                break;
                            }

                            newRange.Start = freshIngredientRange.End + 1;
                        }
                        else if (freshIngredientRange.Contains(end))
                        {
                            newRange.End = freshIngredientRange.Start - 1;
                        }
                        else
                        {
                            if (newRange.Contains(freshIngredientRange.Start) && newRange.Contains(freshIngredientRange.End))
                            {
                                // Need to remove
                                Console.WriteLine("argh");
                            }
                        }
                        
                    }

                    if (!duplicate){
                        freshIngredientRanges.Add(newRange);
                    }
                }
            }

            foreach(var freshIngredientRange in freshIngredientRanges.OrderBy(x => x.Start))
            {
                Console.WriteLine($"{freshIngredientRange.Start} {freshIngredientRange.End} {freshIngredientRange.Size}");
                 
                if (freshIngredientValidRanges + freshIngredientRange.Size < freshIngredientValidRanges) throw new InvalidOperationException();
                freshIngredientValidRanges += freshIngredientRange.Size;
            }

            Console.WriteLine(freshIngredientRanges.Count());

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