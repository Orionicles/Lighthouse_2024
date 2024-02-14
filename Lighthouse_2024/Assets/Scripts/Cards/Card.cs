using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;
using UnityEngine;

/// <summary>
/// A representation of a card, and how it affects your resources.
/// </summary>
[System.Serializable]
public class Card
{
    public List<Option> Options;
    public string cardName;

    /// <summary>
    /// A class representing the changes to values if an option is chosen
    /// </summary>
    [System.Serializable]
    public class Option 
    {
        public int sanity { get; internal set;}
        public int nourishment { get; internal set;}
        public int bait { get; internal set;}
        public int book { get; internal set;}
        public int fish { get; internal set;}
    }

    /// <summary>
    /// Basic Constructor
    /// </summary>
    public Card(string cardName) 
    {
        Options = new List<Option>();
        this.cardName = cardName;
    }

    /// <summary>
    /// Adds an Option to a Card given the changes made to a 
    /// </summary>
    /// <param name="sanity">the Option's Sanity Changes</param>
    /// <param name="nourishment">the Option's Nourishment Changes</param>
    /// <param name="bait">the Option's bait Changes</param>
    /// <param name="book">the Option's book Changes</param>
    /// <param name="fish">the Option's fish changes</param>
    public void AddOption(int sanity, int nourishment, int bait, int book, int fish) {
        var newOption = new Option
        {
            sanity = sanity,
            nourishment = nourishment,
            bait = bait,
            book = book,
            fish = fish
        };
        Options.Add(newOption);
    }

    public override string ToString()
    {
        string output = cardName + "\n";
        foreach (var option in Options)
        {
            output += "Option: " + option.sanity + " Sanity, " + option.nourishment + " Nourishment, " + option.bait + " Bait, " + option.book + " Book, " + option.fish + " Fish\n";
        }
        return output;
    }



}
