using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRenderCam : MonoBehaviour
{
    public Transform m_playerCam;
    public Transform m_portalA;
    public Transform m_portalB;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffset = m_playerCam.position - m_portalB.position;
       // transform.position = m_portalA.position + playerOffset;

        float portalAngDelta = Quaternion.Angle(m_portalA.rotation, m_portalB.rotation);
        Quaternion portalRotDelta = Quaternion.AngleAxis(portalAngDelta, Vector3.up);

        Vector3 newFwd = portalRotDelta * m_playerCam.forward;
        newFwd.x *= -1;
        newFwd.z *= -1;
        transform.rotation = Quaternion.LookRotation(newFwd, Vector3.up);
        
    }
}
