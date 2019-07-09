using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OWLNotebook.Dictionary
{
	public partial class AgentsEditForm : Form
	{
		public Agent agentEdit = new Agent();

		/// <summary>
		/// Конструктор формы редактирования Контрагента
		/// </summary>
		/// <param name="agentEdit">Новый или редактируемый контрагент</param>
		public AgentsEditForm(Agent agentEdit)
		{
			InitializeComponent();

			if(agentEdit.BirthDay < fieldBirthDay.MinDate) agentEdit.BirthDay = fieldBirthDay.MinDate;
			fieldGUID.Text		= agentEdit.GUID.ToString();
			fieldFirstName.Text = agentEdit.FirstName;
			fieldLastName.Text	= agentEdit.LastName;
			fieldMidName.Text	= agentEdit.MidName;
			fieldBirthDay.Value	= agentEdit.BirthDay;
			fieldPhone.Text		= agentEdit.Phone;
			fieldEMail.Text		= agentEdit.EMail;
		}

		/// <summary>
		/// Конструктор формы создания Контрагента
		/// </summary>
		public AgentsEditForm()
		{
			InitializeComponent();
			fieldGUID.Text		= Guid.NewGuid().ToString();
			fieldBirthDay.Value	= DateTime.Today;
		}

		/// <summary>
		/// Сохранение изменений
		/// </summary>
		private void buttonOK_Click(object sender, EventArgs e)
		{
			agentEdit.GUID		= Guid.Parse(fieldGUID.Text);
			agentEdit.FirstName	= fieldFirstName.Text;
			agentEdit.LastName	= fieldLastName.Text;
			agentEdit.MidName	= fieldMidName.Text;
			agentEdit.BirthDay	= fieldBirthDay.Value;
			agentEdit.Phone		= fieldPhone.Text;
			agentEdit.EMail		= fieldEMail.Text;

			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
