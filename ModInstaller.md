# Description #

ModInstaller is a plugin for FEd for installing mods with a click.


# Details #

ModInstaller works from an internal folder to get mods, and also (if possible) it connects to our main server to look for available mods. These mods are downloaded and stored for further use. Of course when connected it checks for mod updates too.

ModInstaller uses a separate folder structure for itself, to make sure it won't be messed up by other plugins. And also to store mod info, there is a mod.xml in every separate mod folder, what lists all mod files, names the Author, and stores the version, update link (if applicable) and some description.

Mods can be installed to an open firmware via a mod selection window. If the mod requires further setup, it displays a nice screen what asks for input data (like Bt name mod, or default theme mod).

It DOES include CenRep mods, but just a few basic ones. All further CenRep mods are restricted in the Mod Repository.
