using UnityEngine;
using System.Collections;

public class Container: MonoBehaviour {
	public bool trapped;
	public GameObject player;
	
	public void Arm(){
		trapped = true;
	}
	
	public void Disarm(){
		trapped = false;
	}
	
	public bool Status(){
		return trapped;
	}
	
	public void Search(){
	}
}
