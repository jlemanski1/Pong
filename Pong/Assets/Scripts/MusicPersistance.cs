using UnityEngine;

public class MusicPersistance : MonoBehaviour {
	
    //  Preserve gameObject through Scenes
	private void Update () {
        DontDestroyOnLoad(gameObject);
	}
}
