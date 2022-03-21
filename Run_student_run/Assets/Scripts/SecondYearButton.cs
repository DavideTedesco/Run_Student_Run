using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondYearButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    // Use it to return on Engineering Bachelor
    public void RetEngBachelor()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////
    //MOVEMENT INSIDE LEVELS
    public void GoToFirstLv()
    {
        SceneManager.LoadScene("2.1 Level");
    }

    public void GoToSecondLv()
    {
        SceneManager.LoadScene("2.2 Level");
    }

    public void GoToThirdLv()
    {
        SceneManager.LoadScene("2.3 Level");
    }

    public void GoToFourthLv()
    {
        SceneManager.LoadScene("2.4 Level");
    }

    public void GoToFifthLv()
    {
        SceneManager.LoadScene("2.5 Level");
    }
    public void GoToSixthLv()
    {
        SceneManager.LoadScene("2.6 Level");
    }

    public void GoToSeventhLv()
    {
        SceneManager.LoadScene("2.7 Level");
    }

    public void GoToEighthLv()
    {
        SceneManager.LoadScene("2.8 Level");
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////
}
