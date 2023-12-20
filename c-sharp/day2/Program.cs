
string filePath = Path.GetFullPath(@"D:\neoVimDir\aoc-2023\inputs\day2.txt");

try
{
    StreamReader reader = new(filePath);
    string line;
    int i = 0;
    int answer = 0;

    while ((line = reader.ReadLine()) != null)
    {
        i++;
        Console.WriteLine("game: " + i);

        int p = getPowerOfCubes(line);
        Console.WriteLine("p: " + p);

        answer += p;
        Console.WriteLine("answer: " + answer);

        /*


          if (isGamePossible(line))
           {
               answer += i;
           }
        */
    }

    Console.WriteLine(answer);
}
catch (Exception e)
{
    Console.WriteLine("Error reading the file: " + e.Message);
}

static int getPowerOfCubes(string line)
{
    string[] showsEachGame = line.Split(":");
    string[] eachShow = showsEachGame[1].Split(";");
    int red = 1 , green = 1, blue = 1;

    foreach (string totalCubes in eachShow)
    {
        string[] cubesOfColor = totalCubes.Split(",");
        foreach (string cubes in cubesOfColor)
        {
            string trimed = cubes.TrimStart();
            int spaceIndex = trimed.IndexOf(' ');
            if (int.TryParse(trimed.AsSpan(0, spaceIndex), out int number))
            {
                string color = trimed[(spaceIndex + 1)..].Trim();

                switch (color)
                {
                    case "red":
                        if(number > red)
                          red = number;
                        break;
                    case "green" : 
                        if(number > green)
                          green = number;
                        break;
                    case "blue": 
                        if(number > blue)
                           blue = number;
                        break;
                };
            }
        }

    }

    return red * green * blue;
}

static bool isGamePossible(string line)
{
    string[] showsEachGame = line.Split(":");

    string[] eachShow = showsEachGame[1].Split(";");
    foreach (string totalCubes in eachShow)
    {
        string[] cubesOfColor = totalCubes.Split(",");
        foreach (string cubes in cubesOfColor)
        {
            string trimed = cubes.TrimStart();
            int spaceIndex = trimed.IndexOf(' ');
            if (int.TryParse(trimed.AsSpan(0, spaceIndex), out int number))
                {
                    string color = trimed[(spaceIndex + 1)..].Trim();

                    if(!isAllowedCubeNumber(number, color))
                    {
                        return false;
                    }
                }
        }

    }
    return true;
}

static bool isAllowedCubeNumber(int cubeNumber,string color)
{
    if (cubeNumber < 12)
    {
        return true;
    }
    else if (cubeNumber > 14)
    {
        return false;
    }

    return color switch
    {
        "red" => cubeNumber <= 12,
        "green" => cubeNumber <= 13,
        "blue" => cubeNumber <= 14,
        _ => false,
    };
}
