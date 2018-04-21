using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

    public string sceneToLoad;      // Name of next scene

    public int sceneLoadDelay;      // In seconds

    public Text countdownText;
    private float countdown;

    // Call OpenNextScene() after the set delay
	private void Awake () {
        Invoke("OpenNextScene", sceneLoadDelay);
        countdown = sceneLoadDelay;
        countdownText = GameObject.Find("Countdown").GetComponent<Text>();      // Get Countdown text
	}
	
	// Transitions to the next scene
	private void OpenNextScene () {
        SceneManager.LoadScene(sceneToLoad);
	}

    // Update menu UI with load countdown
    private void Update() {
        // While Scene is still delaying load
        for (int i = 0; i < sceneLoadDelay; i++) {
            countdown -= Time.deltaTime / 10;
            countdownText.text = Mathf.RoundToInt(countdown).ToString();
            
        }
    }
}
