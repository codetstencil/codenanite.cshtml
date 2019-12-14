// ***********************************************************************
// Assembly         : ZeraSystems.CodeNanite.Expansion
// Author           : Ayodele-Desktop
// Created          : 12-09-2018
//
// Last Modified By : Ayodele-Desktop
// Last Modified On : 12-31-2018
// ***********************************************************************
// <copyright file="frmSelectEntities.Designer.cs" company="ZeraSystems Inc.">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZeraSystems.CodeNanite.Cshtml
{
    /// <summary>
    /// Class frmSelectEntities.
    /// Implements the <see cref="System.Windows.Forms.Form" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class frmSelectEntities
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// <summary>
        /// Disposes of the resources (other than memory) used by the <see cref="T:System.Windows.Forms.Form" />.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBoxTables = new System.Windows.Forms.CheckedListBox();
            this.groupBoxTables = new System.Windows.Forms.GroupBox();
            this.tlpTables = new System.Windows.Forms.TableLayoutPanel();
            this.chkTables = new System.Windows.Forms.CheckBox();
            this.groupBoxRelatedTables = new System.Windows.Forms.GroupBox();
            this.tlpRelatedTables = new System.Windows.Forms.TableLayoutPanel();
            this.checkedListBoxRelated = new System.Windows.Forms.CheckedListBox();
            this.chkRelatedTables = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxForeignKeyTables = new System.Windows.Forms.GroupBox();
            this.tlpForeignKeys = new System.Windows.Forms.TableLayoutPanel();
            this.checkedListBoxForeign = new System.Windows.Forms.CheckedListBox();
            this.chkForeignKeyTables = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBoxTables.SuspendLayout();
            this.tlpTables.SuspendLayout();
            this.groupBoxRelatedTables.SuspendLayout();
            this.tlpRelatedTables.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBoxForeignKeyTables.SuspendLayout();
            this.tlpForeignKeys.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxTables
            // 
            this.checkedListBoxTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxTables.FormattingEnabled = true;
            this.checkedListBoxTables.Location = new System.Drawing.Point(3, 28);
            this.checkedListBoxTables.Name = "checkedListBoxTables";
            this.checkedListBoxTables.Size = new System.Drawing.Size(141, 192);
            this.checkedListBoxTables.TabIndex = 1;
            this.checkedListBoxTables.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxTables_ItemCheck);
            this.checkedListBoxTables.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxTables_SelectedIndexChanged);
            // 
            // groupBoxTables
            // 
            this.groupBoxTables.Controls.Add(this.tlpTables);
            this.groupBoxTables.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTables.Name = "groupBoxTables";
            this.groupBoxTables.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxTables.Size = new System.Drawing.Size(147, 236);
            this.groupBoxTables.TabIndex = 0;
            this.groupBoxTables.TabStop = false;
            this.groupBoxTables.Text = "Tables";
            // 
            // tlpTables
            // 
            this.tlpTables.ColumnCount = 1;
            this.tlpTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTables.Controls.Add(this.checkedListBoxTables, 0, 1);
            this.tlpTables.Controls.Add(this.chkTables, 0, 0);
            this.tlpTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTables.Location = new System.Drawing.Point(0, 13);
            this.tlpTables.Name = "tlpTables";
            this.tlpTables.RowCount = 2;
            this.tlpTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.37441F));
            this.tlpTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.6256F));
            this.tlpTables.Size = new System.Drawing.Size(147, 223);
            this.tlpTables.TabIndex = 0;
            // 
            // chkTables
            // 
            this.chkTables.AutoSize = true;
            this.chkTables.Location = new System.Drawing.Point(3, 3);
            this.chkTables.Name = "chkTables";
            this.chkTables.Size = new System.Drawing.Size(120, 17);
            this.chkTables.TabIndex = 0;
            this.chkTables.Text = "Check/Uncheck All";
            this.chkTables.UseVisualStyleBackColor = true;
            this.chkTables.CheckedChanged += new System.EventHandler(this.chkTables_CheckedChanged);
            // 
            // groupBoxRelatedTables
            // 
            this.groupBoxRelatedTables.Controls.Add(this.tlpRelatedTables);
            this.groupBoxRelatedTables.Location = new System.Drawing.Point(156, 3);
            this.groupBoxRelatedTables.Name = "groupBoxRelatedTables";
            this.groupBoxRelatedTables.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBoxRelatedTables.Size = new System.Drawing.Size(168, 237);
            this.groupBoxRelatedTables.TabIndex = 1;
            this.groupBoxRelatedTables.TabStop = false;
            this.groupBoxRelatedTables.Text = "Related Table(s)";
            // 
            // tlpRelatedTables
            // 
            this.tlpRelatedTables.ColumnCount = 1;
            this.tlpRelatedTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRelatedTables.Controls.Add(this.checkedListBoxRelated, 0, 1);
            this.tlpRelatedTables.Controls.Add(this.chkRelatedTables, 0, 0);
            this.tlpRelatedTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRelatedTables.Location = new System.Drawing.Point(3, 16);
            this.tlpRelatedTables.Name = "tlpRelatedTables";
            this.tlpRelatedTables.RowCount = 2;
            this.tlpRelatedTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.37441F));
            this.tlpRelatedTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.62559F));
            this.tlpRelatedTables.Size = new System.Drawing.Size(162, 221);
            this.tlpRelatedTables.TabIndex = 0;
            // 
            // checkedListBoxRelated
            // 
            this.checkedListBoxRelated.FormattingEnabled = true;
            this.checkedListBoxRelated.Location = new System.Drawing.Point(3, 28);
            this.checkedListBoxRelated.Name = "checkedListBoxRelated";
            this.checkedListBoxRelated.Size = new System.Drawing.Size(156, 94);
            this.checkedListBoxRelated.TabIndex = 1;
            this.checkedListBoxRelated.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxColumns_ItemCheck);
            this.checkedListBoxRelated.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxRelated_SelectedIndexChanged);
            // 
            // chkRelatedTables
            // 
            this.chkRelatedTables.AutoSize = true;
            this.chkRelatedTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRelatedTables.Location = new System.Drawing.Point(3, 3);
            this.chkRelatedTables.Name = "chkRelatedTables";
            this.chkRelatedTables.Size = new System.Drawing.Size(156, 19);
            this.chkRelatedTables.TabIndex = 0;
            this.chkRelatedTables.Text = "Check/Uncheck All";
            this.chkRelatedTables.UseVisualStyleBackColor = true;
            this.chkRelatedTables.CheckedChanged += new System.EventHandler(this.chkColumns_CheckedChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.82779F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.17221F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel4.Controls.Add(this.groupBoxRelatedTables, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBoxTables, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBoxForeignKeyTables, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.51852F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(518, 243);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // groupBoxForeignKeyTables
            // 
            this.groupBoxForeignKeyTables.Controls.Add(this.tlpForeignKeys);
            this.groupBoxForeignKeyTables.Location = new System.Drawing.Point(330, 3);
            this.groupBoxForeignKeyTables.Name = "groupBoxForeignKeyTables";
            this.groupBoxForeignKeyTables.Size = new System.Drawing.Size(180, 236);
            this.groupBoxForeignKeyTables.TabIndex = 2;
            this.groupBoxForeignKeyTables.TabStop = false;
            this.groupBoxForeignKeyTables.Text = "Foreign Key Tables";
            // 
            // tlpForeignKeys
            // 
            this.tlpForeignKeys.ColumnCount = 1;
            this.tlpForeignKeys.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForeignKeys.Controls.Add(this.checkedListBoxForeign, 0, 1);
            this.tlpForeignKeys.Controls.Add(this.chkForeignKeyTables, 0, 0);
            this.tlpForeignKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForeignKeys.Location = new System.Drawing.Point(3, 16);
            this.tlpForeignKeys.Name = "tlpForeignKeys";
            this.tlpForeignKeys.RowCount = 2;
            this.tlpForeignKeys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.37441F));
            this.tlpForeignKeys.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.6256F));
            this.tlpForeignKeys.Size = new System.Drawing.Size(174, 217);
            this.tlpForeignKeys.TabIndex = 0;
            // 
            // checkedListBoxForeign
            // 
            this.checkedListBoxForeign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxForeign.FormattingEnabled = true;
            this.checkedListBoxForeign.Location = new System.Drawing.Point(3, 27);
            this.checkedListBoxForeign.Name = "checkedListBoxForeign";
            this.checkedListBoxForeign.Size = new System.Drawing.Size(168, 187);
            this.checkedListBoxForeign.TabIndex = 1;
            // 
            // chkForeignKeyTables
            // 
            this.chkForeignKeyTables.AutoSize = true;
            this.chkForeignKeyTables.Location = new System.Drawing.Point(3, 3);
            this.chkForeignKeyTables.Name = "chkForeignKeyTables";
            this.chkForeignKeyTables.Size = new System.Drawing.Size(120, 17);
            this.chkForeignKeyTables.TabIndex = 0;
            this.chkForeignKeyTables.Text = "Check/Uncheck All";
            this.chkForeignKeyTables.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.02281F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.97719F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 278);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(526, 26);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(465, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 20);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(403, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 20);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click_1);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.57655F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.42345F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(532, 307);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(526, 269);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(518, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Schema";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(518, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notes/Comments";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.richTextBox, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.linkLabel, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.98712F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.012876F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(374, 233);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // richTextBox
            // 
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(3, 3);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(368, 205);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // linkLabel
            // 
            this.linkLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(3, 215);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(29, 13);
            this.linkLabel.TabIndex = 1;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "See:";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(518, 243);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // frmSelectEntities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 307);
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectEntities";
            this.Text = "frmSelectEntities";
            this.Load += new System.EventHandler(this.frmSelectEntities_Load);
            this.groupBoxTables.ResumeLayout(false);
            this.tlpTables.ResumeLayout(false);
            this.tlpTables.PerformLayout();
            this.groupBoxRelatedTables.ResumeLayout(false);
            this.tlpRelatedTables.ResumeLayout(false);
            this.tlpRelatedTables.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBoxForeignKeyTables.ResumeLayout(false);
            this.tlpForeignKeys.ResumeLayout(false);
            this.tlpForeignKeys.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The checked ListBox tables
        /// </summary>
        private System.Windows.Forms.CheckedListBox checkedListBoxTables;
        /// <summary>
        /// The group box
        /// </summary>
        private System.Windows.Forms.GroupBox groupBoxTables;
        /// <summary>
        /// The group box1
        /// </summary>
        private System.Windows.Forms.GroupBox groupBoxRelatedTables;
        /// <summary>
        /// The checked ListBox columns
        /// </summary>
        private System.Windows.Forms.CheckedListBox checkedListBoxRelated;
        /// <summary>
        /// The table layout panel2
        /// </summary>
        private System.Windows.Forms.TableLayoutPanel tlpTables;
        /// <summary>
        /// The CHK tables
        /// </summary>
        private System.Windows.Forms.CheckBox chkTables;
        /// <summary>
        /// The table layout panel3
        /// </summary>
        private System.Windows.Forms.TableLayoutPanel tlpRelatedTables;
        /// <summary>
        /// The CHK columns
        /// </summary>
        private System.Windows.Forms.CheckBox chkRelatedTables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.GroupBox groupBoxForeignKeyTables;
        private System.Windows.Forms.TableLayoutPanel tlpForeignKeys;
        private System.Windows.Forms.CheckedListBox checkedListBoxForeign;
        private System.Windows.Forms.CheckBox chkForeignKeyTables;
        private System.Windows.Forms.TabPage tabPage3;
    }
}