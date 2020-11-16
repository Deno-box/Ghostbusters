using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    // テキストの種類
    private enum TextType
    {
        NEW_GAME = 0,   // 始めから
        CONTINUE = 1,   // 続きから
        OPTIONS = 2,    // 設定

        ALL_TYPE = 3,
    }

    // 画像位置補正X値
    private const float IMAGE_OFFSET_X = 145.0f;

    // テキスト
    [NamedArrayAttribute(new string[] { "New Game", "Continue", "Options" })]
    [SerializeField]
    Text[] texts = new Text[(int)TextType.ALL_TYPE];

    // 矢印画像
    [NamedArrayAttribute(new string[] { "Left Arrow", "Right Arrow" })]
    [SerializeField]
    Image[] arrowImage = new Image[2];

    // 選択中
    private int selecting = (int)TextType.NEW_GAME;

    // Start is called before the first frame update
    void Start()
    {
        // 初期座標格納用
        RectTransform temp = this.texts[(int)TextType.NEW_GAME].rectTransform;

        // 矢印画像初期座標設定
        this.arrowImage[0].rectTransform.position = new Vector3(temp.position.x + IMAGE_OFFSET_X, temp.position.y, temp.position.z);
        this.arrowImage[1].rectTransform.position = new Vector3(temp.position.x - IMAGE_OFFSET_X, temp.position.y, temp.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // ←キー（Aキー）を押下
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (this.selecting < (int)TextType.ALL_TYPE - 1)
            {
                this.selecting++;
            }
            ChangeArrowPos(this.selecting);
        }
        // →キー（Dキー）を押下
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (this.selecting > 0)
            {
                this.selecting--;
            }
            ChangeArrowPos(this.selecting);
        }

        // モード選択
        ChoiceMode();
    }

    // テキストの変更
    void ChangeArrowPos(int _selecting)
    {
        // 選択中のテキスト位置を取得
        RectTransform temp = this.texts[_selecting].rectTransform;

        // 画像座標設定
        this.arrowImage[0].rectTransform.position = new Vector3(temp.position.x + IMAGE_OFFSET_X, temp.position.y, temp.position.z);
        this.arrowImage[1].rectTransform.position = new Vector3(temp.position.x - IMAGE_OFFSET_X, temp.position.y, temp.position.z);
    }

    // モード選択
    void ChoiceMode()
    {
        //　Enterキー（SPACEキー）を押下
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            switch (this.selecting)
            {
                // ゲームスタート
                case (int)TextType.NEW_GAME:
                    // プレイシーンへ遷移
                    SceneManager.LoadScene(1);
                    break;
                // 続きから
                case (int)TextType.CONTINUE:
                    break;
                // オプション
                case (int)TextType.OPTIONS:
                    break;
            }
        }
    }
}
