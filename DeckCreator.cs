using System;

using System.Collections.Generic;



namespace CardDeck

{

    class Deck

    {

        List<Card> Cards { get; set; }

        public int NumCards { get => Cards.Count; }



        public Deck()

        {

            Cards = new List<Card>();

        }



        public void AddCard(Card newCard)

        {

            Cards.Add(newCard);

        }



        public Card RemoveTopCard()

        {

            Card cardToRemove = Cards[0];

            Cards.RemoveAt(0);

            return cardToRemove;

        }



        public void PrintDeck()

        {

            foreach (Card c in Cards)

            {

                System.Console.WriteLine(c);

            }

        }



        public void SortDeck()

        {

            Cards.Sort();

        }



        public void ShuffleDeck(Deck deck)

        {

            for (int i = 1; i <= 100000; i++)

            {

                Random r = new Random();

                int rInt = r.Next(Cards.Count);

                Card randomCard = Cards[rInt];

                Cards.RemoveAt(rInt);

                deck.AddCard(randomCard);

            }

        }



        public void SplitDeck(Deck playerDeck, Deck computerDeck)

        {

            for (int i = 0; i < Cards.Count; i++)

            {

                if (i % 2 == 0)

                {

                    Card newCard = Cards[i];

                    playerDeck.AddCard(newCard);

                }

                else

                {

                    Card newCard = Cards[i];

                    computerDeck.AddCard(newCard);

                }

            }

        }

    }

}