Console.WriteLine("Welcome to the very real casino!");
Random rnd = new Random();

int rollNum = 0;
int num1 = 0;
int num2 = 0;
int numSides = 0;
bool loopProgram = true;

while (loopProgram)
{
    // getting side input
    numSides = inputSides();

    // rolling numbers
    rollNum += 1;
    num1 = rnd.Next(1, numSides + 1);
    num2 = rnd.Next(1, numSides + 1);

    // displaying
    Console.WriteLine($"Roll {rollNum}:");
    Console.WriteLine($"You rolled a {num1} and a {num2} ({num1 + num2} total).");
    if (numSides == 6)
    {
        if (checkSixSided(num1, num2) == "Snake Eyes")
        {
            Console.WriteLine("Snakes Eyes!");
        }
        else if (checkSixSided(num1, num2) == "Ace Deuce")
        {
            Console.WriteLine("Ace Deuce!");
        }
        else if (checkSixSided(num1, num2) == "Box Cars")
        {
            Console.WriteLine("Box Cars!");
        }

        if (checkSixSidedTotal(num1, num2) == "Win")
        {
            Console.WriteLine("Win!");
        }
        if (checkSixSidedTotal(num1, num2) == "Craps")
        {
            Console.WriteLine("Craps!");
        }
    }
    //continue prompt
    Console.WriteLine("\nWould you like to continue? y/n");
    string answer = "";
    do
    {
        answer = Console.ReadLine();
        if (answer == "y")
        {
            break;
        }
        else if (answer == "n")
        {
            loopProgram = false;
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    } while (answer != "n");
}
Console.WriteLine("Thank you for playing!");


static int inputSides()
{
    bool validInput = false;
    int numSides = 0;
    while (!validInput)
    {
        try
        {
            Console.WriteLine("Please enter the number of sides the die will have.");
            numSides = int.Parse(Console.ReadLine());
            if (numSides <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            validInput = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a positive number.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please enter a positive number");
        }
    }
    return numSides;
}

static string checkSixSided(int die1, int die2)
{
    if (die1 == 1 && die2 == 1)
    {
       return "Snake Eyes";
    }
    if ((die1 == 1 && die2 == 2) || (die1 == 2 && die2 == 1))
    {
        return "Ace Deuce";
    }
    if (die1 == 6 && die2 == 6)
    {
        return "Box Cars";
    }
    return "";
}

static string checkSixSidedTotal(int die1, int die2)
{
    if (die1 + die2 == 7 || die1 + die2 == 11)
    {
        return "Win";

    }
    if (die1 + die2 == 2 || die1 + die2 == 3 || die1 + die2 == 12)
    {
        return "Craps";
    }
    return "";
}