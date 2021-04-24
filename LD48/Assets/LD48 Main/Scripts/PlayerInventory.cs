using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    Dictionary<Items, int> m_items;

    void AddItem(Items item)
    {
        if(m_items.ContainsKey(item))
        {
            m_items[item]++;
        }
        else
        {
            m_items.Add(item, 1);
        }
    }


    bool HasItem(Items item)
    {
        return m_items.ContainsKey(item) && m_items[item] > 0;
    }

    bool UseItem(Items item)
    {
        if (HasItem(item))
        {
            m_items[item]--;
            return true;
        }

        return false;
    }
}
