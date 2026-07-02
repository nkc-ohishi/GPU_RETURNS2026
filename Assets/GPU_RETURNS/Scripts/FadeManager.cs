//---------------------------------------------------------------------------------------------
// ファイル名：FadeManager.cs
// 概　　　要：一番手前に表示させるUIイメージのアルファ値を操作してフェードインアウトを実装する
//---------------------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// シーン遷移時のフェードイン・アウトを制御するためのクラス .
public class FadeManager : MonoBehaviour
{
    // リージョンディレクティブ　折りたたみ可能範囲指定
    #region Singleton

    // FadeManagerインスタンス保存用変数
    private static FadeManager instance;

    // Instanceプロパティの定義
    public static FadeManager Instance
    {
        // getアクセサー（ゲッター）
        get
        {
            // インスタンスが一度も生成されてなければ生成する
			if (instance == null)
            {
				// ヒエラルキーから FadeCanvasオブジェクトを探して取得
				instance = GameObject.Find("FadeCanvas").GetComponent<FadeManager>();

				// ヒエラルキーに FadeCanvas がいない場合はエラー出力 
				if (instance == null)
                {
					Debug.LogError (typeof(FadeManager) + "is nothing");
				}
			}

            // FadeManager のインスタンスを返す
            return instance;
		}
	}

    // リージョンディレクティブ終了（ここまで折りたためる）
    #endregion Singleton

    private float fadeAlpha = 0;            // フェード中の透明度
    private bool isFading   = false;        // フェード中かどうか

    public Image image;                     // FadeCanvasにぶら下げるイメージ
    public Color fadeColor;                 // α値を増減させるために最初のカラー情報を保存する

    // Startメソッドよりも先に呼び出されるgameObject作成時に一度だけ呼び出されるメソッド
    public void Awake ()
	{
        // 既存のFadeManagerインスタンスと別物であれば破棄
        if (this != Instance)
        {
			Destroy(gameObject);
			return;
        }

		// imageをCanvasと同じサイズにする
		RectTransform rectTransform = image.GetComponent<RectTransform>();
		rectTransform.anchorMin = Vector2.zero;
		rectTransform.anchorMax = Vector2.one;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;

        // 色情報を保存
        fadeColor = image.GetComponent<Image>().color;

		// Scene切替時でもFadeCanvasは破棄せずに保持しておく
		DontDestroyOnLoad(gameObject);

    }

    // 更新処理
    private void Update()
    {
        if (!isFading) return;      // フェード中でなければ以下の処理を実行しない

        fadeColor.a = fadeAlpha;    // アルファ値をセット(fadeAlphaはコルーチンで変更)
        image.color = fadeColor;    // Imageオブジェクトの色をセット
    }

    // 画面遷移 
    // 引数：シーン名 , 暗転にかかる時間(秒)
    public void LoadScene (string scene, float interval = 1f)
	{
        // フェード中はコルーチンをスタートさせない
        if (isFading == false)
        {
            // コルーチンをスタート
            StartCoroutine(TransScene(scene, interval));
        }
	}

	// シーン遷移用コルーチン .
    // 引数：シーン名 , 暗転にかかる時間(秒)
	private IEnumerator TransScene (string scene, float interval)
	{
        isFading = true;                // フェードフラグON

        // フェードアウト（だんだん暗く）
        float time = 0;
		while (time <= interval)
        {
			fadeAlpha = Mathf.Lerp (0f, 1f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}

		//シーン切替
		SceneManager.LoadScene(scene);

		// フェードイン（だんだん明るく）
		time = 0;
		while (time <= interval)
        {
			fadeAlpha = Mathf.Lerp (1f, 0f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}

        isFading = false;               // フェードフラグ OFF
	}
}
