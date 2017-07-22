//-----------------------------------------------------------------
// @file   LoginController.cs
// @brief  ログイン画面制御.
//
// @author haruki.tachihara
// Copyright (C) 2017 Walker Industries Co.LLC All Rights Reserved.
//-----------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoginController : MonoBehaviour {

	[SerializeField] private InputField usernameInput;
	[SerializeField] private InputField passwordInput;
	[SerializeField] private Button loginButton;


	private void Start()
	{
		RegisterCallback ();
	}

	private void OnDestroy()
	{
		UnRegisterCallback ();
	}

	private void RegisterCallback()
	{
		usernameInput.onValidateInput = OnValidateUsername;
		usernameInput.onEndEdit.AddListener (OnSubmitUsername);
		passwordInput.onValidateInput = OnValidatePassword;
		passwordInput.onEndEdit.AddListener (OnSubmitPassword);
		loginButton.onClick.AddListener (OnClickLogin);
	}

	private void UnRegisterCallback()
	{
		usernameInput.onValidateInput = null;
		usernameInput.onEndEdit.RemoveAllListeners ();
		passwordInput.onValidateInput = null;
		passwordInput.onEndEdit.RemoveAllListeners ();
		loginButton.onClick.RemoveAllListeners ();
	}


	private char OnValidateUsername (string text, int charIndex, char addedChar)
	{
		// TODO サーバーAPI仕様確認.
		// TODO 絵文字除外.
		return addedChar;
	}

	private void OnSubmitUsername(string text)
	{
		// TODO 禁止文字列のチェック.
	}

	private char OnValidatePassword (string text, int charIndex, char addedChar)
	{
		// TODO サーバーAPI仕様確認.
		// TODO 絵文字除外.
		return addedChar;
	}

	private void OnSubmitPassword(string text)
	{
		// TODO 禁止文字列のチェック.
		// TODO 文字数のチェック.
	}


	private void OnClickLogin()
	{
		CallLoginApi (usernameInput.text, passwordInput.text, OnSuccessLogin, OnErrorLogin);
	}

	private void OnSuccessLogin()
	{
		if (Debug.logger.logEnabled) {
			Debug.Log ("Login Successed. username :" + usernameInput.text + " password :" + passwordInput.text);
		}

		SceneManager.LoadScene (App.Scenes.Headline.ToString());
	}

	private void OnErrorLogin(Exception error)
	{
		if (error == null) return;
		Debug.LogError (error.Message);
	}

	private void CallLoginApi(string username, string password, Action onSuccess, Action<Exception> onError = null)
	{
		// TODO ログインAPIのリクエスト.

		// FIXME ログイン成功時挙動のみ実装.
		if (onSuccess != null) onSuccess();
	}
}
