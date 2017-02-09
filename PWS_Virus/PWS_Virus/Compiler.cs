using System.Collections.Generic;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Windows.Forms;

namespace PWS_Virus
{
    class Compiler
    {
        /// <summary>
        /// Compiles the stubcode using codedom and allows for icons and managed resources to be embedded
        /// </summary>
        /// <param name="source">The stubcode to be used</param>
        /// <param name="Output">The output file location</param>
        /// <param name="Icon">The icon file location</param>
        /// <param name="Resources">Resources to be embedded</param>
        /// <returns>Returns a true or false depending on whether it successfully compiled or not</returns>
        public static bool CompileFromSource(string source, string Output, string Icon = null, string[] Resources = null)
        {
            //object contains all the compile settings
            CompilerParameters cp = new CompilerParameters();

            //Generate executable
            cp.GenerateExecutable = true;
            //Output to given directory
            cp.OutputAssembly = Output;
            //Disable warnings, show only hard errors
            cp.TreatWarningsAsErrors = false;
            
            //Add references
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Core.dll");
            cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            cp.ReferencedAssemblies.Add("System.Drawing.dll");
            cp.ReferencedAssemblies.Add("System.Data.dll");
            cp.ReferencedAssemblies.Add("System.Xml.dll");
            cp.ReferencedAssemblies.Add("System.Xml.Linq.dll");
            cp.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll");
            
            //Optimize the code, make it compatible with x86/32bits and allow pointer editing
            string options = "/optimize+ /platform:x86 /target:winexe /unsafe";
            //Whether or not to use an icon
            if (Icon != null)
                options += " /win32icon:\"" + Icon + "\"";
            //Set the options
            cp.CompilerOptions = options;

            //If resources are attached (managed) add them
            if (Resources != null && Resources.Length > 0)
            {
                //Loop through all resources and add them
                foreach (string res in Resources)
                {
                    cp.EmbeddedResources.Add(res);
                }
            }

            //Compile the code and return the results into the results variable
            CompilerResults Results = new CSharpCodeProvider(new Dictionary<string, string>()
            { { "CompilerVersion", "v4.0" } }).CompileAssemblyFromSource(cp, source);

            //Check for compiling errors
            if (Results.Errors.Count > 0)
            {
                
                MessageBox.Show(string.Format("The compiler has encountered {0} errors", Results.Errors.Count), 
                    "Errors while compiling", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Show all of the concequent errors
                foreach (CompilerError error in Results.Errors)
                {
                    MessageBox.Show(string.Format("{0}\nLine: {1} - Column: {2}\nFile: {3}", error.ErrorText,
                        error.Line, error.Column, error.FileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;

            }
            else
            {
                //No errors, return true
                return true;
            }

        }
    }
}
