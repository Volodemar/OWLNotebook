using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OWLNotebook.Export
{
	public partial class ExportRecordsListForm : Form
	{
		/// <summary>
		/// Репозиторий контрагентов для хранения всех контрагентов
		/// </summary>
		private RepositoryAgents RA;

		/// <summary>
		/// Репозиторий записей для хранения всех записей
		/// </summary>
		private RepositoryRecords RR;

		/// <summary>
		/// Репозиторий контрагентов
		/// </summary>
		private RepositoryAgents ExportRA;

		/// <summary>
		/// Репозиторий контрагентов
		/// </summary>
		private RepositoryRecords ExportRR;

		public ExportRecordsListForm(RepositoryRecords RR, RepositoryAgents RA)
		{
			InitializeComponent();
			this.GridRecords.UpdBtn.Click += new EventHandler(UpdBtn_Click);
			this.GridRecords.ShowUpdateBtn = true;
			this.GridRecords.VisibleColumns = new Dictionary<string, string>
			{
				{"GUID",		"ИД"},
				{"CreateDate",	"Дата записи"},
				{"Agents",		"Контрагенты"},
				{"Description", "Описание"},
				{"EventDate",	"Дата события"},
				{"Priority",	"Приоритет"},
				{"Subj",		"Заголовок" }
			}; 

			if(!DesignMode)
			{ 
				this.RA = RA;
				this.RR = RR;
			}
		}

		/// <summary>
		/// Нажатие кнопки обновления данных в таблице
		/// </summary>
		private void UpdBtn_Click(object sender, EventArgs e)
		{
			FilterUpdate();
		}

		/// <summary>
		/// Обновление табличной части
		/// </summary>
		private void FilterUpdate()
		{
			DateTime fromDate	= fieldDateFrom.Value;
			DateTime toDate		= fieldDateTo.Value;

			RepositoryRecords filterRecords = new RepositoryRecords();
			foreach(Record record in this.RR.Records())
			{
				if(fieldIsDateCreated.Checked)
				{ 
					//Если выбрано по дате создания записи
					if(record.CreateDate >= fromDate && record.CreateDate <= toDate)
						filterRecords.Add(record);
				}
				else
				{
					//Если выбрано по дате события
					if(record.EventDate >= fromDate && record.EventDate <= toDate)
						filterRecords.Add(record);
				}
			}
 
			GridRecords.Grid.DataSource = filterRecords.Records();

			if(fieldExportPatch.Text != "" && filterRecords.Records().Length > 0)
			{ 
				buttonExport.Enabled = true;
				RepositoryAgents filterAgents = new RepositoryAgents();
				foreach(Record record in filterRecords.Records())
				{
					if(record.Agents != null)
					{ 
						foreach(Agent agent in record.Agents)
						{
							filterAgents.Add(agent);
						}
					}
				}

				// Репозитории подготовленые к экспорту
				this.ExportRA = filterAgents;
				this.ExportRR = filterRecords;
			}
			else
			{ 
				buttonExport.Enabled = false;
				this.ExportRA = null;
				this.ExportRR = null;
			}
		}

		/// <summary>
		/// Открыть диекторию для экспорта
		/// </summary>
		private void button1_Click(object sender, EventArgs e)
		{
			//Стираем прошлые значения, но сохраним выбор каталога
			string lastPatch = this.fieldExportPatch.Text == "" ? Directory.GetCurrentDirectory() : this.fieldExportPatch.Text;
			this.fieldExportPatch.Text = "";

			string currentDirectory = Directory.GetCurrentDirectory();

			using(FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				fbd.SelectedPath = lastPatch;
				if(fbd.ShowDialog() == DialogResult.OK)
				{
					//Проверка, что не выбран текущий каталог
					if(fbd.SelectedPath == currentDirectory)
					{
						MessageBox.Show("Запрещено сохранять данные в выбранное место.");
					}
					else
					{
						if(Directory.GetFiles(fbd.SelectedPath, "RepositoryRecords.csv").Length > 0)
						{ 
							if(MessageBox.Show("В указанной дирректории имеются файлы которые будут презаписаны, продолжить?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
							{
								this.fieldExportPatch.Text = fbd.SelectedPath;
							}
						}
						else
						{
							this.fieldExportPatch.Text = fbd.SelectedPath;
						}
					}
				}
			}
		}

		/// <summary>
		/// Нажатие кнопки экспорта
		/// </summary>
		private void buttonExport_Click(object sender, EventArgs e)
		{
			// Защита от хитропопых пользователей если захотят перетереть базу
			if(Directory.GetCurrentDirectory() != this.fieldExportPatch.Text)
			{ 
				if(ExportRA.Count > 0)
				{
					ExportRA.Save(this.fieldExportPatch.Text);
				}

				if(ExportRR.Count > 0)
				{
					ExportRR.Save(this.fieldExportPatch.Text);
				}

				this.Close();
			}
			else
			{
				MessageBox.Show("В данную директорию сохранение запрещено!", "Ошибка!");
			}
		}
	}
}
