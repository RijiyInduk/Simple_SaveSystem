# Unity Save System

Two save system implementations for Unity. Choose the one that fits your project.

---

## SaveSystem1 — Simple 3-Slot Save System

**Best for:** small projects and beginners who need a clean, easy-to-read implementation with exactly three save slots.

### How it works

Each slot has its own dedicated variables (`player1`, `player2`, `player3`, `act1`, `act2`, `act3`). Each slot is saved to a separate JSON file on disk.

| Slot | File on disk |
|------|-------------|
| 1 | `savefile.json1` |
| 2 | `savefile.json2` |
| 3 | `savefile.json3` |

### Saved data

- Player name
- Quest flags: `fiveContractsAct`, `killForestBossAct`, `destrMonolythAct`, `killFinalBossAct` and others
- Building tiers: `tierMain`, `tierArchive`, `tierBarracks`, `tierStables`, `tierStorehouse`, `tierForge`, `tierArtifact`, `tierHerbalist`
- Resources: `baseCoins`, `baseWood`, `baseStone`, `baseLeather`, `baseDiamond`

### Available methods

```csharp
SaveSystem1.ins.ActivePlayer(int playerSlot);  // Generate data and activate slot (1, 2 or 3)
SaveSystem1.ins.SaveInfo();                    // Save the active slot
SaveSystem1.ins.LoadName1();                   // Load slot 1 and make it active
SaveSystem1.ins.LoadName2();                   // Load slot 2 and make it active
SaveSystem1.ins.LoadName3();                   // Load slot 3 and make it active
```

### Setup

1. Create an empty GameObject in your first scene (e.g. `SaveManager`)
2. Add the `SaveSystem1` component
3. The singleton persists across scenes via `DontDestroyOnLoad`

### Button setup in Inspector

Three types of buttons are needed: data generation, save, and load.

#### Data generation buttons (one per slot)

1. Create and select the data generation button for slot 1 in Hierarchy
2. In the `Button` component click `+` in `On Click ()`
3. Drag the GameObject with the `SaveSystem1` component into the object field
4. Select `SaveSystem1 → ActivePlayer`
5. Enter the slot number (1) in the parameter field

Repeat for slots 2 and 3.

#### Save button (one for the entire UI)

`SaveInfo` has no parameters — bind it directly:

1. Create and select the save button in Hierarchy
2. In the `Button` component click `+` in `On Click ()`
3. Drag the GameObject with the `SaveSystem1` component into the object field
4. Select `SaveSystem1 → SaveInfo`

#### Load buttons (one per slot)

`LoadName1`, `LoadName2`, `LoadName3` have no parameters — bind them directly:

1. Create and select the load button for slot 1 in Hierarchy
2. In the `Button` component click `+` in `On Click ()`
3. Drag the GameObject with the `SaveSystem1` component into the object field
4. Select `SaveSystem1 → LoadName1`

Repeat for slots 2 and 3: `LoadName2`, `LoadName3`.

### Reading data in other scripts

```csharp
int coins = SaveSystem1.ins.baseCoins;
int tier  = SaveSystem1.ins.tierMain;
```

---

## SaveSystem2 — Scalable Multi-Slot Save System

**Best for:** projects where the number of save slots may change, or when a cleaner array-based architecture is preferred.

### How it works

All data is stored in arrays indexed by slot number. Slot indices start at **1** (index 0 is unused). Each slot is saved to a separate JSON file.

| Slot | File on disk |
|------|-------------|
| 1 | `savefile_slot1.json` |
| 2 | `savefile_slot2.json` |
| N | `savefile_slotN.json` |

To change the number of slots, edit one constant:

```csharp
private const int realMaxSlots = 3; // change to any number
```

### Saved data

Same set of fields as SaveSystem1, stored in arrays indexed by slot.

### Available methods

```csharp
SaveSystem2.ins.ActivePlayer(int playerSlot);  // Generate data and activate slot (1..realMaxSlots)
SaveSystem2.ins.SaveInfo();                    // Save the active slot
SaveSystem2.ins.SaveSlot(int slot);            // Save a specific slot by index
SaveSystem2.ins.LoadSlot(int slot);            // Load a specific slot by index
```

### Setup

1. Create an empty GameObject in your first scene (e.g. `GameManager`)
2. Add the `SaveSystem2` component
3. The singleton persists across scenes via `DontDestroyOnLoad`

> **Important:** all arrays are initialized in `Awake()` via `InitArrays()`. Do not rely on array sizes set in the Inspector — Unity overwrites field initializers during deserialization, so explicit reinitialization in `Awake` is required.

### Button setup in Inspector

Three types of buttons are needed: data generation, save, and load.

#### Data generation buttons (one per slot)

`ActivePlayer` takes a slot number — the Inspector allows passing it directly:

1. Create and select the data generation button for slot 1 in Hierarchy
2. In the `Button` component click `+` in `On Click ()`
3. Drag the GameObject with the `SaveSystem2` component into the object field
4. Select `SaveSystem2 → ActivePlayer`
5. Enter the slot number (1) in the parameter field

Repeat for slots 2, 3 and beyond.

#### Save button (one for the entire UI)

`SaveInfo` has no parameters — bind it directly:

1. Create and select the save button in Hierarchy
2. In the `Button` component click `+` in `On Click ()`
3. Drag the GameObject with the `SaveSystem2` component into the object field
4. Select `SaveSystem2 → SaveInfo`

#### Load buttons (one per slot)

`LoadSlot` takes a slot number — the Inspector allows passing it directly:

1. Create and select the load button for slot 1 in Hierarchy
2. In the `Button` component click `+` in `On Click ()`
3. Drag the GameObject with the `SaveSystem2` component into the object field
4. Select `SaveSystem2 → LoadSlot`
5. Enter the slot number (1) in the parameter field

Repeat for slots 2, 3 and beyond.

To add a new slot — add generation and load buttons, enter the slot number in the parameter field, and increase `realMaxSlots`. No other changes to the script are needed.

### Reading data in other scripts

```csharp
int activeSlot = SaveSystem2.ins.GetActiveSlot(); // returns 1, 2, 3... or -1 if no active slot
int coins = SaveSystem2.ins.guildCoins[activeSlot];
int tier  = SaveSystem2.ins.tierMain[activeSlot];
```

---

## Comparison

| Parameter | SaveSystem1 | SaveSystem2 |
|-----------|------------|-------------|
| Number of slots | Fixed: 3 | Configured via constant |
| Code style | Explicit variables per slot | Arrays indexed by slot |
| Adding a new slot | Requires new variables and methods | Change constant + add buttons |
| Load button without helper script | Yes (`LoadName1/2/3`) | Yes (`LoadSlot` via Inspector) |
| Readability | High | Medium |
| Scalability | Low | High |
| Save file naming | `savefile.json1/2/3` | `savefile_slot1.json` etc. |

---

## Save file location

Files are written to `Application.persistentDataPath`:

| Platform | Path |
|----------|------|
| Windows | `%AppData%\..\LocalLow\<Company>\<Product>\` |
| macOS | `~/Library/Application Support/<Company>/<Product>/` |
| Linux | `~/.config/unity3d/<Company>/<Product>/` |
| Android | `/storage/emulated/0/Android/data/<package>/files/` |

---

## Notes

- Both systems use the **singleton pattern** (`ins`) and persist across scenes via `DontDestroyOnLoad`
- Data is serialized to **JSON** using `JsonUtility`
- The active slot is automatically saved on `OnApplicationQuit`
- Only **one slot can be active at a time**
