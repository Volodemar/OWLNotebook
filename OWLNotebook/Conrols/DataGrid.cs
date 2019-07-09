using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace OWLNotebook.Conrols
{
	public partial class DataGrid : UserControl
	{
		private Guid CurrentGUID;

		/// <summary>
		/// GUID текущей записи
		/// </summary>
		public Guid GUID
		{
			get { return CurrentGUID;}
		}

		/// <summary>
		/// Переключает видимость кнопки добавления записи
		/// </summary>
		[DefaultValue(true)]
		public bool ShowAddBtn
		{
			get { return this.AddBtn.Visible;}
			set { this.AddBtn.Visible = value;}
		}

		/// <summary>
		/// Переключает видимость кнопки редактирования записи
		/// </summary>
		[DefaultValue(true)]
		public bool ShowEditBtn
		{
			get { return this.EditBtn.Visible;}
			set { this.EditBtn.Visible = value;}
		}

		/// <summary>
		/// Переключает видимость кнопки удаления записи
		/// </summary>
		[DefaultValue(true)]		
		public bool ShowDeleteBtn
		{
			get { return this.DelBtn.Visible;}
			set { this.DelBtn.Visible = value;}
		}

		/// <summary>
		/// Переключает видимость кнопки обновления таблицы
		/// </summary>
		[DefaultValue(true)]		
		public bool ShowUpdateBtn
		{
			get { return this.UpdBtn.Visible;}
			set { this.UpdBtn.Visible = value;}
		}

		public Dictionary<string, string> VisibleColumns {get; set;}

		/// <summary>
		/// Конструктор контрола
		/// </summary>
		public DataGrid()
		{
			InitializeComponent();
			this.Grid.SelectionChanged			+= new EventHandler(this.Grid_SelectionChanged);
			this.Grid.DataSourceChanged			+= new EventHandler(this.Grid_DataSourceChanged);
		}

		/// <summary>
		/// Событие изменение источника данных
		/// </summary>
		private void Grid_DataSourceChanged(object sender, System.EventArgs e)
		{
			if(this.VisibleColumns != null)
			{
				foreach(DataGridViewColumn column in this.Grid.Columns)
				{
					column.Visible = false;
					string columnHeader;
					if(this.VisibleColumns.TryGetValue(column.Name, out columnHeader))
					{
						column.Visible = true;
						column.HeaderText = columnHeader;
					}
				}
			}
		}

		/// <summary>
		/// Событие изменился выбор строки табличной части получаем актуальный GUID
		/// </summary>
		private void Grid_SelectionChanged(object sender, System.EventArgs e)
		{
			DataGridViewSelectedRowCollection selectRows = Grid.SelectedRows;
			
			if(selectRows.Count == 0)
			{
				this.CurrentGUID = Guid.Empty;
				return;
			}

			object data = selectRows[0].DataBoundItem;

			if(data is IGridStruct grid)
			{
				this.CurrentGUID = grid.GUID;
			}

			#region Оставлю на память о том зачем нужны интерфейсы
			//	if(data.GetType() == typeof(Record))
			//	{ 
			//		Record row = (Record)data;
			//		this.CurrentGUID = row.GUID;
			//	}

			//	if(data.GetType() == typeof(Agent))
			//	{ 
			//		Agent row = (Agent)data;
			//		this.CurrentGUID = row.GUID;
			//	}
			#endregion
		}

		/// <summary>
		/// Загрузка расположения колонок
		/// </summary>
		public void GetColumnOrder()
		{
			if (this.Grid.AllowUserToOrderColumns)
			{
				List<ColumnOrderItem> columnOrder = new List<ColumnOrderItem>();
				DataGridViewColumnCollection columns = this.Grid.Columns;
				for (int i = 0; i < columns.Count; i++)
				{
					columnOrder.Add(new ColumnOrderItem
					{
						ColumnIndex = i,
						DisplayIndex = columns[i].DisplayIndex,
						Visible = columns[i].Visible,
						Width = columns[i].Width
					});
				}
				DataGridViewSetting.Default.ColumnOrder[this.Name] = columnOrder;
				DataGridViewSetting.Default.Save();
			}
		}

		/// <summary>
		/// Сохранение расположения колонок
		/// </summary>
		public void SetColumnOrder()
		{
			if (!DataGridViewSetting.Default.ColumnOrder.ContainsKey(this.Name))
				return;

			List<ColumnOrderItem> columnOrder =
				DataGridViewSetting.Default.ColumnOrder[this.Name];

			if (columnOrder != null)
			{
				var sorted = columnOrder.OrderBy(i => i.DisplayIndex);
				if(this.Grid.Columns.Count >= columnOrder.Count())
				{ 
					foreach (var item in sorted)
					{
						this.Grid.Columns[item.ColumnIndex].DisplayIndex = item.DisplayIndex;
						this.Grid.Columns[item.ColumnIndex].Visible = item.Visible;
						this.Grid.Columns[item.ColumnIndex].Width = item.Width;
					}
				}
			}
		}
	}

	internal sealed class DataGridViewSetting : ApplicationSettingsBase
	{
		private static DataGridViewSetting _defaultInstace =
			(DataGridViewSetting)ApplicationSettingsBase.Synchronized(new DataGridViewSetting());
    
		public static DataGridViewSetting Default
		{
			get { return _defaultInstace; }
		}    

		[UserScopedSetting]
		[SettingsSerializeAs(SettingsSerializeAs.Binary)]
		[DefaultSettingValue("")]

		public Dictionary<string, List<ColumnOrderItem>> ColumnOrder
		{
			get { return this["ColumnOrder"] as Dictionary<string, List<ColumnOrderItem>>; }
			set { this["ColumnOrder"] = value; }
		}
	}

	[Serializable]
	public sealed class ColumnOrderItem
	{
		public int DisplayIndex { get; set; }
		public int Width { get; set; }
		public bool Visible { get; set; }
		public int ColumnIndex { get; set; }
	}
}
