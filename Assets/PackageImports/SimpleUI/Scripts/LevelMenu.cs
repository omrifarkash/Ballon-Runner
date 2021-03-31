using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour {

    public GameObject[] LevelButtons;
    public Image FadeScreen;

	//Going to call "SetUnlockedLevels" in start to show the Lock overlay for levels we have not gone to yet!
	void Start () 
	{
		SetUnlockedLevels ();
	}

	//Checks the PlayerPref being passed in when the button is clicked to see if we unlocked the level
	//If the level is unlocked we will load the scene with that name
	//NOTE: These scene load will only work if there is a scene named that in the "Scenes In Build"
	public void LoadScene(string name)
	{
        SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
		
	//Turns off the Lock overlay for all unlocked levels!
	//We're setting Level1 to unlocked so we have a level to play!
	private void SetUnlockedLevels()
	{
        Time.timeScale = 1f;

		//Set Level1 to unlocked
		PlayerPrefs.SetInt ("Level1", 1);
        for (int i = 0; i < LevelButtons.Length; i++) 
        {
			if(PlayerPrefs.GetInt("Level"+(i+1)) == 1)
            {
				LevelButtons[i].transform.Find("Lock").gameObject.SetActive (false);
			}
		}
	}
}