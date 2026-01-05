namespace AdventOfCode
{
    public class Day8 : Day, IDay
    {
        public string SolveA()
        {
            var input = InputLines(8);
            var boxes = new List<JunctionBox>();
            for (int i = 0; i < input.Length; i++)
            {
                var coords = input[i].Split(',');
                boxes.Add(new JunctionBox(){Id = i, x = int.Parse(coords[0]), y = int.Parse(coords[1]), z = int.Parse(coords[2])});
            }


            var distances = new List<JunctionDistance>();
            for (int i = 0; i < boxes.Count; i++)
            {
                for (int j = 0; j < boxes.Count; j++)
                {
                    // don't need to calculate distance to self
                    if (i == j) continue;

                    // don't need to calculate more than once
                    if (distances.Any(x => (x.Box1.Id == i && x.Box2.Id == j) || (x.Box1.Id == j && x.Box2.Id == i))) continue;

                    var x1 = boxes[i].x;
                    var y1 = boxes[i].y;
                    var z1 = boxes[i].z;

                    var x2 = boxes[j].x;
                    var y2 = boxes[j].y;
                    var z2 = boxes[j].z;

                    var value = (x2 - x1)^2 + (y2 - y1) ^2 + (z2 - z1)^2;
                    int negative = 1;
                    if (value < 0)
                    {
                        if(value < 0)
                            negative = -1;
                    }
                    var distance = Math.Sqrt(Math.Abs(value));
                    distances.Add(new JunctionDistance(){Box1 = boxes.Single(b => b.Id == i), Box2 = boxes.Single(b => b.Id == j), Distance = distance});
                }
            }

            var orderedDistances = distances.OrderBy(x => x.Distance).ToList();
            var circuitGroups = new List<CircuitGroup>();
            var count = 0;
            foreach (var distance in orderedDistances)
            {
                if (count == 9) break;

                // check if both boxes already in the same group
                if (circuitGroups.Any(g => g.Boxes.Any(b => b.Id == distance.Box1.Id) && g.Boxes.Any(b => b.Id == distance.Box2.Id))) {
                    continue;
                }

                // check if box 1 in a group
                var box1Group = circuitGroups.SingleOrDefault(g => g.Boxes.Any(b => b.Id == distance.Box1.Id));
                // chewck if box 2 in a group
                var box2Group = circuitGroups.SingleOrDefault(g => g.Boxes.Any(b => b.Id == distance.Box2.Id));
                // if both in a group, join the groups
                if (box1Group != null && box2Group != null)
                {
                    var newJoinedGroup = new CircuitGroup{ Boxes = box1Group.Boxes.Union(box2Group.Boxes).ToList() };
                    circuitGroups = circuitGroups.Where(g => g != box1Group && g != box2Group).Append(newJoinedGroup).ToList();
                    count++;
                    continue;
                }

                if (box1Group != null)
                {
                    box1Group.Boxes.Add(distance.Box2);
                    count++;
                    continue;
                }

                if (box2Group != null)
                {
                    box2Group.Boxes.Add(distance.Box1);
                    count++;
                    continue;
                }

                circuitGroups.Add(new CircuitGroup{ Boxes = new List<JunctionBox>() {distance.Box1, distance.Box2} });
                count++;
            }

            var orderedGroups = circuitGroups.OrderBy(g => g.Boxes.Count()).ToArray();
            var solution = orderedGroups.First().Boxes.Count() * orderedGroups[1].Boxes.Count() * orderedGroups[2].Boxes.Count();

            // finally handle all the singletons
            

            return solution.ToString();
        }

        public string SolveB()
        {
            return "Not Implemented";
        }

        
    }

    public class CircuitGroup
    {
        public List<JunctionBox> Boxes {get; set;}
    }

    public struct JunctionBox
    {
        public int Id {get; set;}

        public int x {get; set;}

        public int y {get; set;}

        public int z {get; set;}
    }

    public struct JunctionDistance
    {
        public JunctionBox Box1 {get; set;}

        public JunctionBox Box2 {get; set;}

        public double Distance {get;set;}
    }
}