using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InputSystemDemo : MonoBehaviour
{
    [SerializeField]Text stickLLabel;   // 表示用UI-TEXTオブジェクト
    [SerializeField] Text buttonLabel;  // 表示用UI-TEXTオブジェクト
    string stickL_text;
    string button_text;

    InputAction stickL;					// アクションマップ【F310_LStick】を取得
    InputAction buttonA;				// アクションマップ【F310_A】を取得
    InputAction buttonB;				// アクションマップ【F310_B】を取得
    InputAction buttonX;				// アクションマップ【F310_X】を取得
    InputAction buttonY;				// アクションマップ【F310_Y】を取得
    InputAction buttonUP;				// アクションマップ【F310_UP】を取得
    InputAction buttonDOWN;				// アクションマップ【F310_DOWN】を取得
    InputAction buttonLEFT;				// アクションマップ【F310_LEFT】を取得
    InputAction buttonRIGHT;			// アクションマップ【F310_RIGHT】を取得

    void Start()
    {
        // アクションマップを取得
        stickL = InputSystem.actions.FindAction("F310_LStick");

        buttonA = InputSystem.actions.FindAction("F310_A");
        buttonB = InputSystem.actions.FindAction("F310_B");
        buttonX = InputSystem.actions.FindAction("F310_X");
        buttonY = InputSystem.actions.FindAction("F310_Y");

        buttonUP    = InputSystem.actions.FindAction("F310_UP");
        buttonDOWN  = InputSystem.actions.FindAction("F310_DOWN");
        buttonLEFT  = InputSystem.actions.FindAction("F310_LEFT");
        buttonRIGHT = InputSystem.actions.FindAction("F310_RIGHT");
    }

    void Update()
    {
        // 左Stickの入力情報
        stickL_text = "LStick = " + stickL.ReadValue<Vector2>().ToString();

        button_text = "ボタンの入力";

        // ボタンの入力情報
        if (buttonA.IsPressed())
        {
            button_text = "Aボタン or Zキーが押されている";
        }
        if (buttonX.IsPressed())
        {
            button_text = "Xボタン or Xキーが押されている";
        }
        if (buttonB.IsPressed())
        {
            button_text = "Bボタン or Cキーが押されている";
        }
        if (buttonY.IsPressed())
        {
            button_text = "Yボタン or Vキーが押されている";
        }
        if (buttonUP.IsPressed())
        {
            button_text = "上ボタン or 1キーが押されている";
        }
        if (buttonDOWN.IsPressed())
        {
            button_text = "下ボタン or 2キーが押されている";
        }
        if (buttonLEFT.IsPressed())
        {
            button_text = "左ボタン or 3キーが押されている";
        }
        if (buttonRIGHT.IsPressed())
        {
            button_text = "右ボタン or 4キーが押されている";
        }

        // UI-Textに反映
        stickLLabel.text = stickL_text;     // 表示用UI-TEXTオブジェクト
        buttonLabel.text = button_text;     // 表示用UI-TEXTオブジェクト



    }
}
