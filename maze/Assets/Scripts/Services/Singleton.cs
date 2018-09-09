﻿using System;
using UnityEngine;

namespace DarkestMaze.Services
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;
		private static object _lock = new object();
		private static bool _applicationIsQuitting;

		public static T Instance
		{
			get
			{
				if (_applicationIsQuitting)
				{
					Debug.LogWarning(string.Format(@"[Singleton] Instance '{0}' already destroyed on application quit.
											Won't create again - returning null.",typeof(T)));
					return null;
				}

				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = (T)FindObjectOfType(typeof(T));

						if (FindObjectsOfType(typeof(T)).Length > 1)
						{

							Debug.LogError(@"[Singleton] Something went really wrong  - there should never be more than 1 singleton!
										 Reopening the scene might fix it.");
							return _instance;
						}

						if (_instance == null)
						{
							GameObject singleton = new GameObject();
							_instance = singleton.AddComponent<T>();
							singleton.name = String.Format("{0}(singleton) ", typeof(T));

							DontDestroyOnLoad(singleton);

							Debug.Log("[Singleton] An instance of " + typeof(T) +
									  " is needed in the scene, so '" + singleton +
									  "' was created with DontDestroyOnLoad.");
						}
						else
						{
							Debug.Log("[Singleton] Using instance already created: " +
									  _instance.gameObject.name);
						}
					}

					return _instance;
				}
			}
		}
		public void OnDestroy()
		{
			_applicationIsQuitting = true;
		}
	}
}