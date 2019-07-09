namespace OWLNotebook.Export
{
	partial class ExportRecordsListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportRecordsListForm));
			this.panelBottom = new System.Windows.Forms.Panel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonExport = new System.Windows.Forms.Button();
			this.panelTop = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.fieldExportPatch = new System.Windows.Forms.TextBox();
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
			this.panelBottom.Controls.Add(this.buttonExport);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelBottom.Location = new System.Drawing.Point(0, 415);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(800, 35);
			this.panelBottom.TabIndex = 4;
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
			// buttonExport
			// 
			this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExport.Enabled = false;
			this.buttonExport.Location = new System.Drawing.Point(722, 6);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(75, 23);
			this.buttonExport.TabIndex = 0;
			this.buttonExport.Text = "Экспорт";
			this.buttonExport.UseVisualStyleBackColor = true;
			this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.button1);
			this.panelTop.Controls.Add(this.fieldExportPatch);
			this.panelTop.Controls.Add(this.fieldIsDateCreated);
			this.panelTop.Controls.Add(this.label2);
			this.panelTop.Controls.Add(this.fieldDateTo);
			this.panelTop.Controls.Add(this.label1);
			this.panelTop.Controls.Add(this.fieldDateFrom);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(800, 38);
			this.panelTop.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(767, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(28, 20);
			this.button1.TabIndex = 7;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// fieldExportPatch
			// 
			this.fieldExportPatch.Location = new System.Drawing.Point(567, 8);
			this.fieldExportPatch.Name = "fieldExportPatch";
			this.fieldExportPatch.ReadOnly = true;
			this.fieldExportPatch.Size = new System.Drawing.Size(200, 20);
			this.fieldExportPatch.TabIndex = 6;
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
			this.GridRecords.TabIndex = 6;
			this.GridRecords.VisibleColumns = null;
			// 
			// ExportRecordsListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.GridRecords);
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.panelTop);
			this.Name = "ExportRecordsListForm";
			this.Text = "Экспорт БД";
			this.panelBottom.ResumeLayout(false);
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonExport;
		private System.Windows.Forms.Panel panelTop;
		private Conrols.DataGrid GridRecords;
		private System.Windows.Forms.CheckBox fieldIsDateCreated;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker fieldDateTo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker fieldDateFrom;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox fieldExportPatch;
	}
}