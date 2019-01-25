using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoTypingTextScript : MonoBehaviour {

    public Text textToDisplay; //Display the text
    public string theText = "Enter Text Here";
    public float minPause = 0.01f; //The higher the values the slower...
    public float maxPause = 0.1f; //...the typing will be
    public float fullStopPauseTime = 1f; //How long should we pause after a full stop?
    public float startDelay = 1f; //Add a start delay?
    public bool playSound = true; //Play a sound or silent?
    public AudioSource letterSound;
    public float minPitch = 1f; //Pitch of the...
    public float maxPitch = 1f; //...audiosource
    
    private float pauseTime;
	public AudioClip[] clips;

    private int levelId;
    void Start() {
        Time.timeScale = 0.0f;
        StartCoroutine("TypeText");
    }

    IEnumerator TypeText() {
        if(startDelay > 0) {
            yield return new WaitForSecondsRealtime(startDelay);
        }
        foreach (char letter in theText.ToCharArray()) {
			textToDisplay.text += letter;
            if(playSound) { 
                letterSound.pitch = Random.Range(minPitch, maxPitch);
				if(clips.Length==1)
					letterSound.clip = clips [0];
				else
					letterSound.clip = clips [Random.Range (0, clips.Length)];
				
				letterSound.Play();
				yield return 0;
            }
            if(letter.ToString() == ".") { 
                pauseTime = Random.Range(minPause, maxPause)+fullStopPauseTime;
            } else {
                pauseTime = Random.Range(minPause, maxPause);
            }
			yield return new WaitForSecondsRealtime (pauseTime);
		}      
        Time.timeScale = 1.0f;

    }

}
