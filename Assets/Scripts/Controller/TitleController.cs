using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // イメージ補正X値
    private const float IMAGE_OFFSET_X = 145.0f;

    // テキスト
    [NamedArrayAttribute(new string[] { "New Game", "Continue", "Options" })]
    [SerializeField]
    Text[] texts = new Text[(int)TextType.ALL_TYPE];

    // 矢印画像
    [SerializeField]
    Image arrowImage = null;

    // 選択中
    private int selecting = (int)TextType.NEW_GAME;

    // Start is called before the first frame update
    void Start()
    {
        // 初期座標格納用
        RectTransform tmp = texts[(int)TextType.NEW_GAME].rectTransform;

        // 矢印画像初期座標設定
        arrowImage.rectTransform.position = new Vector3(tmp.position.x - IMAGE_OFFSET_X, tmp.position.y, tmp.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }
    }
}
