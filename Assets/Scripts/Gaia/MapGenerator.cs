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
        public List<string> m_supportedBiomes = new List<string>{ "Desert_Flat", "Desert_Hills", "Desert_Canyon" };

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


        }
    }
}
