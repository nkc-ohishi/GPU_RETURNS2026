using UnityEngine;
using UnityEngine.InputSystem;

public class FadeDemo : MonoBehaviour
{
	InputAction buttonSTART;            // アクションマップ【F310_START】を取得


    void Start()
    {
        buttonSTART = InputSystem.actions.FindAction("F310_START");
    }

    void Update()
    {
		if(buttonSTART.WasPressedThisFrame())
		{
			FadeManager.Instance.LoadScene("audioDemo");
		}
    }
}
