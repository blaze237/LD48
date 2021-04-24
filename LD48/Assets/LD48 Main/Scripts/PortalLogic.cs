using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Note this only works for portals that exit with the same orientation as the entrance. 
public class PortalLogic : MonoBehaviour
{
    public Transform m_playerRoot;
    public Transform m_player;
    public Transform m_oppositePortal;
    public PortalRenderCam m_camera;

    FirstPersonAIO player;

    private bool m_playerOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if(m_playerOverlapping)
        {
            //Have we walked through the portal
            Vector3 dir2portal = m_player.position - transform.position;
            float dotProd = Vector3.Dot(transform.up, dir2portal);
            if (dotProd < 0.0f)
            {
                float angleDelta = -Quaternion.Angle(transform.rotation, m_oppositePortal.rotation);
                angleDelta += 180;
                m_playerRoot.Rotate(Vector3.up, angleDelta);
        
                Vector3 posOffset = Quaternion.Euler(0, angleDelta, 0) * dir2portal;
                Vector3 newPos = m_oppositePortal.position + posOffset;
                m_player.position = new Vector3(newPos.x, m_player.position.y, newPos.z);

                m_camera.SwitchDirectionality();
                m_playerOverlapping = false;
                
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
          
            m_playerOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            m_playerOverlapping = false;
        }
    }
}
