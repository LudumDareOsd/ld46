using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTexts : MonoBehaviour
{
    //public Text wavetext;
    public Sprite[] NumberSprites;
    private Sprite FirstNumberSprite;
    private Sprite SecondNumberSprite;
    public Image UpperLeftWaveFirstNumber;
    public Image UpperLeftWaveSecondNumber;
    public Image CenterWaveTextImage;
    public Image CenterWaveFirstNumber;
    public Image CentertWaveSecondNumber;
    private int wave = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WaveChange(int newWave)
    {
        wave = newWave;
        var  wavenumbers = wave.ToString().ToCharArray();
        UpperLeftWaveFirstNumber.sprite = FirstNumberSprite = NumberSprites[Int32.Parse(wavenumbers[0].ToString())];
        UpperLeftWaveFirstNumber.color = new Color(255f, 255f, 255f, 1f);
        if (wavenumbers.Length == 2)
        {
            UpperLeftWaveSecondNumber.sprite = SecondNumberSprite = NumberSprites[Int32.Parse(wavenumbers[1].ToString())];
            UpperLeftWaveSecondNumber.color = new Color(255f, 255f, 255f, 1f);
        }
        else
        {
            UpperLeftWaveSecondNumber.color = new Color(255f, 255f, 255f, 0f);
        }
		FadeInOutCenterImages();
    }
    public void FadeOutText(float time, Text text)
    {
        StartCoroutine(FadeOutTextRoutine(time, text));
    }
    public void FadeInText(float time, Text text)
    {
        StartCoroutine(FadeInTextRoutine(time, text));
    }
    public IEnumerator FadeInTextRoutine(float time, Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / time));
            yield return null;
        }
    }
    public void FadeInOutCenterImages()
    {
        CenterWaveFirstNumber.sprite = FirstNumberSprite;
        StartCoroutine(FadeInImageRoutine(1f, CenterWaveTextImage));
        StartCoroutine(FadeInImageRoutine(1f, CenterWaveFirstNumber));
        if (SecondNumberSprite != null)
        {
            CentertWaveSecondNumber.sprite = SecondNumberSprite;
            StartCoroutine(FadeInImageRoutine(1f, CentertWaveSecondNumber));
        }
        Invoke("FadeOutCenterImages", 1.5f);
    }
    public void FadeOutCenterImages()
    {
        StartCoroutine(FadeOutImageRoutine(1f, CenterWaveTextImage));
        StartCoroutine(FadeOutImageRoutine(1f, CenterWaveFirstNumber));
        if (SecondNumberSprite != null)
        {
            CentertWaveSecondNumber.sprite = SecondNumberSprite;
            StartCoroutine(FadeOutImageRoutine(1f, CentertWaveSecondNumber));
        }
    }
    private IEnumerator FadeOutTextRoutine(float time, Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }
    public IEnumerator FadeInImageRoutine(float time, Image iamge)
    {
        iamge.color = new Color(iamge.color.r, iamge.color.g, iamge.color.b, 0);
        while (iamge.color.a < 1.0f)
        {
            iamge.color = new Color(iamge.color.r, iamge.color.g, iamge.color.b, iamge.color.a + (Time.deltaTime / time));
            yield return null;
        }
    }
    private IEnumerator FadeOutImageRoutine(float time, Image image)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a > 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }
}
