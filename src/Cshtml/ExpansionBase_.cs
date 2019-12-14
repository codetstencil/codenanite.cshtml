using System;
using System.Collections.Generic;  
using System.Diagnostics;  
using System.Linq;  
using System.Reflection;  
using System.Text;
using System.Windows.Forms;
using Pluralize.NET;
using ZeraSystems.CodeStencil.Contracts;  
  
namespace ZeraSystems.CodeNanite.Cshtml  
{  
    public abstract partial class ExpansionBase  
    {  
        public StringBuilder ExpandedText = new StringBuilder();  
  
        private List<ISchemaItem> _schemaItem;  
        private List<IExpander> _expander;  
        public const string StrLineFeed = "\n";  
        public const string StrCarriageReturn = "\r";  
        public const string SingleQuote = "\"";

        public enum Noun
        {
            Singularize,
            Pluralize,
            Default
        }
        public void Initializer(List<ISchemaItem> schemaItem, List<IExpander> expander)  
        {  
            _schemaItem = schemaItem;  
            _expander = expander;  
        }  
  
        public string GetTable(string table)  
        {  
            var name = GetTables()  
                           .Where(e => e.ColumnName == table && string.IsNullOrEmpty(e.ColumnType))  
                           .Select(e => e.ColumnName)  
                           .SingleOrDefault() ?? string.Empty;  
            return name;  
        }

        public string GetTableLabel(string table)
        {
            var name = _schemaItem
                .Where(e => e.TableName == table && e.ColumnType != null && e.IsTableLabel == true)
                .Select(e => e.ColumnName)
                .FirstOrDefault(); //?? string.Empty;
            return name;
        }


        public string GetPrimaryKey(string table)
        {
            var name = _schemaItem
                .Where(e => e.TableName == table && e.IsPrimaryKey)
                .Select(e => e.ColumnName)
                .FirstOrDefault(); //?? string.Empty;
            return name;
        }

        /// <summary>  
        /// Return the tables in database as a List Collection  
        /// </summary>  
        /// <returns>Returned List of Table</returns>  
        public List<ISchemaItem> GetTables()  
        {  
            return _schemaItem  
                .Where(e => string.IsNullOrEmpty(e.ColumnType))  
                .ToList();  
        }  
  
        /// <summary>  
        /// Returns columns in the passed table as a List Collection  
        /// </summary>  
        /// <param name="table"></param>  
        /// <returns>Returned List of Columns</returns>  
        public List<ISchemaItem> GetColumns(string table)  
        {  
            return _schemaItem  
                .Where(e => !string.IsNullOrEmpty(e.ColumnType))  
                .Where(e => e.TableName == table)  
                .ToList();  
        }

        public List<ISchemaItem> GetColumnsAndNavigation(string table)
        {
            var columns = GetColumns(table);

            // Get primary key
            var primaryKey = _schemaItem
                .FirstOrDefault(e => (e.TableName == table && e.IsPrimaryKey));

            var list = new List<ISchemaItem>();
            if (primaryKey != null)
            {
                list = _schemaItem
                    .Where(e => !string.IsNullOrEmpty(e.ColumnType))
                    .Where(e => (e.ColumnName == primaryKey.ColumnName && e.RelatedTable == table))
                    .ToList();
            }
            if (list.Count > 0)
            {
                return columns.Concat(list).ToList();
            }
            return columns;
        }

        /// <summary>
        /// Clear the current string - ExpandedText
        /// </summary>
        public virtual void AppendText() => ExpandedText.Clear();

        public virtual void AppendText(string text, string linefeed = StrLineFeed) => ExpandedText.Append(text + linefeed);

        /// <summary>  
        /// Confirm the passed table is in database  
        /// </summary>  
        /// <param name="name"></param>  
        public void IsTableInDatabase(string name)  
        {  
            var isTable = _schemaItem.Where(s => s.ColumnName == name)  
                .Where(s => string.IsNullOrEmpty(s.ColumnType));  
        }

        /// <summary>
        /// Create an indent of x spaces
        /// </summary>
        /// <param name="indent">Number to indent by</param>
        /// <returns>Indented string</returns>
        public virtual string Indent(int indent) => string.Empty.PadLeft(indent);

        #region Project Settings  

        public string GetExpansionString(string label)  
        {  
            var text = _expander.Where(e => e.ExpansionLabel == label).Select(x => x.ExpansionString);  
            return text.FirstOrDefault();  
        }

        public string GetDefaultNameSpace() => GetExpansionString("NAMESPACE");

        public string GetOrganizationLabel() => GetExpansionString("ORGANIZATION_LABEL");

        public string GetOrganizationName() => GetExpansionString("ORGANIZATION_NAME");

        public string GetProjectName() => GetExpansionString("PROJECT_NAME");  
  
        public string GetOutputFolder() => GetExpansionString("OUTPUT_FOLDER");

        public string GetCompanyName() => FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).CompanyName;

        #endregion Project Settings  

        public string Singularize(string text) => new Pluralizer().Singularize(text);
        public  string Pluralize(string text) => new Pluralizer().Pluralize(text);


        void GetInput(List<string> inputlist, int index=0)
        {
            
        }
    }
}
