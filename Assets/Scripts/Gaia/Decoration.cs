using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts.Gaia
{
    class Decoration
    {
        public string m_name = "";
        public float m_probability = 0.1f;
        public string m_assetPath = "";

        public bool Spawn(Vector3 location)
        {
            //float odds = Random()
            return true;
            GameObject decoration = UnityEngine.Object.Instantiate(Resources.Load<GameObject>(m_assetPath)) as GameObject;
            if (decoration != null)
            {
                decoration.transform.position = location;
            }
        }
    }
}
