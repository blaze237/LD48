using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void OnHover(bool m_hoverEnter);
    void OnInteract();
}
