using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ResourceHandler
{
    public enum ResourceType {
        Sanity,
        Nourishment,
        Bait,
        Book,
        Fish
    }

    public static List<ResourceType> consumables { get; private set;}
    public static int SanityMeter {get; private set;}
    public static int NourishmentMeter {get; private set;}

    private static int MeterMax = 5;
    private static int MeterStart = 3;
    private static int ConsumableMax = 5;


    static void Start() {
        SanityMeter = MeterStart;
        NourishmentMeter = MeterStart;
        consumables = new(ConsumableMax);
    }

    /// <summary>
    /// Adds a given amount of a resource to a player's inventory.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="quantity">The number of resources to add (or subtract if negative)</param>
    public static void AddResource(ResourceType type, int quantity) {
        switch (type) 
        {
            case ResourceType.Sanity:
                if (SanityMeter < MeterMax - quantity) 
                    SanityMeter += quantity;
                else if (SanityMeter < MeterMax && quantity > 0)
                    SanityMeter = MeterMax; 
                break;
            case ResourceType.Nourishment:
                if (NourishmentMeter < MeterMax - quantity) 
                    NourishmentMeter += quantity;
                else if (NourishmentMeter < MeterMax && quantity > 0)
                    NourishmentMeter = MeterMax; 
                break;
            default:
                if(quantity > 0) 
                {
                    for(int i = 0; i < quantity; i++) {
                        if (consumables.Count >= ConsumableMax) 
                        {
                            Debug.Log("Consumables are too full");
                            //Prompt for consumable change
                        }
                        else 
                        {
                            consumables.Add(type);
                        }
                    }
                }
                if (quantity < 0) 
                {
                    quantity = Math.Abs(quantity);
                    for(int i = 0; i < quantity; i++) {
                        if (!consumables.Contains(type)) 
                        {
                            Debug.Log("Don't Have Enough Resources");
                            //Prompt for option change
                        }
                        else 
                        {
                            consumables.Remove(type);
                        }
                    }
                }
                break;
        }
        if(SanityMeter < 1 || NourishmentMeter < 1) {
            Debug.Log("You Lose");
            //Prompt Loss State
        }

    }

    /// <summary>
    /// Decreases the amount of one consumable, and increases the amount of another. Throws an error if the removed Resource isn't contained in the consumables.
    /// </summary>
    /// <param name="increased"></param>
    /// <param name="decreased"></param>
    public static void ChangeResource(ResourceType increased, ResourceType decreased) {
        if (!consumables.Remove(decreased)) 
        {
            Debug.LogError("Not enough of Resource type to change");
            return;
        }
        consumables.Add(increased);

    }





}
