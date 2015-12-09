using UnityEngine;
using System.Collections;

public class Blood : MonoBehaviour {
	
	ParticleSystem ps;
	
	public void Start() 
	{
		ps = GetComponent<ParticleSystem>();
	}
	
	public void Update() 
	{
		if(ps)
		{
			if(!ps.isPlaying)
			{
				Destroy(gameObject);
			}
		}
	}
}