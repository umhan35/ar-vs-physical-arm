using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVisibility : MonoBehaviour
{
    Renderer ballRenderer;

    Material originalMaterial;
    public Material invisibleMaterial;
    public GameObject shadowObject;

    // Start is called before the first frame update
    void Start()
    {
        // set ballRenderer & original material
        Transform[] ts = transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in ts)
        {
            if (t.gameObject.name.StartsWith("vis"))
            {
                ballRenderer = t.GetComponent<Renderer>();
                originalMaterial = ballRenderer.material;
            }
        }

        gameObject.SetActive(false);
        shadowObject.SetActive(false);
    }

    public void SetVisible(bool visibility)
    {
        if (!this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
        }

        if (visibility)
        {
            ballRenderer.material = originalMaterial;
        }
        else
        {
            ballRenderer.material = invisibleMaterial;
        }

        shadowObject.SetActive(visibility);
    }
}
