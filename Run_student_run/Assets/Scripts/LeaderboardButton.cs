using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
