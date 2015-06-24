﻿using UnityEngine;
using System.Collections;

public class T4Logic : MonoBehaviour {
    public Camera cam;
    public GameObject path;
    bool once = false;
    void OnGUI() {
        if (!Level.AllowMotion) {
            // no motion
            if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2, 250, 40), "Start")) {
                foreach (var ship in Level.ActiveShips) {
                    ship.transform.position = path.transform.position;
                    //ship.transform.position = new Vector3(0, 0, 0);
                    ship.ctrlAttachedCamera.farClipPlane = 6000f;
					//ship.gameObject.AddComponent<T4HelloWorldYeller>();
                }
				// destroy level preview camera
                DestroyImmediate(cam.gameObject);
                Level.EnableMotion(true);
            }
        } else {
            // motion allowed
            if (!once) {
                // delete all the tiny cams for each player
                foreach (var ship in Level.ActiveShips) {
                    Transform min_cam = ship.transform.Find("Camera");
                    if (min_cam != null) {
                        DestroyImmediate(min_cam.gameObject);
                    }
                }
                once = true;
            }

        }
    }
	// Use this for initialization
	void Start () {
        // add render settings
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = new Color(255, 255, 152, 255); // rgb 0-255 NOT 0-1
        RenderSettings.ambientIntensity = 0.0028f;
        // set level settings
        //Level.drag = 0.3f;
        Level.drag = 1;
        Level.angularDrag = 0.4f;
        Level.InitializationDone();

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}