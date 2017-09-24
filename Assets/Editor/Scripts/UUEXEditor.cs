using UnityEngine;
using System.Collections;
using UnityEditor;

namespace UUEX
{
	public class UUEXEditor 
	{
		// Use this for initialization
		void Start () 
		{
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		[MenuItem("UUEX/UI/Create UI")]
		private static void CreateUI()
		{
			//AssetDatabase.LoadAssetAtPath(
			string path = "Assets/Plugins/UUEX/Objects/PfUI.prefab";
			GameObject obj = (GameObject)AssetDatabase.LoadAssetAtPath (path, typeof(GameObject));
			GameObject.Instantiate (obj);
		}

		[MenuItem("UUEX/UIMenu/Create Menu")]
		private static void CreateMenuUI()
		{
			
		}

		[MenuItem("UUEX/UIMenu/Horizontal Menu")]
		private static void CreateHorizontalMenuUI()
		{
			
		}

		[MenuItem("UUEX/UIMenu/Vertical Menu")]
		private static void CreateVerticalMenuUI()
		{
			
		}
	}
}