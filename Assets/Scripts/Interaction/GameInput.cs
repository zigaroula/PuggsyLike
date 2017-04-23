using System.Collections.Generic;
using UnityEngine;

namespace Game.Interaction
{
    public static class GameInput
    {
        #region Properties
        private static Dictionary<string, KeyCode> m_Inputs;
        #endregion

        #region Private Methods
        private static void SaveChanges()
        {
            string l_GameInput = Tools.Serializer.ConvertToString(m_Inputs);
            PlayerPrefs.SetString("GameInput", l_GameInput);
            PlayerPrefs.Save();
        }
        #endregion

        #region Public Methods
        public static void Initialize()
        {
            m_Inputs = new Dictionary<string, KeyCode>();
            if (PlayerPrefs.HasKey("GameInput"))
            {
                string l_KeyboardInput = PlayerPrefs.GetString("GameInput");
                m_Inputs = Tools.Serializer.ConvertFromString<Dictionary<string, KeyCode>>(l_KeyboardInput);
            }
            else
            {
                Reset();
            }
        }
        public static void Reset()
        {
            m_Inputs["MoveLeft"] = KeyCode.LeftArrow;
            m_Inputs["MoveUp"] = KeyCode.UpArrow;
            m_Inputs["MoveDown"] = KeyCode.DownArrow;
            m_Inputs["MoveRight"] = KeyCode.RightArrow;
            m_Inputs["Jump"] = KeyCode.Space;
            m_Inputs["GrabItem"] = KeyCode.A;
            m_Inputs["UseItem"] = KeyCode.E;
            SaveChanges();
        }
        public static bool GetKeyDown(string name)
        {
            return (Input.GetKeyDown(m_Inputs[name]));
        }
        public static bool GetKeyUp(string name)
        {
            return (Input.GetKeyUp(m_Inputs[name]));
        }
        public static bool GetKey(string name)
        {
            return (Input.GetKey(m_Inputs[name]));
        }
        public static void SetKey(string name, KeyCode code)
        {
            foreach(KeyValuePair<string, KeyCode> input in m_Inputs)
            {
                if (input.Value == code)
                {
                    m_Inputs[input.Key] = m_Inputs[name];
                    break;
                }
            }
            m_Inputs[name] = code;
            SaveChanges();
        }
        #endregion
    }
}
