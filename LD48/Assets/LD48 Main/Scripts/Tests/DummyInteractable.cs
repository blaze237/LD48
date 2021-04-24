using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyInteractable : MonoBehaviour, IInteractable
{

    public void OnHover()
    {

    }

    public void OnInteract()
    {
        Debug.Log("You Just interacted!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
