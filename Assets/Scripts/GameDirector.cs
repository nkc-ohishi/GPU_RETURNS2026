using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
	[SerializeField] Text menuLabel;    // "MenuText"

	public static int gameFlg = 0;      // ゲームフラグ（0:タイトル 1:ゲーム中 2:ゲームオーバー 3:ゲームクリア）

	InputAction buttonSTART;            // アクションマップ【F310_START】を取得
	InputAction buttonBACK;             // アクションマップ【F310_BACK】を取得

	void Start()
    {
		menuLabel.text = "";
		gameFlg = 0;
		buttonSTART = InputSystem.actions.FindAction("F310_START");
		buttonBACK = InputSystem.actions.FindAction("F310_BACK");

		// BGMの再生
		BgmManager.Instance.Play("bgm_maoudamashii_8bit22");

	}

	void Update()
    {
		// ゲームの状態に応じてメニューの表示を切り替える
		switch (gameFlg)
		{
			case 0:     // タイトルシーン	
				menuLabel.text = "";
				break;
			case 1:     // ゲーム中
				menuLabel.text = "";
				break;
			case 2:     // ゲームオーバー
				menuLabel.text = "GAME OVER\nSTARTボタン：リスタート\nBACKボタン：タイトルへ";
				BgmManager.Instance.Play("bgm_maoudamashii_8bit20");
				break;
			case 3:     // ゲームクリアー
				menuLabel.text = "GAME CLEAR\nSTARTボタン：リスタート\nBACKボタン：タイトルへ";
				BgmManager.Instance.Play("bgm_maoudamashii_8bit24");
				break;
		}

		// ゲームフラグが2以上の場合の処理（ゲームオーバーまたはゲームクリアー）
		if (gameFlg >= 2)
		{
			if (buttonSTART.WasPressedThisFrame())
			{
				FadeManager.Instance.LoadScene("GameSceneTemplate", 1.0f); // ゲームシーンをリロード
			}
			if (buttonBACK.WasPressedThisFrame())
			{
				FadeManager.Instance.LoadScene("TitleSceneTemplate", 1.0f); // タイトルシーンに移動
			}
		}
	}
}
