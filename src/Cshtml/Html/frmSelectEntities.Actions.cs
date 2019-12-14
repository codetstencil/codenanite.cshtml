// ***********************************************************************
// Assembly         : ZeraSystems.CodeNanite.Expansion
// Author           : Ayodele-Desktop
// Created          : 12-29-2018
//
// Last Modified By : Ayodele-Desktop
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="frmSelectEntities.Actions.cs" company="ZeraSystems Inc.">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    /// <summary>
    /// Class frmSelectEntities.
    /// Implements the <see cref="System.Windows.Forms.Form" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class frmSelectEntities
    {
        /// <summary>
        /// Checks the column.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
        private void CheckColumn(object sender, ItemCheckEventArgs e)
        {
            SetCheckState(sender, e);
            var table = checkedListBoxTables.GetItemText(checkedListBoxTables.SelectedItem);
            var column = checkedListBoxRelated.GetItemText(checkedListBoxRelated.SelectedItem);
            var check = e.NewValue == CheckState.Checked;
            SaveToObject(table, column, check);
        }

        /// <summary>
        /// Checks the table.
        /// </summary>
        /// <param name="e">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
        private void CheckTable(ItemCheckEventArgs e)
        {
            var table = checkedListBoxTables.GetItemText(checkedListBoxTables.SelectedItem);
            var check = e.NewValue == CheckState.Checked;
            SaveTableCheckState(table, check);
        }

        /// <summary>
        /// Creates the columns string.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns>System.String.</returns>
        private string CreateColumnsString(string table)
        {
            var columns = _util.GetColumns(_schemaItemCopy, table, true).Select(x => x.ColumnName).ToList();
            return string.Join(",", columns);
        }

        /// <summary>
        /// Fills the columns.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="checkState">State of the check.</param>
        private void FillRelatedTables(string table, CheckState checkState)
        {
            if (checkState == CheckState.Checked)
                FillRelatedTables(table);
        }

        /// <summary>
        /// Fills the columns.
        /// </summary>
        /// <param name="table">The table.</param>
        private void FillRelatedTables(string table)
        {
            checkedListBoxRelated.Items.Clear();
            _relatedTables = _util.GetRelatedTables(_schemaItemCopy, table);
            foreach (var item in _relatedTables)
                checkedListBoxRelated.Items.Add(item.TableName, item.IsChecked);

        }

        private void FillForeignKeyTables(string table, CheckState checkState)
        {
            if (checkState == CheckState.Checked)
                FillForeignKeyTables(table);
        }

        private void FillForeignKeyTables(string table)
        {
            checkedListBoxForeign.Items.Clear();
            _foreignKeysInTable = _util.GetForeignKeysInTable(_schemaItemCopy, table)
                .Where(x=>x.RelatedTable != _selectedTable).ToList();
            foreach (var item in _foreignKeysInTable)
                checkedListBoxForeign.Items.Add(item.RelatedTable, item.IsChecked);

        }


        /// <summary>
        /// Fills the tables.
        /// </summary>
        private void FillTables(bool firstTime = false)
        {
            checkedListBoxTables.Items.Clear();
            _tables = _util.GetTables(_schemaItemCopy);
            foreach (var item in _tables)
            {
                if (firstTime)
                {
                    if (_util.GetColumnsFromSettings(_entitiesString, item.TableName) == null)
                    {
                        checkedListBoxTables.Items.Add(item.TableName, false);
                        continue;
                    }
                    else
                        checkedListBoxTables.Items.Add(item.TableName, true);
                }
                else
                    checkedListBoxTables.Items.Add(item.TableName, item.IsChecked);
            }
        }

        /// <summary>
        /// Saves the entities.
        /// </summary>
        private void SaveEntities()
        {
            var tables = _tables
                .Where(x => x.IsChecked).ToList();
            foreach (var item in tables)
            {
                _selectedObjectString.Append("[" + item.TableName + "]".AddCarriage());
                _selectedObjectString.Append(CreateColumnsString(item.TableName).AddCarriage().AddCarriage());
            }
            SchemaString = _selectedObjectString.ToString();
        }

        /// <summary>
        /// Saves to object.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="column">The column.</param>
        /// <param name="check">if set to <c>true</c> [check].</param>
        private void SaveToObject(string table, string column, bool check)
        {
            _schemaItemCopy
                .Where(x => (x.TableName == table && x.ColumnName == column))
                .ToList()
                .ForEach(x => { x.IsChecked = check; });
        }

        /// <summary>
        /// Saves the state of the table check.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="check">if set to <c>true</c> [check].</param>
        private void SaveTableCheckState(string table, bool check)
        {
            try
            {
                _schemaItemCopy
                    .Where(x => (x.TableName == table && string.IsNullOrEmpty(x.ColumnType)))
                    .ToList()
                    .ForEach(x => { x.IsChecked = check; });
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// The selected table
        /// </summary>
        private string _selectedTable;

        /// <summary>
        /// Selects the table row.
        /// </summary>
        private void SelectTableRow()
        {
            try
            {
                checkedListBoxRelated.Items.Clear();
                checkedListBoxForeign.Items.Clear();
                _selectedTable = checkedListBoxTables.GetItemText(checkedListBoxTables.SelectedItem);
                var checkState = checkedListBoxTables.GetItemCheckState(checkedListBoxTables.SelectedIndex);
                FillRelatedTables(_selectedTable, checkState);
            }
            catch (Exception)
            {
            }
        }

        private string _selectedRelatedTable;

        private void SelectRelatedTableRow()
        {
            try
            {
                checkedListBoxForeign.Items.Clear();
                _selectedRelatedTable = checkedListBoxRelated.GetItemText(checkedListBoxRelated.SelectedItem);
                var checkState = checkedListBoxRelated.GetItemCheckState(checkedListBoxRelated.SelectedIndex);
                FillForeignKeyTables(_selectedRelatedTable, checkState);
            }
            catch (Exception)
            {
            }
        }


        /// <summary>
        /// Sets the state of the check.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
        private void SetCheckState(object sender, ItemCheckEventArgs e)
        {
            try
            {
                var clb = (CheckedListBox)sender;
                // Switch off event handler
                clb.ItemCheck -= checkedListBoxColumns_ItemCheck;
                clb.SetItemCheckState(e.Index, e.NewValue);
                // Switch on event handler
                clb.ItemCheck += checkedListBoxColumns_ItemCheck;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Checks the uncheck all.
        /// </summary>
        /// <param name="check">if set to <c>true</c> [check].</param>
        private void CheckUncheckAll(bool check)
        {
            _schemaItemCopy
                .Where(x => (string.IsNullOrEmpty(x.ColumnType)))
                .ToList()
                .ForEach(x => { x.IsChecked = check; });
            FillTables();
        }

        /// <summary>
        /// Checks the uncheck all.
        /// </summary>
        /// <param name="check">if set to <c>true</c> [check].</param>
        /// <param name="table">The table.</param>
        private void CheckUncheckAll(bool check, string table)
        {
            _schemaItemCopy
                .Where(x => (x.TableName == table && !string.IsNullOrEmpty(x.ColumnType)))
                .ToList()
                .ForEach(x => { x.IsChecked = check; });
            FillRelatedTables(table);
        }
    }
}