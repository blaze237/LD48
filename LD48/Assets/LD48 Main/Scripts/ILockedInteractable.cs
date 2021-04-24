using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ILockedInteractable : IGlowingInteractable
{
    public Items m_keyType;

    public abstract void UnlockSuccess();
    public abstract void UnlockFail();


    public override void OnInteract()
    {
        if(Player.instance.m_inventory.HasItem(m_keyType))
        {
            UnlockSuccess();
        }
        else
        {
            UnlockFail();
        }
    }


}
