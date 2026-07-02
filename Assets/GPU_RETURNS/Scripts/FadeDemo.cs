using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeDemo : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Return))
		{
			FadeManager.Instance.LoadScene("audioDemo");
		}
    }
}
