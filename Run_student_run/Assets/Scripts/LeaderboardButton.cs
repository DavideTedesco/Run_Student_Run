using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardButton : MonoBehaviour
{
    public GameObject leaderboardPanel;

    // Start is called before the first frame update
    public void GoToLeaderboard()
    {
        leaderboardPanel.SetActive(true);
    }
}
