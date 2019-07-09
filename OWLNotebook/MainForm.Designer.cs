namespace OWLNotebook
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.fieldMainMenu = new System.Windows.Forms.MenuStrip();
			this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.menuLoad = new System.Windows.Forms.ToolStripMenuItem();
			this.menuImport = new System.Windows.Forms.ToolStripMenuItem();
			this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
			this.menuAgents = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOpenAgentsDictionary = new System.Windows.Forms.ToolStripMenuItem();
			this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripCreateDate = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.fieldPriority = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.fieldSubj = new System.Windows.Forms.TextBox();
			this.fieldEventDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.fieldDescription = new System.Windows.Forms.RichTextBox();
			this.GridRecords = new OWLNotebook.Conrols.DataGrid();
			this.GridAgents = new OWLNotebook.Conrols.DataGrid();
			this.fieldMainMenu.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// fieldMainMenu
			// 
			this.fieldMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuAgents,
            this.menuHelp});
			this.fieldMainMenu.Location = new System.Drawing.Point(0, 0);
			this.fieldMainMenu.Name = "fieldMainMenu";
			this.fieldMainMenu.Size = new System.Drawing.Size(968, 24);
			this.fieldMainMenu.TabIndex = 0;
			this.fieldMainMenu.Text = "Меню";
			// 
			// menuFile
			// 
			this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSave,
            this.menuLoad,
            this.menuImport,
            this.menuExport});
			this.menuFile.Name = "menuFile";
			this.menuFile.Size = new System.Drawing.Size(48, 20);
			this.menuFile.Text = "Файл";
			// 
			// menuSave
			// 
			this.menuSave.Name = "menuSave";
			this.menuSave.Size = new System.Drawing.Size(163, 22);
			this.menuSave.Text = "Сохранить";
			this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
			// 
			// menuLoad
			// 
			this.menuLoad.Name = "menuLoad";
			this.menuLoad.Size = new System.Drawing.Size(163, 22);
			this.menuLoad.Text = "Загрузить";
			this.menuLoad.Click += new System.EventHandler(this.menuLoad_Click);
			// 
			// menuImport
			// 
			this.menuImport.Name = "menuImport";
			this.menuImport.Size = new System.Drawing.Size(163, 22);
			this.menuImport.Text = "Импортировать";
			this.menuImport.Click += new System.EventHandler(this.menuImport_Click);
			// 
			// menuExport
			// 
			this.menuExport.Name = "menuExport";
			this.menuExport.Size = new System.Drawing.Size(163, 22);
			this.menuExport.Text = "Экспортировать";
			this.menuExport.Click += new System.EventHandler(this.menuExport_Click);
			// 
			// menuAgents
			// 
			this.menuAgents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenAgentsDictionary});
			this.menuAgents.Name = "menuAgents";
			this.menuAgents.Size = new System.Drawing.Size(90, 20);
			this.menuAgents.Text = "Контрагенты";
			// 
			// menuOpenAgentsDictionary
			// 
			this.menuOpenAgentsDictionary.Name = "menuOpenAgentsDictionary";
			this.menuOpenAgentsDictionary.Size = new System.Drawing.Size(190, 22);
			this.menuOpenAgentsDictionary.Text = "Открыть справочник";
			this.menuOpenAgentsDictionary.Click += new System.EventHandler(this.OpenAgentsDictionary_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.Name = "menuHelp";
			this.menuHelp.Size = new System.Drawing.Size(65, 20);
			this.menuHelp.Text = "Справка";
			this.menuHelp.Click += new System.EventHandler(this.menuHelp_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCreateDate});
			this.statusStrip1.Location = new System.Drawing.Point(0, 600);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(968, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripCreateDate
			// 
			this.toolStripCreateDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripCreateDate.Enabled = false;
			this.toolStripCreateDate.Name = "toolStripCreateDate";
			this.toolStripCreateDate.Size = new System.Drawing.Size(73, 17);
			this.toolStripCreateDate.Text = "Дата записи";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.GridRecords);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(968, 576);
			this.splitContainer1.SplitterDistance = 299;
			this.splitContainer1.TabIndex = 3;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.buttonCancel);
			this.splitContainer2.Panel1.Controls.Add(this.buttonSave);
			this.splitContainer2.Panel1.Controls.Add(this.fieldPriority);
			this.splitContainer2.Panel1.Controls.Add(this.label3);
			this.splitContainer2.Panel1.Controls.Add(this.label2);
			this.splitContainer2.Panel1.Controls.Add(this.fieldSubj);
			this.splitContainer2.Panel1.Controls.Add(this.fieldEventDate);
			this.splitContainer2.Panel1.Controls.Add(this.label1);
			this.splitContainer2.Panel1.Controls.Add(this.fieldDescription);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.GridAgents);
			this.splitContainer2.Size = new System.Drawing.Size(665, 576);
			this.splitContainer2.SplitterDistance = 434;
			this.splitContainer2.TabIndex = 0;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Enabled = false;
			this.buttonCancel.Location = new System.Drawing.Point(497, 40);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 8;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonSave
			// 
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(578, 40);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 7;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			// 
			// fieldPriority
			// 
			this.fieldPriority.Location = new System.Drawing.Point(328, 41);
			this.fieldPriority.Name = "fieldPriority";
			this.fieldPriority.ReadOnly = true;
			this.fieldPriority.Size = new System.Drawing.Size(48, 20);
			this.fieldPriority.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(258, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Приоритет:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Заголовок:";
			// 
			// fieldSubj
			// 
			this.fieldSubj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fieldSubj.Location = new System.Drawing.Point(105, 13);
			this.fieldSubj.Name = "fieldSubj";
			this.fieldSubj.ReadOnly = true;
			this.fieldSubj.Size = new System.Drawing.Size(548, 20);
			this.fieldSubj.TabIndex = 3;
			// 
			// fieldEventDate
			// 
			this.fieldEventDate.CustomFormat = "d.MM.yyyy HH:m";
			this.fieldEventDate.Enabled = false;
			this.fieldEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.fieldEventDate.Location = new System.Drawing.Point(105, 41);
			this.fieldEventDate.Name = "fieldEventDate";
			this.fieldEventDate.Size = new System.Drawing.Size(147, 20);
			this.fieldEventDate.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Дата события:";
			// 
			// fieldDescription
			// 
			this.fieldDescription.BackColor = System.Drawing.SystemColors.Control;
			this.fieldDescription.Location = new System.Drawing.Point(0, 67);
			this.fieldDescription.Name = "fieldDescription";
			this.fieldDescription.ReadOnly = true;
			this.fieldDescription.Size = new System.Drawing.Size(665, 367);
			this.fieldDescription.TabIndex = 0;
			this.fieldDescription.Text = "";
			// 
			// GridRecords
			// 
			this.GridRecords.AllowDrop = true;
			this.GridRecords.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridRecords.Location = new System.Drawing.Point(0, 0);
			this.GridRecords.Name = "GridRecords";
			this.GridRecords.ShowUpdateBtn = false;
			this.GridRecords.Size = new System.Drawing.Size(299, 576);
			this.GridRecords.TabIndex = 0;
			this.GridRecords.VisibleColumns = null;
			// 
			// GridAgents
			// 
			this.GridAgents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridAgents.Location = new System.Drawing.Point(0, 0);
			this.GridAgents.Name = "GridAgents";
			this.GridAgents.ShowUpdateBtn = false;
			this.GridAgents.Size = new System.Drawing.Size(665, 138);
			this.GridAgents.TabIndex = 0;
			this.GridAgents.VisibleColumns = null;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(968, 622);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.fieldMainMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.fieldMainMenu;
			this.Name = "MainForm";
			this.Text = "OWL Записная книжка";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.fieldMainMenu.ResumeLayout(false);
			this.fieldMainMenu.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip fieldMainMenu;
		private System.Windows.Forms.ToolStripMenuItem menuFile;
		private System.Windows.Forms.ToolStripMenuItem menuSave;
		private System.Windows.Forms.ToolStripMenuItem menuLoad;
		private System.Windows.Forms.ToolStripMenuItem menuImport;
		private System.Windows.Forms.ToolStripMenuItem menuAgents;
		private System.Windows.Forms.ToolStripMenuItem menuOpenAgentsDictionary;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private Conrols.DataGrid GridRecords;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.RichTextBox fieldDescription;
		private Conrols.DataGrid GridAgents;
		private System.Windows.Forms.DateTimePicker fieldEventDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox fieldSubj;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox fieldPriority;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripCreateDate;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.ToolStripMenuItem menuExport;
		private System.Windows.Forms.ToolStripMenuItem menuHelp;
	}
}

