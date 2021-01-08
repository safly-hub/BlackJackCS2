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
            Console.WriteLine($"The total is: {TotalValue()}");
            Console.WriteLine();
        }
        public void AddCardToHand(Card cardToAdd);
    {
      Cards.Add(cardToAdd);
    }
}
class Card
{
    public string Face
    {
        get: set:}
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
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        //will need display greeting method to call into main//Console.WriteLine("Welcome to Luke's New BlackJack!");

    }
}
}
