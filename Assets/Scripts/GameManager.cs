using UnityEngine;
using UnityEngine.SceneManagement; //Need this to load scenes


public class GameManager : MonoBehaviour
{
    public static GameManager instnace;


    private void Awake()
    {
        if (instnace)
        {
            Destroy(gameObject);
        }
        else
        {
            instnace = this; //This is now new game manager
            DontDestroyOnLoad(gameObject); //Don't destroy on load and pass in this script as an argument.
        }
    }


    public static void LoadScene(string newSceneName) // call to load a new scene    HUH making them into static lets it know they belong to the manager class- so even when one is destroyed they carry on their legacy.
    {
      SceneManager.LoadScene(newSceneName);
    }


    public static void Quit() // call to quit the game
    {
        Application.Quit(); //huh that is all theres to it.
    }
}
