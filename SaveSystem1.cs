using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;


public class SaveSystem1: MonoBehaviour
{
    public static SaveSystem1 ins;
    public string player1, player2, player3;
    public int fiveContractsAct, fiveContractsQuant, killForestBossAct, destrMonolythAct, killFinalBossAct, destrForestObelisk, destrCaveObelisk, destrTownObelisk, contractsDone, smallMonolythDone,threeMonolythsDone,finalBossDone;
    public int tierMain,tierArchive,tierBarracks,tierStables,tierStorehouse,tierForge,tierArtifact,tierHerbalist;
    public int baseCoins, baseWood, baseStone, baseLeather, baseDiamond;
    public bool act1, act2, act3;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (ins != this)
        {
            Destroy(ins.gameObject);
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        act1 = false;
        act2 = false;
        act3 = false;
    }

    public void ActivePlayer(int playerSlot)
    {
        if (playerSlot == 1)
        {
            act1 = true;
            act2 = false;
            act3 = false;
            player1 = "RandomName_1";
            player2 = "";
            player3 = "";
        }
        else if (playerSlot == 2)
        {
            act1 = false;
            act2 = true;
            act3 = false;
            player1 = "";
            player2 = "RandomName_2";
            player3 = "";
        }
        else if (playerSlot == 3)
        {
            act1 = false;
            act2 = false;
            act3 = true;
            player1 = "";
            player2 = "";
            player3 = "RandomName_3";
        }

        fiveContractsAct = Random.Range(0, 2);
        fiveContractsQuant = Random.Range(0, 2);
        killForestBossAct = Random.Range(0, 2);
        destrMonolythAct = Random.Range(0, 2);
        killFinalBossAct = Random.Range(0, 2);
        destrForestObelisk = Random.Range(0, 2);
        destrCaveObelisk = Random.Range(0, 2);
        destrTownObelisk = Random.Range(0, 2);
        contractsDone = Random.Range(0, 2);
        smallMonolythDone = Random.Range(0, 2);
        threeMonolythsDone = Random.Range(0, 2);
        finalBossDone = Random.Range(0, 2);

        tierMain = Random.Range(0, 3); 
        tierArchive = Random.Range(0, 3);
        tierBarracks = Random.Range(0, 3);
        tierStables = Random.Range(0, 3);
        tierStorehouse = Random.Range(0, 3);
        tierForge = Random.Range(0, 3);
        tierArtifact = Random.Range(0, 3);
        tierHerbalist = Random.Range(0, 3);

       baseCoins = Random.Range(0, 101);
       baseWood = Random.Range(0, 101);
       baseStone = Random.Range(0, 101);
       baseLeather = Random.Range(0, 101);
       baseDiamond = Random.Range(0, 101);
    }


    #region Savesystem
    [System.Serializable]
    class SaveData
    {
        public int tierMain1, tierMain2, tierMain3, tierArchive1, tierArchive2, tierArchive3, tierBarraks1, tierBarraks2, tierBarraks3, tierStables1, tierStables2, tierStables3,
            tierStoreHouse1, tierStoreHouse2, tierStoreHouse3, tierForge1, tierForge2, tierForge3, tierArtTower1, tierArtTower2, tierArtTower3, tierHerbalist1, tierHerbalist2, tierHerbalist3;
        public string player1, player2, player3;
        public int destrForestObelisk1, destrForestObelisk2, destrForestObelisk3, destrCaveObelisk1, destrCaveObelisk2, destrCaveObelisk3, destrTownObelisk1, destrTownObelisk2, destrTownObelisk3;
        public int fiveContractsAct1, fiveContractsAct2, fiveContractsAct3, fiveContractsQuant1, fiveContractsQuant2, fiveContractsQuant3, killForestBossAct1, killForestBossAct2, killForestBossAct3,
            destrMonolythAct1, destrMonolythAct2, destrMonolythAct3, killFinalBossAct1, killFinalBossAct2, killFinalBossAct3;
        public int contractsDone1, contractsDone2, contractsDone3, smallMonolythDone1, smallMonolythDone2, smallMonolythDone3, threeMonolythsDone1, threeMonolythsDone2, threeMonolythsDone3, finalBossDone1, finalBossDone2, finalBossDone3;
        public int gCoins1, gCoins2, gCoins3, gTree1, gTree2, gTree3, gStone1, gStone2, gStone3, gLeather1, gLeather2, gLeather3, gDiamond1, gDiamond2, gDiamond3;       
    }

    public void SaveInfo()
    {
        if (act1 && !act2 && !act3) SaveName1();
        else if (!act1 && act2 && !act3) SaveName2();
        else if (!act1 && !act2 && act3) SaveName3();
        else Debug.Log("Name not found");
    }


    public void SaveName1()
    {
        SaveData data1 = new SaveData();
        data1.player1 = player1;

        data1.fiveContractsAct1 = fiveContractsAct;
        data1.fiveContractsQuant1 = fiveContractsQuant;
        data1.killForestBossAct1 = killForestBossAct;
        data1.destrMonolythAct1 = destrMonolythAct;
        data1.killFinalBossAct1 = killFinalBossAct;
        data1.destrForestObelisk1 = destrForestObelisk;
        data1.destrCaveObelisk1 = destrCaveObelisk;
        data1.destrTownObelisk1 = destrTownObelisk;
        data1.contractsDone1 = contractsDone;
        data1.smallMonolythDone1 = smallMonolythDone;
        data1.threeMonolythsDone1 = threeMonolythsDone;
        data1.finalBossDone1 = finalBossDone;

        data1.tierMain1 = tierMain;
        data1.tierArchive1 = tierArchive;
        data1.tierBarraks1 = tierBarracks;
        data1.tierStables1 = tierStables;
        data1.tierStoreHouse1 = tierStorehouse;
        data1.tierForge1 = tierForge;
        data1.tierArtTower1 = tierArtifact;
        data1.tierHerbalist1 = tierHerbalist;

        data1.gCoins1 =   baseCoins;
        data1.gTree1 =    baseWood;
        data1.gStone1 =   baseStone;
        data1.gLeather1 = baseLeather;
        data1.gDiamond1 = baseDiamond;

        string json = JsonUtility.ToJson(data1);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json1", json);
    }

    public void SaveName2()
    {
        SaveData data2 = new SaveData();

        data2.player2 = player2;

        data2.fiveContractsAct2 = fiveContractsAct;
        data2.fiveContractsQuant2 = fiveContractsQuant;
        data2.killForestBossAct2 = killForestBossAct;
        data2.destrMonolythAct2 = destrMonolythAct;
        data2.killFinalBossAct2 = killFinalBossAct;
        data2.destrForestObelisk2 = destrForestObelisk;
        data2.destrCaveObelisk2 = destrCaveObelisk;
        data2.destrTownObelisk2 = destrTownObelisk;
        data2.contractsDone2 = contractsDone;
        data2.smallMonolythDone2 = smallMonolythDone;
        data2.threeMonolythsDone2 = threeMonolythsDone;
        data2.finalBossDone2 = finalBossDone;

        data2.tierMain2 = tierMain;
        data2.tierArchive2 = tierArchive;
        data2.tierBarraks2 = tierBarracks;
        data2.tierStables2 = tierStables;
        data2.tierStoreHouse2 = tierStorehouse;
        data2.tierForge2 = tierForge;
        data2.tierArtTower2 = tierArtifact;
        data2.tierHerbalist2 = tierHerbalist;

        data2.gCoins2 =   baseCoins;
        data2.gTree2 =    baseWood;
        data2.gStone2 =   baseStone;
        data2.gLeather2 = baseLeather;
        data2.gDiamond2 = baseDiamond;

        string json = JsonUtility.ToJson(data2);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json2", json);
    }

    public void SaveName3()
    {
        SaveData data3 = new SaveData();

        data3.player3 = player3;

        data3.fiveContractsAct3 = fiveContractsAct;
        data3.fiveContractsQuant3 = fiveContractsQuant;
        data3.killForestBossAct3 = killForestBossAct;
        data3.destrMonolythAct3 =   destrMonolythAct;
        data3.killFinalBossAct3 =   killFinalBossAct;
        data3.destrForestObelisk3 = destrForestObelisk;
        data3.destrCaveObelisk3 =   destrCaveObelisk;
        data3.destrTownObelisk3 =   destrTownObelisk;
        data3.contractsDone3 =      contractsDone;
        data3.smallMonolythDone3 =  smallMonolythDone;
        data3.threeMonolythsDone3 = threeMonolythsDone;
        data3.finalBossDone3 =      finalBossDone;

        data3.tierMain3 =    tierMain;
        data3.tierArchive3 = tierArchive;
        data3.tierBarraks3 = tierBarracks;
        data3.tierStables3 = tierStables;
        data3.tierStoreHouse3 = tierStorehouse;
        data3.tierForge3 =      tierForge;
        data3.tierArtTower3 =   tierArtifact;
        data3.tierHerbalist3 =  tierHerbalist;

        data3.gCoins3 =   baseCoins;
        data3.gTree3 =    baseWood;
        data3.gStone3 =   baseStone;
        data3.gLeather3 = baseLeather;
        data3.gDiamond3 = baseDiamond;

        string json = JsonUtility.ToJson(data3);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json3", json);
    }


    public void LoadName1()
    {
        string path = Application.persistentDataPath + "/savefile.json1";
        act1 = true;
        act2 = false;
        act3 = false;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data1 = JsonUtility.FromJson<SaveData>(json);

            player1 = data1.player1;
            player2 = "";
            player3 = "";
            fiveContractsAct = data1.fiveContractsAct1;
            fiveContractsQuant = data1.fiveContractsQuant1;
            killForestBossAct = data1.killForestBossAct1;
            destrMonolythAct = data1.destrMonolythAct1;
            killFinalBossAct = data1.killFinalBossAct1;
            destrForestObelisk = data1.destrForestObelisk1;
            destrCaveObelisk = data1.destrCaveObelisk1;
            destrTownObelisk = data1.destrTownObelisk1;
            contractsDone = data1.contractsDone1;
            smallMonolythDone = data1.smallMonolythDone1;
            threeMonolythsDone = data1.threeMonolythsDone1;
            finalBossDone = data1.finalBossDone1;

            tierMain = data1.tierMain1;
            tierArchive = data1.tierArchive1;
            tierBarracks = data1.tierBarraks1;
            tierStables = data1.tierStables1;
            tierStorehouse = data1.tierStoreHouse1;
            tierForge = data1.tierForge1;
            tierArtifact = data1.tierArtTower1;
            tierHerbalist = data1.tierHerbalist1;

            baseCoins = data1.gCoins1;
            baseWood = data1.gTree1;
            baseStone = data1.gStone1;
            baseLeather = data1.gLeather1;
            baseDiamond = data1.gDiamond1;
        }
        else Debug.Log("NotFound");
    }

    public void LoadName2()
    {
        string path = Application.persistentDataPath + "/savefile.json2";
        act1 = false;
        act2 = true;
        act3 = false;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data2 = JsonUtility.FromJson<SaveData>(json);

            player2 = data2.player2;
            player1 = "";
            player3 = "";
            fiveContractsAct = data2.fiveContractsAct2;
            fiveContractsQuant = data2.fiveContractsQuant2;
            killForestBossAct = data2.killForestBossAct2;
            destrMonolythAct = data2.destrMonolythAct2;
            killFinalBossAct = data2.killFinalBossAct2;
            destrForestObelisk = data2.destrForestObelisk2;
            destrCaveObelisk = data2.destrCaveObelisk2;
            destrTownObelisk = data2.destrTownObelisk2;
            contractsDone = data2.contractsDone2;
            smallMonolythDone = data2.smallMonolythDone2;
            threeMonolythsDone = data2.threeMonolythsDone2;
            finalBossDone = data2.finalBossDone2;

            tierMain = data2.tierMain2;
            tierArchive = data2.tierArchive2;
            tierBarracks = data2.tierBarraks2;
            tierStables = data2.tierStables2;
            tierStorehouse = data2.tierStoreHouse2;
            tierForge = data2.tierForge2;
            tierArtifact = data2.tierArtTower2;
            tierHerbalist = data2.tierHerbalist2;

            baseCoins = data2.gCoins2;
            baseWood = data2.gTree2;
            baseStone = data2.gStone2;
            baseLeather = data2.gLeather2;
            baseDiamond = data2.gDiamond2;
        }
        else Debug.Log("NotFound");
    }

    public void LoadName3()
    {
        string path = Application.persistentDataPath + "/savefile.json3";
        act1 = false;
        act2 = false;
        act3 = true;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data3 = JsonUtility.FromJson<SaveData>(json);

            player3 = data3.player3;
            player2 = "";
            player1 = "";
            fiveContractsAct = data3.fiveContractsAct3;
            fiveContractsQuant = data3.fiveContractsQuant3;
            killForestBossAct = data3.killForestBossAct3;
            destrMonolythAct = data3.destrMonolythAct3;
            killFinalBossAct = data3.killFinalBossAct3;
            destrForestObelisk = data3.destrForestObelisk3;
            destrCaveObelisk = data3.destrCaveObelisk3;
            destrTownObelisk = data3.destrTownObelisk3;
            contractsDone = data3.contractsDone3;
            smallMonolythDone = data3.smallMonolythDone3;
            threeMonolythsDone = data3.threeMonolythsDone3;
            finalBossDone = data3.finalBossDone3;

            tierMain = data3.tierMain3;
            tierArchive = data3.tierArchive3;
            tierBarracks = data3.tierBarraks3;
            tierStables = data3.tierStables3;
            tierStorehouse = data3.tierStoreHouse3;
            tierForge = data3.tierForge3;
            tierArtifact = data3.tierArtTower3;
            tierHerbalist = data3.tierHerbalist3;

            baseCoins = data3.gCoins3;
            baseWood = data3.gTree3;
            baseStone = data3.gStone3;
            baseLeather = data3.gLeather3;
            baseDiamond = data3.gDiamond3;
        }
        else Debug.Log("NotFound");
    }

    //exit application
    private void OnApplicationQuit()
    {
        if (act1 && !act2 && !act3)
        {
            SaveName1();
        }
        else if (!act1 && act2 && !act3)
        {
            SaveName2();
        }
        else if (!act1 && !act2 && act3)
        {
            SaveName3();
        }
    }

    #endregion



}
