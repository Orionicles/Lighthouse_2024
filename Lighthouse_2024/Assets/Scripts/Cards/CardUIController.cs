using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// PROTOTYPE ONLY - THIS IMPLEMENTATION IS NOT SCALABLE
/// </summary>
public class CardUIController : MonoBehaviour
{
    //change buttons and choices to arrays?
    public GameObject card0;
    public GameObject card1;
    public GameObject card2;
    public GameObject choice1;
    public GameObject choice2;
    public static CardUIController self;
    public void Awake() {
        if(self != null && self != this) {
            Destroy(this);
        }
        else
        {
            self = this;
        }
    }
    // Start is called before the first frame update
    public void playCard(int cardPosition) {
        CardHand.PlayCard(cardPosition);
    }

    public void displayChoice(Card card) {
        //disable buttons
        var strings = parseCardChoices(card);
        choice1.GetComponentInChildren<TextMeshProUGUI>().text = strings[1];
        choice2.GetComponentInChildren<TextMeshProUGUI>().text = strings[2];
    }

    public void displayHand(Card[] cards) {
        //Parse the content of cards to find choices
    }

    public void updateRot(int[] rotCounters) {
        //update rot counters with new info.
    }

    /// <summary>
    /// Splits string so that Name = output[0], options are output = [x > 0]
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    private string[] parseCardChoices(Card card) {
        return card.ToString().Split("\n\n");
    }
}
