using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject airplane;
    [SerializeField] private GameObject camera;

    [SerializeField] private float delayBeforeCameraMove = 2f;
    [SerializeField] private float delayBeforeAirplaneControl = 1f;
    
    [SerializeField] private Animator animator;
    
    private bool isActive = true;

    public void StartButton()
    {
        if (isActive)
        {
            isActive = false;
            StartCoroutine(StartTransition());
        }
    }

    public IEnumerator StartTransition()
    {
        airplane.GetComponent<AirplaneController>().isStarted = true;
        
        animator.Play("A_TitleScreenFadeOut");

        // lerp menu trnasparency
        float time = 0;
        while (time < delayBeforeCameraMove)
        {
            time += Time.deltaTime;
            yield return null;
        };

        camera.GetComponent<ThirdPersonAirplaneCamera>().enabled = true;
        
        yield return new WaitForSeconds(delayBeforeAirplaneControl);

        airplane.GetComponent<AirplaneController>().canTurn = true;
    }

    public void ExitButton()
    {
        if (isActive)
        {
            Application.Quit();
        }
    }
}
