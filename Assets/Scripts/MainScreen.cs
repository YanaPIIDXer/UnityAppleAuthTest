using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
