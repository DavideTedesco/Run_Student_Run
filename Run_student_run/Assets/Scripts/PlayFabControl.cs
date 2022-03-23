using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabControl : MonoBehaviour
{
    [SerializeField] GameObject signUpTab, logInTab, startPanel, HUD;
    public Text username, userEmail, userPassword, userEmailLogin, userPasswordLogin, errorSignUp, errorLogin;
    string encryptedPassword;

    public void SwitchToSignUpTab()
    {
        signUpTab.SetActive(true);
        logInTab.SetActive(false);
    }

    public void SwitchToLoginTab()
    {
        signUpTab.SetActive(false);
        logInTab.SetActive(true);
    }

    
}
