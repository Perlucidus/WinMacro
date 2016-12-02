using IronPython.Runtime.Types;
using System;
using System.IO;
using System.Windows.Forms;
using WinMacro.Scripting;

namespace WinMacro.Macro.Function
{
    public class ExecuteScript : MacroFunction
    {
        private string m_content;
        private Script m_script;

        public ExecuteScript()
        {
            Script = String.Empty;
        }

        public ExecuteScript(string script)
        {
            Script = script;
        }

        #region ISerializable Implementation

        public override void Serialize(BinaryWriter writer)
        {
            writer.Write(Script);
        }

        public override void Deserialize(BinaryReader reader)
        {
            Script = reader.ReadString();
        }

        #endregion

        public override void Execute()
        {
            try
            {
                m_script.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Program.MainForm.Notify("Failed to execute script.", "", ToolTipIcon.Error);
            }
        }

        public override Object Clone()
        {
            return new ExecuteScript(Script);
        }

        public override String ToString()
        {
            return Script;
        }

        public string Script
        {
            get
            {
                return m_content;
            }
            set
            {
                m_content = value;
                m_script = new Script(m_content);
                AddScriptDefinitions();
            }
        }

        private void AddScriptDefinitions()
        {
            m_script.SetVariable("keys", DynamicHelpers.GetPythonTypeFromType(typeof(Keys)));
            m_script.SetVariable("keyboard", DynamicHelpers.GetPythonTypeFromType(typeof(KeyboardScriptAPI)));
            m_script.SetVariable("mouse", DynamicHelpers.GetPythonTypeFromType(typeof(MouseScriptAPI)));
        }
    }
}
