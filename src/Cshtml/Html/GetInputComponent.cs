using System.Collections.Generic;
using System.ComponentModel.Composition;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    /// <summary>
    /// There are 6 elements in the String Array used by the
    /// 0 - Publisher : This is the name of the publisher
    /// 1 - Title : This is the title of the Code Nanite
    /// 2 - Details : This is the
    /// 3 - Version Number
    /// 4 - Label : Label of the Code Nanite
    /// 5 - Namespace
    /// 6 - Release Date
    /// 7 - Name to use for Expander Label
    /// 8 - Indicates that the Nanite is Schema Dependent
    /// 9 - RESERVED
    /// 10 - RESERVED
    /// </summary>
    [Export(typeof(ICodeStencilCodeNanite))]
    [CodeStencilCodeNanite(new[]
    {
        // 0
        "Zera Systems Inc.",  
        // 1
        "Returns an Input Component",    
        // 2
        "Returns an Input Component based on the data type of the column..",                                   
        // 3
        "1.0",                                  
        // 4
        "GetInputComponent",                         
        // 5
        "ZeraSystems.CodeNanite.Cshtml",               
        // 6
        "07/02/2020",                           
        // 7
        "CS_CSHTML_INPUT",                        
        // 8
        "1",                                   
        // 9
        "", 
        // 10
        ""                                      
    })]
    public partial class GetInputComponent : ExpansionBase, ICodeStencilCodeNanite
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public int Counter { get; set; }
        public List<string> OutputList { get; set; }
        public List<ISchemaItem> SchemaItem { get; set; }
        public List<IExpander> Expander { get; set; }
        public List<string> InputList { get ; set; }

        public void ExecutePlugin()
        {
            Initializer(SchemaItem, Expander);
            MainFunction();
        }
    }
}