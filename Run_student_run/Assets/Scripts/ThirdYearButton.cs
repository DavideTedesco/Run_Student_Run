using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdYearButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void RetEngBachelor()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////
    //MOVEMENT INSIDE LEVELS
    public void GoToFirstLv()
    {
        SceneManager.LoadScene("3.1 Level");
    }

    public void GoToSecondLv()
    {
        SceneManager.LoadScene("3.2 Level");
    }

    public void GoToThirdLv()
    {
        SceneManager.LoadScene("3.3 Level");
    }

    public void GoToFourthLv()
    {
        SceneManager.LoadScene("3.4 Level");
    }

    public void GoToFifthLv()
    {
        SceneManager.LoadScene("3.5 Level");
    }
    public void GoToSixthLv()
    {
        SceneManager.LoadScene("3.6 Level");
    }

    public void GoToSeventhLv()
    {
        SceneManager.LoadScene("3.7 Level");
    }

    public void GoToEighthLv()
    {
        SceneManager.LoadScene("3.8 Level");
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////

}
