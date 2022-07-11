import os
import glob
import shutil
import filecmp

### FILE CONFIG ###
Unturned_Server_Path = "F:\\SteamCMD\\steamapps\\common\\U3DS"
Project_Path = "E:\\Plugins\\PluginExemple\\Librairies"
###################

all_dlls = glob.glob(Unturned_Server_Path+"\\Unturned_Data\\Managed\\*dll")+glob.glob(Unturned_Server_Path+"\\Extras\\Rocket.Unturned\\*dll")

dst = Project_Path

my_dlls = glob.glob(dst+"/*.dll")

all_dlls_names = [dll.split('\\')[-1] for dll in all_dlls]
my_dlls_names = [dll.split('\\')[-1] for dll in my_dlls]

need_dlls = []

for dll_name in all_dlls_names:
    if dll_name in my_dlls_names:
        need_dlls.append([
            all_dlls[all_dlls_names.index(dll_name)],
            my_dlls[my_dlls_names.index(dll_name)]
            ])

liste_maj = []

maj = False
for need_dll in need_dlls:
    if not filecmp.cmp(need_dll[0],need_dll[1]):
        name = os.path.abspath(need_dll[0]).split("\\")[-1]
        liste_maj.append(name)
        maj = True



if maj:
    print("Ces dlls :")
    for dll_maj in liste_maj:
        print(f'> {dll_maj}')
    choix = input("peuvent être mise à jours\n Mettre à jour ? [y/n]\n>")
    if choix == "y" or "Y":
        for need_dll in need_dlls:
            if not filecmp.cmp(need_dll[0],need_dll[1]):
                full_path = os.path.abspath(need_dll[0])
                name = full_path.split("\\")[-1]
                shutil.copy(full_path,dst)
                print(f'{name} mis à jour')
else:
    print("aucune maj trouvé")


input("--END--")
            



