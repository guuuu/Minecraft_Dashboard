using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using System.Drawing.Text;
//DAR FIX AO LOGGING E AO VALOR DO TEMPO A LIMPAR O CHAO QND ALTERADO PELO MINE
namespace Minecraft_Dashboard
{
    public partial class Form1 : Form
    {
        Thread server_thread;
        Thread limpar_chao_thread;
        Thread auto_backup_thread;
        public static Process process;
        public static bool back = true;
        public static bool first = true;
        public static bool logging = true;
        public static int to_sleep = 60000;
        public static Process backup_process;
        public static bool server_status = false;
        public static bool is_doing_backup = false;
        public static int backup_sleep = 12 * 60 * 60 * 1000;
        public static string backup_folder_path = String.Empty;
        public static string server_file = Directory.GetCurrentDirectory().ToString() + "\\Server\\start.bat";
        public static string backup_file = Directory.GetCurrentDirectory().ToString() + "\\Backup\\backup.bat";
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
        IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font myFont;
        public Form1(){ 
            InitializeComponent();
            byte[] fontData = Properties.Resources.MuktaVaani_Regular;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.MuktaVaani_Regular.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.MuktaVaani_Regular.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 16.0F);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            chao_val.Maximum = 60;
            chao_val.Value = 60;
            timer1.Start();
            check_back_status.Start();
            check_logging.Start();
           
            backup_folder_path = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Backup\\backup_folder.ini");
            if (!Directory.Exists(backup_folder_path))
            {
                restore_backup.Enabled = false;
                create_backup.Enabled = false;
            }
            else
            {
                get_backups();
                restore_backup.Enabled = true;
                create_backup.Enabled = true;
            }
            auto_backup_thread = new Thread(new ThreadStart(auto_backup));
            auto_backup_thread.Start();
            auto_backup_thread.IsBackground = true;
            backup_timer.Start();

            styleButtons();

            sv_out.ScrollBars = ScrollBars.Both;
            //sv_out.ScrollBars = ScrollBars.Horizontal;
        }
        private void start_Click(object sender, EventArgs e)
        {
            server_thread = new Thread(new ThreadStart(start_server));
            server_thread.Start();
            server_thread.IsBackground = true;
            server_status = true;
        }
        private void start_server()
        {
            if(first)
                Directory.SetCurrentDirectory(Directory.GetCurrentDirectory().ToString() + "\\Server");
            try
            {
                process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = server_file,
                        Arguments = "",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                Thread thread = new Thread(new ThreadStart(get_output));
                limpar_chao_thread = new Thread(new ThreadStart(limpar_chao));
                thread.Start();
                thread.IsBackground = true;
                Thread.Sleep(20000);
                limpar_chao_thread.Start();
                limpar_chao_thread.IsBackground = true;
            }
            catch(Exception e){ AddLinha($"[CONTROLLER - ERROR] - {e.Message}"); }
        }
        private void get_output()
        {
            while (!process.StandardOutput.EndOfStream)
            {
                try
                {
                    var line = process.StandardOutput.ReadLine();
                    line.Replace("[STDOUT]", "");
                    AddLinha($"[SERVER] - {line}");

                    if (line.ToString().ToUpper().Contains("$SET") && line.ToString().ToUpper().Contains("CLEAR_GROUND="))
                        if(Convert.ToInt32(line.Split('=')[1].ToString()) >= 0 && Convert.ToInt32(line.Split('=')[1].ToString()) <= 60) { 
                            to_sleep = Convert.ToInt32(line.Split('=')[1].ToString()) * 1000;
                            chao_val.Value = to_sleep / 1000;
                            if(logging)
                                send_input("/say O intervalo de tempo para limpar o chao foi alterado para " + to_sleep / 1000 + " segundos");
                            AddLinha("O intervalo de tempo para limpar o chao foi alterado para " + to_sleep / 1000 + " segundos");
                        }
                    if (line.ToLower().Contains("/stop")) server_status = false;
                    if (line.ToLower().Contains("$set") && line.ToLower().Contains("logging"))                    
                        if(line.Split('=')[1] == "0")
                            if (logging) { 
                                logging = false;
                                send_input("/say Valor alterado com sucesso!");
                            }
                            else if (line.Split('=')[1] == "1") { 
                                if (!logging) { 
                                    logging = true;
                                    send_input("/say Valor alterado com sucesso!");
                                }
                            }
                }
                catch (Exception e){ AddLinha($"[ERROR] - {e.Message}"); }
            }
        }
        private void stop_Click(object sender, EventArgs e)
        {
            send_input("/stop");
            server_thread.Abort();
            first = false;
            server_status = false;
        }
        public void AddLinha(String text)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate () { AddLinha(text); });
                return;
            }
            sv_out.AppendText(text + "\r\n");
        }
        private void send_input_bt_Click(object sender, EventArgs e)
        {
            send_input(command.Text);
            if (command.Text.ToLower() == "/stop")
            {
                server_status = false;
                server_thread.Abort();
            }
            if (command.Text.ToLower() == "/start")
            {
                if (!server_status)
                {
                    server_thread = new Thread(new ThreadStart(start_server));
                    server_thread.Start();
                    server_thread.IsBackground = true;
                    server_status = true;
                }
            }
            command.Text = String.Empty;
        }
        private void send_input(string arg){ process.StandardInput.WriteLine(arg); }
        private void command_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter){ 
                send_input(command.Text);
                command.Text = String.Empty;
                if (command.Text.ToLower() == "/stop")
                {
                    server_status = false;
                    server_thread.Abort();
                }
                if (command.Text.ToLower() == "/start")
                {
                    if (!server_status)
                    {
                        server_thread = new Thread(new ThreadStart(start_server));
                        server_thread.Start();
                        server_thread.IsBackground = true;
                        server_status = true;
                    }
                }
            }
        }
        private void cls_Click(object sender, EventArgs e){ sv_out.Text = String.Empty; }
        private void limpar_chao()
        {
            do
            {
                Thread.Sleep(to_sleep / 2);
                if (logging)
                {
                    send_input("/say O chao vai ser limpo dentro de " + ((to_sleep / 1000) / 2).ToString() + " segundos");
                    AddLinha("/say O chao vai ser limpo dentro de " + ((to_sleep / 1000) / 2).ToString() + " segundos");
                }
                Thread.Sleep(to_sleep / 2);

                send_input("/kill @e[type=Item]");
                if (logging) AddLinha("Chão limpo");
            } while (true);
        }
        private void Mudar_valor_limpar_chao_Click(object sender, EventArgs e)
        {
            if(chao_val.Value >= 0 && chao_val.Value <= 60) { 
                to_sleep = chao_val.Value * 1000;
                if (logging)
                    send_input("/say O intervalo de tempo para limpar o chao foi alterado para " + to_sleep / 1000 + " segundos");
                AddLinha("O intervalo de tempo para limpar o chao foi alterado para " + to_sleep / 1000 + " segundos");
            }
        }
        private void set_logging_Click(object sender, EventArgs e)
        {
            if (logging) { 
                set_logging.Text = "Logging - OFF";
                AddLinha("Logging foi desligado!");
                logging = false;
            }
            else { 
                set_logging.Text = "Logging - ON";
                AddLinha("Logging foi ligado!");
                logging = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (server_status)
            {
                stop.Enabled = true;
                start.Enabled = false;
                command.Enabled = true;
                chao_val.Enabled = true;
                set_logging.Enabled = true;
                send_input_bt.Enabled = true;
                server_status_lbl.Text = "Running";
                Mudar_valor_limpar_chao.Enabled = true;
                server_status_lbl.ForeColor = Color.Green;
            }
            else
            {
                stop.Enabled = false;
                start.Enabled = true;
                command.Enabled = false;
                chao_val.Enabled = false;
                set_logging.Enabled = false;
                send_input_bt.Enabled = false;
                server_status_lbl.Text = "Not running";
                Mudar_valor_limpar_chao.Enabled = false;
                server_status_lbl.ForeColor = Color.Red;
            }
        }
        private void chao_val_Scroll(object sender, EventArgs e)
        {
            val_scroll.Text = chao_val.Value.ToString();
        }
        private void get_backups()
        {
            foreach (string file in Directory.GetFiles(backup_folder_path))
            {
                string aux = file.Replace(backup_folder_path + "\\", "");
                if(aux.Contains(".zip") || aux.Contains(".rar") || aux.Contains(".7z"))
                    backup_list.Items.Add(aux);
            }
        }
        private void restore_backup_Click(object sender, EventArgs e)
        {
            bool proceed = true;

            if(backup_list.SelectedIndex.ToString() != "-1") { 
                DialogResult resposta = MessageBox.Show($"ATENÇÃO\nPretende mesmo repor este backup '{backup_list.SelectedItem}' ???", "PERIGO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(resposta == DialogResult.Yes)
                {
                    DialogResult confirmacao = MessageBox.Show($"ATENÇÃO\nTem mesmo a certeza que pretende repor ???", "PERIGO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if(confirmacao == DialogResult.Yes)
                    {
                        if (server_status) { 
                            send_input("/say O servidor vai repor um backup dentro de 5 segundos");
                            Thread.Sleep(5000);
                            send_input("/stop");
                            Thread.Sleep(5000);
                            server_status = false;
                        }

                        try
                        {
                            AddLinha("\n[CONTROLLER] - A preparar para repor o backup....");
                            Directory.Move("world", "world backup before restore");
                        }
                        catch (Exception ex)
                        {
                            AddLinha("[CONTROLLER] - Alguma coisa correu mal a reverter...");
                            AddLinha("[CONTROLLER - ERROR] - " + ex.Message);
                            DialogResult res = MessageBox.Show("Já existe um backup do mundo original antes de ser revertido.\nDeseja eleminar esse mesmo backup?", "Backup existente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if(res == DialogResult.Yes)
                            {
                                Directory.Delete(Directory.GetCurrentDirectory() + "\\world backup before restore", true);
                                proceed = true;
                            }
                            else
                            {
                                proceed = false;
                            }
                        }

                        if (proceed) { 
                            try
                            {
                                AddLinha("[CONTROLLER] - Renomeado o ficheiro atual do mundo....");
                                File.Copy(backup_folder_path + "\\" + backup_list.SelectedItem, Directory.GetCurrentDirectory() + "\\" + backup_list.SelectedItem);
                            }
                            catch (Exception ex)
                            {
                                AddLinha("[CONTROLLER] - Alguma coisa correu mal a reverter...");
                                AddLinha("[CONTROLLER - ERROR] - " + ex.Message);
                                Directory.Move("world backup before restore", "world");
                            }

                            try
                            {
                                AddLinha("[CONTROLLER] - Copiado o backup para a pasta do servidor....");
                                Directory.CreateDirectory("world");
                            }
                            catch (Exception ex)
                            {
                                AddLinha("[CONTROLLER] - Alguma coisa correu mal a reverter...");
                                AddLinha("[CONTROLLER - ERROR] - " + ex.Message);
                                Directory.Move("world backup before restore", "world");
                                File.Delete(Directory.GetCurrentDirectory() + "\\" + backup_list.SelectedItem);
                            }

                            try
                            {
                                AddLinha("[CONTROLLER] - Criado o novo diretorio para os ficheiros do mundo....");
                                ZipFile.ExtractToDirectory(Directory.GetCurrentDirectory() + "\\" + backup_list.SelectedItem, Directory.GetCurrentDirectory() + "\\world");
                            }
                            catch (Exception ex)
                            {
                                AddLinha("[CONTROLLER] - Alguma coisa correu mal a reverter...");
                                AddLinha("[CONTROLLER - ERROR] - " + ex.Message);
                                Directory.Delete("world", true);
                                Directory.Move("world backup before restore", "world");
                                File.Delete(Directory.GetCurrentDirectory() + "\\" + backup_list.SelectedItem);
                            }

                            try
                            {
                                AddLinha("[CONTROLLER] - Ficheiros extraidos com sucesso....");
                                File.Delete(Directory.GetCurrentDirectory() + "\\" + backup_list.SelectedItem);
                            }
                            catch (Exception ex)
                            {
                                AddLinha("[CONTROLLER] - Alguma coisa correu mal a reverter...");
                                AddLinha("[CONTROLLER - ERROR] - " + ex.Message);
                                Directory.Delete("world", true);
                                Directory.Move("world backup before restore", "world");
                                File.Delete(Directory.GetCurrentDirectory() + "\\" + backup_list.SelectedItem);
                            }
                        }

                        Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + "\\..");
                        AddLinha("[CONTROLLER] - Pronto para iniciar o servidor novamente....");
                    }
                }
            }
        }
        private void create_backup_Click(object sender, EventArgs e)
        {
            if (server_status)
            {
                DialogResult res = MessageBox.Show("É necessário desligar o servidor para efetuar o backup.\nPretende desligar?", "Servidor ligado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(res == DialogResult.Yes)
                {
                    DialogResult res2 = MessageBox.Show("Pretende informar os jogadores?", "Informar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(res2 == DialogResult.Yes)
                    {
                        send_input("/say O servidor vai ser desligado para efetuar um backup.");
                        Thread.Sleep(5000);
                    }

                    send_input("/stop");
                    server_thread.Abort();
                    server_status = false;
                    AddLinha("[CONTROLLER] - Servidor parado, a iniciar backup...");
                    Directory.SetCurrentDirectory(backup_file + "\\..");
                    execute_backup();
                    Directory.SetCurrentDirectory(server_file + "\\..");
                }
            }
            else { 
                Directory.SetCurrentDirectory(backup_file + "\\..");
                execute_backup();
                Directory.SetCurrentDirectory(server_file + "\\..");
            }
        }
        private void get_backup_process_output()
        {
            is_doing_backup = true;
            while (!backup_process.StandardOutput.EndOfStream)
            {
                try
                {
                    var line = backup_process.StandardOutput.ReadLine();
                    AddLinha($"[CONTROLLER] - {line}");
                }
                catch (Exception e) { AddLinha($"[ERROR] - {e.Message}"); }
            }

            is_doing_backup = false;
        }
        private void setup_backup_folder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    backup_folder_path = fbd.SelectedPath;
                    File.WriteAllText(backup_file + "\\..\\backup_folder.ini", String.Empty);
                    using (StreamWriter file = new StreamWriter(backup_file + "\\..\\backup_folder.ini", true))
                    {
                        file.Write(fbd.SelectedPath);
                    }
                    if (!Directory.Exists(backup_folder_path))
                    {
                        restore_backup.Enabled = false;
                        create_backup.Enabled = false;
                    }
                    else
                    {
                        backup_list.Items.Clear();
                        get_backups();
                        restore_backup.Enabled = true;
                        create_backup.Enabled = true;
                    }
                }
            }
        }
        private void auto_backup()
        {
            AddLinha("[CONTROLLER] - 12 horas até ao backup");

            Thread.Sleep(11 * 60 * 60 * 1000);
            send_input("/say O servidor vai ser desligado em 1 hora para fazer backup!");
            AddLinha("[CONTROLLER] - 55 minutos até ao backup");

            Thread.Sleep(55 * 60 * 1000);
            send_input("/say O servidor vai ser desligado em 5 minutos para fazer backup!");
            AddLinha("[CONTROLLER] - 4 minutos até ao backup");

            Thread.Sleep(4 * 60 * 1000);
            send_input("/say O servidor vai ser desligado em 1 minuto para fazer backup!");
            AddLinha("[CONTROLLER] - 1 minuto até ao backup");

            Thread.Sleep(1 * 60 * 1000);
            send_input("/say A desligar...");
            AddLinha($"[CONTROLLER] - A desligar o servidor...");
            Thread.Sleep(10 * 1000);
            if (server_status) { 
                send_input("/stop");
                server_thread.Abort();
            }
            Directory.SetCurrentDirectory(backup_file + "\\..");
            execute_backup();
            Directory.SetCurrentDirectory(server_file + "\\..");
        }
        private void execute_backup()
        {
            try
            {
                backup_process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = backup_file,
                        Arguments = "",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                        CreateNoWindow = true
                    }
                };

                backup_process.Start();

                Thread get_out = new Thread(new ThreadStart(get_backup_process_output));
                get_out.Start();
                get_out.IsBackground = true;
            }
            catch (Exception ex) { AddLinha($"[CONTROLLER - ERROR] - {ex.Message}"); }
        }
        private void backup_timer_Tick(object sender, EventArgs e)
        {
            if(backup_sleep - 1000 > 0) { 
                backup_sleep -= 1000;
                time_left_backup_auto.Text = convert_string();
            }
            else
            {
                backup_timer.Stop();
                backup_sleep = 12 * 60 * 60 * 1000;
            }
        }
        private string convert_string()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(backup_sleep);
            return ts.ToString(@"hh\:mm\:ss");
        }
        private void check_back_status_Tick(object sender, EventArgs e)
        {
            //if (is_doing_backup) start.Enabled = false;
            //else start.Enabled = true;
        }
        private void styleButtons()
        {
            start.FlatStyle = FlatStyle.Flat;
            start.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C495FD");
            start.FlatAppearance.BorderSize = 1;

            stop.FlatStyle = FlatStyle.Flat;
            stop.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C495FD");
            stop.FlatAppearance.BorderSize = 1;

            Mudar_valor_limpar_chao.FlatStyle = FlatStyle.Flat;
            Mudar_valor_limpar_chao.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C495FD");
            Mudar_valor_limpar_chao.FlatAppearance.BorderSize = 1;

            cls.FlatStyle = FlatStyle.Flat;
            cls.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C495FD");
            cls.FlatAppearance.BorderSize = 1;

            set_logging.FlatStyle = FlatStyle.Flat;
            set_logging.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C495FD");
            set_logging.FlatAppearance.BorderSize = 1;

            restore_backup.FlatStyle = FlatStyle.Flat;
            restore_backup.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C495FD");
            restore_backup.FlatAppearance.BorderSize = 1;

            create_backup.FlatStyle = FlatStyle.Flat;
            create_backup.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C495FD");
            create_backup.FlatAppearance.BorderSize = 1;

            setup_backup_folder.FlatStyle = FlatStyle.Flat;
            setup_backup_folder.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C495FD");
            setup_backup_folder.FlatAppearance.BorderSize = 1;

            send_input_bt.FlatStyle = FlatStyle.Flat;
            send_input_bt.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#C495FD");
            send_input_bt.FlatAppearance.BorderSize = 1;

            command.BackColor = ColorTranslator.FromHtml("#212121");
        }
        private void start_MouseEnter(object sender, EventArgs e){ start.BackColor = ColorTranslator.FromHtml("#C495FD"); }
        private void start_MouseLeave(object sender, EventArgs e){ start.BackColor = ColorTranslator.FromHtml("#212121"); }
        private void stop_MouseEnter(object sender, EventArgs e){ stop.BackColor = ColorTranslator.FromHtml("#C495FD"); }
        private void stop_MouseLeave(object sender, EventArgs e){ stop.BackColor = ColorTranslator.FromHtml("#212121"); }
        private void cls_MouseEnter(object sender, EventArgs e){ cls.BackColor = ColorTranslator.FromHtml("#C495FD"); }
        private void cls_MouseLeave(object sender, EventArgs e){ cls.BackColor = ColorTranslator.FromHtml("#212121"); }
        private void Mudar_valor_limpar_chao_MouseEnter(object sender, EventArgs e){ Mudar_valor_limpar_chao.BackColor = ColorTranslator.FromHtml("#C495FD"); }
        private void Mudar_valor_limpar_chao_MouseLeave(object sender, EventArgs e){ Mudar_valor_limpar_chao.BackColor = ColorTranslator.FromHtml("#212121"); }
        private void set_logging_MouseEnter(object sender, EventArgs e){ set_logging.BackColor = ColorTranslator.FromHtml("#C495FD"); }
        private void set_logging_MouseLeave(object sender, EventArgs e){ set_logging.BackColor = ColorTranslator.FromHtml("#212121"); }
        private void restore_backup_MouseEnter(object sender, EventArgs e){ restore_backup.BackColor = ColorTranslator.FromHtml("#C495FD"); }
        private void restore_backup_MouseLeave(object sender, EventArgs e){ restore_backup.BackColor = ColorTranslator.FromHtml("#212121"); }
        private void create_backup_MouseEnter(object sender, EventArgs e){ create_backup.BackColor = ColorTranslator.FromHtml("#C495FD"); }
        private void create_backup_MouseLeave(object sender, EventArgs e){ create_backup.BackColor = ColorTranslator.FromHtml("#212121"); }
        private void setup_backup_folder_MouseEnter(object sender, EventArgs e){ setup_backup_folder.BackColor = ColorTranslator.FromHtml("#C495FD"); }
        private void setup_backup_folder_MouseLeave(object sender, EventArgs e){ setup_backup_folder.BackColor = ColorTranslator.FromHtml("#212121"); }
        private void send_input_bt_MouseEnter(object sender, EventArgs e){ send_input_bt.BackColor = ColorTranslator.FromHtml("#C495FD"); }
        private void send_input_bt_MouseLeave(object sender, EventArgs e){ send_input_bt.BackColor = ColorTranslator.FromHtml("#212121"); }
        private void check_logging_Tick(object sender, EventArgs e)
        {
            if (logging)
                set_logging.Text = "Logging - ON";
            else
                set_logging.Text = "Logging - OFF";
        }
    }
}