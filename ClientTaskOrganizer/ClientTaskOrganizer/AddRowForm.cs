﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTaskOrganizer
{
    public partial class AddRowForm : Form
    {
        public AddRowForm()
        {
            InitializeComponent();
        }

        private void AddRowForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        public void butOk_Click(object sender, EventArgs e)
        {
            
        }
    }
}