# AchievementManager
Simple mod that gives or removes all the steam achievements

*made on a bet i couldn't do it quickly which i won*

## Quick Links
* **[MyBoplMods Repo](https://github.com/maxgamertyper/MyBoplMods)**
* **[Thunderstore Link]([https://github.com/maxgamertyper/MyBoplMods](https://thunderstore.io/c/bopl-battle/p/maxgamertyper1/AchievementManager/))**

> *No video here as it wouldnt really show anything*

---

## General Information & Setup

### Mod-Manager Setup
> *this is specifically guided for thunderstore, it may be slightly different for other mod managers*

#### Prerequisites
* A mod-manager (thunderstore, R2modman, or others) configured for the game bopl battle
* The game Bopl Battle

#### Steps

1) access the **Bopl Battle** game
2) make a new mod profile
3) go to the mods tab
4) search for "AchievementManager"
5) click download
6) run the game twice (it won't work the first time as the manager is initializing the mod installer)
7) check your mod manager's config area to choose remove all achievements or give all achievements

### BepInEx Setup
> *note: this is directed towards a windows installation*

#### Prerequisites
* An installation of the BepInEx Zip file
* the game Bopl Battle
* the AchievementManager.dll file

#### Steps
1) find your game directory through steam likely at `C:\Program Files (x86)\Steam\steamapps\common\Bopl Battle`
2) unzip the BepInEx file into the folder
3) run the game once
4) return to the directory
5) move the AchievementManager.dll file into the plugins folder
6) run the game
7) check the BepInEx config directory to choose remove all achievements or give all achievements

---

## Configuration Architecture

The only configuration is in the default bepinex configuration file which requires a true or false value. A value of true will give you every achievement, a value of false will remove every achievement
