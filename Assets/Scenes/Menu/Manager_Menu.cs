using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Menu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject _settingsButton;

    private void OnEnable() {
        Manager_Event.GameManager.OnLoadedScene.Get().AddListener(OnLoadScene);
    }

    private void OnDisable() {
        Manager_Event.GameManager.OnLoadedScene.Get().AddListener(OnLoadScene);
    }

    private void OnLoadScene() {
        //Play Song Menu
        AudioManager.Instance.InitializeMusic(FMODEvents.Instance.MenuMusic, MusicIntensity.Intensity3);
    }

    private void LeavingMenu(){
        //Stop Song
        AudioManager.Instance.StopMusic();
    }

    #region Onclick

    public void OnClick_Play(){
        LeavingMenu();
        GameManager.Instance.LoadScene(SceneIndex.TopDown);
    }

    //--Menu Settings
    public void OnClick_Settings(){
        _settingsButton.SetActive(true);
    }

    public void OnClick_SettingsClose(){
        _settingsButton.SetActive(false);
    }

    //--Menu Exit
    public void OnClick_Exit(){
        Application.Quit();
    }

    #endregion
}
