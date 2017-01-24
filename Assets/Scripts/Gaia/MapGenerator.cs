using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using MadMilkman.Ini;

namespace Assets.Scripts.Gaia
{
    class MapGenerator : MonoBehaviour
    {
        public Vector2 m_mapSize = new Vector2(100, 100);
        public float m_tileSize = 10.0f;
        public List<string> m_supportedBiomes = new List<string>{ "Desert_Flat", "Desert_Hills", "Desert_Canyon" };

        public GameObject[] m_decorations;


        private string BIOME_SETTINGS_PATH       = "//Config//BiomeSettings.ini";
        private string DECORATIONS_SETTINGS_PATH = "//Config//Decorations.ini";

        private IniOptions m_iniOptions = new IniOptions();
        private IniFile m_biomeSettingsINI = new IniFile();
        private IniFile m_decorationsSettingsINI = new IniFile();

        private void initSettings()
        {
            try
            {
                m_biomeSettingsINI.Load(Application.dataPath + BIOME_SETTINGS_PATH);
            }
            catch (Exception e)
            {
                Debug.LogError("[Gaia] Biome settings file not found!");
                Debug.LogError(e.Message);
                throw;
            }
            try
            {
                m_biomeSettingsINI.Load(Application.dataPath + BIOME_SETTINGS_PATH);
            }
            catch (Exception e)
            {
                Debug.LogError("[Gaia] Decorations settings file not found!");
                Debug.LogError(e.Message);
                m_decorationsSettingsINI.Load(DECORATIONS_SETTINGS_PATH);
                throw;
            }
        }

        private void Start()
        {
            initSettings();
            Vector3 refPoint = GameObject.Find("rail_spawn").transform.position;
            Vector3 origin = new Vector3(refPoint.x - 300, refPoint.y, refPoint.z - 100);
            m_decorations = new GameObject[8];
            string[] decorationNames = { "deco_arroyo", "deco_bush", "deco_cart", "deco_cask", "deco_rock_small", "deco_rock_medium", "deco_cactus", "deco_mesa" };

            for ( int indexW = 0; indexW < m_mapSize.x; ++indexW)
            {
                for(int indexH = 0; indexH < m_mapSize.y; ++indexH)
                {
                    GameObject baseTile = Instantiate(Resources.Load<GameObject>("tile_desert_flat"));
                    baseTile.transform.position = new Vector3(origin.x + 10 * indexW, -0.01f, -(origin.z + 10 * indexH));

                    int selectionRandom = (int)UnityEngine.Random.Range(0.0f, 8.0f);
                    int probabilityRandom = (int)UnityEngine.Random.Range(0.0f, 10.0f);
                    if (probabilityRandom < 4.0f)
                    {
                        GameObject decoration = Instantiate(Resources.Load<GameObject>("Desert/" + decorationNames[selectionRandom]));
                        decoration.transform.position = new Vector3(origin.x + 10 * indexW / 2, -0.9f, -(origin.z + 10 * indexH / 2));
                    }
                }
            }
        }


    }
}
