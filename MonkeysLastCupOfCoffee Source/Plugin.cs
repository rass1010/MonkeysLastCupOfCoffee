using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using Utilla;

namespace MonkeysLastCupOfCoffee
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    public class Plugin : BaseUnityPlugin
    {

        GameObject rightHand;
        GameObject _Coffee;

        void Awake()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += GameInitialized;
        }

        void Update()
        {

        }

        private void GameInitialized(object sender, EventArgs e)
        {
            Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("MonkeysLastCupOfCoffee.Assets.coffee");
            AssetBundle bundle = AssetBundle.LoadFromStream(str);

            GameObject Coffee = bundle.LoadAsset<GameObject>("Coffee");
            _Coffee = Instantiate(Coffee);

            rightHand = GameObject.Find("OfflineVRRig/Actual Gorilla/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/");
            _Coffee.transform.SetParent(rightHand.transform, false);
            _Coffee.transform.localPosition = Vector3.zero;
            _Coffee.transform.localScale = new Vector3(1, 1, 1);
            _Coffee.transform.GetChild(0).localPosition = new Vector3(-0.02f, 0.12f, 0.02f);
            _Coffee.transform.GetChild(0).localRotation = Quaternion.Euler(90, 180, 0);
            _Coffee.transform.GetChild(0).localScale = new Vector3(0.06f, 0.06f, 0.06f);
        }
    }
}
