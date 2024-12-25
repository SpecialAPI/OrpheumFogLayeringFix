using BepInEx;
using System;
using UnityEngine;

namespace OrpheumFogLayeringFix
{
    [BepInPlugin("SpecialAPI.OrpheumFogLayeringFix", "Orpheum Fog Layering Fix", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public void Awake()
        {
            var env = LoadedAssetsHandler.TryGetOverworldEnvironmentPrefab("Zone02_OWEnv");

            if (env == null)
                return;

            var staticEnv = env.transform.Find("StaticEnvironment");

            if (staticEnv == null)
                return;

            var sprites = staticEnv.GetComponentsInChildren<SpriteRenderer>(true);

            foreach(var s in sprites)
            {
                if(s == null)
                    continue;

                s.sortingOrder -= 10;
            }
        }
    }
}
