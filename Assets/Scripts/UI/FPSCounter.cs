﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {

	public int FPS {get; private set; }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		FPS = (int)(1f / Time.unscaledDeltaTime);
	}
}
