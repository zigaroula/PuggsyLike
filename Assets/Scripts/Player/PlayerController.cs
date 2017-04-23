using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Interaction;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Properties

        #endregion

        #region Private Methods
        void Start()
        {

        }

        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                PlayerPrefs.DeleteAll();
            }

            if (GameInput.GetKey("MoveLeft"))
            {
                transform.Translate(new Vector3(-10.0f * Time.deltaTime, 0.0f, 0.0f));
            }
            else if (GameInput.GetKey("MoveRight"))
            {
                transform.Translate(new Vector3(10.0f * Time.deltaTime, 0.0f, 0.0f));
            }

            if (GameInput.GetKey("MoveUp"))
            {
                transform.Translate(new Vector3(0.0f, 10.0f * Time.deltaTime, 0.0f));
            }
            else if (GameInput.GetKey("MoveDown"))
            {
                transform.Translate(new Vector3(0.0f, -10.0f * Time.deltaTime, 0.0f));
            }
        }
        #endregion

        #region Public Methods

        #endregion
    }
}