namespace Minecraft_Dashboard
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sv_out = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.command = new System.Windows.Forms.TextBox();
            this.send_input_bt = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.cls = new System.Windows.Forms.Button();
            this.chao_val = new System.Windows.Forms.TrackBar();
            this.Mudar_valor_limpar_chao = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.val_scroll = new System.Windows.Forms.Label();
            this.set_logging = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.server_status_lbl = new System.Windows.Forms.Label();
            this.backup_list = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.backup_controller = new System.Windows.Forms.GroupBox();
            this.time_left_backup_auto = new System.Windows.Forms.Label();
            this.setup_backup_folder = new System.Windows.Forms.Button();
            this.create_backup = new System.Windows.Forms.Button();
            this.restore_backup = new System.Windows.Forms.Button();
            this.backup_timer = new System.Windows.Forms.Timer(this.components);
            this.check_back_status = new System.Windows.Forms.Timer(this.components);
            this.check_logging = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chao_val)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.backup_controller.SuspendLayout();
            this.SuspendLayout();
            // 
            // sv_out
            // 
            this.sv_out.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.sv_out.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.sv_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sv_out.ForeColor = System.Drawing.Color.White;
            this.sv_out.Location = new System.Drawing.Point(12, 51);
            this.sv_out.Multiline = true;
            this.sv_out.Name = "sv_out";
            this.sv_out.ReadOnly = true;
            this.sv_out.Size = new System.Drawing.Size(1215, 752);
            this.sv_out.TabIndex = 0;
            this.sv_out.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(439, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Consola do servidor";
            // 
            // start
            // 
            this.start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.ForeColor = System.Drawing.Color.White;
            this.start.Location = new System.Drawing.Point(1233, 51);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(260, 52);
            this.start.TabIndex = 2;
            this.start.Text = "Ligar servidor";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            this.start.MouseEnter += new System.EventHandler(this.start_MouseEnter);
            this.start.MouseLeave += new System.EventHandler(this.start_MouseLeave);
            // 
            // command
            // 
            this.command.AcceptsReturn = true;
            this.command.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.command.ForeColor = System.Drawing.Color.White;
            this.command.Location = new System.Drawing.Point(12, 809);
            this.command.MaxLength = 150;
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(1083, 31);
            this.command.TabIndex = 3;
            this.command.KeyUp += new System.Windows.Forms.KeyEventHandler(this.command_KeyUp);
            // 
            // send_input_bt
            // 
            this.send_input_bt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.send_input_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.send_input_bt.ForeColor = System.Drawing.Color.White;
            this.send_input_bt.Location = new System.Drawing.Point(1101, 809);
            this.send_input_bt.Name = "send_input_bt";
            this.send_input_bt.Size = new System.Drawing.Size(126, 31);
            this.send_input_bt.TabIndex = 4;
            this.send_input_bt.Text = "Enviar";
            this.send_input_bt.UseVisualStyleBackColor = true;
            this.send_input_bt.Click += new System.EventHandler(this.send_input_bt_Click);
            this.send_input_bt.MouseEnter += new System.EventHandler(this.send_input_bt_MouseEnter);
            this.send_input_bt.MouseLeave += new System.EventHandler(this.send_input_bt_MouseLeave);
            // 
            // stop
            // 
            this.stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop.ForeColor = System.Drawing.Color.White;
            this.stop.Location = new System.Drawing.Point(1233, 109);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(260, 52);
            this.stop.TabIndex = 5;
            this.stop.Text = "Desligar servidor";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            this.stop.MouseEnter += new System.EventHandler(this.stop_MouseEnter);
            this.stop.MouseLeave += new System.EventHandler(this.stop_MouseLeave);
            // 
            // cls
            // 
            this.cls.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cls.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cls.ForeColor = System.Drawing.Color.White;
            this.cls.Location = new System.Drawing.Point(1233, 167);
            this.cls.Name = "cls";
            this.cls.Size = new System.Drawing.Size(260, 52);
            this.cls.TabIndex = 6;
            this.cls.Text = "Limpar consola";
            this.cls.UseVisualStyleBackColor = true;
            this.cls.Click += new System.EventHandler(this.cls_Click);
            this.cls.MouseEnter += new System.EventHandler(this.cls_MouseEnter);
            this.cls.MouseLeave += new System.EventHandler(this.cls_MouseLeave);
            // 
            // chao_val
            // 
            this.chao_val.LargeChange = 1;
            this.chao_val.Location = new System.Drawing.Point(8, 73);
            this.chao_val.Name = "chao_val";
            this.chao_val.Size = new System.Drawing.Size(244, 45);
            this.chao_val.TabIndex = 7;
            this.chao_val.Value = 1;
            this.chao_val.Scroll += new System.EventHandler(this.chao_val_Scroll);
            // 
            // Mudar_valor_limpar_chao
            // 
            this.Mudar_valor_limpar_chao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mudar_valor_limpar_chao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mudar_valor_limpar_chao.ForeColor = System.Drawing.Color.White;
            this.Mudar_valor_limpar_chao.Location = new System.Drawing.Point(8, 124);
            this.Mudar_valor_limpar_chao.Name = "Mudar_valor_limpar_chao";
            this.Mudar_valor_limpar_chao.Size = new System.Drawing.Size(246, 52);
            this.Mudar_valor_limpar_chao.TabIndex = 8;
            this.Mudar_valor_limpar_chao.Text = "Aplicar";
            this.Mudar_valor_limpar_chao.UseVisualStyleBackColor = true;
            this.Mudar_valor_limpar_chao.Click += new System.EventHandler(this.Mudar_valor_limpar_chao_Click);
            this.Mudar_valor_limpar_chao.MouseEnter += new System.EventHandler(this.Mudar_valor_limpar_chao_MouseEnter);
            this.Mudar_valor_limpar_chao.MouseLeave += new System.EventHandler(this.Mudar_valor_limpar_chao_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 40);
            this.label2.TabIndex = 9;
            this.label2.Text = "Intervalo de tempo para limpar\r\no chão";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.val_scroll);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chao_val);
            this.groupBox1.Controls.Add(this.Mudar_valor_limpar_chao);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(1233, 225);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 182);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controlo de items";
            // 
            // val_scroll
            // 
            this.val_scroll.AutoSize = true;
            this.val_scroll.Location = new System.Drawing.Point(235, 105);
            this.val_scroll.Name = "val_scroll";
            this.val_scroll.Size = new System.Drawing.Size(19, 13);
            this.val_scroll.TabIndex = 10;
            this.val_scroll.Text = "60";
            // 
            // set_logging
            // 
            this.set_logging.Cursor = System.Windows.Forms.Cursors.Hand;
            this.set_logging.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.set_logging.ForeColor = System.Drawing.Color.White;
            this.set_logging.Location = new System.Drawing.Point(1233, 413);
            this.set_logging.Name = "set_logging";
            this.set_logging.Size = new System.Drawing.Size(260, 52);
            this.set_logging.TabIndex = 11;
            this.set_logging.Text = "Logging - ON";
            this.set_logging.UseVisualStyleBackColor = true;
            this.set_logging.Click += new System.EventHandler(this.set_logging_Click);
            this.set_logging.MouseEnter += new System.EventHandler(this.set_logging_MouseEnter);
            this.set_logging.MouseLeave += new System.EventHandler(this.set_logging_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Server status: ";
            // 
            // server_status_lbl
            // 
            this.server_status_lbl.AutoSize = true;
            this.server_status_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server_status_lbl.Location = new System.Drawing.Point(133, 25);
            this.server_status_lbl.Name = "server_status_lbl";
            this.server_status_lbl.Size = new System.Drawing.Size(91, 20);
            this.server_status_lbl.TabIndex = 13;
            this.server_status_lbl.Text = "Not running";
            // 
            // backup_list
            // 
            this.backup_list.ForeColor = System.Drawing.Color.Black;
            this.backup_list.FormattingEnabled = true;
            this.backup_list.Location = new System.Drawing.Point(8, 39);
            this.backup_list.Name = "backup_list";
            this.backup_list.Size = new System.Drawing.Size(246, 121);
            this.backup_list.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Últimos backups";
            // 
            // backup_controller
            // 
            this.backup_controller.Controls.Add(this.time_left_backup_auto);
            this.backup_controller.Controls.Add(this.setup_backup_folder);
            this.backup_controller.Controls.Add(this.create_backup);
            this.backup_controller.Controls.Add(this.restore_backup);
            this.backup_controller.Controls.Add(this.label4);
            this.backup_controller.Controls.Add(this.backup_list);
            this.backup_controller.ForeColor = System.Drawing.Color.White;
            this.backup_controller.Location = new System.Drawing.Point(1233, 471);
            this.backup_controller.Name = "backup_controller";
            this.backup_controller.Size = new System.Drawing.Size(260, 369);
            this.backup_controller.TabIndex = 16;
            this.backup_controller.TabStop = false;
            this.backup_controller.Text = "Controlo de backups";
            // 
            // time_left_backup_auto
            // 
            this.time_left_backup_auto.AutoSize = true;
            this.time_left_backup_auto.Location = new System.Drawing.Point(203, 21);
            this.time_left_backup_auto.Name = "time_left_backup_auto";
            this.time_left_backup_auto.Size = new System.Drawing.Size(49, 13);
            this.time_left_backup_auto.TabIndex = 19;
            this.time_left_backup_auto.Text = "00:00:00";
            // 
            // setup_backup_folder
            // 
            this.setup_backup_folder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setup_backup_folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setup_backup_folder.ForeColor = System.Drawing.Color.White;
            this.setup_backup_folder.Location = new System.Drawing.Point(10, 282);
            this.setup_backup_folder.Name = "setup_backup_folder";
            this.setup_backup_folder.Size = new System.Drawing.Size(242, 81);
            this.setup_backup_folder.TabIndex = 18;
            this.setup_backup_folder.Text = "Definir pasta de Backups";
            this.setup_backup_folder.UseVisualStyleBackColor = true;
            this.setup_backup_folder.Click += new System.EventHandler(this.setup_backup_folder_Click);
            this.setup_backup_folder.MouseEnter += new System.EventHandler(this.setup_backup_folder_MouseEnter);
            this.setup_backup_folder.MouseLeave += new System.EventHandler(this.setup_backup_folder_MouseLeave);
            // 
            // create_backup
            // 
            this.create_backup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.create_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create_backup.ForeColor = System.Drawing.Color.White;
            this.create_backup.Location = new System.Drawing.Point(8, 224);
            this.create_backup.Name = "create_backup";
            this.create_backup.Size = new System.Drawing.Size(246, 52);
            this.create_backup.TabIndex = 17;
            this.create_backup.Text = "Criar backup";
            this.create_backup.UseVisualStyleBackColor = true;
            this.create_backup.Click += new System.EventHandler(this.create_backup_Click);
            this.create_backup.MouseEnter += new System.EventHandler(this.create_backup_MouseEnter);
            this.create_backup.MouseLeave += new System.EventHandler(this.create_backup_MouseLeave);
            // 
            // restore_backup
            // 
            this.restore_backup.BackColor = System.Drawing.Color.Transparent;
            this.restore_backup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restore_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restore_backup.ForeColor = System.Drawing.Color.White;
            this.restore_backup.Location = new System.Drawing.Point(8, 166);
            this.restore_backup.Name = "restore_backup";
            this.restore_backup.Size = new System.Drawing.Size(246, 52);
            this.restore_backup.TabIndex = 16;
            this.restore_backup.Text = "Repor backup";
            this.restore_backup.UseVisualStyleBackColor = false;
            this.restore_backup.Click += new System.EventHandler(this.restore_backup_Click);
            this.restore_backup.MouseEnter += new System.EventHandler(this.restore_backup_MouseEnter);
            this.restore_backup.MouseLeave += new System.EventHandler(this.restore_backup_MouseLeave);
            // 
            // backup_timer
            // 
            this.backup_timer.Interval = 1000;
            this.backup_timer.Tick += new System.EventHandler(this.backup_timer_Tick);
            // 
            // check_back_status
            // 
            this.check_back_status.Interval = 1000;
            this.check_back_status.Tick += new System.EventHandler(this.check_back_status_Tick);
            // 
            // check_logging
            // 
            this.check_logging.Interval = 1000;
            this.check_logging.Tick += new System.EventHandler(this.check_logging_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1497, 857);
            this.Controls.Add(this.backup_controller);
            this.Controls.Add(this.server_status_lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.set_logging);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cls);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.send_input_bt);
            this.Controls.Add(this.command);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sv_out);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft dashboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chao_val)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.backup_controller.ResumeLayout(false);
            this.backup_controller.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sv_out;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox command;
        private System.Windows.Forms.Button send_input_bt;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button cls;
        private System.Windows.Forms.TrackBar chao_val;
        private System.Windows.Forms.Button Mudar_valor_limpar_chao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button set_logging;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label server_status_lbl;
        private System.Windows.Forms.Label val_scroll;
        private System.Windows.Forms.ListBox backup_list;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox backup_controller;
        private System.Windows.Forms.Button restore_backup;
        private System.Windows.Forms.Button create_backup;
        private System.Windows.Forms.Button setup_backup_folder;
        private System.Windows.Forms.Label time_left_backup_auto;
        private System.Windows.Forms.Timer backup_timer;
        private System.Windows.Forms.Timer check_back_status;
        private System.Windows.Forms.Timer check_logging;
    }
}

