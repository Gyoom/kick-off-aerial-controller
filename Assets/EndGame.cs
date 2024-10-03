using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 3f;
    [SerializeField] private Canvas canvas;

    public void Die(GameObject airplane)
    {
        Destroy(airplane);
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        /*CanvasRenderer CR = canvas.GetComponent<CanvasRenderer>();
        Image I = canvas.GetComponent<Image>();
        float time = 0;
        //float startValue = CR.a;


        //CR.SetAlpha(1);
        Color c = I.color;
        c.a = 255;

        Debug.Log(CR.GetAlpha());

        while (time < fadeDuration)
        {
            colorCanvas.a = Mathf.Lerp(startValue, 255, time / fadeDuration);

            time += Time.deltaTime;
            yield return null;
        }
        colorCanvas.a = 255;*/

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("guill");
    }
}
