using UnityEngine;

public class Fixed : MonoBehaviour
{
    public Texture image;

    public void Load()
    {
        Debug.Log($"Load: {transform.parent.name}");
        var mat = new Material(GetComponent<Renderer>().sharedMaterial);
        mat.mainTexture = image;
        GetComponent<Renderer>().sharedMaterial = mat;
    }

}
