using System.Collections;
using UnityEngine;

public class OnOff : MagicEye
{
    public Texture offImage;
    public Texture onImage;
    public float waitTime;

    public bool playAudio;
    public bool loopAudio;
    public bool muteAudio;

    public AudioClip audioClip;

    AudioSource aSrc;
    Material offMat;
    Material onMat;
    Coroutine opener;

    WaitForSeconds wait;
    void Start()
    {
        aSrc = GetComponent<AudioSource>();
        offMat = new Material(GetComponent<Renderer>().material);
        offMat.mainTexture = offImage;
        offMat.name = "MyOff";
        onMat = new Material(offMat);
        onMat.mainTexture = onImage;
        onMat.name = "MyOn";
        GetComponent<Renderer>().material = offMat;
        wait = new WaitForSeconds(waitTime);
    }

    public void Load()
    {
        var mat = new Material(GetComponent<Renderer>().sharedMaterial);
        mat.mainTexture = offImage;
        GetComponent<Renderer>().sharedMaterial = mat;
        GetComponent<AudioSource>().clip = audioClip;
    }

    internal override void Open()
    {
        Debug.Log($"{transform.parent.name} Open");
        base.Open();

        if (playAudio && !aSrc.isPlaying)
        {
            aSrc.loop = loopAudio;
            aSrc.Play();
        }

        opener = StartCoroutine(Opener());
    }


    internal override void Close()
    {
        base.Close();

        StopCoroutine(opener);

        if (aSrc.isPlaying)
        {
            if (muteAudio)
            {
                aSrc.Stop();
            }
            else
            {
                aSrc.loop = false;
            }
        }

        GetComponent<Renderer>().material = offMat;
    }

    IEnumerator Opener()
    {
        Debug.Log($"{transform.parent.name} Opener");
        yield return wait;

        //GetComponent<Renderer>().material = onMat;
        GetComponent<Renderer>().material.mainTexture = onImage;
        Debug.Log($"[{offMat}] [{GetComponent<Renderer>().material}]");
    }
}
