using UnityEngine;

/// <summary>
/// This class is used to handle the main screen of Tegment SDK Sample, This will be used to decide whether to login or signup
/// </summary>
namespace Tegment.Unity.Samples
{
    public class SignInMenuUI : MonoBehaviour
    {
        public GameObject SignUpScreen;
        public GameObject SignInScreen;
        /// <summary>
        /// Signin Button
        /// </summary>
        public void GoToSignIn()
        {
            SignInScreen.SetActive(true);
            gameObject.SetActive(false);
        }
        /// <summary>
        /// Sign up button
        /// </summary>
        public void GoToSignUp()
        {
            SignUpScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
