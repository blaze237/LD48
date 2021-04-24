using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinButton : MonoBehaviour
{
    public enum PinButtonID
    {
        Zero,
        One, 
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Delete,
        OK
    }

    public PinButtonID m_button;

    public void OnHover(bool hoverEnter)
    {
        //Glow
    }

 
}
