using System.Collections;
using UnityEngine;

public class Shy : MagicEye
{
    public float shrinkTime = 3;
    public float waitTime = 1;

    public Texture shyImage;
    public Texture shrinkImage;

    public bool playAudio;

    public AudioClip audioClip;

    AudioSource aSrc;

    Material main;

    WaitForSeconds wait;

    bool isShrinking;

    public void Load()
    {
        var mat = new Material(GetComponent<Renderer>().sharedMaterial);
        mat.mainTexture = shyImage;
        GetComponent<Renderer>().sharedMaterial = mat;
        GetComponent<AudioSource>().clip = audioClip;
    }

    private void Start()
    {
        aSrc = GetComponent<AudioSource>();
        GetComponent<Renderer>().material.mainTexture = shyImage;
        wait = new WaitForSeconds(waitTime);
        isShrinking = false;
    }

    internal override void Open()
    {
        if (isShrinking) return;

        isShrinking = true;

        base.Open();

        StartCoroutine(Shrink());
    }

    IEnumerator Shrink()
    {
        yield return wait;

        GetComponent<Renderer>().material.mainTexture = shrinkImage;

        if (playAudio)
        {
            aSrc.Play();
        }

        Vector3 scale = transform.localScale;
        float timeLeft = shrinkTime;

        while (timeLeft > 0)
        {
            timeLeft = timeLeft - Time.deltaTime;

            timeLeft = timeLeft > 0 ? timeLeft : 0;

            transform.localScale = (timeLeft / shrinkTime) * scale;

            yield return null;
        }
    }
}
