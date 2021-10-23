using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject storyCanvas;
    public GameObject background;
    public GameObject optionsCanvas;
    public GameObject controlsCanvas;

    public void NextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Story()
    {
        menuCanvas.SetActive(false);
        background.SetActive(false);
        storyCanvas.SetActive(true);
    }

    public void OpenOptions()
    {
        menuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public void CloseOptions()
    {
        menuCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
    }

    public void OpenControls()
    {
        menuCanvas.SetActive(false);
        controlsCanvas.SetActive(true);
    }

    public void CloseControls()
    {
        menuCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
