using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UUEX.UI
{
	/// <summary>
	/// UIText
	/// UI Text implementation
	/// </summary>
	[RequireComponent(typeof(Text))]
	public class UIText : UIItem 
	{
		public LocaleString _LocaleText;
		private Text mText;

		public override void Awake()
		{
			base.Awake ();

			mText = GetComponent<Text> ();
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
	}
}
