﻿using UnityEngine;
using System.Collections.Generic;

using ControlFreak2;

namespace ControlFreak2.DebugUtils
{

public class AxisDebugger : MonoBehaviour 
	{
	public bool 
		drawGUI			= true,
		drawUnityAxes	= false;

	[Tooltip("When pressed, delta accumulators will be reset.")]
	public KeyCode
		deltaResetKey = KeyCode.F5;
		
	private Vector2 
		cfScroll,
		unScroll,
		cfMouseDelta,
		unMouseDelta;

	public GUISkin
		skin;

		
	void Update()	
		{
		if (Input.GetKeyDown(this.deltaResetKey))
			{
			this.unScroll = Vector2.zero;
			this.cfScroll = Vector2.zero;
			this.cfMouseDelta = Vector2.zero;
			this.unMouseDelta = Vector2.zero;
			}

		this.cfScroll += CF2Input.mouseScrollDelta;
		//this.cfScroll.y += CF2Input.GetAxis("Mouse Scroll Wheel Y");
		this.unScroll.x += Input.mouseScrollDelta.x;
		this.unScroll.y += Input.mouseScrollDelta.y;
	
		this.cfMouseDelta.x += CF2Input.GetAxis("Mouse X");
		this.cfMouseDelta.y += CF2Input.GetAxis("Mouse Y");
		
		this.unMouseDelta.x += GetUnityAxis("Mouse X");
		this.unMouseDelta.y += GetUnityAxis("Mouse Y");

		}


	// -------------------
	void OnGUI()
		{
		if (CF2Input.activeRig == null)
			return;
		

		GUI.skin = this.skin;

		
		GUILayout.Box("Active RIG: " + CF2Input.activeRig.name);

		GUILayout.Box("Scroll: cf:" + this.cfScroll + " un:" + this.unScroll + "\n" +
			"Mouse Delta: cf: " + this.cfMouseDelta + " un:" + this.unMouseDelta);

		List<InputRig.AxisConfig> axes = CF2Input.activeRig.axes.list;
		for (int i = 0; i < axes.Count; ++i)
			{
			InputRig.AxisConfig axis = axes[i];
				
			float 
				cfAxisVal		= 0, 
				unityAxisVal	= 0;
			bool	
				unityAxisAvailable = false;
	
			cfAxisVal = axis.GetAnalog();
			
			try { unityAxisVal = Input.GetAxis(axis.name); unityAxisAvailable = true; } catch (System.Exception ) {}

			if ((cfAxisVal == 0) && (!this.drawUnityAxes || (unityAxisVal == 0)))
				continue; 
				
			const float BAR_WIDTH = 100;
			
			GUILayout.BeginVertical();	
				GUILayout.Label(axis.name);

				GUI.color = ((cfAxisVal == 0) || (cfAxisVal == 1) || (cfAxisVal == -1)) ? Color.green : Color.gray;
				GUILayout.Label("CF : " + cfAxisVal.ToString("0.00000"));
	
				GUILayout.Box("", GUILayout.Width(Mathf.Abs(cfAxisVal) * BAR_WIDTH));

				if (this.drawUnityAxes)
					{
					GUI.color = ((unityAxisVal == 0) || (unityAxisVal == 1) || (unityAxisVal == -1)) ? Color.green : Color.gray;
					GUILayout.Label("UN : " + (unityAxisAvailable ? unityAxisVal.ToString("0.00000") : "UNAVAILABLE!"));

					GUILayout.Box("", GUILayout.Width(Mathf.Abs(unityAxisVal) * BAR_WIDTH));
					}

			GUILayout.EndVertical();
				
			GUI.color = Color.white;

			if (axis.axisType == InputRig.AxisType.Analog)
				{
				}
			}

		}



	// --------------------
	private float GetUnityAxis(string name, float defaultVal = 0)
		{
		float v = defaultVal;

		try { v = Input.GetAxis(name); } catch (System.Exception ) {}

		return v;
		}

		
	}
}
