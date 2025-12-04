namespace AdventOfCode
{
    public class Day4 : Day, IDay
    {
        public string SolveA()
        {
            var input = GetInputAsCharMatrix(4);

            var isReachable = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {   
                    if (input[i][j] != '@') continue;

                    var adjacentSpaces = 0;
                    
                    // handle corners
                    if (i == 0)
                    {
                       if (j == 0 || j ==  input[i].Length - 1) adjacentSpaces += 5; // this is enough, can skip the rest
                       else {
                        adjacentSpaces += 3;
                        if (input[i][j-1] == '.') adjacentSpaces += 1;
                        if (input[i][j+1] == '.') adjacentSpaces += 1;
                        if (input[i+1][j-1] == '.') adjacentSpaces += 1;
                        if (input[i+1][j] == '.') adjacentSpaces += 1;
                        if (input[i+1][j+1] == '.') adjacentSpaces += 1;
                        }
                    }
                    else if (i == input.Length - 1)
                    {
                       if (j == 0 || j ==  input[i].Length - 1) adjacentSpaces += 5; // this is enough, can skip the rest
                       else {
                        adjacentSpaces += 3;
                         if (input[i-1][j-1] == '.') adjacentSpaces += 1;
                        if (input[i-1][j] == '.') adjacentSpaces += 1;
                        if (input[i-1][j+1] == '.') adjacentSpaces += 1;
                        if (input[i][j-1] == '.') adjacentSpaces += 1;
                        if (input[i][j+1] == '.') adjacentSpaces += 1;
                        }
                    }
                    else if (j == 0)
                    {
                       if (i == 0 || i ==  input.Length - 1 ) adjacentSpaces += 5; // this is enough, can skip the rest
                       else {
                        adjacentSpaces += 3;
                        if (input[i-1][j] == '.') adjacentSpaces += 1;
                        if (input[i-1][j+1] == '.') adjacentSpaces += 1;
                        if (input[i][j+1] == '.') adjacentSpaces += 1;
                        if (input[i+1][j] == '.') adjacentSpaces += 1;
                        if (input[i+1][j+1] == '.') adjacentSpaces += 1;
                        }
                    }
                    else if (j ==  input[i].Length - 1)
                    {
                       if (i == 0 || i ==  input.Length - 1 ) adjacentSpaces += 5; // this is enough, can skip the rest
                       else {
                        adjacentSpaces += 3;
                         if (input[i-1][j-1] == '.') adjacentSpaces += 1;
                        if (input[i-1][j] == '.') adjacentSpaces += 1;
                        if (input[i][j-1] == '.') adjacentSpaces += 1;
                        if (input[i+1][j-1] == '.') adjacentSpaces += 1;
                        if (input[i+1][j] == '.') adjacentSpaces += 1;
                        }
                    }
                    else
                    {
                        if (input[i-1][j-1] == '.') adjacentSpaces += 1;
                        if (input[i-1][j] == '.') adjacentSpaces += 1;
                        if (input[i-1][j+1] == '.') adjacentSpaces += 1;
                        if (input[i][j-1] == '.') adjacentSpaces += 1;
                        if (input[i][j+1] == '.') adjacentSpaces += 1;
                        if (input[i+1][j-1] == '.') adjacentSpaces += 1;
                        if (input[i+1][j] == '.') adjacentSpaces += 1;
                        if (input[i+1][j+1] == '.') adjacentSpaces += 1;
                    }

                    if (adjacentSpaces >= 5) isReachable +=1;
                }
            }
            return isReachable.ToString();
        }

        public string SolveB()
        {
            var input = GetInputAsCharMatrix(4);
            var copy = input;
            var isReachable = 0;
            var startingReachable = -1;
            do {
                startingReachable = isReachable;
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {   
                        if (input[i][j] != '@') continue;

                        var adjacentSpaces = 0;
                        
                        // handle corners
                        if (i == 0)
                        {
                        if (j == 0 || j ==  input[i].Length - 1) adjacentSpaces += 5; // this is enough, can skip the rest
                        else {
                            adjacentSpaces += 3;
                            if (input[i][j-1] == '.') adjacentSpaces += 1;
                            if (input[i][j+1] == '.') adjacentSpaces += 1;
                            if (input[i+1][j-1] == '.') adjacentSpaces += 1;
                            if (input[i+1][j] == '.') adjacentSpaces += 1;
                            if (input[i+1][j+1] == '.') adjacentSpaces += 1;
                            }
                        }
                        else if (i == input.Length - 1)
                        {
                        if (j == 0 || j ==  input[i].Length - 1) adjacentSpaces += 5; // this is enough, can skip the rest
                        else {
                            adjacentSpaces += 3;
                            if (input[i-1][j-1] == '.') adjacentSpaces += 1;
                            if (input[i-1][j] == '.') adjacentSpaces += 1;
                            if (input[i-1][j+1] == '.') adjacentSpaces += 1;
                            if (input[i][j-1] == '.') adjacentSpaces += 1;
                            if (input[i][j+1] == '.') adjacentSpaces += 1;
                            }
                        }
                        else if (j == 0)
                        {
                        if (i == 0 || i ==  input.Length - 1 ) adjacentSpaces += 5; // this is enough, can skip the rest
                        else {
                            adjacentSpaces += 3;
                            if (input[i-1][j] == '.') adjacentSpaces += 1;
                            if (input[i-1][j+1] == '.') adjacentSpaces += 1;
                            if (input[i][j+1] == '.') adjacentSpaces += 1;
                            if (input[i+1][j] == '.') adjacentSpaces += 1;
                            if (input[i+1][j+1] == '.') adjacentSpaces += 1;
                            }
                        }
                        else if (j ==  input[i].Length - 1)
                        {
                        if (i == 0 || i ==  input.Length - 1 ) adjacentSpaces += 5; // this is enough, can skip the rest
                        else {
                            adjacentSpaces += 3;
                            if (input[i-1][j-1] == '.') adjacentSpaces += 1;
                            if (input[i-1][j] == '.') adjacentSpaces += 1;
                            if (input[i][j-1] == '.') adjacentSpaces += 1;
                            if (input[i+1][j-1] == '.') adjacentSpaces += 1;
                            if (input[i+1][j] == '.') adjacentSpaces += 1;
                            }
                        }
                        else
                        {
                            if (input[i-1][j-1] == '.') adjacentSpaces += 1;
                            if (input[i-1][j] == '.') adjacentSpaces += 1;
                            if (input[i-1][j+1] == '.') adjacentSpaces += 1;
                            if (input[i][j-1] == '.') adjacentSpaces += 1;
                            if (input[i][j+1] == '.') adjacentSpaces += 1;
                            if (input[i+1][j-1] == '.') adjacentSpaces += 1;
                            if (input[i+1][j] == '.') adjacentSpaces += 1;
                            if (input[i+1][j+1] == '.') adjacentSpaces += 1;
                        }

                        if (adjacentSpaces >= 5) {isReachable +=1;
                            copy[i][j] = '.';
                        }
                    }
                }
            } while (isReachable > startingReachable);
            return isReachable.ToString();
        }
    }
}