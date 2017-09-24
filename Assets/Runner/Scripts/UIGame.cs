using UnityEngine;
using System.Collections;
using UUEX.UI;

namespace GameFramework
{
	public class UIGame : UI
	{
		private UIText mHighscore;
		private UIText mScore;
		private UIText mHealth;
		private UIText mLives;

		public override void Awake()
		{
			base.Awake ();

			mHighscore = (UIText)GetItem ("TxtHighscore");
			mScore = (UIText)GetItem ("TxtScore");
			mHealth = (UIText)GetItem ("TxtHealth");
			mLives = (UIText)GetItem ("TxtLives");
			
			mHighscore.SetText ("Highscore : 0");
			mScore.SetText ("Score : 0");
		}

		public void UpdateHighscore(int highscore)
		{
			mHighscore.SetText ("Highscore : " + highscore);
		}

		public void Updatescore(int score)
		{
			mScore.SetText ("Score : " + score);
		}

		public void UpdateHealth(int percentage)
		{
			mHealth.SetText("Health : " + percentage + "%");
		}

		public void UpdateLives(int lives)
		{
			mLives.SetText ("Lives : " + lives);
		}
	}
}
