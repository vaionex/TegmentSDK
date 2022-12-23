using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInMenuUI : MonoBehaviour
{
   public GameObject SignUpScreen;
   public GameObject SignInScreen;
   public void GoToSignIn()
   {
        SignInScreen.SetActive(true);
        gameObject.SetActive(false);
   }
   public void GoToSignUp()

   {
        SignUpScreen.SetActive(true);
        gameObject.SetActive(false); 
   }
}
