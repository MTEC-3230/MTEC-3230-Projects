using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

namespace ON
{
	public class ON_Trigger_SelectEntered : ON_TriggerEvents
	{

		public UnityEvent OnSelectEntered;



		public Color newColor;
		public Color oldColor;
		public bool getOldColorFromMaterial = false;
		public bool getOldColorFromCurrent = false;
		public string channel;
		public float speed;
		float counter = 0;
		Material mat;
		public bool reverse = false;
		public bool pingpong;


		void Awake()
		{

		}

		public override void Ping()
		{
			base.Ping();
			OnSelectEntered.Invoke(); 

		}


		public override void Reset()
		{
			base.Reset();
		}






	}
}
