using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject LevelSelectMenu;
	public GameObject SettingsMenu;
	public GameObject CreditsMenu;
    public GameObject ConfirmationMenu;
    public GameObject HomeButton;
    public Image FadeScreen;

    public void Awake()
    {
        //SimpleUI.Instance.FadeIn(FadeScreen, 1.5f);
    }

	public void PlayButtonPressed()
	{
        LevelSelectMenu.SetActive(true);
    }

	public void SettingsButtonPressed()
	{
        SettingsMenu.SetActive(true);
    }

	public void CreditsButtonPressed()
	{
        CreditsMenu.SetActive(true);
    }

	public void ExitButtonPressed()
	{
        ConfirmationMenu.SetActive(true);
    }

    public void BoxOutButtonPressed()
    {
        if (LevelSelectMenu.activeSelf)
            LevelSelectMenu.SetActive(false);
        if (SettingsMenu.activeSelf)
            SettingsMenu.SetActive(false);
        if (CreditsMenu.activeSelf)
            CreditsMenu.SetActive(false);
        if (ConfirmationMenu.activeSelf)
            ConfirmationMenu.SetActive(false);
    }

    public void HomeButtonPressed()
    {
        LevelSelectMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        ConfirmationMenu.SetActive(false);
    }
}
