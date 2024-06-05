using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_2
{
    public class Snapshot
    {
        private Editor _editor;
        private string _text;
        private int _cursorPos;

        public Snapshot(Editor editor)
        {
            _editor = editor;
            _text = editor.Text;
            _cursorPos = editor.CursotPos;
        }

        public Editor Restore()
        {
            _editor.Text = _text;
            _editor.CursotPos = _cursorPos;
            return _editor;
        }

    }
    public class Editor
    {
        private StringBuilder _stringBuilder;
        public string Text 
        { 
            get => _stringBuilder.ToString(); 
            set 
            {
                SetText(value);
            } 
        }
        private int _cursorPos;
        public int CursotPos 
        {
            get => _cursorPos;
            set 
            {
                if (value < 0 || value > _stringBuilder.Length)
                    throw new ArgumentOutOfRangeException();
                _cursorPos = value;
            }
        }

        public Editor(string text) 
        {
            SetText(text);
            CursotPos = 0;
        }
        public Editor() : this("") { }

        public void MoveCursorLeft()
        {
            if (CursotPos == 0)
                return;
            CursotPos--;
        }

        public void MoveCursorRight()
        {
            if(CursotPos + 1 < _stringBuilder.Length)
                CursotPos++;

        }

        public void Del()
        {
            if (CursotPos == 0)
                return;
            var startPosition = CursotPos - 1;
            var length = 1;
            _stringBuilder.Remove(startPosition, length);
            MoveCursorLeft();
        }

        public Snapshot CreateSnapshot()
        {
            return new Snapshot(this);
        }

        private void SetText(string text)
        {
            if (text == null)
                throw new ArgumentNullException($"{nameof(text)} is null");
            _stringBuilder = new StringBuilder(text);
            CursotPos = 0;
        }

    }
}
