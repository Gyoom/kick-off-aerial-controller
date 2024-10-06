using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 2f;
    [SerializeField] private CanvasGroup blackScreenUIElement;
    [SerializeField] private CanvasGroup endTextUIElement;
    [SerializeField] private ParticleSystem diePS;

    public void Die(GameObject airplane)
    {
        Instantiate(diePS, airplane.transform.position, Quaternion.identity);
        
        Destroy(airplane);
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {

        float time = 0;
        float startValueAlphaScreen = blackScreenUIElement.alpha;

        float halfDuration = fadeDuration / 2;

        while (time < halfDuration)
        {
            blackScreenUIElement.alpha = Mathf.Lerp(startValueAlphaScreen, 1, time / halfDuration);

            time += Time.deltaTime;
            yield return null;
        }
        blackScreenUIElement.alpha = 1;

        time = 0;
        float startValueAlphaText = endTextUIElement.alpha;
        while (time < halfDuration)
        {
            endTextUIElement.alpha = Mathf.Lerp(startValueAlphaText, 1, time / halfDuration);

            time += Time.deltaTime;
            yield return null;
        }
        endTextUIElement.alpha = 1;

        SceneManager.LoadScene("MZR");
    }
}
