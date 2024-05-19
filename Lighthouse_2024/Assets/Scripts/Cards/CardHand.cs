using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class CardHand
{
    private static readonly int cardChoices = 3;
    private static Card[] cardlist = new Card[cardChoices];
    private static int[] rotCounters = new int[cardChoices];
    public static int rotTurns = 3;



    /// <summary>
    /// Sets up a month from a given month number, and draws 3 cards, keeping track of rot.
    /// </summary>
    /// <param name="month"></param>
    public static void SetUp(int month) {
        CardHandler.newMonth(month);
        
        for (int i = 0; i < cardlist.Length; i++)
        {
            cardlist[i] = CardHandler.DrawCard();
            rotCounters[i] = rotTurns;
        }
        CardUIController.self.displayHand(cardlist);


    }

    /// <summary>
    /// Calls for a choice to be displayed, refills card slots, and adjusts rot
    /// </summary>
    /// <param name="cardPosition">[0,cardChoices - 1]</param>
    public static void PlayCard(int cardPosition) {
        CardUIController.self.displayChoice(cardlist[cardPosition]);
        for (int i = 0; i < cardlist.Length; i++)
        {
            if(i == cardPosition) {
                cardlist[i] = CardHandler.DrawCard();
                rotCounters[i] = rotTurns;
            }
            else {
                rotCounters[i]--;
            }
        }
        // if rot counters = 0, replace with rot card.
        CardUIController.self.updateRot(rotCounters);
    }
}
