                using PlayFab;
                using PlayFab.ClientModels;
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
                        //loginPanel.SetActive(false);
                        //SceneManager.LoadScene("MainScene");
                        loginPage.SetActive(false);
                        mainPage.SetActive(true);
                        GetStats();

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
                    public float playerHealth;
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
                                //downcast for the StatisticUpdate maybe not correct TODO
                                new StatisticUpdate { StatisticName = "PlayerHealth", Value = (int)playerHealth },
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
        #endregion PlayerStats
    }