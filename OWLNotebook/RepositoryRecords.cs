using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace OWLNotebook
{
	/// <summary>
	/// Репозиторий записей записной книжки (Справочник записи)
	/// </summary>
	public class RepositoryRecords
	{
		/// <summary>
		/// Имя файла хранения репозитория записей
		/// </summary>
		private string FileName {get; set;}

		/// <summary>
		/// Счетчик следующий номер записи
		/// </summary>
		private int NextIndex { get; set;}

		/// <summary>
		/// Список агентов для наполнения и автоматической вставки при создании записи
		/// </summary>
		private List<Agent> AddAgentRecord = new List<Agent>(); 

		/// <summary>
		/// Количество записей возвращает -1 если записей нету.
		/// </summary>
		public int Count 
		{ 
			get	{
					if(records == null)
						return 0;
					else
						return records.Length;
				} 
			private set{ this.Count = value;}
		} 

		/// <summary>
		/// Записи
		/// </summary>
		private Record[] records;

		/// <summary>
		/// Возвращает все записи записной книжки
		/// </summary>
		/// <returns></returns>
		public Record[] Records()
		{
			return this.records;
		}

		/// <summary>
		/// Индексатор для доступа к процедурам записи
		/// </summary>
		/// <param name="index">Индекс записи</param>
		public Record this[int index]
		{
			get {return records[index];}
			set {records[index] = value;}
		}

		/// <summary>
		/// Индексатор для доступа к записи по GUID
		/// </summary>
		/// <param name="guid">GUID запсии</param>
		public Record this[Guid guid]
		{
			get
			{
				foreach(Record record in records)
				{
					if(record.GUID == guid)
						return record;
				}
				return new Record();
			}
		}

		/// <summary>
		/// Конструктор репозитория записей
		/// </summary>
		public RepositoryRecords()
		{
			this.FileName = @"RepositoryRecords.csv";
			records = new Record[0];
			this.NextIndex = 0;
		}

		/// <summary>
		/// Добавление записи в репозиторий
		/// </summary>
		/// <param name="newRecord">запись</param>
        public void Add(Record newRecord)
        {
			//Проверка, что такого контрагента нет в репозитории
			foreach(Record record in this.records)
			{
				if(record.GUID == newRecord.GUID)
					return;

				if(record.EventDate == newRecord.EventDate && record.Subj == newRecord.Subj)
					return;
			}

			if(this.records.Length <= this.NextIndex)
				Array.Resize(ref this.records, this.records.Length+1);
            this.records[this.NextIndex] = newRecord;
			this.NextIndex++;

			AddAgentRecord.Clear();
        }

		/// <summary>
		/// Редактирование записи
		/// </summary>
		/// <param name="editRecord"></param>
		public void Edit(Record editRecord)
		{
			//Найдем текущую запись
			for(int i=0;i<this.records.Length;i++)
			{
				if(this.records[i].GUID == editRecord.GUID)
				{
					this.records[i].Subj		= editRecord.Subj;
					this.records[i].Description	= editRecord.Description;
					this.records[i].EventDate	= editRecord.EventDate;
					this.records[i].Priority	= editRecord.Priority;
					this.records[i].Agents		= editRecord.Agents;
				}
			}
		}

		/// <summary>
		/// Добавляет контрагентов для сохранения перед добавлением новой записи
		/// </summary>
		/// <param name="newAgent">Новый или известный КА</param>
		/// <param name="RA">Репозиторий контрагентов</param>
		public void AddAgentList(Agent newAgent, ref RepositoryAgents RA)
		{
			if(!this.AddAgentRecord.Contains(newAgent))
			{ 
				RA.Add(newAgent);
				RA.Save();
				this.AddAgentRecord.Add(newAgent);
			}
		}

		/// <summary>
		/// Возвращает массив контрагентов для добавления к новой записи
		/// </summary>
		/// <returns></returns>
		public Agent[] GetAgentList()
		{
			return this.AddAgentRecord.ToArray<Agent>();
		}

		/// <summary>
		/// Вывод на экран записей
		/// </summary>
		public void Print()
		{
			for(int i=0;i<records.Length;i++)
			{
				Console.Write($"Index:{i}, ");
				records[i].Print();
			}
		}

		/// <summary>
		/// Удаление записи из ежедневника, не сохраняет данные в файл.
		/// </summary>
		/// <param name="guid">Guid удаляемой записи.</param>
		public void Delete(Guid guid)
		{
			List<Record> newRecords = new List<Record>();
			for(int i=0;i<records.Length;i++)
			{
				if(records[i].GUID != guid)
					newRecords.Add(records[i]);
			}
			records = newRecords.ToArray<Record>();
			this.NextIndex = records.Length;
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
					foreach(Record record in records)
					{
						sw.WriteLine(record.ToCSV());
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
		/// Загрузка записей записной книжки из файла
		/// </summary>
		public void Load(RepositoryAgents RA, string folder = null)
		{
			string fullFileName = folder == null ? this.FileName : folder+"\\"+this.FileName;

			FileInfo fileInfo = new FileInfo(fullFileName);

			if(fileInfo.Exists)
			{ 
				using (StreamReader sr = new StreamReader(fullFileName))
				{
					while (!sr.EndOfStream)
					{
						string[] record = sr.ReadLine().Split('#');

						for(int i=0;i<record.Length;i++)
						{
							foreach(Agent agent in RA.Agents())
							{ 
								if(i > 1 && record[i] == agent.GUID.ToString())
								{ 
									this.AddAgentList(agent, ref RA);
								}
							}
						}

						Record addRecord        = new Record();
						addRecord.GUID			= Guid.Parse(record[0]);
						addRecord.CreateDate	= Convert.ToDateTime(record[1]);
						addRecord.EventDate		= Convert.ToDateTime(record[2]);
						addRecord.Subj			= record[3];
						addRecord.Description	= record[4].Replace("Environment.NewLine", "\n");
						addRecord.Agents		= this.GetAgentList();
						addRecord.Priority		= Convert.ToInt32(record[5]);

						this.Add(addRecord);
					}
				}
			}
		}
	}

	public struct Record : IGridStruct
	{
		#region Поля записи
		/// <summary>
		/// GUID записи
		/// </summary>
		public Guid GUID {get; set;}

		/// <summary>
		/// Дата создания
		/// </summary>
		public DateTime CreateDate {get; set;}

		/// <summary>
		/// Дата события
		/// </summary>
		public DateTime EventDate {get; set;}

		/// <summary>
		/// Заголовок
		/// </summary>
		public string Subj {get; set;}

		/// <summary>
		/// Описание
		/// </summary>
		public string Description {get; set;}

		/// <summary>
		/// Список контактов
		/// </summary>
		public Agent[] Agents {get; set;}

		/// <summary>
		/// Приоритет
		/// </summary>
		public int Priority {get; set;}

		#endregion 

		/// <summary>
		/// Конструктор записей
		/// </summary>
		/// <param name="createDate">Дата создания записи</param>
		/// <param name="eventDate">Дата события</param>
		/// <param name="subj">Заголовок</param>
		/// <param name="description">Описание</param>
		/// <param name="agents">Контрагенты</param>
		/// <param name="priority">Приоритет</param>
		public Record(DateTime eventDate, string subj, string description, Agent[] agents, int priority)
		{
			this.GUID			= Guid.NewGuid();
			this.CreateDate		= DateTime.Now;
			this.EventDate		= eventDate;
			this.Subj			= subj;
			this.Description	= description;
			this.Agents			= agents;
			this.Priority		= priority;
		}

		/// <summary>
		/// Конструктор записей для загрузки
		/// </summary>
		/// <param name="guid">GUID записи</param>
		/// <param name="createDate">Дата создания записи</param>
		/// <param name="eventDate">Дата события</param>
		/// <param name="subj">Заголовок</param>
		/// <param name="description">Описание</param>
		/// <param name="agents">Контрагенты</param>
		/// <param name="priority">Приоритет</param>
		public Record(Guid guid, DateTime createDate, DateTime eventDate, string subj, string description, Agent[] agents, int priority) : 
			      this(eventDate, subj, description, agents, priority)
		{
			this.GUID		= guid;
			this.CreateDate	= createDate;
		}

		/// <summary>
		/// Вывод на экран текущей записи
		/// </summary>
		public void Print()
		{
			Console.WriteLine($"CreateDate:{this.CreateDate.ToString()}, EventDate:{this.EventDate.ToString()}, Subj:{this.Subj}, Description:{this.Description}, Priority:{this.Priority}");
			
			if(this.Agents != null)
			{ 
				for(int i=0;i<this.Agents.Length;i++)
				{
					Console.WriteLine($"Agents{i}: {this.Agents[i].GUID.ToString()}");
				}
			}
		}

		/// <summary>
		/// Конвертирует данные записи в csv формат
		/// </summary>
		/// <returns>Возвращает csv строку</returns>
		public string ToCSV()
		{
			string csvDescription = this.Description.Replace("\n", "Environment.NewLine");
			string csv = $"{this.GUID.ToString()}#{this.CreateDate.ToString()}#{this.EventDate.ToString()}#{this.Subj}#{csvDescription}#{this.Priority}";
			if(this.Agents != null)
			{ 
				for(int i=0;i<this.Agents.Length;i++)
				{
					csv = csv + $"#{this.Agents[i].GUID.ToString()}";
				}
			}
			return csv;
		}
	}
}
