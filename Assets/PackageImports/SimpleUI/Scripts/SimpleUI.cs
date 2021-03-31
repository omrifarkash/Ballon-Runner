using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleUI : MonoBehaviour 
{
    public static SimpleUI _instance;
    public static SimpleUI Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindObjectOfType(typeof(SimpleUI)) as SimpleUI;
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "SimpleUIObject";
                    _instance = container.AddComponent(typeof(SimpleUI)) as SimpleUI;
                }
            }

            return _instance;
        }
    }

    //Scales an object to given scale over given duration
    public void ScaleTo(GameObject obj, Vector3 endScale, float duration) 
    {
        StartCoroutine(ScaleObj(obj, endScale, duration));
    }

    //Loads given level after a delay
    public void LoadLevelDelay(string name, float duration)
    {
        StartCoroutine(Load(name, duration));
    }

    //Fades in an image over given duration
    public void FadeIn(Image img, float duration)
    {
        StartCoroutine(Fade(true, img, duration));
    }

    //Fades out an image over given duration
    public void FadeOut(Image img, float duration)
    {
        StartCoroutine(Fade(false, img, duration));
    }

    IEnumerator ScaleObj(GameObject obj, Vector3 endScale, float duration)
    {
        obj.SetActive(true);
        float progress = 0.0f;
        while(progress <= duration)
        {
            obj.transform.localScale = Vector3.Lerp(obj.transform.localScale, endScale, progress);
            progress += Time.deltaTime;
            yield return null;
        }
        obj.transform.localScale = endScale;
        if (obj.transform.localScale.x <= 0)
            obj.SetActive(false);
    }

    IEnumerator Fade(bool bIn, Image img, float duration)
    {
        float startTime = Time.time;
        float timePassed = 0.0f;
        Color endColor;

        if (bIn)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 1.0f); 
            endColor = new Color(img.color.r, img.color.g, img.color.b, 0.0f); 
        }
        else
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0.0f); 
            endColor = new Color(img.color.r, img.color.g, img.color.b, 1.0f); 
        }
            
        while (timePassed < duration)
        { 
            timePassed = Time.time - startTime;
            float nT = Mathf.Clamp(timePassed / duration, 0, 1);
            img.color = Color.Lerp(img.color, endColor, nT);
            yield return new WaitForFixedUpdate(); 
        } 
    }

    IEnumerator Load(string name, float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(name);
    }
}