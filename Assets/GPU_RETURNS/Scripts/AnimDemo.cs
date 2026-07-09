using UnityEngine;
using UnityEngine.InputSystem;

public class AnimDemo : MonoBehaviour
{
    private Rigidbody2D rb;			// リジッドボディ2Dのコンポーネントを保存する変数
    float moveSpeed;                // 移動速度
	Transform visual;				// 子オブジェクトのVisualを保存
	Vector3 startScale;				// 最初のスケール値
	InputAction moveAction;			// アクションマップ【Move】を取得
	InputAction jumpAction;         // アクションマップ【Jump】を取得

	void Start()
    {
        rb = GetComponent<Rigidbody2D>();       // リジッドボディ2Dコンポーネントを取得
        moveSpeed = 3.0f;                       // 移動速度

		// アクションマップを取得
		moveAction = InputSystem.actions.FindAction("Move");
		jumpAction = InputSystem.actions.FindAction("Jump");

		// Visualの最初のスケール値を保存
		visual = transform.GetChild(0);
		startScale = visual.localScale;
	}

    void Update()
    {
		// 左右移動
		Vector3 vel = rb.linearVelocity;
		vel.x = moveAction.ReadValue<Vector2>().x * moveSpeed;
		rb.linearVelocity = vel;

		// 画像左右反転
		Vector3 scale = visual.localScale;
		if(vel.x < 0f)
		{
			scale.x = -startScale.x;
		}
		else if(vel.x > 0f)
		{
			scale.x = startScale.x;
		}
		visual.localScale = scale;

		// ジャンプ処理
		if (jumpAction.WasPerformedThisFrame())
		{
			rb.AddForce(Vector2.up * 500);
		}


	}
}
