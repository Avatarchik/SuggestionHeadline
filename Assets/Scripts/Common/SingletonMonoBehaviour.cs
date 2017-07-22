using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monobehaviour用テンプレートシングルトン.
/// </summary>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	protected static T instance;
	public static T Instance {
		get {
			if (instance == null) {
				var go = new GameObject (typeof(T).Name);
				instance = go.AddComponent<T> ();
			}
			return instance;
		}
	}

	public static string PrefabPath { get; set; }

	/// <summary>
	/// 必ずoverrideしてください.
	/// また、初期化処理はbase.Awakeの後に記述してください.
	/// </summary>
	protected virtual void Awake() {
		if (instance && this != instance) {
			Destroy (this);
			return;
		}
		DontDestroyOnLoad (gameObject);
	}

	/// <summary>
	/// 必ずoverrideしてください.
	/// </summary>
	protected virtual void OnDestroy() {
		if (this == instance) {
			instance = null;
		}
	}
}
