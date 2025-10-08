using System;
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    public event Action<ItemType> OnItemListChanged;
    public static event Action<Dictionary<ItemType, List<Item>>> OnItemsUpdated;

    public static Dictionary<ItemType, List<Item>> items { get; private set; }

    

    public Inventory()
    {
        items = new();

        foreach(ItemType type in Enum.GetValues(typeof(ItemType)))
        {
            items.Add(type, new());
        }
    }



    public void AddItem(Item item)
    {
        items[item.Type].Add(item);
        OnItemListChanged?.Invoke(item.Type);

        //Debug.Log($"Aded {item.Type} to the list, the list now contains {items[item.Type].Count}");

        OnItemsUpdated?.Invoke(items);
    }
    private void RemoveItem(ItemType type, Item item)
    {
        items[item.Type].Remove(item);
        OnItemListChanged?.Invoke(item.Type);
        
        OnItemsUpdated?.Invoke(items);
    }
    public void RemoveItemByType(ItemType type)
    {
        if (items[type].Count > 0)
        {
            items[type].RemoveAt(0);
            OnItemListChanged?.Invoke(type);
            
            OnItemsUpdated?.Invoke(items);
        }
        else
        {
            Debug.Log($"There aint no more items to remove of the type {type}");
        }
    }
    public List<Item> GetItems(ItemType type) => items[type];
    public Dictionary<ItemType, List<Item>> GetAllItems() => items;
    public Item GetKey()
    {
        if (items[ItemType.KeyItem].Count  > 0)
        {
            Item keyToReturn = items[ItemType.KeyItem][0];
            RemoveItem(ItemType.KeyItem, keyToReturn);
            return keyToReturn;
        }
        else
        {
            return null;
        }
    }
}
