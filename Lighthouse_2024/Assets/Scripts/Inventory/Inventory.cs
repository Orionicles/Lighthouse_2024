using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Singleton allows us to refer to this script very quickly
    // by calling 'Inventory.instance'
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion

    // delegate funcion that gets called any time inventory changes
    // This is useful for managing the inventory UI
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 8;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough space in inventory, max is " + space);
                return false;
            }

                items.Add(item);
            
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    { 
        items.Remove(item);

        if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
    }

    // Start is called before the first frame update
    private Canvas CanvasObject; // Assign in inspector
    void Start()
    {
        //CanvasObject = GetComponent<Canvas>();
        //CanvasObject.enabled = false;
    }

}
