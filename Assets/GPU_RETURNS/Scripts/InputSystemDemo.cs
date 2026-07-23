using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InputSystemDemo : MonoBehaviour
{
    [SerializeField]Text stickLabel;    // 表示用UI-TEXTオブジェクト
    [SerializeField] Text buttonLabel;  // 表示用UI-TEXTオブジェクト
    string stick_text;
    string button_text;

    InputAction stickL;                 // アクションマップ【F310_LStick】を取得
	InputAction stickR;                 // アクションマップ【F310_RStick】を取得
	InputAction stickLPress;            // アクションマップ【F310_LStickPress】を取得
	InputAction stickRPress;            // アクションマップ【F310_RStickPress】を取得

	InputAction buttonA;				// アクションマップ【F310_A】を取得
    InputAction buttonB;				// アクションマップ【F310_B】を取得
    InputAction buttonX;				// アクションマップ【F310_X】を取得
    InputAction buttonY;				// アクションマップ【F310_Y】を取得

    InputAction buttonUP;				// アクションマップ【F310_UP】を取得
    InputAction buttonDOWN;				// アクションマップ【F310_DOWN】を取得
    InputAction buttonLEFT;				// アクションマップ【F310_LEFT】を取得
    InputAction buttonRIGHT;            // アクションマップ【F310_RIGHT】を取得

	InputAction buttonRB;               // アクションマップ【F310_RB】を取得
	InputAction buttonLB;               // アクションマップ【F310_LB】を取得
	InputAction buttonRT;               // アクションマップ【F310_RT】を取得
	InputAction buttonLT;               // アクションマップ【F310_LT】を取得

	InputAction buttonSTART;            // アクションマップ【F310_START】を取得
	InputAction buttonBACK;             // アクションマップ【F310_BACK】を取得

	void Start()
    {
        // アクションマップを取得
        stickL = InputSystem.actions.FindAction("F310_LStick");
        stickR = InputSystem.actions.FindAction("F310_RStick");
        stickLPress = InputSystem.actions.FindAction("F310_LStickPress");
        stickRPress = InputSystem.actions.FindAction("F310_RStickPress");

        buttonA = InputSystem.actions.FindAction("F310_A");	
        buttonB = InputSystem.actions.FindAction("F310_B");
        buttonX = InputSystem.actions.FindAction("F310_X");
        buttonY = InputSystem.actions.FindAction("F310_Y");

        buttonUP    = InputSystem.actions.FindAction("F310_UP");
        buttonDOWN  = InputSystem.actions.FindAction("F310_DOWN");
        buttonLEFT  = InputSystem.actions.FindAction("F310_LEFT");
        buttonRIGHT = InputSystem.actions.FindAction("F310_RIGHT");

		buttonRB = InputSystem.actions.FindAction("F310_RB");
		buttonLB = InputSystem.actions.FindAction("F310_LB");
		buttonRT = InputSystem.actions.FindAction("F310_RT");
		buttonLT = InputSystem.actions.FindAction("F310_LT");

		buttonSTART  = InputSystem.actions.FindAction("F310_START");
		buttonBACK = InputSystem.actions.FindAction("F310_BACK");
	}

	void Update()
    {
		// Stickの入力情報
		stick_text = "スティックの入力";
		if (stickL.ReadValue<Vector2>().magnitude != 0)
		{
			stick_text = "左Stick = " + stickL.ReadValue<Vector2>().ToString();
		}
		if(stickR.ReadValue<Vector2>().magnitude != 0)
		{
			stick_text = "右Stick = " + stickR.ReadValue<Vector2>().ToString();
		}

        button_text = "ボタンの入力";

        // ボタンの入力情報
        if (buttonA.IsPressed())
        {
            button_text = "Aボタン(Zキー)が押されている";
        }
        if (buttonX.IsPressed())
        {
            button_text = "Xボタン(Xキー)が押されている";
        }
        if (buttonB.IsPressed())
        {
            button_text = "Bボタン(Cキー)が押されている";
        }
        if (buttonY.IsPressed())
        {
            button_text = "Yボタン(Vキー)が押されている";
        }
        if (buttonUP.IsPressed())
        {
            button_text = "上ボタン(1キー)が押されている";
        }
        if (buttonDOWN.IsPressed())
        {
            button_text = "下ボタン(2キー)が押されている";
        }
        if (buttonLEFT.IsPressed())
        {
            button_text = "左ボタン(3キー)が押されている";
        }
        if (buttonRIGHT.IsPressed())
        {
            button_text = "右ボタン(4キー)が押されている";
        }

		if (buttonRB.IsPressed())
		{
			button_text = "RBボタン(Eキー)が押されている";
		}
		if (buttonLB.IsPressed())
		{
			button_text = "LBボタン(Qキー)が押されている";
		}
		if (buttonRT.IsPressed())
		{
			button_text = "RTボタン(Rキー)が押されている";
		}
		if (buttonLT.IsPressed())
		{
			button_text = "LTボタン(Fキー)が押されている";
		}

		if (buttonSTART.IsPressed())
        {
            button_text = "STARTボタン(ENTERキー)が押されている";
        }
        if (buttonBACK.IsPressed())
        {
            button_text = "BACKボタン(Escキー)が押されている";
        }

		if (stickLPress.IsPressed())
		{
			button_text = "左スティック(左Shift)が押し込まれている";
		}
		if (stickRPress.IsPressed())
		{
			button_text = "右スティック(右Shift)が押し込まれている";
		}

		// UI-Textに反映
		stickLabel.text = stick_text;     // 表示用UI-TEXTオブジェクト
        buttonLabel.text = button_text;     // 表示用UI-TEXTオブジェクト

    }
}
