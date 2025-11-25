using UnityEngine;

public class Swap_Xray : MonoBehaviour
{
    [SerializeField] private bool xray = false;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material materialNormal, xrayMaterial;

    public void SwapXray()
    {
        if (xray) //if Xray is currently enabled
        {
            //Turn it off
            xray = false;
            meshRenderer.material = materialNormal;
        }
        else //else if Xray is not currently enabled
        {
            //Turn it on
            xray = true;
            meshRenderer.material = xrayMaterial;
        }
    }
}
