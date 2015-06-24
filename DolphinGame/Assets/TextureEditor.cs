using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    static class TextureEditor
    {
        public static List<Sprite> GetSpritesFromAtlas(Texture2D atlas, int spritesAmount, float width, float height, float interval, Vector2 position)
        {
            var sprites = new List<Sprite>();
            for (int i = 0; i < spritesAmount; i++)
            {
                sprites.Add(Sprite.Create(atlas, new Rect(interval + i * width, 0, width, height), position));
            }
            return sprites;
        }
    }
}
