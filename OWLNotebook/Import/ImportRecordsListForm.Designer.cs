namespace OWLNotebook.Import
{
	partial class ImportRecordsListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportRecordsListForm));
			this.panelBottom = new System.Windows.Forms.Panel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonImport = new System.Windows.Forms.Button();
			this.panelTop = new System.Windows.Forms.Panel();
			this.buttonGetPath = new System.Windows.Forms.Button();
			this.fieldImportPath = new System.Windows.Forms.TextBox();
			this.fieldIsDateCreated = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.fieldDateTo = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.fieldDateFrom = new System.Windows.Forms.DateTimePicker();
			this.GridRecords = new OWLNotebook.Conrols.DataGrid();
			this.panelBottom.SuspendLayout();
			this.panelTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelBottom
			// 
			this.panelBottom.Controls.Add(this.buttonCancel);
			this.panelBottom.Controls.Add(this.buttonImport);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelBottom.Location = new System.Drawing.Point(0, 415);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(800, 35);
			this.panelBottom.TabIndex = 8;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(641, 6);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonImport
			// 
			this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonImport.Enabled = false;
			this.buttonImport.Location = new System.Drawing.Point(722, 6);
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new System.Drawing.Size(75, 23);
			this.buttonImport.TabIndex = 0;
			this.buttonImport.Text = "Импорт";
			this.buttonImport.UseVisualStyleBackColor = true;
			this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.buttonGetPath);
			this.panelTop.Controls.Add(this.fieldImportPath);
			this.panelTop.Controls.Add(this.fieldIsDateCreated);
			this.panelTop.Controls.Add(this.label2);
			this.panelTop.Controls.Add(this.fieldDateTo);
			this.panelTop.Controls.Add(this.label1);
			this.panelTop.Controls.Add(this.fieldDateFrom);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(800, 38);
			this.panelTop.TabIndex = 7;
			// 
			// buttonGetPath
			// 
			this.buttonGetPath.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetPath.Image")));
			this.buttonGetPath.Location = new System.Drawing.Point(767, 8);
			this.buttonGetPath.Name = "buttonGetPath";
			this.buttonGetPath.Size = new System.Drawing.Size(28, 20);
			this.buttonGetPath.TabIndex = 7;
			this.buttonGetPath.UseVisualStyleBackColor = true;
			this.buttonGetPath.Click += new System.EventHandler(this.buttonGetPath_Click);
			// 
			// fieldImportPath
			// 
			this.fieldImportPath.Location = new System.Drawing.Point(567, 8);
			this.fieldImportPath.Name = "fieldImportPath";
			this.fieldImportPath.ReadOnly = true;
			this.fieldImportPath.Size = new System.Drawing.Size(200, 20);
			this.fieldImportPath.TabIndex = 6;
			// 
			// fieldIsDateCreated
			// 
			this.fieldIsDateCreated.AutoSize = true;
			this.fieldIsDateCreated.Checked = true;
			this.fieldIsDateCreated.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fieldIsDateCreated.Location = new System.Drawing.Point(344, 10);
			this.fieldIsDateCreated.Name = "fieldIsDateCreated";
			this.fieldIsDateCreated.Size = new System.Drawing.Size(105, 17);
			this.fieldIsDateCreated.TabIndex = 5;
			this.fieldIsDateCreated.Text = "По дате записи";
			this.fieldIsDateCreated.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(171, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "По:";
			// 
			// fieldDateTo
			// 
			this.fieldDateTo.Location = new System.Drawing.Point(201, 8);
			this.fieldDateTo.Name = "fieldDateTo";
			this.fieldDateTo.Size = new System.Drawing.Size(126, 20);
			this.fieldDateTo.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(17, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "С:";
			// 
			// fieldDateFrom
			// 
			this.fieldDateFrom.Location = new System.Drawing.Point(35, 8);
			this.fieldDateFrom.Name = "fieldDateFrom";
			this.fieldDateFrom.Size = new System.Drawing.Size(126, 20);
			this.fieldDateFrom.TabIndex = 1;
			// 
			// GridRecords
			// 
			this.GridRecords.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridRecords.Location = new System.Drawing.Point(0, 38);
			this.GridRecords.Name = "GridRecords";
			this.GridRecords.ShowAddBtn = false;
			this.GridRecords.ShowDeleteBtn = false;
			this.GridRecords.ShowEditBtn = false;
			this.GridRecords.ShowUpdateBtn = false;
			this.GridRecords.Size = new System.Drawing.Size(800, 377);
			this.GridRecords.TabIndex = 9;
			this.GridRecords.VisibleColumns = null;
			// 
			// ImportRecordsListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.GridRecords);
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.panelTop);
			this.Name = "ImportRecordsListForm";
			this.Text = "Импорт в БД";
			this.panelBottom.ResumeLayout(false);
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonImport;
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Button buttonGetPath;
		private System.Windows.Forms.TextBox fieldImportPath;
		private System.Windows.Forms.CheckBox fieldIsDateCreated;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker fieldDateTo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker fieldDateFrom;
		private Conrols.DataGrid GridRecords;
	}
}