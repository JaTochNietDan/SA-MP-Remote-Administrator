# Remote Administrator

![Pic 1](https://dl.dropbox.com/u/12901320/Pictures/Capture1.PNG) ![Pic 2](https://dl.dropbox.com/u/12901320/Pictures/Capture2.PNG) ![Pic 3](https://dl.dropbox.com/u/12901320/Pictures/Capture3.PNG)
![Pic 4](https://dl.dropbox.com/u/12901320/Pictures/Capture%204.png) ![Pic 5](https://dl.dropbox.com/u/12901320/Pictures/Capture%205.png)

## Features

- Fully interactive in-game chat (with player colours)
- List of in-game players (with player colours)
- Right-click on player list to do an administrator action on them
- Live in-game statistics with a map view (awesome tracking mode included and pictures of current vehicle/skin)
- In-game statistics can be edited immediately by changing the value and pressing enter
- Total ban system, includes timed bans, permanent bans and a simplified ban management interface
- Administration system, you can add/edit administrators who will be able to login with this tool
- Used to commands? You can use /kick and /ban through the chat box!
- Administrate your server from anywhere at any time!
- Type part of someone's name and press TAB to automatically finish it!
- Keeps up to 10 of your last messages/commands stored, you can scroll through them using the arrow keys.

## Installation

- Make sure you have BlueG's [Socket Plugin](http://forum.sa-mp.com/showthread.php?t=333934) installed on your SA-MP server
- Download the [RemoteAdmin Filterscript](https://dl.dropbox.com/u/12901320/releases/RemoteAdmins/remoteadmin.amx) ([source](https://dl.dropbox.com/u/12901320/releases/RemoteAdmins/remoteadmin.pwn)) and load it on your server. This filterscript requires you to have the [sscanf2](http://forum.sa-mp.com/showthread.php?t=120356) plugin on your server.
- Select an official download of the Remote Administrator application below.
- Launch the application, enter your server details and login with username: admin, password: admin
- That's it! You can now change your default administrator password for security and add more administrators!

**Follow each step, it doesn't take long and most of your questions are already answered!**

## Frequently Asked Questions

### Various player list problems, missing names, missing IDs etc
Make sure that the [filterscript](https://dl.dropbox.com/u/12901320/releases/RemoteAdmins/remoteadmin.amx) is the first one being loaded to avoid conflicts with other scripts.

### Do I have to use a different port than my server for Remote Administrator?
Yes, you need to specify a different port for the Remote Administrator service to use in the filterscript that you downloaded. The default port is 9890 and will usually work fine with that.

### No connection could be made because the target machine actively refused it.
This means that you are either not connecting to the correct port for the Remote Administrator service that was set in the filterscript (by default 9890), or your server is refusing connections. Most likely the former.

### socket_listen(): Socket has failed to bind
Download the [filterscript source](https://dl.dropbox.com/u/12901320/releases/RemoteAdmins/remoteadmin.pwn), open it, find this line:

```
//#define SOCKET_BIND "127.0.0.1"
```

Remove the // from the start of the line, compile and load the new filterscript.

### Can I configure my own administrator levels for certain actions?
Yes, they are completely configurable, just download the [filterscript source](https://dl.dropbox.com/u/12901320/releases/remoteadmin.pwn), open it, edit the level definitions and compile it.

**What are the default permissions for each level?**

```
#define KICK_LEVEL 1
#define BAN_LEVEL 3

#define INFO_LEVEL 1
#define SKIN_LEVEL 2
#define HEALTH_LEVEL 2
#define ARMOUR_LEVEL 2
#define WEAPON_LEVEL 2
#define SCORE_LEVEL 2
#define INTERIOR_LEVEL 3
#define WORLD_LEVEL 3
#define VHEALTH_LEVEL 2

#define PVAR_LEVEL 4

#define BAN_MANAGE 4
#define ADMIN_MANAGE 5
```

### Can I edit what SQLite file it uses and the names of the tables?
Yes, also completely configurable, follow the same steps as above.

### What about the in-game message colours?
Same as above.

### Do you have a filterscript compatible with sscanf1 (old PAWN version)?
Yes, download it [here](https://dl.dropbox.com/u/12901320/releases/RemoteAdmins/remoteadmin2.amx) ([source](https://dl.dropbox.com/u/12901320/releases/RemoteAdmins/remoteadmin2.pwn))

__Note: This is deprecated, it is insecure as pointed out by Y_Less__

### Download Options

- [Installer with automatic updates](http://files.jatochnietdan.com/mirror.php?file=https://dl.dropbox.com/u/12901320/releases/RemoteAdmins/setup.exe) (**Recommended**)
- [Standalone Executable](http://files.jatochnietdan.com/download.php?file=RemoteAdmin_0.2.3.rar)

__Please do not host any mirrors__

[Source](https://dl.dropbox.com/u/12901320/releases/RemoteAdmins/RemoteAdmin_0.2.3_source.rar)

**This is a beta release, please provide feedback! - Thank you :)**
