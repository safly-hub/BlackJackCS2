using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackCS2
{
    class Hand
    {
        public List<Card> Cards = new List<Card>();
        public int TotalValue()
        {
            var total = 0;

            foreach (var card in Cards)
            {
                total = total + card.Value();
            }
            return total;
        }
        public bool Busted()
        {
            if (TotalValue() > 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Display()
        {
            foreach (var card in Cards)
            {
                Console.WriteLine($"The {card.Face} of {card.Suit}");
            }
            Console.WriteLine($"\nThe total is: {TotalValue()}\n");
            Console.WriteLine();
        }
        public void AddCardToHand(Card cardToAdd)
        {
            Cards.Add(cardToAdd);
        }
    }
    class Card
    {
        public string Face { get; set; }
        public string Suit { get; set; }
        public int Value()
        {
            var answer = 0;
            switch (Face)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                    answer = int.Parse(Face);
                    break;

                case "Jack":
                case "Queen":
                case "King":
                    answer = 10;
                    break;

                case "Ace":
                    answer = 11;
                    break;
            }

            return answer;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var playAgain = "YES"; while (playAgain.ToUpper() == "YES")
            {
                var deck = new List<Card>();
                var suits = new List<string>() { "Hearts", "Spades", "Diamonds", "Clubs" };
                var faces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

                Console.WriteLine("\n--------------------------------\n");
                Console.WriteLine("Welcome to Luke's New BlackJack!");
                Console.WriteLine("\n--------------------------------\n");


                foreach (var suit in suits)
                {
                    foreach (var face in faces)
                    {
                        var ourCard = new Card()
                        {
                            Face = face,
                            Suit = suit,
                        };
                        deck.Add(ourCard);
                    }
                }
                var n = deck.Count();
                for (var rightIndex = n - 1; rightIndex >= 1; rightIndex--)
                {
                    var randomNumberGenerator = new Random();
                    var leftIndex = randomNumberGenerator.Next(rightIndex);

                    var leftCard = deck[rightIndex];
                    var rightCard = deck[leftIndex];
                    deck[rightIndex] = rightCard;
                    deck[leftIndex] = leftCard;
                }
                var player = new Hand();
                var dealer = new Hand();

                var firstCardForPlayer = deck[0];
                deck.Remove(firstCardForPlayer);
                player.AddCardToHand(firstCardForPlayer);

                var secondCardForPlayer = deck[0];
                deck.Remove(secondCardForPlayer);
                player.AddCardToHand(secondCardForPlayer);

                var firstCardForDealer = deck[0];
                deck.Remove(firstCardForDealer);
                dealer.AddCardToHand(firstCardForDealer);

                var secondCardForDealer = deck[0];
                deck.Remove(secondCardForDealer);
                dealer.AddCardToHand(secondCardForDealer);

                var choice = " ";
                while (choice != "STAND" && !player.Busted())
                {
                    Console.WriteLine("\n------ YOUR HAND -----\n");
                    player.Display();

                    Console.Write("\nTHE DEALER HAS ALREADY BEEN DEALT TWO CARDS\n");

                    Console.WriteLine("\nDEALERS CARDS WILL NOT BE SHOWN TILL END OF GAME\n");

                    Console.Write("\nWOULD YOU LIKE TO HIT or STAND?\n");

                    choice = Console.ReadLine();

                    if (choice == "HIT")
                    {
                        var additionalCard = deck[0];
                        deck.Remove(additionalCard);
                        player.AddCardToHand(additionalCard);
                    }
                }
                Console.WriteLine("\n------ YOUR HAND -----\n");
                player.Display();

                while (!player.Busted() && dealer.TotalValue() < 17)
                {
                    var additionalCard = deck[0];
                    deck.Remove(additionalCard);
                    dealer.AddCardToHand(additionalCard);
                }
                Console.WriteLine("------ DEALERS HAND -----");
                Console.WriteLine();
                dealer.Display();

                if (player.Busted())
                {
                    Console.WriteLine("Dealer wins! YOU BUSTED");
                    Console.WriteLine();
                }
                else
                {
                    if (dealer.Busted())
                    {
                        Console.WriteLine("YOU WIN! DEALER BUSTED");
                        Console.WriteLine();
                    }
                    else
                    {
                        if (dealer.TotalValue() > player.TotalValue())
                        {
                            Console.WriteLine("Dealer Wins!");
                            Console.WriteLine();
                        }
                        else
                        {
                            if (player.TotalValue() > dealer.TotalValue())
                            {
                                Console.WriteLine("YOU WIN!");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Tie goes to the dealer");
                                Console.WriteLine();
                            }
                        }
                    }
                }
                Console.WriteLine(); Console.Write("Play again? YES or NO? "); playAgain = Console.ReadLine();
            }
        }
    }
}