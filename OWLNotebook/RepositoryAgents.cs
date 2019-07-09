using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace OWLNotebook
{
	/// <summary>
	/// Репозиторий контактов (Справочник контрагенты)
	/// </summary>
	public class RepositoryAgents
	{
		/// <summary>
		/// Имя файла хранения репозитория контрагентов
		/// </summary>
		private string FileName {get; set;}

		/// <summary>
		/// Количество записей возвращает -1 если записей нету.
		/// </summary>
		public int Count 
		{ 
			get	{
					if(agents == null)
						return 0;
					else
						return agents.Length;
				} 
			private set{ this.Count = value;}
		} 

		/// <summary>
		/// Счетчик следующий номер записи
		/// </summary>
		private int NextIndex { get; set;}

		/// <summary>
		/// Контрагенты
		/// </summary>
		private Agent[] agents;

		/// <summary>
		/// Индексатор для доступа к процедурам контрагента
		/// </summary>
		/// <param name="id">Индекс контрагента</param>
		public Agent this[int id]
		{
			get {return agents[id];}
			set {agents[id] = value;}
		}

		/// <summary>
		/// Индексатор для доступа к записи по GUID
		/// </summary>
		/// <param name="guid">GUID запсии</param>
		public Agent this[Guid guid]
		{
			get
			{
				foreach(Agent agent in agents)
				{
					if(agent.GUID == guid)
						return agent;
				}
				return new Agent();
			}
		}

		/// <summary>
		/// Возвращает всех агентов репозитория
		/// </summary>
		/// <returns></returns>
		public Agent[] Agents()
		{
			return this.agents;
		}

		/// <summary>
		/// Конструктор репозитория контрагентов
		/// </summary>
		public RepositoryAgents()
		{
			this.FileName = @"RepositoryAgents.csv";
			agents = new Agent[0];
			this.NextIndex = 0;
		}

		/// <summary>
		/// Конструктор репозитория контрагентов c иным местом хранения
		/// </summary>
		public RepositoryAgents(string folder) : this()
		{
			this.FileName = folder + @"RepositoryAgents.csv";
			Console.WriteLine(this.FileName);
		}

		/// <summary>
		/// Добавление контрагента в репозиторий
		/// </summary>
		/// <param name="newAgent">Контрагент</param>
        public void Add(Agent newAgent)
        {
			//Проверка, что такого контрагента нет в репозитории
			foreach(Agent agent in this.agents)
			{
				if(agent.GUID == newAgent.GUID)
					return;

				if(agent.FirstName == newAgent.FirstName && agent.LastName == newAgent.LastName && agent.MidName == newAgent.MidName)
					return;
			}

			if(this.agents.Length <= this.NextIndex)
				Array.Resize(ref this.agents, this.agents.Length+1);
            this.agents[this.NextIndex] = newAgent;
			this.NextIndex++;
        }

		/// <summary>
		/// Редактирование контрагента
		/// </summary>
		/// <param name="editAgent">Измененный контрагент</param>
		public void Edit(Agent editAgent)
		{
			//Найдем текущую запись
			for(int i=0;i<this.agents.Length;i++)
			{
				if(this.agents[i].GUID == editAgent.GUID)
				{
					this.agents[i].FirstName	= editAgent.FirstName;
					this.agents[i].LastName		= editAgent.LastName;
					this.agents[i].MidName		= editAgent.MidName;
					this.agents[i].BirthDay		= editAgent.BirthDay;
					this.agents[i].Phone		= editAgent.Phone;
					this.agents[i].EMail		= editAgent.EMail;
				}
			}
		}

		/// <summary>
		/// Удаление записи из Контрагента.
		/// </summary>
		/// <param name="guid">Guid удаляемой записи.</param>
		public void Delete(Guid guid)
		{
			List<Agent> newAgents = new List<Agent>();
			for(int i=0;i<agents.Length;i++)
			{
				if(agents[i].GUID != guid)
					newAgents.Add(agents[i]);
			}
			agents = newAgents.ToArray<Agent>();
			this.NextIndex = agents.Length;
		}

		/// <summary>
		/// Вывод на экран репозитория контрагентов
		/// </summary>
		public void Print()
		{
			for(int i=0;i<agents.Length;i++)
			{
				Console.Write($"Index:{i}, ");
				agents[i].Print();
			}
		}

		/// <summary>
		/// Сохранение репозитория в файл
		/// </summary>
		/// <returns>true при успешной загрузке</returns>
		public bool Save(string folder = null)
		{
			string fullFileName = folder == null ? this.FileName : folder+"\\"+this.FileName;

            try
            {
				using (StreamWriter sw = new StreamWriter(fullFileName, false, Encoding.Unicode))
				{ 
					foreach(Agent agent in agents)
					{
						sw.WriteLine(agent.ToCSV());
					}
				}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
			return true;
		}

		/// <summary>
		/// Загрузка контрагентов из файла
		/// </summary>
		public void Load(string folder = null)
		{
			string fullFileName = folder == null ? this.FileName : folder+"\\"+this.FileName;

			FileInfo fileInfo = new FileInfo(fullFileName);

			if(fileInfo.Exists)
			{ 
				using (StreamReader sr = new StreamReader(fullFileName))
				{
					while (!sr.EndOfStream)
					{
						string[] agent = sr.ReadLine().Split('#');

						this.Add(new Agent(Guid.Parse(agent[0]), agent[1], agent[2], agent[3], Convert.ToDateTime(agent[4]), agent[5], agent[6]));
					}
				}
			}
		}
	}

	public struct Agent : IGridStruct
	{
		#region Поля контакта
		/// <summary>
		/// Ключ записи контрагента
		/// </summary>
		public Guid GUID {get; set;}

		/// <summary>
		/// Имя контакта
		/// </summary>
		public string FirstName {get; set;}

		/// <summary>
		/// Фамилия контакта
		/// </summary>
		public string LastName {get; set;}

		/// <summary>
		/// Отчество контакта
		/// </summary>
		public string MidName {get; set;}

		/// <summary>
		/// День рождения
		/// </summary>
		public DateTime BirthDay {get; set;}

		/// <summary>
		/// Телефон
		/// </summary>
		public string Phone {get; set;}

		/// <summary>
		/// Электронный адрес
		/// </summary>
		public string EMail {get; set;}
		#endregion 

		/// <summary>
		/// Конструктор контакта
		/// </summary>
		/// <param name="firstName">Имя</param>
		/// <param name="lastName">Фамилия</param>
		/// <param name="midName">Отчество</param>
		/// <param name="birthDay">Дата день рождения</param>
		/// <param name="phone">Основной телефон</param>
		/// <param name="email">Электронный адрес</param>
		public Agent(string firstName, string lastName, string midName, DateTime birthDay, string phone, string email)
		{
			this.GUID			= Guid.NewGuid();
			this.FirstName		= firstName;
			this.LastName		= lastName;
			this.MidName		= midName;
			this.BirthDay		= birthDay;
			this.Phone			= phone;
			this.EMail			= email;
		}

		/// <summary>
		/// Конструктор контакта
		/// </summary>
		/// <param name="guid">ИД записи</param>
		/// <param name="firstName">Имя</param>
		/// <param name="lastName">Фамилия</param>
		/// <param name="midName">Отчество</param>
		/// <param name="birthDay">Дата день рождения</param>
		/// <param name="phone">Основной телефон</param>
		/// <param name="email">Электронный адрес</param>
		public Agent(Guid guid, string firstName, string lastName, string midName, DateTime birthDay, string phone, string email) : this(firstName, lastName, midName, birthDay, phone, email)
		{
			this.GUID		= guid;
		}

		/// <summary>
		/// Вывод на экран текущего контрагента
		/// </summary>
		public void Print()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append($"GUID:{this.GUID}, ");
			sb.Append($"FirstName:{this.FirstName}, ");
			sb.Append($"LastName:{this.LastName}, ");
			sb.Append($"MidName:{this.MidName}, ");
			sb.Append($"BirthDay:{this.BirthDay.ToString()}, ");
			sb.Append($"Phone:{this.Phone}, ");
			sb.Append($"Email:{this.EMail}");

			Console.WriteLine(sb.ToString());
		}

		/// <summary>
		/// Конвертирует данные контрагента в csv формат
		/// </summary>
		/// <returns>Возвращает csv строку</returns>
		public string ToCSV()
		{
			return $"{this.GUID}#{this.FirstName}#{this.LastName}#{this.MidName}#{this.BirthDay.ToString()}#{this.Phone}#{this.EMail}";
		}
	}
}
