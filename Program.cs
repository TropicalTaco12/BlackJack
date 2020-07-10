using System;

class Program
{

    static void Main(string[] args)
    {
        Random r = new Random();
        int playerCard = r.Next(1, 14);
        int playerCard2 = r.Next(1, 14);
        int dealerCard = r.Next(1, 14);
        int dealerCard2 = r.Next(1, 14);
        int playerTotal;
        int dealersTotal;
        int totalChips = 100;

        Console.WriteLine("Welcome to BlackJack!");
        Console.WriteLine("You have 100 chips.");
        Console.WriteLine("How much do you want to bet?");
        string x = Console.ReadLine();
        int personInput = Convert.ToInt32(x);

        while (true)
        {
            while (personInput > totalChips)
            {
                Console.WriteLine("You can't bet more than the amount you have!");
                Console.WriteLine("You have " + totalChips + " chips.");
                Console.WriteLine("How much do you want to bet?");
                x = Console.ReadLine();
                personInput = Convert.ToInt32(x);
                totalChips = 100;

                while (personInput < 0)
                {
                    Console.WriteLine("You have to bet more chips");
                    Console.WriteLine("You have " + totalChips + " chips.");
                    Console.WriteLine("How much do you want to bet?");
                    x = Console.ReadLine();
                    personInput = Convert.ToInt32(x);
                    totalChips = 100;
                }
            }
            totalChips = totalChips - personInput;

            Console.WriteLine("The amount of chips you have now is " + totalChips + ".");
            Console.WriteLine("Your 2 cards are " + NumberToCard(playerCard) + " and a " + NumberToCard(playerCard2));

            Console.WriteLine("The Dealer's Cards are " + NumberToCard(dealerCard) + " while the other card is hidden.");
            playerTotal = NumberToValue(playerCard) + NumberToValue(playerCard2);
            Console.WriteLine("Your total is " + playerTotal);

            int[] cardCounter = new int[14];

            DoStuff(cardCounter, playerCard);

            while (true)
            {
                Console.WriteLine("Would you like to 'hit' or 'stand'?");
                string personInput1 = Console.ReadLine();

                Random r2 = new Random();
                int playerNewCard = r2.Next(1, 14);

                if (personInput1 == "hit")
                {
                    Console.WriteLine("Your card is " + NumberToCard(playerNewCard));
                    playerTotal = playerTotal + NumberToValue(playerNewCard);
                    Console.WriteLine("Your new total is " + playerTotal);
                }

                if (playerTotal > 21)
                {
                    Console.WriteLine("Awww! You went over 21! You lose.");
                    Console.WriteLine("You now have " + totalChips + " chips.");
                    Console.WriteLine("How much do you want to bet?");
                    x = Console.ReadLine();
                    personInput = Convert.ToInt32(x);


                }

                if (personInput1 == "stand")
                {
                    Console.WriteLine("Ok, it is now the dealers turn.");
                    Console.WriteLine("The dealer's hidden card was " + NumberToCard(dealerCard2));
                    dealersTotal = NumberToValue(dealerCard) + NumberToValue(dealerCard2);
                    Console.WriteLine("The dealer's total is " + dealersTotal);

                    while (dealersTotal < 17)
                    {
                        int dealerNewCard = r2.Next(1, 10);

                        Console.WriteLine("Dealer chooses to hit.");
                        Console.WriteLine("Dealer draws a " + NumberToCard(dealerNewCard));
                        dealersTotal = dealersTotal + NumberToValue(dealerNewCard);
                        Console.WriteLine("The dealer's total is now " + dealersTotal);

                        if (dealersTotal > 21)
                        {
                            Console.WriteLine("Ayyy! You won! The dealer went over 21!");
                            Console.WriteLine("You now have " + totalChips + " chips.");
                            Console.WriteLine("How much do you want to bet?");
                            x = Console.ReadLine();
                            personInput = Convert.ToInt32(x);



                        }

                        if (dealersTotal >= 17)
                        {
                            Console.WriteLine("The dealer has to stand.");
                        }

                        if (playerTotal > dealersTotal)
                        {
                            totalChips = personInput * 2 + totalChips;
                        }
                        else
                        {
                            totalChips = personInput * 2 - totalChips;
                        }

                    }

                    if (playerTotal > dealersTotal)
                    {

                        Console.WriteLine("Nice! You won!");
                        Console.WriteLine("You now have " + totalChips + " chips.");
                        Console.WriteLine("How much do you want to bet?");
                        x = Console.ReadLine();
                        personInput = Convert.ToInt32(x);


                    }
                    else
                    {
                        Console.WriteLine("Awww. You Lost");
                        Console.WriteLine("You now have " + totalChips + " chips.");
                        Console.WriteLine("How much do you want to bet?");
                        x = Console.ReadLine();
                        personInput = Convert.ToInt32(x);



                    }





                }
            }
        }

    }

    public static void DoStuff(int[] cardCounter, int playerCard)
    {
        for (int i = 0; i < cardCounter.Length; i++)
        {
            cardCounter[i] = 4;
        }

        if (playerCard == 1)
        {
            cardCounter[1]--;
        }
        else if (playerCard == 2)
        {
            cardCounter[2]--;
        }
        else if (playerCard == 3)
        {
            cardCounter[3]--;
        }
        else if (playerCard == 4)
        {
            cardCounter[4]--;
        }
        else if (playerCard == 5)
        {
            cardCounter[5]--;
        }
        else if (playerCard == 6)
        {
            cardCounter[6]--;
        }
        else if (playerCard == 7)
        {
            cardCounter[7]--;
        }
        else if (playerCard == 8)
        {
            cardCounter[8]--;
        }
        else if (playerCard == 9)
        {
            cardCounter[9]--;
        }
        else if (playerCard == 10)
        {
            cardCounter[10]--;
        }
        else if (playerCard == 11)
        {
            cardCounter[11]--;
        }
        else if (playerCard == 12)
        {
            cardCounter[12]--;

        }
        else if (playerCard == 13)
        {
            cardCounter[13]--;
        }
    }
    public static string NumberToCard(int playerCard)
    {
        if (playerCard == 13)
        {
            return "K";
        }
        else if (playerCard == 12)
        {
            playerCard = 10;
            return "Q";
        }
        else if (playerCard == 11)
        {
            playerCard = 10;
            return "J";
        }
        else if (playerCard == 1)
        {
            return "A";
        }
        else
        {
            string x = playerCard.ToString();

            return x;
        }
    }
    public static int NumberToValue(int playerCard)
    {
        if (playerCard == 13)
        {
            return 10;
        }
        else if (playerCard == 12)
        {
            return 10;
        }
        else if (playerCard == 11)
        {
            return 10;
        }
        else if (playerCard == 1)
        {
            //TODO handle ace to be 1 or 11
            return 1;
        }
        else
        {
            return playerCard;
        }
    }
}





