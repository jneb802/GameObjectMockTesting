using System.Reflection;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace GameObjectMockTesting;

public class Location
{
    private const string BundleName = "mocktesting";
    public static AssetBundle assetBundle;

    public static void LoadAssetBundle()
    {
        assetBundle = AssetUtils.LoadAssetBundleFromResources(
            BundleName,
            Assembly.GetExecutingAssembly()
        );
    }
    
    public static LocationConfig Ruins_warp_1_old_Config = new LocationConfig
    {
        Biome = Heightmap.Biome.Meadows,
        Quantity = 20,
        Priotized = true,
        ExteriorRadius = 8,
        ClearArea = true,
        RandomRotation = false,
        Group = "Ruins_small",
        MinDistanceFromSimilar = 256,
        MaxTerrainDelta = 2f,
        MinAltitude = 1,
        MaxDistance = 2000,
        InForest = false,
    };

    public static void AddLocation()
    {
        
        var locationGameObject = assetBundle.LoadAsset<GameObject>("Ruins_warp_1_old");
        
        GameObject jotunnLocationContainer = ZoneManager.Instance.CreateLocationContainer(locationGameObject);
        
        CustomLocation customLocation = new CustomLocation(jotunnLocationContainer, fixReference: true, Ruins_warp_1_old_Config);
        
        ZoneManager.Instance.AddCustomLocation(customLocation);   
        
        ZoneManager.OnVanillaLocationsAvailable -= AddLocation;
    }
    
}