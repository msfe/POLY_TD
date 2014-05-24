using UnityEngine;
using System.Collections;

public class BorderBehaviour : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Bullet") {
			Destroy(collider.gameObject);
		}
	}

}
