namespace AdventOfCode
{
    public class Day7 : Day, IDay
    {
        public string SolveA()
        {
            var input = GetInputAsCharMatrix(7);
            var startPoint = Array.IndexOf(input[0].ToArray(), 'S'); 
            var lightBeamPoints = new HashSet<int>() {startPoint};
            var splitCount = 0;
            for (int i = 1; i < input.Length - 1 ; i++)
            {
                var newLightBeamPoints = new HashSet<int>();
                for (int j = 0; j < input[0].ToArray().Length - 1 ; j++)
                {
                    // if there is nothing to split we don't care
                    if (!lightBeamPoints.Contains(j)) continue;
                    
                    // we didn't split so carry beam down to next line
                    if (input[i][j] == '.') {
                        newLightBeamPoints.Add(j);
                        continue;
                    }

                    // otherwise we split (hast set deals with dups)
                    splitCount += 1;
                    newLightBeamPoints.Add(j-1);
                    newLightBeamPoints.Add(j+1);
                }

                lightBeamPoints = newLightBeamPoints;
            }

            return splitCount.ToString();
        }

        public string SolveB()
        {
            var input = GetInputAsCharMatrix(7);
            var startPoint = Array.IndexOf(input[0].ToArray(), 'S'); 
            var lightBeamPoints = new List<int>() {startPoint};
            var timePoints = 0;
            for (int i = 1; i < input.Length - 1 ; i++)
            {
                var newLightBeamPoints = new List<int>();
                for (int j = 0; j < input[0].ToArray().Length - 1 ; j++)
                {
                    // if there is nothing to split we don't care
                    if (!lightBeamPoints.Contains(j)) continue;
                    
                    // we didn't split so carry beam down to next line
                    if (input[i][j] == '.') {
                        var noOfPointsAtPoint = lightBeamPoints.Where(p => p ==j).Count();
                        while (noOfPointsAtPoint > 0){
                            newLightBeamPoints.Add(j);
                            noOfPointsAtPoint -=1;
                            if (i == input.Length - 2){
                                timePoints += 2;
                            }
                        }
                        continue;
                    }

                    // otherwise we split (hast set deals with dups)
                    if (i == input.Length - 2){
                    timePoints += 2;
                    }
                    newLightBeamPoints.Add(j-1);
                    newLightBeamPoints.Add(j+1);
                }

                lightBeamPoints = newLightBeamPoints;
            }
            Console.WriteLine(timePoints);
            return lightBeamPoints.Count().ToString();
        }
    }
}