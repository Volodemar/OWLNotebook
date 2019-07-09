using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OWLNotebook
{
	static class Program
	{
		/// <summary>
        /// Разработать ежедневник.
        /// В ежедневнике реализовать возможность 
        /// - создания
        /// - удаления
        /// - реактирования 
        /// записей
        /// 
        /// В отдельной записи должно быть не менее пяти полей
        /// 
        /// Реализовать возможность 
        /// - Загрузки даннах из файла
        /// - Выгрузки даннах в файл
        /// - Добавления данных в текущий ежедневник из выбранного файла
        /// - Импорт записей по выбранному диапазону дат
        /// - Упорядочивания записей ежедневника по выбранному полю
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
