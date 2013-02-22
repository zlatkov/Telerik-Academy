using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCombinations
{
    class CardCombinations
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 13; ++i)
            {
                string cardValue = "";
                string cardSuit = "";

                switch(i)
                {
                    case 0: cardValue = "Two"; break;
                    case 1: cardValue = "Three"; break;
                    case 2: cardValue = "Four"; break;
                    case 3: cardValue = "Five"; break;
                    case 4: cardValue = "Six"; break;
                    case 5: cardValue = "Seven"; break;
                    case 6: cardValue = "Eight"; break;
                    case 7: cardValue = "Nine"; break;
                    case 8: cardValue = "Ten"; break;
                    case 9: cardValue = "Jack"; break;
                    case 10: cardValue = "Queen"; break;
                    case 11: cardValue = "King"; break;
                    case 12: cardValue = "Ace"; break;
                }

                for (int j = 0; j < 4; ++j)
                {
                    switch (j)
                    {
                        case 0: cardSuit = "Spades"; break;
                        case 1: cardSuit = "Hearts"; break;
                        case 2: cardSuit = "Diamonds"; break;
                        case 3: cardSuit = "Clubs"; break;
                    }

                    Console.WriteLine(cardValue + " of " + cardSuit);
                }
            }
        }
    }
}
