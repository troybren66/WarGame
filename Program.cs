using System;



namespace CardDeck

{

    class Program

    {

        static void Main(string[] args)

        {

            Deck d = new Deck();



            foreach (CardSuit cs in Enum.GetValues(typeof(CardSuit)))

            {

                foreach (CardValue cv in Enum.GetValues(typeof(CardValue)))

                {

                    d.AddCard(new Card(cs, cv));

                }

            }



            War(d);

        }



        static void War(Deck deck)

        {

            Console.WriteLine("Welcome to War!");

            deck.ShuffleDeck(deck);



            Deck playerDeck = new Deck();

            Deck computerDeck = new Deck();



            deck.SplitDeck(playerDeck, computerDeck);



        cardDraw:

            while (playerDeck.NumCards > 0 && computerDeck.NumCards > 0)

            {

                Console.WriteLine("Press any key to begin...");

                char playerDraw = Console.ReadKey().KeyChar;



                Card pCard = playerDeck.RemoveTopCard();

                Card cCard = computerDeck.RemoveTopCard();

                Console.WriteLine($"Player card: {pCard}");

                Console.WriteLine($"Computer card: {cCard}");



                pCard.CompareTo(cCard);

                while (pCard != cCard)

                {

                    if (pCard < cCard)

                    {

                        Console.WriteLine($"{cCard} is bigger than {pCard}. You lose!");

                        computerDeck.AddCard(pCard);

                        computerDeck.AddCard(cCard);

                        Console.WriteLine($"Player deck: {playerDeck.NumCards}");

                        Console.WriteLine($"Computer deck: {computerDeck.NumCards}");

                    }

                    else if (pCard > cCard)

                    {

                        Console.WriteLine($"{pCard} is bigger than {cCard}. You win!");

                        playerDeck.AddCard(pCard);

                        playerDeck.AddCard(cCard);

                        Console.WriteLine($"Player deck: {playerDeck.NumCards}");

                        Console.WriteLine($"Computer deck: {computerDeck.NumCards}");

                    }

                    goto cardDraw;

                }



                if (pCard == cCard)

                {

                    if (playerDeck.NumCards >= 2 && computerDeck.NumCards >= 2)

                    {

                        Console.WriteLine($"{pCard} and {cCard} are the same ");

                        Console.WriteLine("War!");



                    warStart:

                        Console.WriteLine("Press any key to go to war...");

                        char tieContinue = Console.ReadKey().KeyChar;



                        Card unkPCard = playerDeck.RemoveTopCard();

                        Card unkCCard = computerDeck.RemoveTopCard();

                        Card pCard2 = playerDeck.RemoveTopCard();

                        Card cCard2 = computerDeck.RemoveTopCard();

                        Console.WriteLine($"Player card: {pCard2}");

                        Console.WriteLine($"Computer card: {cCard2}");



                        if (pCard2 < cCard2)

                        {

                            Console.WriteLine($"{cCard2} is bigger than {pCard2}. You lose!");

                            computerDeck.AddCard(pCard);

                            computerDeck.AddCard(cCard);

                            computerDeck.AddCard(pCard2);

                            computerDeck.AddCard(cCard2);

                            computerDeck.AddCard(unkPCard);

                            computerDeck.AddCard(unkCCard);

                            Console.WriteLine($"Player deck: {playerDeck.NumCards}");

                            Console.WriteLine($"Computer deck: {computerDeck.NumCards}");

                        }



                        else if (pCard2 > cCard2)

                        {

                            Console.WriteLine($"{pCard2} is bigger than {cCard2}. You win!");

                            playerDeck.AddCard(pCard);

                            playerDeck.AddCard(cCard);

                            playerDeck.AddCard(pCard2);

                            playerDeck.AddCard(cCard2);

                            playerDeck.AddCard(unkPCard);

                            playerDeck.AddCard(unkCCard);

                            Console.WriteLine($"Player deck: {playerDeck.NumCards}");

                            Console.WriteLine($"Computer deck: {computerDeck.NumCards}");

                        }



                        else if (pCard2 == cCard2 && playerDeck.NumCards >= 2 && computerDeck.NumCards >= 2)

                        {

                            Console.WriteLine("War again!");

                            playerDeck.AddCard(pCard2);

                            computerDeck.AddCard(cCard2);

                            playerDeck.AddCard(unkPCard);

                            computerDeck.AddCard(unkCCard);

                            goto warStart;

                        }



                        else if (pCard2 == cCard2 && (playerDeck.NumCards < 2 || computerDeck.NumCards < 2))

                        {

                            Console.WriteLine("There are not enough cards to go to war again...");

                            

                            playerDeck.AddCard(pCard2);

                            computerDeck.AddCard(cCard2);

                            playerDeck.AddCard(unkPCard);

                            computerDeck.AddCard(unkCCard);

                            goto cardDraw;

                        }

                    }



                    else if (playerDeck.NumCards < 2)

                    {

                        Console.WriteLine("Player does not have enough cards to go to war...");

                        

                        playerDeck.AddCard(pCard);

                        computerDeck.AddCard(cCard);

                        goto cardDraw;

                    }



                    else if (computerDeck.NumCards < 2)

                    {

                        Console.WriteLine("Computer does not have enough cards to go to war...");

                       

                        playerDeck.AddCard(pCard);

                        computerDeck.AddCard(cCard);

                        goto cardDraw;

                    }

                }

            }



            if (playerDeck.NumCards == 0)

            {

                Console.WriteLine("You lose!");

            }



            else if (computerDeck.NumCards == 0)

            {

                Console.WriteLine("You win!");

            }

        }

    }

}