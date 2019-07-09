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

namespace OWLNotebook.Import
{
	public partial class ImportRecordsListForm : Form
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
		/// Репозиторий контрагентов для хранения импортируемых контрагентов
		/// </summary>
		public RepositoryAgents ImportRA;

		/// <summary>
		/// Репозиторий записей для хранения импортируемых записей
		/// </summary>
		public RepositoryRecords ImportRR;

		public ImportRecordsListForm(RepositoryRecords RR, RepositoryAgents RA)
		{
			InitializeComponent();
			this.GridRecords.UpdBtn.Click += new EventHandler(GridRecordsUpdBtn_Click);
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
				this.RR = RR;
				this.RA = RA;
			}
		}

		/// <summary>
		/// Нажатие кнопки обновления данных в таблице
		/// </summary>
		private void GridRecordsUpdBtn_Click(object sender, EventArgs e)
		{
			FilterUpdate();
		}

		/// <summary>
		/// Обновление табличной части, делает загрузку данных согласно фильтрации
		/// </summary>
		private void FilterUpdate()
		{
			DateTime fromDate	= fieldDateFrom.Value;
			DateTime toDate		= fieldDateTo.Value;

			// Загружаем данные из файлов
			if(fieldImportPath.Text != "")
			{
				RepositoryAgents FileAgents = new RepositoryAgents();
				FileAgents.Load(fieldImportPath.Text);

				RepositoryRecords FileRecords = new RepositoryRecords();
				FileRecords.Load(FileAgents, fieldImportPath.Text);
				
				RepositoryRecords filterRecords = new RepositoryRecords();
				
				foreach(Record record in FileRecords.Records())
				{
					if(fieldIsDateCreated.Checked)
					{ 
						//Если выбрано по дате создания записи
						if(record.CreateDate >= fromDate && record.CreateDate <= toDate)
						{ 
							filterRecords.Add(record);
						}
					}
					else
					{
						//Если выбрано по дате события
						if(record.EventDate >= fromDate && record.EventDate <= toDate)
						{ 
							filterRecords.Add(record);
						}
					}
				}

				GridRecords.Grid.DataSource = filterRecords.Records();

				if(filterRecords.Count > 0)
				{
					buttonImport.Enabled = true;

					RepositoryAgents  filterAgents	= new RepositoryAgents();
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

					this.ImportRA = filterAgents;
					this.ImportRR = filterRecords;
				}
				else
				{
					buttonImport.Enabled = false;
					this.ImportRA = null;
					this.ImportRR = null;
				}
			}
		}

		/// <summary>
		/// Нажата кнопка импорта записей
		/// </summary>
		private void buttonImport_Click(object sender, EventArgs e)
		{
			// Проверим, что есть что импортировать
			if(this.ImportRR.Count > 0)
			{
				// Выходи из формы с одобрением
				this.DialogResult = DialogResult.OK;
			}
		}

		/// <summary>
		/// Открытие файла для импорта, выполнит получение пути к файлу
		/// </summary>
		private void buttonGetPath_Click(object sender, EventArgs e) 
		{
			//Стираем прошлые значения, но сохраним выбор каталога
			string lastPath = this.fieldImportPath.Text == "" ? Directory.GetCurrentDirectory() : this.fieldImportPath.Text;
			this.fieldImportPath.Text = "";

			string currentDirectory = Directory.GetCurrentDirectory();

			using(OpenFileDialog fd = new OpenFileDialog())
			{
				fd.Filter = "OWLNotebook | RepositoryRecords.csv";
				fd.InitialDirectory = lastPath;
				if(fd.ShowDialog() == DialogResult.OK)
				{
					FileInfo fi = new FileInfo(fd.FileName);
					if(fi.DirectoryName == currentDirectory)
					{
						MessageBox.Show("Из этой папки запрещено импортировать данные.");
					}
					else
					{
						this.fieldImportPath.Text = fi.DirectoryName;
					}
				}
			}
		}
	}
}
