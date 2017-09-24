using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UUEX.UI
{
	/// <summary>
	/// UIButton
	/// UI Button implementation
	/// </summary>
	[RequireComponent(typeof(Button))]
	public class UIButton : UIItem, IWWWAsync
	{
		public LocaleString _LocaleText;
		protected Text mText;

		public override void Awake()
		{
			base.Awake ();

			mText = GetComponentInChildren<Text> ();
	
			Button button = GetComponent<Button> ();
			button.interactable = _Interactive;
		}

		public override void Start()
		{
			base.Start ();

			if(!string.IsNullOrEmpty(_LocaleText._Text))
				mText.text = _LocaleText.GetLocalisedString ();
		}
		
		public override void SetVisibility (bool visibility)
		{

		}

		public void SetText(string newText)
		{
			mText.text = newText;
		}

		public virtual void AsyncUpdate(WWWAsync.DownloadState progression, object result, object userData)
		{
			if (progression == UUEX.UI.WWWAsync.DownloadState.COMPLETED) 
			{
				Texture2D texture = result as Texture2D;

				Image image = GetComponent<Image>();
				Sprite sprite = Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), new Vector2(0.5f,0.5f));
				image.sprite = sprite;
			}
		}
		
		public virtual void SetTextureFromURL(string url)
		{
			ResourceManager.DownloadAsset(this, url, typeof(Texture2D));
		}
		
		public virtual void SetTexture(Texture2D texture)
		{
			Image image = GetComponent<Image>();
			Sprite sprite = Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), new Vector2(0.5f,0.5f));
			image.sprite = sprite;
		}

		public virtual void SetSprite(string atlasName, string spriteName)
		{
			Sprite sprite = ResourceManager.GetSprite (atlasName, spriteName);
			
			if(sprite != null)
			{
				Image image = GetComponent<Image> ();
				image.sprite = sprite;
			}
		}

		public override void SetInteractive (bool interactive)
		{
			base.SetInteractive (interactive);

			Button button = GetComponent<Button> ();
			if(button != null)
				button.interactable = interactive;
		}

		public override void SetDisabled (bool disabled)
		{
			base.SetDisabled (disabled);

			Button button = GetComponent<Button> ();
			if(button != null)
				button.enabled = !disabled;
		}
	}
}
