namespace OWLNotebook.Conrols
{
	partial class DataGrid
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGrid));
			this.GridToolBar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.DelBtn = new System.Windows.Forms.ToolStripButton();
			this.UpdBtn = new System.Windows.Forms.ToolStripButton();
			this.Grid = new System.Windows.Forms.DataGridView();
			this.GridToolBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
			this.SuspendLayout();
			// 
			// GridToolBar
			// 
			this.GridToolBar.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.GridToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.EditBtn,
            this.DelBtn,
            this.UpdBtn});
			this.GridToolBar.Location = new System.Drawing.Point(0, 0);
			this.GridToolBar.Name = "GridToolBar";
			this.GridToolBar.Size = new System.Drawing.Size(339, 25);
			this.GridToolBar.TabIndex = 0;
			this.GridToolBar.Text = "toolStrip1";
			// 
			// AddBtn
			// 
			this.AddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
			this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(23, 22);
			this.AddBtn.Text = "toolStripButton1";
			this.AddBtn.ToolTipText = "Создать";
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(23, 22);
			this.EditBtn.Text = "toolStripButton2";
			this.EditBtn.ToolTipText = "Изменить";
			// 
			// DelBtn
			// 
			this.DelBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.DelBtn.Image = ((System.Drawing.Image)(resources.GetObject("DelBtn.Image")));
			this.DelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DelBtn.Name = "DelBtn";
			this.DelBtn.Size = new System.Drawing.Size(23, 22);
			this.DelBtn.Text = "toolStripButton3";
			this.DelBtn.ToolTipText = "Удалить";
			// 
			// UpdBtn
			// 
			this.UpdBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.UpdBtn.Image = ((System.Drawing.Image)(resources.GetObject("UpdBtn.Image")));
			this.UpdBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.UpdBtn.Name = "UpdBtn";
			this.UpdBtn.Size = new System.Drawing.Size(23, 22);
			this.UpdBtn.ToolTipText = "Обновить";
			this.UpdBtn.Visible = false;
			// 
			// Grid
			// 
			this.Grid.AllowDrop = true;
			this.Grid.AllowUserToOrderColumns = true;
			this.Grid.AllowUserToResizeRows = false;
			this.Grid.BackgroundColor = System.Drawing.SystemColors.Control;
			this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Grid.Location = new System.Drawing.Point(0, 25);
			this.Grid.MultiSelect = false;
			this.Grid.Name = "Grid";
			this.Grid.ReadOnly = true;
			this.Grid.RowHeadersVisible = false;
			this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Grid.Size = new System.Drawing.Size(339, 345);
			this.Grid.TabIndex = 1;
			// 
			// DataGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Grid);
			this.Controls.Add(this.GridToolBar);
			this.Name = "DataGrid";
			this.Size = new System.Drawing.Size(339, 370);
			this.GridToolBar.ResumeLayout(false);
			this.GridToolBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.ToolStrip GridToolBar;
		public System.Windows.Forms.ToolStripButton AddBtn;
		public System.Windows.Forms.ToolStripButton EditBtn;
		public System.Windows.Forms.DataGridView Grid;
		public System.Windows.Forms.ToolStripButton DelBtn;
		public System.Windows.Forms.ToolStripButton UpdBtn;
	}
}
