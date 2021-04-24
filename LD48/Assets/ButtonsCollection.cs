using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsCollection : MonoBehaviour
{
   public void EnableButtons()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Collider>().enabled = true;
        }
    }


    public void DisableButtons()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Collider>().enabled = false;
        }
    }
}
