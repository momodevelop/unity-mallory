using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Momo
{
    public class ScaleToScreenSize : MonoBehaviour
    {
        private const float pixelPerUnit = 100;
        public bool width;
        public bool height;

        // Start is called before the first frame update
        void Awake()
        {
            Vector2 mins = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            Vector2 maxs = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            Sprite sp = null;
            Texture texture = null;
            if (sr)
            {
                sp = sr.sprite;
                if (sp)
                    texture = sp.texture;
            }

            // get world to screen units?



            if (width)
            {
                float scaleX = (maxs.x - mins.x) * pixelPerUnit;
                if (texture)
                    scaleX /= texture.width;
                transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
            }

            if (height)
            {
                float scaleY = (maxs.y - mins.y) * pixelPerUnit;
                if (texture)
                    scaleY /= texture.height;
                transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
            }

            Destroy(this);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}