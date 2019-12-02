using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Momo
{
    [CustomEditor(typeof(AnchorToScreenPosition))]
    public class AnchorToScreenPositionEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            AnchorToScreenPosition obj = target as AnchorToScreenPosition;

            obj.anchorX = EditorGUILayout.Toggle("Anchor X", obj.anchorX);
            if (obj.anchorX)
            {

                obj.normalizedX = EditorGUILayout.FloatField("Normalized X", obj.normalizedX);
            }

            EditorGUILayout.Space();
            obj.anchorY = EditorGUILayout.Toggle("Anchor Y", obj.anchorY);
            if (obj.anchorY)
            {
                obj.normalizedY = EditorGUILayout.FloatField("Normalized Y", obj.normalizedY);
            }

        }
    }

    public class AnchorToScreenPosition : MonoBehaviour
    {
        private const float pixelPerUnit = 100;

        public bool anchorX;
        public float normalizedX;
        public bool anchorY;
        public float normalizedY;

        // Start is called before the first frame update
        void Awake()
        {
            normalizedX = Mathf.Clamp(normalizedX, 0.0f, 1.0f);
            normalizedY = Mathf.Clamp(normalizedY, 0.0f, 1.0f);

            normalizedX = Mathf.Lerp(0, Screen.width, normalizedX);
            normalizedY = Mathf.Lerp(0, Screen.height, normalizedY);

            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(normalizedX, normalizedY, transform.position.z));
            Destroy(this);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}