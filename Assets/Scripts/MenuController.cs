using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator transition;
    private void Start()
    {
        transition.gameObject.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void GoToScene(string sceneName)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadFade(sceneName));
    }

    IEnumerator LoadFade(string sceneName)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
