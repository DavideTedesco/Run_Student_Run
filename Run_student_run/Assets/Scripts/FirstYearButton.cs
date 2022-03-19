using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstYearButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton()
    {
        SceneManager.LoadScene("FirstYear");
    }

    // Use it to return on the Engineering Bachelor
    public void RetEngBachelor()
    {
        SceneManager.LoadScene("AllYears");
    }

    //Use it to return on the start page
    public void RetStartPage()
    {
        SceneManager.LoadScene("1 - Start_Scene");
    }

    public void GoToAuthors()
    {
        SceneManager.LoadScene("Authors");
    }

    public void GoToShare()
    {
        SceneManager.LoadScene("Share");
    }

    public void RetToShare()
    {
        SceneManager.LoadScene("1 - Start_Scene");
    }
}