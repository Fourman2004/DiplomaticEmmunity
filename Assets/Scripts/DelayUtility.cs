using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayUtility : MonoBehaviour 
{
    static Dictionary<float, WaitForSeconds> delayDictionary = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetDelay(float newTime)
    {
        if (delayDictionary.ContainsKey(newTime))
            return delayDictionary[newTime];
        else
        {
            delayDictionary.Add(newTime, new WaitForSeconds(newTime));
            return delayDictionary[newTime];
        }
    }

    public class Item { }

    public class ItemSlot
    {
        Item currentItem;
        int amount;
    }

    public class Container 
    { 
        Dictionary<Item, List<ItemSlot>> myContainer;  
        
        public bool HasItem(Item checkItem)
        {
            if (myContainer.ContainsKey(checkItem))
                return true;
            else
                return false;
        }
    }


}
