using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public static class CardHandler
{
    private static List<Card> monthDeck = new();
    private static readonly System.Random random = new();
    
    /// <summary>
    /// Loads a given Month's Cards into the deck, and shuffles it
    /// </summary>
    /// <param name="monthNumber">r = [1,# of months]</param>
    public static void newMonth(int monthNumber) 
    {
        LoadMonthData(monthNumber);
        ShuffleDeck();
        
    }

    /// <summary>
    /// Loads the Cards of the given month into the monthDeck. Could be improved by creating a MonthDatabase in editor being a List<List<(string, int)>>
    /// </summary>
    /// <param name="monthNumber"></param>
    private static void LoadMonthData(int monthNumber) 
    {
        //Empties the Database
        monthDeck.Clear();

        //Reads the CSV files
        List<Dictionary<string, object>> data = CSVReader.Read("MonthData");
        for (int i = 0; i < data.Count; i++)
        {
            var cardName = data[i]["CardName"].ToString();
            var cardQuantity = int.Parse(data[i]["Month " + monthNumber + " Quantity"].ToString());
            for(int j = 0; j < cardQuantity; j++) {
                monthDeck.Add(CardDatabase.self.cardDatabase[cardName]);
                //Debug.Log(cardName);
            }
        } 
    }

    /// <summary>
    /// Shuffles the Deck
    /// </summary>
    public static void ShuffleDeck() {
       monthDeck = monthDeck.OrderBy(_ => random.Next()).ToList();
    }

    /// <summary>
    /// Removes a card from the top of the Deck, returning that Card.
    /// </summary>
    /// <returns></returns>
    public static Card DrawCard() {
        //Possibly link to an event in the front-end
        Card output = monthDeck[0];
        monthDeck.RemoveAt(0);
        return output;
    }

}
