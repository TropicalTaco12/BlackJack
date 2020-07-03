using System;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        int playerCard = r.Next(1, 10);
        int playerCard2 = r.Next(1, 10);
        int dealerCard = r.Next(1, 10);
        int dealerCard2 = r.Next(1, 10);
        int playerTotal;
        int dealersTotal;

        Console.WriteLine("Welcome to BlackJack!");
        Console.WriteLine("Your 2 cards are " + playerCard + " and a " + playerCard2);
        playerTotal = playerCard + playerCard2;
        Console.WriteLine("Your total is " + playerTotal);
        Console.WriteLine("The Dealer's Cards are " + dealerCard + " while the other card is hidden.");

        while (true)
        {
            Console.WriteLine("Would you like to 'hit' or 'stand'?");
            string personInput = Console.ReadLine();

            Random r2 = new Random();
            int playerNewCard = r2.Next(1, 10);

            if (personInput == "hit")
            {
                Console.WriteLine("Your number is " + playerNewCard);
                playerTotal = playerTotal + playerNewCard;
                Console.WriteLine("Your new total is " + playerTotal);
            }

            if (playerTotal > 21)
            {
                Console.WriteLine("Awww! You went over 21! You lose.");
                break;
            }

            if (personInput == "stand")
            {
                Console.WriteLine("Ok, it is now the dealers turn.");
                Console.WriteLine("The dealer's hidden card was " + dealerCard2);
                dealersTotal = dealerCard + dealerCard2;
                Console.WriteLine("The dealer's total is " + dealersTotal);

                while (dealersTotal < 17)
                {
                    int dealerNewCard = r2.Next(1, 10);

                    Console.WriteLine("Dealer chooses to hit.");
                    Console.WriteLine("Dealer draws a " + dealerNewCard);
                    dealersTotal = dealersTotal + dealerNewCard;
                    Console.WriteLine("The dealer's total is now " + dealersTotal);

                    if (dealersTotal > 21)
                    {
                        Console.WriteLine("Ayyy! You won! The dealer went over 21!");
                        break;
                    }

                    if (dealersTotal >= 17)
                    {
                        Console.WriteLine("The dealer has to stand.");
                    }

                }

                if (playerTotal > dealersTotal)
                {
                    Console.WriteLine("Nice! You won!");
                }
                else
                {
                    Console.WriteLine("Awww. You Lost");  
                }
                break;
            }
        }
    }
}





