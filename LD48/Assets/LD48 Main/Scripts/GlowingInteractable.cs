using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGlowingInteractable : MonoBehaviour, IInteractable
{
    public void OnHover(bool m_hoverEnter)
    {
        //enable glow
    }

    public abstract void OnInteract();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
