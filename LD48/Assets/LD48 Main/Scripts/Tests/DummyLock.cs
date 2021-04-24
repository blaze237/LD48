using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyLock : ILockedInteractable
{
    public override void UnlockFail()
    {
        Debug.Log("You dont have the key!");
    }

    public override void UnlockSuccess()
    {
        Debug.Log("You have the key");
    }

   
}
