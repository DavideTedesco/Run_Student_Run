using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayfabManager : MonoBehaviour
{
    #region new_register_and_login
    [Header("UI")]

    public string messageText;
    public SerializeField emailInput;
    public SerializeField passwordInput;

    public void registerButton()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.ToString(),
            Password = passwordInput.ToString(),
            RequireBothUsernameAndEmail = false

        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText = "Registered and logged in!";
    }

    void OnError(PlayFabError error)
    {
        messageText = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    #endregion new_register_and_login
}
