using UnityEngine;

public class Plane : MonoBehaviour
{
    public Texture image;

    public void Load()
    {
        var mat = new Material(GetComponent<Renderer>().sharedMaterial);
        mat.mainTexture = image;
        GetComponent<Renderer>().sharedMaterial = mat;
    }

}
