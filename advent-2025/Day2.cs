namespace AdventOfCode
{
    public class Day2 : Day, IDay
    {
        public string SolveA()
        {
            var input = InputLines(2);
            var idRanges = input[0].Split(',');

            List<long> invalidIds = new List<long>();
            foreach (var idRange in idRanges)
            {
                var currentId = idRange.Split('-').First();
                var lastId = idRange.Split('-').Last();

                var currentIdAsInt = long.Parse(currentId);
                var lastIdAsInt = long.Parse(lastId);

                while (currentIdAsInt != lastIdAsInt + 1)
                {
                    var currentIdAsCharArray = currentIdAsInt.ToString().ToCharArray();

                    // has to be even in length to repeat
                    if (currentIdAsCharArray.Count() % 2 != 0)
                    {
                        currentIdAsInt += 1;
                        continue;
                    }

                    var firstHalf = currentIdAsCharArray.Take(currentIdAsCharArray.Length / 2);
                    var secondHalf = currentIdAsCharArray.TakeLast(currentIdAsCharArray.Length / 2);

                    if (firstHalf.SequenceEqual(secondHalf))
                    {
                        Console.WriteLine(currentIdAsInt);
                        invalidIds.Add(currentIdAsInt);
                        currentIdAsInt += 1;
                        continue;
                    }

                    currentIdAsInt += 1;
                }
            }

            return invalidIds.Sum().ToString();
        }

        public string SolveB()
        {
            var input = InputLines(2);
            var idRanges = input[0].Split(',');

            var invalidIds = new List<long>();
            foreach (var idRange in idRanges)
            {
                var firstId = idRange.Split('-').First();
                var lastId = idRange.Split('-').Last();

                var currentIdAsInt = long.Parse(firstId);
                var lastIdAsInt = long.Parse(lastId);

                while (currentIdAsInt != lastIdAsInt + 1)
                {
                    var currentIdAsCharArray = currentIdAsInt.ToString().ToCharArray();

                    // exclude single digits
                    if (currentIdAsCharArray.Count() == 1)
                    {
                        currentIdAsInt += 1;
                        continue;
                    }

                    //check if they are all the same number
                        if (currentIdAsCharArray.Distinct().Count() == 1)
                        {
                            Console.WriteLine(currentIdAsInt);
                            invalidIds.Add(currentIdAsInt);
                            currentIdAsInt += 1;
                            continue;
                        }

                    var splitLength = currentIdAsCharArray.Length / 2;

                    var currentIdAsString = currentIdAsInt.ToString();
                    while (splitLength > 1)
                    {
                        if (currentIdAsCharArray.Length % splitLength == 0)
                        {
                            var chunks = new List<string>();
                            for (var i = 0; i < currentIdAsString.Length; i += splitLength)
                            {
                                var chunk = currentIdAsString.Substring(i, splitLength);
                                chunks.Add(chunk);

                                // new chunck didn't match existing chunk - bail now
                                if (chunks.Count() > 1 && chunks.Distinct().Count() > 1)
                                {
                                    break;
                                }
                            }

                            if (chunks.Count > 1 && chunks.Distinct().Count() == 1)
                            {
                                Console.WriteLine(currentIdAsInt);
                                invalidIds.Add(currentIdAsInt);
                                currentIdAsInt += 1;
                                break;
                            }
                        }

                        splitLength -= 1;
                    }

                    currentIdAsInt += 1;
                }
            }

            return invalidIds.Sum().ToString();
        }
    }
}