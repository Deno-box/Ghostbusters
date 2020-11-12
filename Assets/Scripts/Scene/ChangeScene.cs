using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // スタートボタン押下
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    // タイトルへ戻るボタン押下
    public void OnBuckTitleButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
