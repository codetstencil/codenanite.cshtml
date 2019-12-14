// ***********************************************************************
// Assembly         : ZeraSystems.CodeNanite.Expansion
// Author           : Ayodele-Desktop
// Created          : 12-09-2018
//
// Last Modified By : Ayodele-Desktop
// Last Modified On : 01-03-2019
// ***********************************************************************
// <copyright file="frmSelectEntities.cs" company="ZeraSystems Inc.">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ZeraSystems.CodeStencil.Contracts;
using ZeraSystems.CodeNanite.Expansion;

namespace ZeraSystems.CodeNanite.Cshtml
{
    /// <summary>
    /// Class frmSelectEntities.
    /// Implements the <see cref="System.Windows.Forms.Form" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class frmSelectEntities : Form
    {
        #region Fields

        /// <summary>
        /// The utility
        /// </summary>
        private readonly BaseHelper _util = new BaseHelper();

        /// <summary>
        /// The selected object string
        /// </summary>
        private readonly StringBuilder _selectedObjectString = new StringBuilder();

        /// <summary>
        /// The tables
        /// </summary>
        private List<ISchemaItem> _tables;

        /// <summary>
        /// The related tables
        /// </summary>
        private List<ISchemaItem> _relatedTables;

        private List<ISchemaItem> _foreignKeysInTable;

        /// <summary>
        /// The schema item copy
        /// </summary>
        private readonly List<ISchemaItem> _schemaItemCopy;

        private readonly string _entitiesString;

        /// <summary>
        /// Contains the result of the selected tables and columns in the form:
        ///
        /// [Table1]
        /// column1, column2, ccolumn3
        ///
        /// </summary>
        /// <summary>
        /// Gets the schema string.
        /// </summary>
        /// <value>The schema string.</value>
        public string SchemaString { get; private set; }

        #endregion Fields

        public string Url { get; set; }
        public string Comments { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="frmSelectEntities"/> class.
        /// </summary>
        public frmSelectEntities() => InitializeComponent();

        /// <summary>
        /// Initializes a new instance of the <see cref="frmSelectEntities"/> class.
        /// </summary>
        /// <param name="schemaItem">The schema item.</param>
        /// <param name="expander">The expander.</param>
        /// <summary>
        /// Initializes a new instance of the <see cref="frmSelectEntities"/> class.
        /// </summary>
        /// <param name="schemaItem">The schema item.</param>
        /// <param name="expander">The expander.</param>
        /// <param name="entitiesString">String containing the Tables/Columns</param>
        public frmSelectEntities(List<ISchemaItem> schemaItem, List<IExpander> expander, string entitiesString) : this()
        {
            _schemaItemCopy = schemaItem.DeepClone();
            _entitiesString = entitiesString;

            _util.Initializer(_schemaItemCopy, expander);
            FillTables(true);
            linkLabel.Text = Url;
            richTextBox.Text = Comments;
        }

        private void frmSelectEntities_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Handles the SelectedIndexChanged event of the checkedListBoxTables control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void checkedListBoxTables_SelectedIndexChanged(object sender, System.EventArgs e) => SelectTableRow();

        /// <summary>
        /// Handles the ItemCheck event of the checkedListBoxColumns control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
        private void checkedListBoxColumns_ItemCheck(object sender, ItemCheckEventArgs e) => CheckColumn(sender, e);

        /// <summary>
        /// Handles the ItemCheck event of the checkedListBoxTables control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
        private void checkedListBoxTables_ItemCheck(object sender, ItemCheckEventArgs e) => CheckTable(e);

        /// <summary>
        /// Handles the CheckedChanged event of the chkTables control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkTables_CheckedChanged(object sender, EventArgs e) => CheckUncheckAll(chkTables.Checked);

        /// <summary>
        /// Handles the CheckedChanged event of the chkColumns control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkColumns_CheckedChanged(object sender, EventArgs e) => CheckUncheckAll(chkRelatedTables.Checked, _selectedTable);

        private void btnOk_Click_1(object sender, EventArgs e) => SaveEntities();

        private void checkedListBoxRelated_SelectedIndexChanged(object sender, EventArgs e) => SelectRelatedTableRow();
    }

    /// <summary>
    /// Class BaseHelper.
    /// Implements the <see cref="ZeraSystems.CodeNanite.Expansion.ExpansionBase" />
    /// </summary>
    /// <seealso cref="ZeraSystems.CodeNanite.Expansion.ExpansionBase" />
    public class BaseHelper : ExpansionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpansionBase"/> class.
        /// </summary>
        public BaseHelper()
        {
            //Initializer(schemaItem, Expander);
        }
    }
}