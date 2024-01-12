using UnityEngine;

public class Fragile : MonoBehaviour
{
    public Texture image;
    public AudioClip audioClip;

    Renderer r;

    public void Load()
    {
        var mat = new Material(GetComponent<Renderer>().sharedMaterial);
        mat.mainTexture = image;
        GetComponent<Renderer>().sharedMaterial = mat;
        GetComponent<AudioSource>().clip = audioClip;
    }
    private void Start()
    {
        r = GetComponent<Renderer>();
    }

    private void OnCollisionEnter()
    {
        Debug.Log("Fragile Collision");
        r.enabled = false;
    }
}
