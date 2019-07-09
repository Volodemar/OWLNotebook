using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using OWLNotebook.Dictionary;
using OWLNotebook.Export;
using OWLNotebook.Import;

namespace OWLNotebook
{
	public partial class MainForm : Form
	{
		RepositoryAgents  RA	= new RepositoryAgents();			//Репозиторий контрагентов
		RepositoryRecords RR	= new RepositoryRecords();			//Репозиторий записей
		bool isCreatedRecord	= false;							//Флаг, что создается новая запись
		bool isEditRecord		= false;							//Флаг, что редактируется запись ежедневника 

		public MainForm()
		{
			InitializeComponent();

			// События карточки записи ежедневника
			this.buttonSave.Click	+= ButtonSave_Click;
			this.buttonCancel.Click += ButtonCancel_Click;

			// События с таблицей Записи
			this.GridRecords.Grid.ColumnHeaderMouseClick	+= new DataGridViewCellMouseEventHandler(this.GridRecords_ColumnHeaderMouseClick);
			this.GridRecords.Grid.SelectionChanged			+= new EventHandler(this.GridRecords_SelectionChanged);
			this.GridRecords.Grid.DataSourceChanged			+= new EventHandler(this.GridRecords_DataSourceChanged);
			this.GridRecords.AddBtn.Click					+= new EventHandler(this.GridRecords_AddBtnClick);
			this.GridRecords.EditBtn.Click					+= new EventHandler(this.GridRecords_EditBtnClick);
			this.GridRecords.DelBtn.Click					+= new EventHandler(this.GridRecords_DelBtnClick);

			// События с табличной частью Контрагенты
			this.GridAgents.Grid.DataSourceChanged			+= new EventHandler(this.GridAgents_DataSourceChanged);
			this.GridAgents.AddBtn.Click					+= new EventHandler(this.GridAgents_AddBtn_Click);
			this.GridAgents.EditBtn.Click					+= new EventHandler(this.GridAgents_EditBtn_Click);
			this.GridAgents.DelBtn.Click					+= new EventHandler(this.GridAgents_DelBtn_Click);

			// Кастомизация при запуске
			this.GridAgents.GridToolBar.Enabled				= false;
		}

		/// <summary>
		/// Отмена редактирования записи
		/// </summary>
		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			SetRecordForm(false, false);

			//Загрузка старых данных 
			RA.Load();
			RR.Load(RA);

			//Обновление данных
			this.GridRecords_SelectionChanged(this.GridRecords, new System.EventArgs());
		}

		/// <summary>
		/// Редактирование контрагента
		/// </summary>
		private void GridAgents_EditBtn_Click(object sender, System.EventArgs e)
		{
			// Сохраняем список контрагентов
			List<Agent> agents = new List<Agent>();
			foreach(Agent agent in (this.GridAgents.Grid.DataSource as Agent[]))
			{
				agents.Add(agent);
			}

			// Передаем на редактирование текущего контрагента
			Agent editAgent = (Agent)this.GridAgents.Grid.SelectedRows[0].DataBoundItem;
			using(AgentsEditForm f = new AgentsEditForm(editAgent))
			{
				f.ShowDialog();
				this.RA.Edit(f.agentEdit);

				// Обновляем текущего контрагента измененным
				for(int i=0;i<agents.Count;i++)
				{
					if(agents[i].GUID == f.agentEdit.GUID)
					{
						agents[i] = f.agentEdit;
					}
				}

				// Обновляем табличную часть включая изменения в КА
				this.GridAgents.Grid.DataSource = agents.ToArray<Agent>();
				this.GridAgents.Grid.Refresh();
				this.RA.Save();
			}
		}

		/// <summary>
		/// Событие нажато сохранение карточки ежедневника
		/// </summary>
		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if(isCreatedRecord)
			{
				//*Создание новой записи*
				Agent[] agents = (GridAgents.Grid.DataSource as Agent[]);
				if(agents != null)
				{ 
					foreach(Agent agent in agents)
					{ 
						RR.AddAgentList(agent, ref RA);
					}
				}
				RR.Add(new Record(fieldEventDate.Value, fieldSubj.Text, fieldDescription.Text, RR.GetAgentList(), Convert.ToInt32(fieldPriority.Text)));
				

				SetRecordForm(false, false);

				//Загрузка сохраненных данных
				this.GridRecords.Grid.DataSource = RR.Records();
				this.GridRecords.Grid.Refresh();

				//Сохранение изменений в файл
				RR.Save();
			}
			else
			{
				//*Завершение редактирования текущей записи*
				if(RR.Count > 0)
				{ 
					for(int i=0;i<RR.Count;i++)
					{
						if(RR[i].GUID == this.GridRecords.GUID)
						{
							Record editRecord		= RR[i];
							editRecord.EventDate	= fieldEventDate.Value;
							editRecord.Subj			= fieldSubj.Text;
							editRecord.Description	= fieldDescription.Text;
							editRecord.Priority		= int.Parse(fieldPriority.Text);

							Agent[] agents = (GridAgents.Grid.DataSource as Agent[]);
							if(agents != null)
							{ 
								// Если добавлены новые контакты то надо их сохранить
								foreach(Agent agent in agents)
								{ 
									RA.Add(agent);
								}
								editRecord.Agents = agents;
							}
							else
							{
								editRecord.Agents		= null;
							}

							SetRecordForm(false, false);

							RR.Edit(editRecord);
						}
					}
				}

				//Загрузка сохраненных данных
				this.GridRecords.Grid.DataSource = RR.Records();
				this.GridRecords.Grid.Refresh();

				//Сохранение изменений в файл
				RR.Save();
			}
		}

		
		/// <summary>
		/// Удаление контрагента из записи
		/// </summary>
		private void GridAgents_DelBtn_Click(object sender, EventArgs e)
		{
			Agent       agentDelete = (Agent)this.GridAgents.Grid.SelectedRows[0].DataBoundItem;
			List<Agent> agentsNew   = new List<Agent>();
			foreach(Agent agent in (Agent[])this.GridAgents.Grid.DataSource)
			{
				if(agent.GUID != agentDelete.GUID)
				{ 
					agentsNew.Add(agent);
				}
			}
			this.GridAgents.Grid.DataSource = agentsNew.ToArray<Agent>();
			this.GridAgents.Grid.Refresh();
		}

		/// <summary>
		/// Добавление новой записи контрагента
		/// </summary>
		private void GridAgents_AddBtn_Click(object sender, EventArgs e)
		{
			using (AgentsListForm f = new AgentsListForm(RR, ref RA))
			{
				f.ShowPanelTop = false;
				f.ShowDialog();
				if(f.SelectAgents() != null)
				{
					List<Agent> newAgents = new List<Agent>();
					foreach(Agent agent in f.SelectAgents())
					{
						newAgents.Add(agent);
					}
					if(this.GridAgents.Grid.Rows.Count > 0)
					{ 
						foreach(Agent agent in (this.GridAgents.Grid.DataSource as Agent[]))
						{
							bool isExists = false;
							//Проверка что не добавляется в список старый КА без изменений когда были изменения в КА при добавлении КА
							foreach(Agent checkAgent in newAgents.ToArray<Agent>())
							{
								if(checkAgent.GUID == agent.GUID)
									isExists = true;
							}

							if(!isExists)
								newAgents.Add(agent);
						}
					}
					this.GridAgents.Grid.DataSource = newAgents.ToArray<Agent>();
				}
			}
		}

		/// <summary>
		/// Добавление записи в ежедневник
		/// </summary>
		private void GridRecords_AddBtnClick(object sender, EventArgs e)
		{
			// Очистка данных для создания новой записи
			GridAgents.Grid.DataSource		= null;
			this.fieldDescription.Text		= "";
			this.fieldEventDate.Value		= DateTime.Now;
			this.fieldPriority.Text			= "100";
			this.fieldSubj.Text				= "";

			this.SetRecordForm(true, false);
		}

		/// <summary>
		/// Удаление записи ежедневника
		/// </summary>
		private void GridRecords_DelBtnClick(object sender, EventArgs e)
		{
			if(this.GridRecords.Grid.Rows.Count == 0)
				return;

			//Запоминаем текущую позицию в гриде
			int index = this.GridRecords.Grid.SelectedRows[0].Index;

			//Удаляем запись из репозитория
			RR.Delete(this.GridRecords.GUID);

			//Сохраняем изменения
			RR.Save();

			//Обновление данных в гриде
			this.GridRecords.Grid.DataSource = RR.Records();
			this.Refresh();

			//Выставляем позицию в ближайшее значение
			if(this.GridRecords.Grid.Rows.Count > index)
				this.GridRecords.Grid.Rows[index].Selected = true;
			else if(this.GridRecords.Grid.Rows.Count > 0)
				this.GridRecords.Grid.Rows[index-1].Selected = true;

			// Если после удаления не осталось записей
			if(RR.Count == 0)
			{
				this.GridAgents.Grid.DataSource			= null;
				this.fieldSubj.Text						= "";
				this.fieldDescription.Text				= "";
				this.fieldEventDate.Value				= DateTime.Now;
				this.fieldPriority.Text					= "";
				this.toolStripCreateDate.Text			= "Записи отсутствуют.";
			}
		}

		/// <summary>
		/// Редактирование записи в ежедневник
		/// </summary>
		private void GridRecords_EditBtnClick(object sender, EventArgs e)
		{
			// Открытие полей для редактирования
			this.SetRecordForm(false, true);
		}

		/// <summary>
		/// Открывает или закрывает возможность редактирования карточки записи
		/// </summary>
		/// <param name="isCreatedRecord">Происходит создание</param>
		/// <param name="isEditRecord">Происходит редактирования</param>
		private void SetRecordForm(bool isCreatedRecord, bool isEditRecord)
		{
			if(isCreatedRecord)
			{
				// Открываем редактирование карточки
				this.fieldSubj.ReadOnly					= false;
				this.fieldDescription.ReadOnly			= false;
				this.fieldDescription.BackColor			= this.fieldSubj.BackColor;
				this.fieldEventDate.Enabled				= true;
				this.fieldPriority.ReadOnly				= false;
				this.GridAgents.GridToolBar.Enabled		= true;
				this.buttonSave.Enabled					= true;
				this.buttonCancel.Enabled				= true;

				// Пометка, что есть не сохраненная запись создания
				this.isCreatedRecord					= true;
			}
			else if(isEditRecord)
			{
				// Открываем редактирование карточки
				this.fieldSubj.ReadOnly					= false;
				this.fieldDescription.ReadOnly			= false;
				this.fieldDescription.BackColor			= this.fieldSubj.BackColor;
				this.fieldEventDate.Enabled				= true;
				this.fieldPriority.ReadOnly				= false;
				this.GridAgents.GridToolBar.Enabled		= true;
				this.buttonSave.Enabled					= true;
				this.buttonCancel.Enabled				= true;

				// Пометка, что есть не сохраненная запись создания
				this.isEditRecord						= true;
			}
			else
			{
				// Закрываем редактирование карточки
				this.fieldSubj.ReadOnly					= true;
				this.fieldDescription.ReadOnly			= true;
				this.fieldDescription.BackColor			= this.fieldSubj.BackColor;
				this.fieldEventDate.Enabled				= false;
				this.fieldPriority.ReadOnly				= true;
				this.GridAgents.GridToolBar.Enabled		= false;
				this.buttonSave.Enabled					= false;
				this.buttonCancel.Enabled				= false;

				// Пометка редактирование или изменение закончено
				this.isCreatedRecord					= false;
				this.isEditRecord						= false;
			}
		}

		/// <summary>
		/// Событие изменен источник данных
		/// </summary>
		private void GridAgents_DataSourceChanged(object sender, EventArgs e)
		{
			foreach(DataGridViewColumn column in GridAgents.Grid.Columns)
			{
				column.Visible = false;

				if(column.Name == "FirstName")
				{ 
					column.Visible    = true;
					column.HeaderText = "Имя";
				}

				if(column.Name == "LastName")
				{ 
					column.HeaderText = "Фамилия";
					column.Visible = true;
				}			

				if(column.Name == "MidName")
				{ 
					column.HeaderText = "Отчество";
					column.Visible = true;
				}		

				if(column.Name == "BirthDay")
				{ 
					column.HeaderText = "День рождения";
					column.Visible = true;
				}

				if(column.Name == "Phone")
				{ 
					column.HeaderText = "Телефон";
					column.Visible = true;
				}

				if(column.Name == "EMail")
				{ 
					column.HeaderText = "EMail";
					column.Visible = true;
				}
			}
		}

		/// <summary>
		/// Событие изменился источник данных
		/// </summary>
		private void GridRecords_DataSourceChanged(object sender, EventArgs e)
		{
			foreach(DataGridViewColumn column in GridRecords.Grid.Columns)
			{
				column.Visible = false;

				if(column.Name == "EventDate")
				{ 
					column.Visible    = true;
					column.HeaderText = "Дата события";
				}

				if(column.Name == "Subj")
				{ 
					column.HeaderText = "Запись";
					column.Visible = true;
				}			
			}
		}

		/// <summary>
		/// Событие загрузка формы
		/// </summary>
		private void MainForm_Load(object sender, System.EventArgs e)
		{
			// Загрузка справочника контрагенты
			RA.Load();

			// Загрузка записей ежедневника
			RR.Load(RA);
			GridRecords.Grid.DataSource = RR.Records();

			this.GridRecords.SetColumnOrder();
			this.GridAgents.SetColumnOrder();
		}

		/// <summary>
		/// Событие изменился выбор строки табличной части
		/// </summary>
		private void GridRecords_SelectionChanged(object sender, System.EventArgs e)
		{
			if(GridRecords.Grid.Rows.Count == 0)
				return;

			DataGridViewSelectedRowCollection selectRows = GridRecords.Grid.SelectedRows;
			
			if(selectRows.Count == 0)
				return;

			// Закрываем редактирование или создание без сохранения
			this.SetRecordForm(false, false);

			//Заполняем карточку новыми данными если произошла смена позиции
			RefrashRecord();
		}

		/// <summary>
		/// Событие клик по колонке, выполнить сортировка по столбцу
		/// </summary>
		private void GridRecords_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if(GridRecords.Grid.Rows.Count == 0)
				return;

			// Получим колонку по которой произошел клик
			DataGridViewColumn column = GridRecords.Grid.Columns[e.ColumnIndex];

			// Сохранение предыдущей позиции
			Record recordOld = (Record)GridRecords.Grid.SelectedRows[0].DataBoundItem;

			// Вернем записи табличной части в массив, и выполним сортировку массива в зависимости от колонки
			Record[] records = (GridRecords.Grid.DataSource as Record[]);	

			// Используется отражение для динамического доступа к данным структуры
			PropertyInfo propertyInfo = typeof(Record).GetProperty(column.Name);    
			records = records.OrderBy(x=>propertyInfo.GetValue(x, null)).ToArray<Record>();

			#region Старый вариант сортировки для истории
			//if(column.Name == "EventDate")
			//	records = records.OrderBy(x=>x.EventDate).ToArray<Record>();
			#endregion

			// Перезапишем в таблицу записи согласно сортировке
			GridRecords.Grid.DataSource = records;

			// Вернем позицию выделения записи как было до сортировки
			foreach(DataGridViewRow row in GridRecords.Grid.Rows)
			{
				Record record = (Record)row.DataBoundItem;
				if(record.GUID == recordOld.GUID)
				{
					//Курсор устанавливается в ячейку той-же колонки ,что приводит к выделению строки
					GridRecords.Grid.CurrentCell = row.Cells[e.ColumnIndex]; 
				}
			}
		}

		/// <summary>
		/// Открыть форму справочника контрагентов
		/// </summary>
		private void OpenAgentsDictionary_Click(object sender, EventArgs e)
		{
			AgentsListForm f  = new AgentsListForm(RR, ref RA);
			f.ShowPanelTop		= false;
			f.ShowPanelBottom	= false;

			//Обновление текущей записи если изменится КА в справочнике контрагентов
			f.EventAgentEdit += F_RefrashRecord; //+= RefrashRecord();
			f.Show();
		}

		/// <summary>
		/// Сохраняет все записи в указанный каталог для удобства, запрещает сохранять в каталог где находится текущий источник 
		/// </summary>
		private void menuSave_Click(object sender, EventArgs e)
		{
			string currentDirectory = Directory.GetCurrentDirectory();

			using(FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				fbd.SelectedPath = currentDirectory;
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
								RA.Save(fbd.SelectedPath);
								RR.Save(fbd.SelectedPath);
							}
						}
						else
						{
							RA.Save(fbd.SelectedPath);
							RR.Save(fbd.SelectedPath);
						}
					}
				}
			}
		}

		/// <summary>
		/// Загружает все записи из указанной директории с проверкой на существование файла
		/// </summary>
		private void menuLoad_Click(object sender, EventArgs e)
		{
			string currentDirectory = Directory.GetCurrentDirectory();

			using(OpenFileDialog fd = new OpenFileDialog())
			{
				fd.InitialDirectory = currentDirectory;
				fd.Filter		= "OWLNotebook|RepositoryRecords.csv";
				fd.DefaultExt	= "csv";
				fd.Multiselect	= false;
				if(fd.ShowDialog() == DialogResult.OK)
				{
					FileInfo fileInfo = new FileInfo(fd.FileName);
					if(fileInfo.DirectoryName == currentDirectory)
					{ 
						MessageBox.Show("Эти данные уже загружены.");
					}
					else
					{
						RepositoryAgents  loadRA = new RepositoryAgents();
						RepositoryRecords loadRR = new RepositoryRecords();

						// Загрузка из указанной директории
						loadRA.Load(fileInfo.DirectoryName);
						loadRR.Load(loadRA, fileInfo.DirectoryName);
						RA = loadRA;
						RR = loadRR;

						// Сохранение в текущий репозиторий
						RA.Save();
						RR.Save();

						// Отменяем редактирование или создание записей
						this.SetRecordForm(false, false);

						// Загружаем текущие данные
						this.GridRecords.Grid.DataSource	= RR.Records();
						this.GridRecords.Grid.Refresh();

						// Обновление данных на форме
						this.RefrashRecord();
					}
				}
			}
		}

		/// <summary>
		/// Обновление данных текущей записи
		/// </summary>
		private void RefrashRecord()
		{
			Record currentRecord				= RR[this.GridRecords.GUID];
			this.fieldSubj.Text					= currentRecord.Subj;
			this.fieldDescription.Text			= currentRecord.Description;
			this.fieldEventDate.Value			= currentRecord.EventDate < this.fieldEventDate.MinDate ? this.fieldEventDate.MinDate : currentRecord.EventDate;
			this.fieldPriority.Text				= currentRecord.Priority.ToString();
			this.toolStripCreateDate.Text		= "Дата записи: " + currentRecord.CreateDate.ToString();

			this.GridAgents.Grid.DataSource		= RR[this.GridRecords.GUID].Agents;
			this.GridAgents.Grid.Refresh();
		}

		/// <summary>
		/// Обновление данных записей если произошли изменения в справочнике Контрагенты
		/// </summary>
		private void F_RefrashRecord()
		{
			RepositoryRecords newRR = new RepositoryRecords();
			newRR.Load(RA);
			RR = newRR;
			RefrashRecord();
		}

		/// <summary>
		/// При закрытии формы сохраним настройки гридов
		/// </summary>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.GridRecords.GetColumnOrder();
			this.GridAgents.GetColumnOrder();
		}

		/// <summary>
		/// Экспорт записной книжки
		/// </summary>
		private void menuExport_Click(object sender, EventArgs e)
		{
			using(ExportRecordsListForm f = new ExportRecordsListForm(RR, RA))
			{
				if(f.ShowDialog() == DialogResult.OK)
				{
					//Вся обработка данных в форме
				}
			}
		}

		/// <summary>
		/// Импорт записей в записную книжку
		/// </summary>
		private void menuImport_Click(object sender, EventArgs e)
		{
			using(ImportRecordsListForm f = new ImportRecordsListForm(RR, RA))
			{
				// Если сюда попали значит все для импорта готово
				if(f.ShowDialog() == DialogResult.OK)
				{
					// Добавим новых КА
					if(f.ImportRA.Agents() != null)
					{ 
						foreach(Agent agent in f.ImportRA.Agents())
						{
							RA.Add(agent);
						}
					}

					// Добавим новые записи записной книжки
					if(f.ImportRR.Records() != null)
					{
						foreach(Record record in f.ImportRR.Records()) 
						{
							RR.Add(record);							
						}
					}

					RA.Save();
					RR.Save();

					GridRecords.Grid.DataSource = RR.Records();
					GridRecords.Grid.Refresh();
				}
			}
		}

		/// <summary>
		/// Открытие справки по программе
		/// </summary>
		private void menuHelp_Click(object sender, EventArgs e)
		{
			string HelpFile = Directory.GetCurrentDirectory()+"\\OWLNotebook.chm";
			Process.Start(HelpFile);
		}
	}
}
