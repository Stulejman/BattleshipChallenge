// See https://aka.ms/new-console-template for more information
using BattleshipChallenge.Model;
using BattleshipChallenge.Model.Exceptions;
using BattleshipChallenge.Model.Enums;
using BattleshipChallenge.Model.Enums.Extensions;

BattleshipsGame game = new BattleshipsGame(new BoardFactory(), new ConsoleBoardPrinter());
game.Start();

while (game.InProgress)
{
	try
	{
		Console.Write("Input: ");

//Supress for you to test exceptions, and for me to have 0 warnings :)
#pragma warning disable CS8604 // Possible null reference argument.
		AttackOutcome result = game.PlayTurn(Console.ReadLine());
#pragma warning restore CS8604 // Possible null reference argument.

		Console.WriteLine($"Result:{result.GetDescription()}");
	}
    catch (WrongCellNameException)
	{
        InvalidArgumentConsoleMessage();
    }
    catch (ArgumentNullException)
	{
        InvalidArgumentConsoleMessage();
    }
	catch (ArgumentException)
	{
		InvalidArgumentConsoleMessage();
    }
	catch(Exception)
	{
		throw;
    }
}

void InvalidArgumentConsoleMessage()
{
	Console.WriteLine("Invalid input... Press any key to retry.");
	Console.ReadKey();
}
