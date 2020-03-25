using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private void Awake()
    {
        instance = this;
    }

    public int inventorySpace = 5;
    Item[] slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = new Item[inventorySpace];
    }

    public void AddItem(Item item)
    {
        bool itemAdded = false;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = item;
                itemAdded = true;
                Debug.Log("Item added");
                break;
            }
        }

        if (!itemAdded)
        {
            Debug.Log("Inventory full");
        }
    }

    public void RemoveItem(int index)
    {
        slots[index] = null;
    }
}
