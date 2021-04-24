using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinTerminal : IGlowingInteractable
{
    private const int SIZE = 4;
    public int[] m_pinCode = new int[SIZE];
    public Text m_textOutput;
    public ButtonsCollection buttonsCollection;
    public Camera camera;

    bool m_active = true;
    int m_interactLayer;
    PinButton m_lastHover = null;

    void Start()
    {
        if (m_pinCode.Length != SIZE)
        {
            Debug.LogWarning("Don't change the m_pinCode array size!");
        }

        m_interactLayer = LayerMask.GetMask("Button");

    }


    int[] m_input = new int[4];
    int m_inputPtr = 0;


    public void ValidatePin()
    {
        bool pinOk = true;
        for(int i = 0; i < SIZE; ++i)
        {
            if(m_pinCode[i] != m_input[i] )
            {
                pinOk = false;
                break;
            }
        }


        if(pinOk)
        {
            OnPinOK();
        }
        else
        {
            OnPinFail();
        }
    }


    public void OnPinFail()
    {
        Debug.Log("Wrong pin");
    }

    public void OnPinOK()
    {
        Debug.Log("Correct pin");
        OnDeactivate();

    }


   

    public void OnClickOK()
    {
        if(!m_active)
        {
            return;
        }
        if (m_inputPtr == 4)
        {
            ValidatePin();
            m_inputPtr = 0;
            m_textOutput.text = "";
        }
        else
        {
            OnPinFail();
            m_inputPtr = 0;
            m_textOutput.text = "";
        }
    }

   public void OnClickDelete()
   {
        if (!m_active)
        {
            return;
        }
        if (m_inputPtr > 0)
        {
            m_inputPtr--;
            m_textOutput.text = m_textOutput.text.Substring(0, m_textOutput.text.Length - 1);

        }
    }

   public void OnClickNumImpl(int i)
   {
        if (!m_active)
        {
            return;
        }

        if (m_inputPtr < SIZE)
        {
            m_input[m_inputPtr++] = i;

            m_textOutput.text += i;
        }
    }

    public override void OnInteract()
    {
        Player.instance.ClaimControls();
        m_active = true;
        buttonsCollection.EnableButtons();
    }


    void OnDeactivate()
    {
        m_active = false;
        buttonsCollection.DisableButtons();
        Player.instance.ReleaseControls();

    }

    void Update()
    {
        if(!m_active)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Escape) && m_active )
        {
            OnDeactivate();
            return;
        }

        //raycast for buttons


        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 5000))
            {
                PinButton button = hit.collider.GetComponent<PinButton>();

                if (m_lastHover != button && m_lastHover != null)
                {
                    m_lastHover.OnHover(false);
                }

                button.OnHover(true);
                m_lastHover = button;

                switch (button.m_button)
                {
                    case PinButton.PinButtonID.Zero:
                        OnClickNumImpl(0);
                        break;
                    case PinButton.PinButtonID.One:
                        OnClickNumImpl(1);
                        break;
                    case PinButton.PinButtonID.Two:
                        OnClickNumImpl(2);
                        break;
                    case PinButton.PinButtonID.Three:
                        OnClickNumImpl(3);
                        break;
                    case PinButton.PinButtonID.Four:
                        OnClickNumImpl(4);
                        break;
                    case PinButton.PinButtonID.Five:
                        OnClickNumImpl(5);
                        break;
                    case PinButton.PinButtonID.Six:
                        OnClickNumImpl(6);
                        break;
                    case PinButton.PinButtonID.Seven:
                        OnClickNumImpl(7);
                        break;
                    case PinButton.PinButtonID.Eight:
                        OnClickNumImpl(8);
                        break;
                    case PinButton.PinButtonID.Nine:
                        OnClickNumImpl(9);
                        break;
                    case PinButton.PinButtonID.Delete:
                        OnClickDelete();
                        break;
                    case PinButton.PinButtonID.OK:
                        OnClickOK();
                        break;
                }
            }

        }


       
    }
}
