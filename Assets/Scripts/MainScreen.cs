using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

/// <summary>
/// メインスクリーン
/// </summary>
public class MainScreen : MonoBehaviour
{
    /// <summary>
    /// 結果表示用テキスト
    /// </summary>
    [SerializeField]
    private Text resultText = null;

    /// <summary>
    /// 認証ボタン
    /// </summary>
    [SerializeField]
    private Button authButton = null;

    /// <summary>
    /// 認証ボタンが押された
    /// </summary>
    public IObservable<Unit> OnAuth => authButton.OnClickAsObservable();

    /// <summary>
    /// 結果のテキストを設定
    /// </summary>
    /// <param name="text">テキスト</param>
    public void SetResultText(string text)
    {
        resultText.text = text;
        authButton.interactable = true;
    }

    void Awake()
    {
        OnAuth.Subscribe(_ => authButton.interactable = false).AddTo(gameObject);
    }
}
