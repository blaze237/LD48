using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    //We use a singleton for player as know there will only ever be one player present in any given scene for this game
    public static Player instance = null;
    public FirstPersonAIO m_controller;

    public GameObject interactPrompt;


    public PlayerInventory m_inventory { get; set; }

    int m_interactLayer;
    IInteractable m_hoveredInteractable = null;
    bool m_controlsClaimed = false;

    public void Awake()
    {
        m_inventory = new PlayerInventory();
        m_inventory.AddItem(Items.BlueKey);



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
        if (!m_controlsClaimed)
        {
            ScanForInteractables();
        }
    }

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_controlsClaimed)
        {
            ProcessInput();
        }
    }


    public void ClaimControls()
    {
        if (m_controlsClaimed)
        {
            Debug.LogError("Controls allready claimed");
        }
        m_controlsClaimed = true;

        m_controller.ControllerPause();
        //m_controller.enableCameraMovement = false;
        //m_controller.playerCanMove = false;

    }

    public void ReleaseControls()
    {
        m_controlsClaimed = false;

        m_controller.enableCameraMovement = true;
        m_controller.playerCanMove = true;

        //if (m_controller.controllerPauseState)
        {
            m_controller.ControllerPause();
        }
        //m_controller.enableCameraMovement = true;
        //m_controller.playerCanMove = true;
    }

    void ProcessInput()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(m_hoveredInteractable != null)
            {
                m_hoveredInteractable.OnInteract();
            }
        }
    }


    void ScanForInteractables()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3, m_interactLayer))
        {
            m_hoveredInteractable = hit.collider.GetComponent<IInteractable>();
            m_hoveredInteractable.OnHover(true);
            interactPrompt.SetActive(true);
        }
        else
        {
            if (m_hoveredInteractable != null)
            {
                m_hoveredInteractable.OnHover(false);
            }
            interactPrompt.SetActive(false);
            m_hoveredInteractable = null;

        }
    }


}
