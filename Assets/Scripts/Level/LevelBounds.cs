using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Level
{
    public class LevelBounds : MonoBehaviour
    {
        #region Properties
        public float Left { get; set; }
        public float Right { get; set; }
        public float Top { get; set; }
        public float Bottom { get; set; }
        #endregion

        #region Private Methods
        private void Awake()
        {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            Left = transform.position.x - collider.size.x / 2;
            Right = transform.position.x + collider.size.x / 2;
            Top = transform.position.y + collider.size.y / 2;
            Bottom = transform.position.y - collider.size.y / 2;
        }
        #endregion

        #region Public Methods

        #endregion
    }
}