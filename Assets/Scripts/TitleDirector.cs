using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TitleDirector : MonoBehaviour
{
	[SerializeField] Text startLabel;    // "STARTボタンで開始"

	InputAction buttonSTART;            // アクションマップ【F310_START】を取得

	const float START_SPEED = 5f;		// 通常速度
	const float SPEEDUP_TIME = 2f;		// スピードアップ時間
	float speed;						// フェード速度
	float time;							// 時間計測用変数
	bool speedUpFlg;					// スピードアップフラグ

	void Start()
    {
		buttonSTART = InputSystem.actions.FindAction("F310_START");

		speed = START_SPEED;                    // スピードの初期値設定
		speedUpFlg = false;                     // スピードアップフラグOFF

		// BGMの再生
		BgmManager.Instance.Play("bgm_maoudamashii_8bit08");
	}

	void Update()
    {
		//オブジェクトのAlpha値を更新
		startLabel.color = GetAlphaColor(startLabel.color);

		// "STARTボタンで開始"の点滅処理
		if (buttonSTART.WasPressedThisFrame())
		{
			speedUpFlg = true;
			speed *= 3f;
			time = 0f;

			// SEの再生
			SeManager.Instance.Play("katana-slash5");
		}

		// STARTボタンが押されてからSPEEDUP_TIME秒たったらシーン遷移
		if (speedUpFlg && (time / speed) >= SPEEDUP_TIME)
		{
			BgmManager.Instance.Stop();
			FadeManager.Instance.LoadScene("GameSceneTemplate", 1.0f);
		}

	}

	//Alpha値を更新してColorを返す
	Color GetAlphaColor(Color color)
	{
		time += Time.deltaTime * speed;
		// アルファ値を 0.0～1.0の範囲で循環させる
		color.a = Mathf.Sin(time) * 0.5f + 0.5f;
		return color;
	}
}
