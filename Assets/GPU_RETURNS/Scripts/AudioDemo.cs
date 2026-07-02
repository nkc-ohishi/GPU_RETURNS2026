//---------------------------------------------------------------------------------------------
// ファイル名：AudioDemo.cs
// 概要：BgmManager と SeManager のテスト
//---------------------------------------------------------------------------------------------
using UnityEngine;

public class AudioDemo : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        // BGM1の再生
        if(Input.GetKeyDown(KeyCode.Z))
        {
            BgmManager.Instance.Play("bgm_maoudamashii_8bit08");
        }

        // BGM2の再生
        if (Input.GetKeyDown(KeyCode.X))
        {
            BgmManager.Instance.Play("bgm_maoudamashii_8bit10");
        }

        // BGMの停止
        if (Input.GetKeyDown(KeyCode.C))
        {
            BgmManager.Instance.Stop();
        }

        // SEの再生
        if (Input.GetKeyDown(KeyCode.Alpha1)) SeManager.Instance.Play("bomb");
        if (Input.GetKeyDown(KeyCode.Alpha2)) SeManager.Instance.Play("damage1");
        if (Input.GetKeyDown(KeyCode.Alpha3)) SeManager.Instance.Play("decision18");


		// フェードデモシーンへ以降
		if(Input.GetKeyDown(KeyCode.Return))
		{
			FadeManager.Instance.LoadScene("FadeDemo");
		}

    }
}
