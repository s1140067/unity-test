using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	private Animator motion;
	private AnimatorStateInfo state;
	
	void Update () {
		motion = GetComponent<Animator>();
		state = motion.GetCurrentAnimatorStateInfo(0);

		motion.SetBool("Jump", false);
		if(Input.GetKeyDown("space")){
			motion.SetBool("Jump", true);
		}

		if(state.IsName("Locomotion.JUMP00")){
			motion.SetBool("Jump", false);
		}
	}
}
