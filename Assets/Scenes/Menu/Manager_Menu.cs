using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Manager_Menu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _creditsButton;
    [SerializeField] private GameObject _settingsFirstButton;

    [Header("Containers")]
    [SerializeField] private GameObject _settingsContainer;


    private void OnEnable() {
        Manager_Event.GameManager.OnLoadedScene.Get().AddListener(OnLoadScene);
    }

    private void OnDisable() {
        Manager_Event.GameManager.OnLoadedScene.Get().AddListener(OnLoadScene);
    }

    private void Start(){
        EventSystem.current.SetSelectedGameObject(_playButton);
    }

    #region Scene Management
    private void OnLoadScene() {
        //Play Song Menu
        AudioManager.Instance.InitializeMusic(FMODEvents.Instance.MenuMusic, MusicIntensity.Intensity3);
        _settingsContainer.SetActive(false);
    }

    private void LeavingMenu(){
        //Stop Song
        AudioManager.Instance.StopMusic();
    }

    #endregion

    #region Onclick

    public void OnClick_Play(){
        LeavingMenu();
        GameManager.Instance.LoadScene(SceneIndex.TopDown);
    }

    //--Menu Settings
    public void OnClick_Settings(){
        _settingsContainer.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_settingsFirstButton);
    }

    public void OnClick_SettingsClose(){
        _settingsContainer.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_settingsButton);
    }

    //--Menu Exit
    public void OnClick_Exit(){
        Application.Quit();
    }

    #endregion
}
