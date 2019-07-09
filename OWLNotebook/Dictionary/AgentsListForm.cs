using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// Пространство справочников
/// </summary>
namespace OWLNotebook.Dictionary
{
	public partial class AgentsListForm : Form
	{
		public delegate void AgentEditHandler();
		public event AgentEditHandler EventAgentEdit;

		/// <summary>
		/// Показывать нижнюю панель с кнопками, по умолчанию видно
		/// </summary>
		public bool ShowPanelBottom {get; set;} = true;
		
		/// <summary>
		/// Показывать верхнюю панель с фильтрами, по умолчанию видно
		/// </summary>
		public bool ShowPanelTop {get; set;} = true;

		/// <summary>
		/// Список выбранных КА
		/// </summary>
		private List<Agent> selectAgents = new List<Agent>();

		/// <summary>
		/// Репозиторий контрагентов
		/// </summary>
		private RepositoryAgents RA;

		/// <summary>
		/// Репозиторий контрагентов
		/// </summary>
		private RepositoryRecords RR;

		/// <summary>
		/// Конструктор списковой формы контрагентов
		/// </summary>
		/// <param name="RA">Репозиторий справочника контрагентов</param>
		/// <param name="RR">Репозиторий справочника записи</param>
		public AgentsListForm(RepositoryRecords RR, ref RepositoryAgents RA)
		{
			InitializeComponent();
			this.GridAgents.VisibleColumns = new Dictionary<string, string>
			{
				{"GUID",		"ИД"},
				{"FirstName",	"Имя"},
				{"LastName",	"Фамилия"},
				{"MidName",		"Отчество"},
				{"Phone",		"Телефон"},
				{"BirthDay",	"День рождения"},
				{"EMail",		"EMail" }
			};

			if(!this.DesignMode)
			{
				this.GridAgents.Grid.DataSource = RA.Agents();
				this.RA = RA;
				this.RR = RR;
				this.GridAgents.AddBtn.Click	+= new System.EventHandler(GridAgents_AddBtn_Click);
				this.GridAgents.EditBtn.Click	+= new System.EventHandler(GridAgents_EditBtn_Click);
				this.GridAgents.DelBtn.Click	+= new System.EventHandler(GridAgents_DelBtn_Click);
			}
		}

		/// <summary>
		/// Удаление контрагента
		/// </summary>
		private void GridAgents_DelBtn_Click(object sender, System.EventArgs e)
		{
			Agent delAgent = (Agent)this.GridAgents.Grid.SelectedRows[0].DataBoundItem;
			int countRecordWithAgent = 0;
			foreach(Record record in RR.Records())
			{
				if(record.Agents != null)
				{
					foreach(Agent agent in record.Agents)
					{
						if(agent.GUID == delAgent.GUID)
							countRecordWithAgent++;
					}
				}
			}

			if(countRecordWithAgent > 0)
			{
				MessageBox.Show($"Данного контрагента нельзя удалить из справочника т.к. он используется в {countRecordWithAgent} записях(си).", "Внимание!");
			}
			else
			{
				RA.Delete(delAgent.GUID);
				RA.Save();

				this.GridAgents.Grid.DataSource = RA.Agents();
				this.GridAgents.Grid.Refresh();
			}
		}

		/// <summary>
		/// Редактирование контрагента
		/// </summary>
		private void GridAgents_EditBtn_Click(object sender, System.EventArgs e)
		{
			Agent editAgent = (Agent)this.GridAgents.Grid.SelectedRows[0].DataBoundItem;
			using(AgentsEditForm f = new AgentsEditForm(editAgent))
			{
				f.ShowDialog();
				this.RA.Edit(f.agentEdit);
				this.GridAgents.Grid.DataSource = RA.Agents();
				this.GridAgents.Grid.Refresh();
				this.RA.Save();

				// Вызов события обновление карточки эжедневника
				if(EventAgentEdit != null)
					EventAgentEdit();
			}
		}

		/// <summary>
		/// Добавление нового контрагента
		/// </summary>
		private void GridAgents_AddBtn_Click(object sender, System.EventArgs e)
		{
			using(AgentsEditForm f = new AgentsEditForm())
			{
				f.ShowDialog();
				this.RA.Add(f.agentEdit);
				this.GridAgents.Grid.DataSource = RA.Agents();
				this.GridAgents.Grid.Refresh();
				this.RA.Save();
			}
		}

		/// <summary>
		/// Возвращает выбранные КА
		/// </summary>
		/// <returns></returns>
		public Agent[] SelectAgents()
		{
			return selectAgents.ToArray();
		}

		/// <summary>
		/// Нажатие ОК, закрытие формы, сохранение изменений, возвращаем выбранных КА
		/// </summary>
		private void buttonSelect_Click(object sender, System.EventArgs e)
		{
			if(this.GridAgents.Grid.SelectedRows.Count == 0)
				return;
		
			Agent agent = (Agent)this.GridAgents.Grid.SelectedRows[0].DataBoundItem;
			
			//Проверка, что данный КА небыл уже добавлен в список
			if(!selectAgents.Contains(agent))
			{ 
				selectAgents.Add(agent);
				if(selectAgents.Count > 0)
				buttonSelect.Text = $"Выбрано ({selectAgents.Count})";
			}
		}

		/// <summary>
		/// Отменяет изменения и закрывает окно
		/// </summary>
		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			selectAgents.Clear();
			this.Close();
		}

		/// <summary>
		/// Событие показать форму
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AgentsListForm_Shown(object sender, System.EventArgs e)
		{
			this.panelTop.Visible		= ShowPanelTop;
			this.panelBottom.Visible	= ShowPanelBottom;
		}
	}
}
