using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestResultSceneController : MonoBehaviour
{
    Fadecontroller fadeController = null;
    float timer = 0.0f;
    float timerMax = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.fadeController = GameObject.Find("FadeCanvas").GetComponent<Fadecontroller>();

    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーを押す or 一定時間経過後タイトルに遷移する
        if(Input.GetKeyDown(KeyCode.Space))
            this.fadeController.fadeOutStart(0, 0, 0, 0, "TitleScene");

        this.timer += Time.deltaTime;
        if(this.timer >= this.timerMax)
            this.fadeController.fadeOutStart(0, 0, 0, 0, "TitleScene");
    }
}
