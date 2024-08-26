using UnityEngine;
using System.IO;

public class ConfigLoader : MonoBehaviour
{
    public TextAsset jsonFile;

    [System.Serializable]
    public class PlayerData
    {
        public float speed;
    }

    [System.Serializable]
    public class PulpitData
    {
        public float min_pulpit_destroy_time;
        public float max_pulpit_destroy_time;
        public float pulpit_spawn_time;
    }

    [System.Serializable]
    public class GameData
    {
        public PlayerData player_data;
        public PulpitData pulpit_data;
    }

    public GameData gameData;

    void Start()
    {
        gameData = JsonUtility.FromJson<GameData>(jsonFile.text);
        DoofusController controller = FindObjectOfType<DoofusController>();
        controller.speed = gameData.player_data.speed;

        PulpitManager pulpitManager = FindObjectOfType<PulpitManager>();
        pulpitManager.minPulpitDestroyTime = gameData.pulpit_data.min_pulpit_destroy_time;
        pulpitManager.maxPulpitDestroyTime = gameData.pulpit_data.max_pulpit_destroy_time;
        pulpitManager.pulpitSpawnTime = gameData.pulpit_data.pulpit_spawn_time;
    }
}
