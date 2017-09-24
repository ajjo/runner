using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UUEX.UI
{
	[RequireComponent(typeof(RawImage))]
	public class UIImage : UIItem, IWWWAsync
	{
		public void AsyncUpdate(WWWAsync.DownloadState progression, object result, object userData)
		{
			if (progression == UUEX.UI.WWWAsync.DownloadState.COMPLETED) 
			{
				Texture2D texture = result as Texture2D;
				
				RawImage rawImage = GetComponent<RawImage>();
				if(rawImage != null)
					rawImage.texture = texture;
			}
		}
		
		public void SetTextureFromURL(string url)
		{
			ResourceManager.DownloadAsset(this, url, typeof(Texture2D));
		}
		
		public void SetTexture(Texture2D texture)
		{
			RawImage rawImage = GetComponent<RawImage>();
			rawImage.texture = texture;
		}
	}
}
