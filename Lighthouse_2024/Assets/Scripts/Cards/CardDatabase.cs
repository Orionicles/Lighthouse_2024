using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting.Dependencies.NCalc;

/// <summary>
/// Inspiration from https://www.youtube.com/watch?v=C37C2yCUlCM&ab_channel=JesseEtzler
/// </summary>
public class CardDatabase : MonoBehaviour
{
    // A dictionary that compares a card's name to a card's effects
    public static Dictionary<string, Card> cardDatabase = new();
    
    /// <summary>
    /// Refills the Database based off of the data within the \Resources\CardEffects. Shouldn't be called in-code.
    /// </summary>
    public static void LoadCardData() 
    {
        //Empties the Database
        cardDatabase.Clear();

        //Reads the CSV files
        List<Dictionary<string, object>> data = CSVReader.Read("CardEffects");
        foreach (var row in data)
        {
            int totalOptions = int.Parse(row["# of Options"].ToString());
            var newCard = new Card(row["CardName"].ToString());
            for (int j = 1; j <= totalOptions ; j++)
            {
                int sanity = int.Parse(row["Option " + j + " Sanity"].ToString());
                int nourishment = int.Parse(row["Option " + j + " Nourishment"].ToString());
                int bait = int.Parse(row["Option " + j + " Sanity"].ToString());
                int book = int.Parse(row["Option " + j + " Sanity"].ToString());
                int fish = int.Parse(row["Option " + j + " Sanity"].ToString());

                newCard.AddOption(sanity, nourishment, bait, book, fish);
            }
            Debug.Log(newCard.ToString());
            cardDatabase.Add(newCard.cardName, newCard);
        } 
    }

    
}

/// <summary>
/// Allows for a Unity Editor button to refill the Database
/// </summary>
[CustomEditor(typeof(CardDatabase))]
public class CardDatabaseEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if(GUILayout.Button("Reimport Card Database")) {
            CardDatabase.LoadCardData();
        }
    }
}
