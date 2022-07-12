using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;


 public class WelcomeScripts : MonoBehaviour
 {
     private void Start()
     {

     }

     private void Update()
     {

     }

     public void GoLogin()
     {
         SceneManager.LoadScene("Login");
     }

     public void GoRegister()
     {
         SceneManager.LoadScene("Register");
     }
 }
