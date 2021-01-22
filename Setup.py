import re
import os
import sys
import shutil
import psutil
import os, winshell
import tkinter as tk
from tkinter import filedialog
from win32com.client import Dispatch

def main():
    original_path = os.path.join(os.getcwd(), "bin\\Debug")
    os.chdir(original_path)
    root = tk.Tk()
    root.withdraw()
    dirname = filedialog.askdirectory(parent=root, initialdir="/", title='Por favor selecione o local para configurar o painel de controlo do servidor')

    print("Pasta selecionada com sucesso!")
    print("A copiar os ficheiros")

    if not os.path.exists(os.path.join(dirname, "Minecraft server dashboard")):
        os.mkdir(os.path.join(dirname, "Minecraft server dashboard"))
    else:
        input("Já existe uma pasta com o nome Minecraft server dashboard, por favor elimine antes de continuar ou escolha outro diretorio.")
        sys.exit(0)

    folder = os.path.join(dirname, "Minecraft server dashboard")

    shutil.copytree(os.path.join(os.getcwd(), "Backup"), os.path.join(folder, "Backup"))
    shutil.copy(os.path.join(os.getcwd(), "Minecraft Dashboard.exe"), folder)
    os.mkdir(os.path.join(folder, "Server"))
    
    while True:
        try:
            mb = int(input("Quantos gb pretende dedicar ao servidor? ->")) * 1024

            if(mb * 1024 >= 1 * 1024 * 1024 and mb * 1024 < int(str(psutil.virtual_memory().total))):
                os.chdir(os.path.join(os.getcwd(), "Server"))
                client_server_file = filedialog.askopenfile(parent=root, initialdir="/", title="Selecione o ficheiro de servidor do minecraft")
                client_server_file_name = str(client_server_file.name).split("/")[len(str(client_server_file.name).split("/")) - 1]
                with open(os.path.join(folder, os.path.join("Server", "start.bat")), "w", encoding="utf-8") as f:
                    f.write(f"java -Xmx{str(mb).strip()}M -Xms{str(mb).strip()}M -jar {str(client_server_file_name).strip()} nogui")
                shutil.copy(client_server_file.name, os.path.join(folder, "Server"))
                os.chdir(os.path.join(folder, "Server"))
                print("Ignore os erros que se seguem, os mesmos devem-se aos termos e condições, pode ler os mesmos aqui: https://account.mojang.com/documents/minecraft_eula")
                os.system(f"java -Xmx{str(mb).strip()}M -Xms{str(mb).strip()}M -jar {str(client_server_file_name).strip()} nogui")
                with open(os.path.join(os.getcwd(), "eula.txt"), "r+", encoding="utf-8") as eula:
                    text = eula.read()
                    text = re.sub('false', 'true', text)
                    eula.seek(0)
                    eula.write(text)
                    eula.truncate()

                path = os.path.join("C:", os.path.join(os.path.join(os.environ["HOMEPATH"], "Desktop"), "Minecraft server dashboard.lnk"))
                target = os.path.join(original_path, "Minecraft Dashboard.exe")
                work_dir = original_path

                shell = Dispatch('WScript.Shell')
                shortcut = shell.CreateShortCut(path)
                shortcut.Targetpath = target
                shortcut.WorkingDirectory = work_dir
                shortcut.save()                
                break
            else:
                print(f"Tem de dicar pelo menos 1GB de RAM ao servidor, e não pode dedicar mais do que a memória que tem disponivel {psutil.virtual_memory()/1024/1024}")
        except Exception as ex:
            print(ex)

    print("Tudo pronto, pode abrir o painel de controlo e terminar a sua configuração")

if __name__ == "__main__":
    main()