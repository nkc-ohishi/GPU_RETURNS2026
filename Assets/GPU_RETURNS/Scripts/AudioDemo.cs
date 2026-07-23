//---------------------------------------------------------------------------------------------
// ファイル名：AudioDemo.cs
// 概要：BgmManager と SeManager のテスト
//---------------------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioDemo : MonoBehaviour
{
	InputAction buttonA;                // アクションマップ【F310_A】を取得
	InputAction buttonX;                // アクションマップ【F310_X】を取得
	InputAction buttonB;                // アクションマップ【F310_B】を取得

	InputAction buttonUP;               // アクションマップ【F310_UP】を取得
	InputAction buttonDOWN;             // アクションマップ【F310_DOWN】を取得
	InputAction buttonLEFT;             // アクションマップ【F310_LEFT】を取得

	InputAction buttonSTART;            // アクションマップ【F310_START】を取得

	void Start()
    {
		buttonA = InputSystem.actions.FindAction("F310_A");
		buttonX = InputSystem.actions.FindAction("F310_X");
		buttonB = InputSystem.actions.FindAction("F310_B");

		buttonUP = InputSystem.actions.FindAction("F310_UP");
		buttonDOWN = InputSystem.actions.FindAction("F310_DOWN");
		buttonLEFT = InputSystem.actions.FindAction("F310_LEFT");

		buttonSTART = InputSystem.actions.FindAction("F310_START");
	}

	void Update()
    {
        // BGM1の再生
        if(buttonA.WasPressedThisFrame())
        {
            BgmManager.Instance.Play("bgm_maoudamashii_8bit08");
        }

        // BGM2の再生
        if (buttonX.WasPressedThisFrame())
        {
            BgmManager.Instance.Play("bgm_maoudamashii_8bit10");
        }

        // BGMの停止
        if (buttonB.WasPressedThisFrame())
        {
            BgmManager.Instance.Stop();
        }

        // SEの再生
        if (buttonUP.WasPressedThisFrame()) SeManager.Instance.Play("bomb");
        if (buttonDOWN.WasPressedThisFrame()) SeManager.Instance.Play("damage1");
        if (buttonLEFT.WasPressedThisFrame()) SeManager.Instance.Play("decision18");

		// フェードデモシーンへ以降
		if (buttonSTART.WasPressedThisFrame())
		{
			FadeManager.Instance.LoadScene("FadeDemo");
		}

    }
}
