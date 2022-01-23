using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    // called when cover1 image is clicked
    public void Cover1Click()
    {
        // save book choice and load AR scene
        PlayerPrefs.SetInt("cover", 1);
        SceneManager.LoadScene(1);
    }

    // called when cover2 image is clicked
    public void Cover2Click()
    {
        // save book choice and load AR scene
        PlayerPrefs.SetInt("cover", 2);
        SceneManager.LoadScene(1);
    }

    // called when cover3 image is clicked
    public void Cover3Click()
    {
        // save book choice and load AR scene
        PlayerPrefs.SetInt("cover", 3);
        SceneManager.LoadScene(1);
    }

    // called when cover4 image is clicked
    public void Cover4Click()
    {
        // save book choice and load AR scene
        PlayerPrefs.SetInt("cover", 4);
        SceneManager.LoadScene(1);
    }

    // called when quit button is clicked
    public void QuitClick()
    {
        Application.Quit();
    }


    private void Update()
    {
        // if user pressed phone's back button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
