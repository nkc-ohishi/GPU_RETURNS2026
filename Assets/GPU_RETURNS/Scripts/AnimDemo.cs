using UnityEngine;
using UnityEngine.InputSystem;

public class AnimDemo : MonoBehaviour
{
	private Rigidbody2D rb;				// リジッドボディ2Dのコンポーネントを保存する変数
	float moveSpeed;					// 移動速度
	Transform visual;					// 子オブジェクトのVisualを保存
	Vector3 startScale;					// 最初のスケール値
	Animator plAnimator;				// アニメーターコンポーネント取得
	CapsuleCollider2D col;				// カプセルコライダー2Dコンポーネント取得

	InputAction stickL;					// アクションマップ【F310_LStick】を取得
    InputAction buttonA;				// アクションマップ【F310_A】を取得

    bool isGrounded = true;				// 地面に接地しているか
	float groundCheckDistance = 0.1f;	// 地面チェックの距離

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();       // リジッドボディ2Dコンポーネントを取得
		col = GetComponent<CapsuleCollider2D>();// カプセルコライダー2Dコンポーネントを取得
		moveSpeed = 3.0f;                       // 移動速度

        // アクションマップを取得
        stickL = InputSystem.actions.FindAction("F310_LStick");
        buttonA = InputSystem.actions.FindAction("F310_A");

		// Visualの各種パラメータを取得
		visual = transform.GetChild(0);					// Visualのトランスフォームコンポーネント取得
		startScale = visual.localScale;					// Visualのスケール値取得
		plAnimator = visual.GetComponent<Animator>();	// Visualのアニメーターコンポーネント取得

	}

	void Update()
	{
		// 足元の位置を計算（コライダーの下端）
		Vector2 footPosition = new Vector2(transform.position.x, col.bounds.min.y);

		// 地面チェック（足元から下方向をチェック）
		RaycastHit2D hit = Physics2D.Raycast(footPosition, Vector2.down, groundCheckDistance);
		Debug.DrawRay(footPosition, Vector2.down * groundCheckDistance, Color.red); // デバッグ用にRayを表示
		isGrounded = hit.collider != null;

		// 左右移動中かどうか
		bool isHorizontalMove = false;

		// 左右移動
		Vector3 vel = rb.linearVelocity;
		vel.x = stickL.ReadValue<Vector2>().x * moveSpeed;
		rb.linearVelocity = vel;

		// 画像左右反転
		Vector3 scale = visual.localScale;
		if(vel.x < 0f)
		{
			scale.x = -startScale.x;
			isHorizontalMove = true;
		}
		else if(vel.x > 0f)
		{
			scale.x = startScale.x;
			isHorizontalMove = true;
		}
		visual.localScale = scale;

		// isRunningのパラメータを左右移動と静止時で切り替える
		plAnimator.SetBool("isRunning", isHorizontalMove);

		// ジャンプ状態のアニメーション制御
		if (!isGrounded)
		{
			// 空中にいる場合
			if (vel.y > 0.1f)
			{
				// 上昇中のアニメーションを再生
				plAnimator.SetBool("isJumping", true);
				plAnimator.SetBool("isFalling", false);
			}
			else if (vel.y < -0.1f)
			{
				// 下降中のアニメーションを再生
				plAnimator.SetBool("isJumping", false);
				plAnimator.SetBool("isFalling", true);
			}
		}
		else
		{
			// 地面に着地している場合、アイドル状態に戻る
			plAnimator.SetBool("isJumping", false);
			plAnimator.SetBool("isFalling", false);
		}

		// ジャンプ処理
		if (buttonA.WasPerformedThisFrame() && isGrounded)
		{
			// 上方向に力を加える
			rb.AddForce(Vector2.up * 700);
		}


	}
}
