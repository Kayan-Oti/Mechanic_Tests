using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_TopDown : MonoBehaviour
{
    public void BackToMenu(){
        GameManager.Instance.LoadScene(SceneIndex.Menu);
    }
}
