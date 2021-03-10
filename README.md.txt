# Code is king : Uppgift 4
Poker hand analyzer.

Shuffles a standard deck of 52 cards using Fisher-Yates shuffle method and deals the top 5 cards to a hand.
The hand is analysed and given ranks according to the keys in the table below.

                                    +-----------------------+
                                    | Key : Type of hand    |
                                    +-----------------------+
                                    |  0  : High Card (Ace) |
                                    |  1  :            Pair |
                                    |  2  :        Two Pair |
                                    |  3  : Three Of A Kind |
                                    |  4  :        Straight |
                                    |  5  :           Flush |
                                    |  6  :      Full House |
                                    |  7  :  Four Of A Kind |
                                    |  8  :  Straight Flush |
                                    |  9  :     Royal Flush |
                                    +-----------------------+

When a dealt hand contains all ranks in the wanted hand, the shuffling stops and the hand is presented.

The algorithm tops around 190 000 shuffles/s.