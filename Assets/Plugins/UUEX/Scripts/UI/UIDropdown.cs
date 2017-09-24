using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace UUEX.UI
{
	[RequireComponent(typeof(Dropdown))]
	public class UIDropdown : UIItem
	{
		private Dropdown mDropDown = null;
		private int mSelectedIndex = 0;

		public override void Awake ()
		{
			base.Awake ();

			mDropDown = GetComponent<Dropdown> ();
			mDropDown.onValueChanged.AddListener (DropdownValueChanged);
		}

		public void AddValueChangedListener(UnityAction<int> action)
		{
			mDropDown.onValueChanged.AddListener (action);
		}

		public void DropdownValueChanged(int item)
		{
			// 0 to N
			mSelectedIndex = item;
		}

		public int GetSelectedItemIndex()
		{
			return mSelectedIndex;
		}

		public void AddOption(Dropdown.OptionData optionData)
		{
			mDropDown.options.Add (optionData);
		}

		public void AddOption(string text)
		{
			Dropdown.OptionData newOption = new Dropdown.OptionData (text);
			mDropDown.options.Add (newOption);
		}

		public void AddOption(Sprite image)
		{
			Dropdown.OptionData newOption = new Dropdown.OptionData (image);
			mDropDown.options.Add (newOption);
		}

		public void AddOption(string text, Sprite image)
		{
			Dropdown.OptionData newOption = new Dropdown.OptionData (text, image);
			mDropDown.options.Add (newOption);
		}

		public override void SetInteractive (bool interactive)
		{
			base.SetInteractive (interactive);

			mDropDown.interactable = interactive;
		}

		public override void SetDisabled (bool disabled)
		{
			base.SetDisabled (disabled);

			mDropDown.enabled = !disabled;
		}
	}
}
