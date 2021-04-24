using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    //We use a singleton for player as know there will only ever be one player present in any given scene for this game
    public static Player instance = null;

    public GameObject interactPrompt;



    PlayerInventory m_inventory;

    int m_interactLayer;
    IInteractable m_hoveredInteractable = null;

    public void Awake()
    {

        //Check if instance already exists
        if (instance == null)
        {
            instance = this;
        }
        //Enforce singleton pattern in the case that a second instance of the player has been made
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        m_interactLayer = LayerMask.GetMask("Interactable"); 
    }


    void FixedUpdate()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3, m_interactLayer))
        {
            m_hoveredInteractable = hit.collider.GetComponent<IInteractable>();
            m_hoveredInteractable.OnHover();
            interactPrompt.SetActive(true);
        }
        else
        {
            m_hoveredInteractable = null;
            interactPrompt.SetActive(false);
        }
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
