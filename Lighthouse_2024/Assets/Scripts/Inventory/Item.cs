using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    // https://youtu.be/HQNl3Ff2Lpo?list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7
    new public string name = "New Item"; // new means overriding old definition that it has by default
    public Sprite icon = null;
    public bool isDefaultItem = false;

	// string used to uniquely identify this item
	// should always be in snake case
	public string id;

    public virtual void Use()
    {
        // Use the item
        // Something might happen

        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
