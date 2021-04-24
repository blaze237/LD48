using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRenderManager : MonoBehaviour
{
    public Camera portalCam;
    public Renderer portalA;

    [System.Serializable]
    public class PortalSystem
    {
        public Camera m_cam;
        public Renderer portalA;
        public Renderer portalB;

    }
    public PortalSystem[] portalSystems;



    // Start is called before the first frame update
    void Start()
    {
        foreach (var portalSystem in portalSystems)
        {
            if (portalSystem.m_cam != null)
            {
                portalSystem.m_cam.targetTexture.Release();
            }


            portalSystem.m_cam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            portalSystem.portalA.material.mainTexture = portalSystem.m_cam.targetTexture;
            portalSystem.portalB.material.mainTexture = portalSystem.m_cam.targetTexture;
        }
    }
}
