using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 2f;
    [SerializeField] private CanvasGroup blackScreenUIElement;
    [SerializeField] private CanvasGroup EndTextUIElement;

    public void Die(GameObject airplane)
    {
        Destroy(airplane);
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {

        float time = 0;
        float startValueAlphaScreen = blackScreenUIElement.alpha;

        float halftDuration = fadeDuration / 2;

        while (time < halftDuration)
        {
            blackScreenUIElement.alpha = Mathf.Lerp(startValueAlphaScreen, 1, time / halftDuration);

            time += Time.deltaTime;
            yield return null;
        }
        blackScreenUIElement.alpha = 1;

        time = 0;
        float startValueAlphaText = EndTextUIElement.alpha;
        while (time < halftDuration)
        {
            EndTextUIElement.alpha = Mathf.Lerp(startValueAlphaText, 1, time / halftDuration);

            time += Time.deltaTime;
            yield return null;
        }
        EndTextUIElement.alpha = 1;

        SceneManager.LoadScene("guill");
    }
}
