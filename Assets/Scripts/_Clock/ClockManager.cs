using System;
using UnityEngine;

namespace JazzApps
{
	public class ClockManager : MonoBehaviour
	{
		// Consts
		const float hoursToDegrees = 30f, minutesToDegrees = 6f, secondsToDegrees = 6f;
		
		// Externals
		[SerializeField] Transform hoursPivot, minutesPivot, secondsPivot;

		private void LateUpdate ()
		{
			RefreshClockDisplay();
		}

		private void RefreshClockDisplay()
		{
			var time = DateTime.Now.TimeOfDay;
			hoursPivot.localRotation = Quaternion.Euler(0f, hoursToDegrees * (float)time.TotalHours, 0f);
			minutesPivot.localRotation = Quaternion.Euler(0f, minutesToDegrees * (float)time.TotalMinutes, 0f);
			secondsPivot.localRotation = Quaternion.Euler(0f, secondsToDegrees * (float)time.TotalSeconds, 0f);
		}
	}
}
