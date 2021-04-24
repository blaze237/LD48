


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Note this only works for portals that exit with the same orientation as the entrance. 
public class PortalRenderCam : MonoBehaviour
{
    public Transform m_playerCam;
    public Transform m_portalA;
    public Transform m_portalB;

    private Vector3[] m_portalPositions = new Vector3[2];
    private int m_exitInd = 1;
    // Start is called before the first frame update
    void Start()
    {
        m_portalPositions[0] = m_portalA.position;
        m_portalPositions[1] = m_portalB.position;

        //By default the portal system will be set up with the camera looking out of portal B
        transform.position = m_portalPositions[m_exitInd];
    }

    // Update is called once per frame
    void Update()
    {

        float portalAngDelta = Quaternion.Angle(m_portalA.rotation, m_portalB.rotation);
        Quaternion portalRotDelta = Quaternion.AngleAxis(portalAngDelta, Vector3.up);

        //Exit portal is mirrored in the other dir
        Vector3 newFwd = portalRotDelta * m_playerCam.forward;
         newFwd.x *= -1;
         newFwd.z *= -1;
        transform.rotation = Quaternion.LookRotation(newFwd, Vector3.up);
    }

    public void SwitchDirectionality()
    {
        m_exitInd = m_exitInd == 0 ? 1 : 0;

        transform.position = m_portalPositions[m_exitInd];
    }
}
