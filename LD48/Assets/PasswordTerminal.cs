using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PasswordTerminal : IGlowingInteractable
{
    public int maxInput = 10;

    public string m_password;
    public Text m_textOutput;

    bool m_active = false;


    public void OnPasswordCorrect()
    {
        //Default does nothing
        Debug.Log("Correct pw!");
        Player.instance.ReleaseControls();
    }

    public void OnPasswordIncorrect()
    {
        //Default does nothing
        Debug.Log("wrong pw!");
    }
   
    public override void OnInteract()
    {
        Player.instance.ClaimControls();
        m_active = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        if(m_password.Length > maxInput)
        {
            Debug.LogError("Unwriteable password!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_active)
        {
            PollInput();
        }
    }

    void PollInput()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Player.instance.ReleaseControls();
            m_active = false;
            return;
        }

        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (m_textOutput.text.Length != 0)
                {
                    m_textOutput.text = m_textOutput.text.Substring(0, m_textOutput.text.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                CheckPassword();
            }
            else if(m_textOutput.text.Length < maxInput)
            {
                m_textOutput.text += c;
            }
        }
    }


    void CheckPassword()
    {
        if(m_password.Equals(m_textOutput.text))
        {
            OnPasswordCorrect();
        }
        else
        {
            m_textOutput.text = "";
            OnPasswordIncorrect();       
        }
    }
   
}
