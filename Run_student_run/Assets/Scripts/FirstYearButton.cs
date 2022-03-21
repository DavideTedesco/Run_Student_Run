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
        SceneManager.LoadScene("Start_Scene");
    }

    public void GoToAuthors()
    {
        SceneManager.LoadScene("Authors");
    }

    public void GoToShare()
    {
        SceneManager.LoadScene("Share");
    }

    public void RetToShare(){
        SceneManager.LoadScene("Start_Scene");
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////
    //MOVEMENT INSIDE LEVELS
    public void GoToFirstLv()
    {
        SceneManager.LoadScene("1.1 Level");
    }

    public void GoToSecondLv()
    {
        SceneManager.LoadScene("1.2 Level");
    }

    public void GoToThirdLv()
    {
        SceneManager.LoadScene("1.3 Level");
    }

    public void GoToFourthLv()
    {
        SceneManager.LoadScene("1.4 Level");
    }

    public void GoToFifthLv()
    {
        SceneManager.LoadScene("1.5 Level");
    }
    public void GoToSixthLv()
    {
        SceneManager.LoadScene("1.6 Level");
    }

    public void GoToSeventhLv()
    {
        SceneManager.LoadScene("1.7 Level");
    }

    public void GoToEighthLv()
    {
        SceneManager.LoadScene("1.8 Level");
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////

}