using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTexts : MonoBehaviour
{
    public Text wavetext;
    public Text waveChangeText;
    private int wave = 0;

    // Start is called before the first frame update
    void Start()
    {
        waveChangeText.text = wavetext.text = "Wave " + wave;
        Color waveChangeTextColor = waveChangeText.color;
        waveChangeText.color = new Color(waveChangeTextColor.r, waveChangeTextColor.g, waveChangeTextColor.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WaveChange(int newWave)
    {
        wave = newWave;
        FadeInText(1, waveChangeText);
        Invoke("FadeOutTextWaveChangeText", 1);
        waveChangeText.text = wavetext.text = "Wave " + wave;
    }
    public void FadeOutTextWaveChangeText()
    {
        FadeOutText(2, waveChangeText);
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
    private IEnumerator FadeOutTextRoutine(float time, Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }
}
