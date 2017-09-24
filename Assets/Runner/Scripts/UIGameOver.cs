using UnityEngine;
using System.Collections;
using UUEX.UI;

namespace GameFramework
{
	public class UIGameOver : UI
	{
		private IRunner mRunner;

		public void Start()
		{
			mRunner = ServiceLocator.GetService<IRunner> ();
		}

		public override void OnItemClick (UIItem item)
		{
			base.OnItemClick (item);

			if(item.HasName("BtnRestart"))
			{
				mRunner.Restart();
				SetVisibility(false);
			}
		}
	}
}
