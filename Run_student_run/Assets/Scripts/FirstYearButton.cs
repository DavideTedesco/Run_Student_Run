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
        SceneManager.LoadScene("MainScene");
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
    public void GoToFirstYear()
    {
        SceneManager.LoadScene("FirstYear");
    }

    //First Year
    public void GoToFirstFirstLv()
    {
        SceneManager.LoadScene("1.1 Level");
    }

    public void GoToFirstSecondLv()
    {
        SceneManager.LoadScene("1.2 Level");
    }

    public void GoToFirstThirdLv()
    {
        SceneManager.LoadScene("1.3 Level");
    }

    public void GoToFirstFourthLv()
    {
        SceneManager.LoadScene("1.4 Level");
    }

    public void GoToFirstFifthLv()
    {
        SceneManager.LoadScene("1.5 Level");
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////

}