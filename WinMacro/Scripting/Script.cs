using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace WinMacro.Scripting
{
    public class Script
    {
        private static ScriptEngine m_engine = Python.CreateEngine();
        private ScriptScope m_scope;

        public string Content { get; private set; }

        public Script(string script)
        {
            Content = script;
            m_scope = m_engine.CreateScope();
        }

        public bool HasVariable(string name)
        {
            return m_scope.ContainsVariable(name);
        }

        public dynamic GetVariable(string name)
        {
            return m_scope.GetVariable(name);
        }

        public void SetVariable(string name, object value)
        {
            m_scope.SetVariable(name, value);
        }

        public void Execute()
        {
            m_engine.Execute(Content, m_scope);
        }
    }
}
