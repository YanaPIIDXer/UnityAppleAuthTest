using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppleAuth;
using AppleAuth.Native;
using AppleAuth.Enums;
using UniRx;
using System;
using AppleAuth.Interfaces;

/// <summary>
/// シーケンス
/// </summary>
public class Sequence : MonoBehaviour
{
    /// <summary>
    /// メインスクリーン
    /// </summary>
    [SerializeField]
    private MainScreen mainScreen = null;

    /// <summary>
    /// 認証マネージャ
    /// </summary>
    private AppleAuthManager authManager = null;

    void Awake()
    {
        if (AppleAuthManager.IsCurrentPlatformSupported)
        {
            authManager = new AppleAuthManager(new PayloadDeserializer());
        }

        mainScreen.OnAuth.Subscribe(_ =>
        {
            if (authManager == null)
            {
                mainScreen.SetResultText("未対応");
                return;
            }

            var args = new AppleAuthLoginArgs(LoginOptions.IncludeEmail | LoginOptions.IncludeFullName);
            authManager.LoginWithAppleId(args, credential =>
            {
                var idCredential = credential as IAppleIDCredential;
                if (idCredential == null)
                {
                    mainScreen.SetResultText("ID Credential is null.");
                    return;
                }
                mainScreen.SetResultText(idCredential.FullName.ToString());
            },
            error =>
            {
                mainScreen.SetResultText("ERROR:" + error.ToString());
            });
        }).AddTo(gameObject);
    }

    void Update()
    {
        if (authManager != null)
        {
            authManager.Update();
        }
    }
}
