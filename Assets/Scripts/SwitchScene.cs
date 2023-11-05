using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchTIme : MonoBehaviour
{
    // Update is called once per frame
    public Animator transition;

    public float transitionTime = 1f;

    public string levelToLoad;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TravelToPast();
        }
    }

    public void TravelToPast()
    {
        StartCoroutine(LoadLevel(levelToLoad));
    }

    IEnumerator LoadLevel(string level)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level);

    }
}
