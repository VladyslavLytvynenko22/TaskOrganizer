// <copyright file="WorkWithDataGridViewTest.cs">Copyright ©  2019</copyright>
using System;
using System.Windows.Forms;
using ClientTaskOrganizer;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClientTaskOrganizer.Tests
{
    /// <summary>Этот класс содержит параметризованные модульные тесты для WorkWithDataGridView</summary>
    [PexClass(typeof(WorkWithDataGridView))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class WorkWithDataGridViewTest
    {
        /// <summary>Тестовая заглушка для CheckDataGridViewRow(DataGridView)</summary>
        [PexMethod]
        internal bool CheckDataGridViewRowTest(DataGridView dataGridView)
        {
            bool result = WorkWithDataGridView.CheckDataGridViewRow(dataGridView);
            return result;
            // TODO: добавление проверочных утверждений в метод WorkWithDataGridViewTest.CheckDataGridViewRowTest(DataGridView)
        }
    }
}
