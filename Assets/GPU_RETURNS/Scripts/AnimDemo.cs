using UnityEngine;
using UnityEngine.InputSystem;

public class AnimDemo : MonoBehaviour
{
    private Rigidbody2D rb; // リジッドボディ2Dのコンポーネントを保存する変数
    float moveSpeed;        // 移動速度

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       // リジッドボディ2Dコンポーネントを取得
        moveSpeed = 3.0f;                       // 移動速度
    }

    void Update()
    {
        // Dキーが押されている間
        if (Keyboard.current.dKey.isPressed)
        {
            // 右方向に移動
            rb.linearVelocity = transform.right * moveSpeed;
        }

        // Aキーが押されている間
        if (Keyboard.current.aKey.isPressed)
        {
            // 左方向へ移動
            rb.linearVelocity = -transform.right * moveSpeed;
        }

        // .isPressed
        // 押している間 GetKey

        // .wasPressedThisFrame
        // 押した瞬間、GetKeyDown

        // .wasReleasedThisFrame
        // 離した瞬間、GetKeyUp

    }
}
