using UnityEngine;
using UnityEngine.SceneManagement; //Need this to load scenes


public class GameManager : MonoBehaviour
{

    /*
    [Header("Preload Scenes")] //I dont feel like coding a whole addable list again, so the scenes will be hardcoded.
    [SerializeField] private string sceneToPreload = "Lobby";
    private AsyncOperation backgroundLoadOp;

    void Start()
    {
        // Starts the operation of loading data in a steady steam here
        StartCoroutine(PreloadSceneInBackground());
    }

    private System.Collections.IEnumerator PreloadSceneInBackground()
    {
        // Utilize a cpu thread to preload a scene
        backgroundLoadOp = SceneManager.LoadSceneAsync(sceneToPreload);

        // Prevents the scene to load for the user (or total failure if it does do that)
        backgroundLoadOp.allowSceneActivation = false;

        // Waiting for background to be finished
        while (!backgroundLoadOp.isDone)
        {
            // I didn't know you can get this deep into API, forcing unity to stop loading at 90% cool!
            if (backgroundLoadOp.progress >= 0.9f)
            {
                Debug.Log($"[GameManager] {sceneToPreload} in RAM");
                yield break; // Leave loop when finished
            }

            yield return null; // From here, waits for the next frame and checks progress
        }
    }

    // PUBLIC FUNCTION: Hook this up to your Quest Action List!
    public void ActivatePreloadedScene()
    {
        if (backgroundLoadOp != null)
        {
            Debug.Log("[GameManager] Throwing the switch! Swapping scenes instantly.");
            backgroundLoadOp.allowSceneActivation = true; // Unlock the door!
        }
        else
        {
            // Emergency fallback: If the player somehow triggered this before it loaded
            SceneManager.LoadScene(sceneToPreload);
        }
    }

    Above code is for future optimization later.
    */ 

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
