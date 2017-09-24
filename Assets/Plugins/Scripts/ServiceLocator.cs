using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Service locator.
/// Implementation of the Service Locator Pattern - IRunner is the only one for now
/// </summary>
public class ServiceLocator
{
	private static Dictionary<System.Type, object> mServices = new Dictionary<System.Type, object> ();
	
	public static void AddService(System.Type type, object obj)
	{
		mServices.Add (type, obj);
	}
	
	public static T GetService<T>()
	{
		try
		{
			return (T)mServices[typeof(T)];
		}
		catch(Exception e)
		{
			Debug.Log (e.Message);
			throw new Exception(e.Message);
		}
	}

	public static void Clear()
	{
		mServices.Clear ();
	}
}
