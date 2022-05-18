using PlayFab;
using PlayFab.ClientModels;
//da commentare per build
//using PlayFab.PfEditor.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayFabController : MonoBehaviour
{
    public static PlayFabController PFC;

    private string userEmail;
    private string userPassword;
    private string username;
    public GameObject loginPanel, mainPage, loginPage;

    private void OnEnable()
    {
        if (PlayFabController.PFC == null)
            PlayFabController.PFC = this;
        else
        {
            if(PlayFabController.PFC != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);

    }
    //testing username: pippo32
    //testing pass: pippoPluto32
    //testing email: davide_hrd(at)hotmail.it

    public void Start()
    {

        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "6487C"; // Please change this value to your own titleId from PlayFab Game Manager
        }
        var request = new LoginWithCustomIDRequest { CustomId = "LoginRequest", CreateAccount = true };
        //var requestWithoutPrefs = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        //PlayFabClientAPI.LoginWithEmailAddress(requestWithoutPrefs, OnLoginSuccess, OnLoginFailure);
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        //Commentare l'if qui sotto per effettuare il login senza prefs
        /*if (PlayerPrefs.HasKey("EMAIL"))
        {
            userEmail = PlayerPrefs.GetString("EMAIL");
            userPassword = PlayerPrefs.GetString("PASSWORD");
            var requestWithPrefs = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
            PlayFabClientAPI.LoginWithEmailAddress(requestWithPrefs, OnLoginSuccess, OnLoginFailure);
        }
        //ANONYMOUS LOGIN
        //TODO*/
    }

    public void StartGame()
    {
        loginPage.SetActive(true);
        mainPage.SetActive(false);
    }

    #region Login
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        //loginPanel.SetActive(false);
        //SceneManager.LoadScene("MainScene");
        loginPage.SetActive(false);
        mainPage.SetActive(true);
        GetStats();

    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest { DisplayName = username},OnDisplayName, OnLoginFailure );
        //loginPanel.SetActive(false);
        //SceneManager.LoadScene("MainScene");
        GetStats();
        loginPage.SetActive(false);
        mainPage.SetActive(true);

    }

    void OnDisplayName(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log(result.DisplayName + " is your new display name!");
        }

    private void OnLoginFailure(PlayFabError error)
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email = userEmail, Password = userPassword, Username = username};
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    public void GetUserEmail(string emailIn)
    {
        userEmail = emailIn;

    }

    public void GetUserPassword(string passwordIn)
    {
        userPassword = passwordIn;
    }

    public void GetUsername(string usernameIn)
    {
        username = usernameIn;
    }

    public void onClickLogin()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

    #endregion Login

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
public  void StartCloudUpdatePlayerStats()
{
PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
{
FunctionName = "UpdatePlayerStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
FunctionParameter = new { PlayerLevel = playerLevel, GameLevel = gameLevel, PlayerHealth = playerHealth, BooksCounter = booksCounter, PlayerHighScore = playerHighScore}, // The parameter provided to your function
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
var requestLeaderBoard = new GetLeaderboardRequest { StartPosition = 0, StatisticName = "PlayerHighScore", MaxResultsCount = 20};
PlayFabClientAPI.GetLeaderboard(requestLeaderBoard, OnGetLeaderBoard, OnErrorLeaderBoard );
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

for (int i = listingContainer.childCount - 1; i>=0; i--)
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