using UnityEngine;
using System.Collections;

public class MoveBarBottom : MonoBehaviour {

		// Use this for initialization
	void Start () {
	
		Camera c = FindObjectOfType<Camera>();
		RectTransform r = GetComponent<RectTransform>();

		r.sizeDelta = new Vector2(c.pixelWidth, c.pixelHeight * 0.1f);


		//transform.localScale. = c.pixelWidth;
		//transform.height = c.pixelHeight * 0.1f;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
