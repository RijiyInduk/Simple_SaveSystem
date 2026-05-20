using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class SaveSystem2: MonoBehaviour
{
    public static SaveSystem2 ins;
    [System.NonSerialized] private const int realMaxSlots = 3;//for three save slots; increase if necessary
    [System.NonSerialized] private const int maxSlots = realMaxSlots+1;
    [System.NonSerialized] public string[] playerNames = new string[maxSlots];
    [System.NonSerialized] public bool[] act = new bool[maxSlots];

    public int[] fiveContractsAct = new int[maxSlots];
    public int[] fiveContractsQuant = new int[maxSlots];
    public int[] killForestBossAct = new int[maxSlots];
    public int[] destrMonolythAct = new int[maxSlots];
    public int[] killFinalBossAct = new int[maxSlots];
    public int[] destrForestObelisk = new int[maxSlots];
    public int[] destrCaveObelisk = new int[maxSlots];
    public int[] destrTownObelisk = new int[maxSlots];
    public int[] contractsDone = new int[maxSlots];
    public int[] smallMonolythDone = new int[maxSlots];
    public int[] threeMonolythsDone = new int[maxSlots];
    public int[] finalBossDone = new int[maxSlots];

    public int[] tierMain = new int[maxSlots];
    public int[] tierArchive = new int[maxSlots];
    public int[] tierBarracks = new int[maxSlots];
    public int[] tierStables = new int[maxSlots];
    public int[] tierStorehouse = new int[maxSlots];
    public int[] tierForge = new int[maxSlots];
    public int[] tierArtifact = new int[maxSlots];
    public int[] tierHerbalist = new int[maxSlots];

    public int[] guildCoins = new int[maxSlots];
    public int[] guildWood = new int[maxSlots];
    public int[] guildStone = new int[maxSlots];
    public int[] guildLeather = new int[maxSlots];
    public int[] guildDiamond = new int[maxSlots];


    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
            InitArrays();
        }
        else if (ins != this)
        {
            Destroy(ins.gameObject);
            ins = this;
            DontDestroyOnLoad(gameObject);
            InitArrays();
        }
    }

    private void InitArrays()
    {
        act = new bool[maxSlots];
        playerNames = new string[maxSlots];

        fiveContractsAct = new int[maxSlots];
        fiveContractsQuant = new int[maxSlots];
        killForestBossAct = new int[maxSlots];
        destrMonolythAct = new int[maxSlots];
        killFinalBossAct = new int[maxSlots];
        destrForestObelisk = new int[maxSlots];
        destrCaveObelisk = new int[maxSlots];
        destrTownObelisk = new int[maxSlots];
        contractsDone = new int[maxSlots];
        smallMonolythDone = new int[maxSlots];
        threeMonolythsDone = new int[maxSlots];
        finalBossDone = new int[maxSlots];

        tierMain = new int[maxSlots];
        tierArchive = new int[maxSlots];
        tierBarracks = new int[maxSlots];
        tierStables = new int[maxSlots];
        tierStorehouse = new int[maxSlots];
        tierForge = new int[maxSlots];
        tierArtifact = new int[maxSlots];
        tierHerbalist = new int[maxSlots];

        guildCoins = new int[maxSlots];
        guildWood = new int[maxSlots];
        guildStone = new int[maxSlots];
        guildLeather = new int[maxSlots];
        guildDiamond = new int[maxSlots];
    }

    private void Start()
    {        
        for (int i = 1; i < maxSlots; i++) act[i] = false;        
    }
   

    // Activate slot (playerSlot = 0, 1, 2)
    public void ActivePlayer(int playerSlot)
    {
        if (playerSlot < 1 || playerSlot >= maxSlots) return;

        // Reset the activity of all slots
        for (int i = 1; i < maxSlots; i++) act[i] = false;
        act[playerSlot] = true;

        // Name cleaning
        for (int i = 1; i < maxSlots; i++) playerNames[i] = "";
        playerNames[playerSlot] = "RandomName_" + playerSlot;

        // Generating random data for this slot
        fiveContractsAct[playerSlot] = Random.Range(0, 2);
        fiveContractsQuant[playerSlot] = Random.Range(0, 2);
        killForestBossAct[playerSlot] = Random.Range(0, 2);
        destrMonolythAct[playerSlot] = Random.Range(0, 2);
        killFinalBossAct[playerSlot] = Random.Range(0, 2);
        destrForestObelisk[playerSlot] = Random.Range(0, 2);
        destrCaveObelisk[playerSlot] = Random.Range(0, 2);
        destrTownObelisk[playerSlot] = Random.Range(0, 2);
        contractsDone[playerSlot] = Random.Range(0, 2);
        smallMonolythDone[playerSlot] = Random.Range(0, 2);
        threeMonolythsDone[playerSlot] = Random.Range(0, 2);
        finalBossDone[playerSlot] = Random.Range(0, 2);

        tierMain[playerSlot] = Random.Range(0, 3);
        tierArchive[playerSlot] = Random.Range(0, 3);
        tierBarracks[playerSlot] = Random.Range(0, 3);
        tierStables[playerSlot] = Random.Range(0, 3);
        tierStorehouse[playerSlot] = Random.Range(0, 3);
        tierForge[playerSlot] = Random.Range(0, 3);
        tierArtifact[playerSlot] = Random.Range(0, 3);
        tierHerbalist[playerSlot] = Random.Range(0, 3);

        guildCoins[playerSlot] = Random.Range(0, 101);
        guildWood[playerSlot] = Random.Range(0, 101);
        guildStone[playerSlot] = Random.Range(0, 101);
        guildLeather[playerSlot] = Random.Range(0, 101);
        guildDiamond[playerSlot] = Random.Range(0, 101);
    }

    #region SaveSystem

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int fiveContractsAct, fiveContractsQuant, killForestBossAct,
                  destrMonolythAct, killFinalBossAct, destrForestObelisk,
                  destrCaveObelisk, destrTownObelisk, contractsDone,
                  smallMonolythDone, threeMonolythsDone, finalBossDone;
        public int tierMain, tierArchive, tierBarracks, tierStables,
                  tierStorehouse, tierForge, tierArtifact, tierHerbalist;
        public int guildCoins, guildWood, guildStone, guildLeather, guildDiamond;
    }

    // Keep the active slot
    public void SaveInfo()
    {
        int slot = GetActiveSlot();
        if (slot >= 1) SaveSlot(slot);
        else Debug.Log("There is no active save slot");
    }

    // Save a specific slot by index (0, 1, 2)
    public void SaveSlot(int slot)
    {
        if (slot < 1 || slot >= maxSlots) return;

        SaveData data = new SaveData();
        data.playerName = playerNames[slot];

        data.fiveContractsAct = fiveContractsAct[slot];
        data.fiveContractsQuant = fiveContractsQuant[slot];
        data.killForestBossAct = killForestBossAct[slot];
        data.destrMonolythAct = destrMonolythAct[slot];
        data.killFinalBossAct = killFinalBossAct[slot];
        data.destrForestObelisk = destrForestObelisk[slot];
        data.destrCaveObelisk = destrCaveObelisk[slot];
        data.destrTownObelisk = destrTownObelisk[slot];
        data.contractsDone = contractsDone[slot];
        data.smallMonolythDone = smallMonolythDone[slot];
        data.threeMonolythsDone = threeMonolythsDone[slot];
        data.finalBossDone = finalBossDone[slot];

        data.tierMain = tierMain[slot];
        data.tierArchive = tierArchive[slot];
        data.tierBarracks = tierBarracks[slot];
        data.tierStables = tierStables[slot];
        data.tierStorehouse = tierStorehouse[slot];
        data.tierForge = tierForge[slot];
        data.tierArtifact = tierArtifact[slot];
        data.tierHerbalist = tierHerbalist[slot];

        data.guildCoins = guildCoins[slot];
        data.guildWood = guildWood[slot];
        data.guildStone = guildStone[slot];
        data.guildLeather = guildLeather[slot];
        data.guildDiamond = guildDiamond[slot];

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + $"/savefile_slot{slot}.json";
        File.WriteAllText(path, json);
    }

    // Load the slot (and make it active)
    public void LoadSlot(int slot)
    {
        if (slot < 1 || slot >= maxSlots) return;

        string path = Application.persistentDataPath + $"/savefile_slot{slot}.json";
        if (!File.Exists(path))
        {
            Debug.Log($"Slot {slot} not found");
            return;
        }

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        // Make this slot active
        for (int i = 1; i < maxSlots; i++) act[i] = false;
        act[slot] = true;

        playerNames[slot] = data.playerName;

        fiveContractsAct[slot] = data.fiveContractsAct;
        fiveContractsQuant[slot] = data.fiveContractsQuant;
        killForestBossAct[slot] = data.killForestBossAct;
        destrMonolythAct[slot] = data.destrMonolythAct;
        killFinalBossAct[slot] = data.killFinalBossAct;
        destrForestObelisk[slot] = data.destrForestObelisk;
        destrCaveObelisk[slot] = data.destrCaveObelisk;
        destrTownObelisk[slot] = data.destrTownObelisk;
        contractsDone[slot] = data.contractsDone;
        smallMonolythDone[slot] = data.smallMonolythDone;
        threeMonolythsDone[slot] = data.threeMonolythsDone;
        finalBossDone[slot] = data.finalBossDone;

        tierMain[slot] = data.tierMain;
        tierArchive[slot] = data.tierArchive;
        tierBarracks[slot] = data.tierBarracks;
        tierStables[slot] = data.tierStables;
        tierStorehouse[slot] = data.tierStorehouse;
        tierForge[slot] = data.tierForge;
        tierArtifact[slot] = data.tierArtifact;
        tierHerbalist[slot] = data.tierHerbalist;

        guildCoins[slot] = data.guildCoins;
        guildWood[slot] = data.guildWood;
        guildStone[slot] = data.guildStone;
        guildLeather[slot] = data.guildLeather;
        guildDiamond[slot] = data.guildDiamond;
    }    

    private int GetActiveSlot()
    {
        for (int i = 1; i < maxSlots; i++)
            if (act[i]) return i;
        return -1;
    }

    private void OnApplicationQuit()
    {
        int slot = GetActiveSlot();
        if (slot >= 1) SaveSlot(slot);
    }

    #endregion
}
