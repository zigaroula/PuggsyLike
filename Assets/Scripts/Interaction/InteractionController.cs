using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interaction
{
    public class InteractionController : MonoBehaviour
    {
        void Awake()
        {
            GameInput.Initialize();
        }
    }
}