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

                    // otherwise we split (hash set deals with dups)
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
            var startPoint = Array.IndexOf([.. input[0]], 'S'); 
            var lightBeamPoints = new Dictionary<int, long>
            {
                { startPoint, 1 }
            };
            for (int i = 2; i < input.Length - 1 ; i += 2)
            {
                var newLightBeamPoints = new Dictionary<int, long>();
                for (int j = 0; j < input[0].ToArray().Length - 1 ; j++)
                {
                    // if there is nothing to split we don't care
                    if (!lightBeamPoints.ContainsKey(j)) continue;
                    
                    // we didn't split so carry beam down to next line
                    if (input[i][j] == '.') {
                        if (newLightBeamPoints.TryGetValue(j, out long value))
                        {
                            newLightBeamPoints[j] = value + lightBeamPoints[j];
                        }
                        else
                        {
                            newLightBeamPoints.Add(j, lightBeamPoints[j]);
                        }
                        continue;
                    }

                    if (newLightBeamPoints.ContainsKey(j - 1))
                    {
                        newLightBeamPoints[j-1] = newLightBeamPoints[j-1] + lightBeamPoints[j];
                    }
                    else
                    {
                        newLightBeamPoints.Add(j - 1, lightBeamPoints[j]);
                    }

                    if (newLightBeamPoints.ContainsKey(j + 1))
                    {
                        newLightBeamPoints[j+1] = newLightBeamPoints[j+1] + lightBeamPoints[j];
                    }
                    else
                    {
                        newLightBeamPoints.Add(j + 1, lightBeamPoints[j]);
                    }
                }

                lightBeamPoints = newLightBeamPoints;
            }
            
            return lightBeamPoints.Sum(x => x.Value).ToString();
        }
    }
}