using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WebSocketSharp;
using WebSocketSharp.Net;

public class TextureUpdater : MonoBehaviour {
  Texture2D tex;
	public void Start () {
    tex = new Texture2D(2, 2);
		// Create a texture. Texture size does not matter, since
		// LoadImage will replace with with incoming image size.
		// A small 64x64 Unity logo encoded into a PNG.
	}

  public void UpdateTexture(byte[] png_bytes) {
      		// Load data into the texture.
      		tex.LoadImage(png_bytes);
      		// Assign texture to renderer's material.
      		GetComponent<Renderer>().material.mainTexture = tex;
  }
}
