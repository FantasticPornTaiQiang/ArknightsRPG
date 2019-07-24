using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {

	
	public void Start () {
        GameObject.FindGameObjectWithTag("map1").GetComponent<AudioSource>().Stop();
    }


}
