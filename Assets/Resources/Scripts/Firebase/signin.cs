
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class signin : MonoBehaviour
{
    List<string> perms = new List<string>() { "public_profile", "email" };
    public Text statusText;
    public Text statusTextFB;
    public InputField inputField;

    public string webClientId = "300596356012-2nkohurv7jsibqc1sas6ts1d4d5uv4lc.apps.googleusercontent.com";

    private GoogleSignInConfiguration configuration;

    // Defer the configuration creation until Awake so the web Client ID
    // Can be set via the property inspector in the Editor.
    void Awake()
    {
        configuration = new GoogleSignInConfiguration
        {
            WebClientId = webClientId,
            RequestIdToken = true
        };
        
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
        
    }
    
    public void FBLogin()
    {
        MainMenuController.instance.notifkonek.SetActive(true);
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            statusTextFB.text = aToken.UserId;

            Firebase.Auth.Credential credential =
    Firebase.Auth.FacebookAuthProvider.GetCredential(aToken.TokenString);
            firedatabase.auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("SignInWithCredentialAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                    return;
                }
                if (task.IsCompleted)
                {
                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    LinkedAcc linkedAcc = new LinkedAcc("Facebook", newUser.Email, newUser.DisplayName, newUser.UserId);
                    firedatabase.instance.cekidexist("Facebook", newUser.UserId.ToString());
                }
                MainMenuController.instance.notifkonek.SetActive(false);

                //Debug.LogFormat("User signed in successfully: {0} ({1})",
                //    newUser.DisplayName, newUser.UserId);
                //FB.API("/me?fields=id,name,email", HttpMethod.GET, GetFacebookInfo, new Dictionary<string, string>() { });


            });

        }else
        FB.LogInWithReadPermissions(perms, AuthCallback);
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            statusTextFB.text = aToken.UserId;

            Firebase.Auth.Credential credential =
    Firebase.Auth.FacebookAuthProvider.GetCredential(aToken.TokenString);
            firedatabase.auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("SignInWithCredentialAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                    return;
                }
                if (task.IsCompleted)
                {
                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    LinkedAcc linkedAcc = new LinkedAcc("Facebook", newUser.Email, newUser.DisplayName, newUser.UserId);
                    firedatabase.instance.cekidexist("Facebook", newUser.UserId.ToString());
                }
                MainMenuController.instance.notifkonek.SetActive(false);

                //Debug.LogFormat("User signed in successfully: {0} ({1})",
                //    newUser.DisplayName, newUser.UserId);
                //FB.API("/me?fields=id,name,email", HttpMethod.GET, GetFacebookInfo, new Dictionary<string, string>() { });


            });            

        }
        else
        {
            Debug.Log("User cancelled login");
            statusTextFB.text = "User cancelled login";
            MainMenuController.instance.notifkonek.SetActive(false);
        }
    }

    public void GetFacebookInfo(IResult result)
    {
        if (result.Error == null)
        {
            Debug.Log(result.ResultDictionary["id"].ToString());
            Debug.Log(result.ResultDictionary["name"].ToString());
            Debug.Log(result.ResultDictionary["email"].ToString());

            
            
            //StartCoroutine(firedatabase.instance.WriteNewUser(inputField.text, linkedAcc));
        }
        else
        {
            Debug.Log(result.Error);
        }
    }

    public void OnSignIn()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
        AddStatusText("Calling SignIn");

        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(
          OnAuthenticationFinished);
    }

    public void OnSignOut(string tipeacc)
    {
        AddStatusText("Calling SignOut");
        if (tipeacc == "Google")
            GoogleSignIn.DefaultInstance.SignOut();
        else if (tipeacc == "Facebook")
        {
            Debug.Log("Keluar FB");
            FB.LogOut();
        }
    }

    public void OnDisconnect()
    {
        AddStatusText("Calling Disconnect");
        GoogleSignIn.DefaultInstance.Disconnect();
    }

    internal void OnAuthenticationFinished(Task<GoogleSignInUser> task)
    {
        if (task.IsFaulted)
        {
            using (IEnumerator<System.Exception> enumerator =
                    task.Exception.InnerExceptions.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    GoogleSignIn.SignInException error =
                            (GoogleSignIn.SignInException)enumerator.Current;
                    AddStatusText("Got Error: " + error.Status + " " + error.Message);
                }
                else
                {
                    AddStatusText("Got Unexpected Exception?!?" + task.Exception);
                }
            }
        }
        else if (task.IsCanceled)
        {
            AddStatusText("Canceled");
        }
        else
        {
            AddStatusText("Welcome: " + task.Result.DisplayName + "!");
        }
    }

    public void OnSignInSilently()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
        AddStatusText("Calling SignIn Silently");

        GoogleSignIn.DefaultInstance.SignInSilently()
              .ContinueWith(OnAuthenticationFinished);
    }


    public void OnGamesSignIn()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = true;
        GoogleSignIn.Configuration.RequestIdToken = false;

        AddStatusText("Calling Games SignIn");

        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(
          OnAuthenticationFinished);
    }
    
    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
            statusTextFB.text = "Failed to Initialize the Facebook SDK";
        }
    }
    

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    private List<string> messages = new List<string>();
    void AddStatusText(string text)
    {
        if (messages.Count == 5)
        {
            messages.RemoveAt(0);
        }
        messages.Add(text);
        string txt = "";
        foreach (string s in messages)
        {
            txt += "\n" + s;
        }
        statusText.text = txt;
    }
}

