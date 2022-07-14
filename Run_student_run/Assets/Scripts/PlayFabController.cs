    using PlayFab;
    using PlayFab.ClientModels;
    using System.Collections.Generic;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class PlayFabController : MonoBehaviour
    {
    //=====================================================================LOGIN

    #region Login
    [SerializeField] GameObject signUpTab, loginTab, startPanel, mainPage;

    public Text username, userEmail, userPassword, userEmailLogin, userPasswordLogin, errorSignUp, errorLogin;

    string encryptedPassword;

    public void SignUpTab() {
        signUpTab.SetActive(true);
        loginTab.SetActive(false);
        errorSignUp.text = "";
        errorLogin.text = "";

    }

    public void LoginTab()
    {
        signUpTab.SetActive(false);
        loginTab.SetActive(true);
        errorSignUp.text = "";
        errorLogin.text = "";
    }

    string Encrypt(string pass)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach(byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }

        return s.ToString();
    }

    public void SignUp()
    {
        var registerRequest = new RegisterPlayFabUserRequest
        {
            Email = userEmail.text,
            Password = Encrypt(userPassword.text),
            Username = username.text,
            DisplayName = username.text
        };

        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, RegisterSuccess, RegisterError);
    }

    public void RegisterSuccess(RegisterPlayFabUserResult result)
    {
        errorSignUp.text = "";
        errorLogin.text = "";
        StartGame();
    }

    public void RegisterError(PlayFabError error)
    {
        errorSignUp.text = error.GenerateErrorReport();

    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = userEmailLogin.text,
            Password = Encrypt(userPasswordLogin.text),
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, LoginSuccess, LoginError);
    }

    public void LoginSuccess(LoginResult result)
    {
        errorSignUp.text = "";
        errorLogin.text = "";
        StartGame();
    }

    public void LoginError(PlayFabError error)
    {
        errorLogin.text = error.GenerateErrorReport();
    }

    void StartGame()
    {
        //DontDestroyOnLoad(this.signUpTab);
        //DontDestroyOnLoad(this.loginTab);
        //DontDestroyOnLoad(this.startPanel);
        //DontDestroyOnLoad(this.mainPage);
        //DontDestroyOnLoad(this.username);
        //DontDestroyOnLoad(this.userEmail);
        //DontDestroyOnLoad(this.userEmailLogin);
        //DontDestroyOnLoad(this.userPasswordLogin);
        //DontDestroyOnLoad(this.leaderboardPanel);
        //DontDestroyOnLoad(this.listingContainer);
        //DontDestroyOnLoad(this.gameObject);
        startPanel.SetActive(false);
        mainPage.SetActive(true);
    }

    #endregion Login
    //===============================================================LEADERBOARD

    public int playerLevel;
    public int gameLevel;
    //downcast not possible for the StatisticUpdate, playerHealth must be an int
    public int playerHealth;
    public int booksCounter;
    public int playerHighScore;

    #region PlayerStats

    public void SetStats()
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            // request.Statistics is a list, so multiple StatisticUpdate objects can be defined if required.
            Statistics = new System.Collections.Generic.List<StatisticUpdate> {
                new StatisticUpdate { StatisticName = "PlayerLevel", Value = playerLevel },
                new StatisticUpdate { StatisticName = "GameLevel", Value = gameLevel },
                new StatisticUpdate { StatisticName = "PlayerHealth", Value = playerHealth },
                new StatisticUpdate { StatisticName = "BooksCounter", Value = booksCounter },
                new StatisticUpdate { StatisticName = "PlayerHighScore", Value = playerHighScore },

    }
        },
result => { Debug.Log("User statistics updated"); },
error => { Debug.LogError(error.GenerateErrorReport()); });
    }

    void GetStats()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetStats,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    void OnGetStats(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics)
        {
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);
            switch (eachStat.StatisticName)
            {
                case "PlayerLevel":
                    playerLevel = eachStat.Value;
                    break;
                case "GameLevel":
                    gameLevel = eachStat.Value;
                    break;
                case "PlayerHealth":
                    playerHealth = eachStat.Value;
                    break;
                case "BooksCounter":
                    booksCounter = eachStat.Value;
                    break;
                case "PlayerHighScore":
                    playerHighScore = eachStat.Value;
                    break;
            }
        }
    }

    // Build the request object and access the API
    public void StartCloudUpdatePlayerStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new { PlayerLevel = playerLevel, GameLevel = gameLevel, PlayerHealth = playerHealth, BooksCounter = booksCounter, PlayerHighScore = playerHighScore }, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudUpdateStats, OnErrorShared);
    }
    // OnCloudHelloWorld defined in the next code block

    private static void OnCloudUpdateStats(ExecuteCloudScriptResult result)
    {
        // CloudScript (Legacy) returns arbitrary results, so you have to evaluate them one step and one parameter at a time

        //da commentare per build TODO
        //Debug.Log(JsonWrapper.SerializeObject(result.FunctionResult));

        //JsonObject jsonResult = (JsonObject)result.FunctionResult;
        //object messageValue;
        //jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in CloudScript (Legacy)
        //Debug.Log((string)messageValue);
    }

    private static void OnErrorShared(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    #endregion PlayerStats

    public GameObject leaderboardPanel;
    public GameObject listingPrefab;
    public Transform listingContainer;

    #region LeaderBoard
    public void GetLeaderBoard()
    {
        var requestLeaderBoard = new GetLeaderboardRequest { StartPosition = 0, StatisticName = "PlayerHighScore", MaxResultsCount = 20 };
        PlayFabClientAPI.GetLeaderboard(requestLeaderBoard, OnGetLeaderBoard, OnErrorLeaderBoard);
    }

    public void OnGetLeaderBoard(GetLeaderboardResult result)
    {
        leaderboardPanel.SetActive(true);
        mainPage.SetActive(false);
        //Debug.Log(result.Leaderboard[0].StatValue);
        foreach (PlayerLeaderboardEntry player in result.Leaderboard)
        {
            GameObject tempListing = Instantiate(listingPrefab, listingContainer);
            LeaderboardListing LL = tempListing.GetComponent<LeaderboardListing>();
            LL.playerNameText.text = player.DisplayName;
            LL.playerScoreText.text = player.StatValue.ToString();
            Debug.Log(player.DisplayName + ": " + player.StatValue);
        }

    }

    public void CloseLeaderboardPanel()
    {

        leaderboardPanel.SetActive(false);
        mainPage.SetActive(true);

        for (int i = listingContainer.childCount - 1; i >= 0; i--)
        {
            Destroy(listingContainer.GetChild(i).gameObject);
        }
    }
    public void OnErrorLeaderBoard(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }
    #endregion LeaderBoard

}
