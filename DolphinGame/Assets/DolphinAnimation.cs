using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;

public class DolphinAnimation : MonoBehaviour {
    public Texture2D DolphinTextureCollection;
    public int AnimateImagesAmount;
    private List<Sprite> DolphinTextures;
	// Use this for initialization
	void Start () {
        DolphinTextures = TextureEditor.GetSpritesFromAtlas(DolphinTextureCollection, AnimateImagesAmount, 310, 260, 70, this.transform.position);
	}
    int fps = 0;
    private int AnimationCounter = 0;
	void Update () {
        fps++;
        if (fps % 10 == 0)
        {
            if (AnimationCounter == AnimateImagesAmount)
            {
                AnimationCounter = 0;
            }
            this.GetComponent<SpriteRenderer>().sprite = DolphinTextures[AnimationCounter];
            AnimationCounter++;
        }
    }
}
