import os
import sys
import shutil
from datetime import datetime, date

doc_path = f"C:\\Users\\{os.getlogin()}\\Documents\\Server Backups"

def main():
    global backup_folder_path
    with open(os.path.join(os.getcwd(), "backup_folder.ini"), "r", encoding="utf-8") as f:
        backup_folder_path = f.readline()

    if not os.path.exists(doc_path):
        os.mkdir(doc_path)
        print("Created the folder for backups!")
        sys.stdout.flush()
        backup()
    else:
        print("Folder is already created, starting the backup!")
        sys.stdout.flush()
        backup()

def backup():
    global folder_name, location
    location = os.getcwd() + "\\..\\Server"
    print("Backup started...")
    sys.stdout.flush()
    folder_name = "world " + str(datetime.now()).split(".")[0].replace(":","-")
    shutil.copytree(location + "\\world", doc_path + "\\" + folder_name)
    print("Backup finished, starting to zip the folder...")
    sys.stdout.flush()
    zip_n_upload()

def zip_n_upload():
    print("Starting to zip the content...")
    sys.stdout.flush()
    os.chdir(doc_path)
    shutil.make_archive(folder_name, "zip", os.path.join(doc_path, folder_name))
    print("Content finished getting zipped, starting upload to cloud...")
    sys.stdout.flush()
    sync()

def sync():
    print("Sending folder to the drive...")
    sys.stdout.flush()
    shutil.copy(os.path.join(doc_path, folder_name) + ".zip", backup_folder_path)
    print("Folder is done copying...")
    sys.stdout.flush()
    check_files()

def check_files():
    files = os.listdir(path=backup_folder_path) 

    most_recent_full_date = files[len(files) - 1].split(" ")[1].split("-")
    d2 = date(int(most_recent_full_date[0]), int(most_recent_full_date[1]), int(most_recent_full_date[2]))

    for file in files:
        try:
            full_date = file.split(" ")[1].split("-")
            d = date(int(full_date[0]), int(full_date[1]), int(full_date[2]))
            aux = d2 - d
            if aux.days >= 3:
                os.remove(path=os.path.join(backup_folder_path, file))
                print(f"Deleted backup {file} it was {aux.days} days old!")
                sys.stdout.flush()
        except:
            pass

    to_delete = os.listdir(path=doc_path)

    for f in to_delete:
        try:
            folder = os.path.join(doc_path, f)
            for filename in os.listdir(folder):
                file_path = os.path.join(folder, filename)
                try:
                    if os.path.isfile(file_path) or os.path.islink(file_path):
                        os.unlink(file_path)
                    elif os.path.isdir(file_path):
                        shutil.rmtree(file_path)
                except Exception as e:
                    print('Failed to delete %s. Reason: %s' % (file_path, e))

            for f in os.listdir(path=doc_path):
                os.rmdir(os.path.join(doc_path, f))
        except:
            try:
                os.remove(path=os.path.join(doc_path, f))
            except:
                pass

if __name__ == "__main__":
    main()