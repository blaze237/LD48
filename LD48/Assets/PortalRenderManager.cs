using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRenderManager : MonoBehaviour
{
    public Camera portalCam;
    public Material portalRenderMat;


    // Start is called before the first frame update
    void Start()
    {
        if(portalCam.targetTexture != null)
        {
            portalCam.targetTexture.Release();
        }

        portalCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        portalRenderMat.mainTexture = portalCam.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
