# Description #

Central Repository (or CenRep for short) is the main settings container on Symbian.
It is found under !:\Private\10202be9\, and consist of all txt and cre files found in these folders. Usually a CenRep file defines factory settings of the phone, like the background image after hard reset, or the theme UID after hard reset, or disabled menu points all over the system, and even search paths for built-in applications.


Third party apps usually can't access CenRep for writing (although they can read it).


# Usage #

We can use CenRep files for a lot of things:
  * Create personalized firmwares
  * Modify system values
  * Change system appearance and behavior
  * Enable disabled functions


# File structure #

A CenRep file consists of a header and a body part.
The header part defines the cenrep version, the owner UID (the application what gets modified by it) and some metadata, platform security and so on.

```

cenrep
version 1 # defining file and version
[owner]
0x10275102 # setting up the owner's UID
[defaultmeta]
 16777216 # some default metadata and further UID's to be affected
0x00000101 0x000001ff 16777216
[platsec]
 cap_rd=alwayspass # set up read (RD) value for base UID
0x00000101 0x000001ff cap_rd=alwayspass cap_wr=WriteDeviceData # set up read and write capabilities for the secondary UIDs.

```

As you can see, some values are defined by textual way (cenrep |version 1) and some are defined by tags ([platsec](platsec.md)).


The body part contains the real modification stuff. It is based on hex coordinates, and most of the time there is no description of the value, like what it affects. We can only guess sometimes, by looking at the owner UID in the header.


```
[Main]
0x100 int 271012082 16777216 cap_rd=alwayspass cap_wr=WriteDeviceData
0x101 int 271012084 16777216 cap_rd=alwayspass cap_wr=WriteDeviceData
0x200 int 0 16777216 cap_rd=alwayspass cap_wr=WriteDeviceData
0x300 int 164 0 cap_rd=alwayspass cap_wr=alwaysfail
0x301 int 133 0 cap_rd=alwayspass cap_wr=alwaysfail
0x302 int -1 0 cap_rd=alwayspass cap_wr=alwaysfail
0x303 int 1500 0 cap_rd=alwayspass cap_wr=alwaysfail
0x304 int 165 0 cap_rd=alwayspass cap_wr=alwaysfail
0x305 int 600 0 cap_rd=alwayspass cap_wr=alwaysfail
0x400 int 0 0 cap_rd=alwayspass cap_wr=alwaysfail
0x500 int 1 0 cap_rd=alwayspass cap_wr=alwaysfail
0x600 int 1 16777216 cap_rd=alwayspass cap_wr=WriteDeviceData
0x700 int 0 0 cap_rd=alwayspass cap_wr=alwaysfail
0x800 int 0 16777216 cap_rd=alwayspass cap_wr=WriteDeviceData
0x900 string "" 0 cap_rd=alwayspass cap_wr=WriteDeviceData
0x1000 string "Settings/Shortcut" 0 cap_rd=alwayspass cap_wr=alwaysfail
0x1001 string "0x00000001" 0 cap_rd=alwayspass cap_wr=alwaysfail
0x1002 string "localapp:0x102072c3" 0 cap_rd=alwayspass cap_wr=alwaysfail
0x1003 string "Settings/Shortcut" 0 cap_rd=alwayspass cap_wr=alwaysfail
0x1004 string "0x00000002" 0 cap_rd=alwayspass cap_wr=alwaysfail
0x1005 string "localapp:0x100058c5" 0 cap_rd=alwayspass cap_wr=alwaysfail

```

As you can see, the body part begins with the [Main](Main.md) tag, so it is extremely easy to divide them into two.

Then there are two types of values represented here: the int and the string.
int can contain any number
string can contain any text

Usually int is the way to disable an option (0 value) or define an UID, and string is used for translate-able stuff and paths.