using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {
	public bool isClear;
	public SpriteRenderer sr;
	public float fadeSpeed = .05f;
	public bool isFading;
	public float lightTimer;
	public float fadeTime = 1f;
	public bool startFadingClear;
	public bool startFadingBlack;
	// Use this for initialization
	void Start () {
		isClear = true;
		sr.color = new Color(255,255,255,0);
	}
	
	// Update is called once per frame
	void Update () {
		if(isClear){

			sr.color = new Color(255,255,255,0);
		}
		else {
			sr.color = new Color(255,255,255,1);

				}

	}
}
