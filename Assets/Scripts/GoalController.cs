using UnityEngine;

public class GoalController : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		// プレーヤーのうごきを止める
		collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;

		// ゲームクリアのフラグを立てる
		GameDirector.gameFlg = 3;
	}
}
