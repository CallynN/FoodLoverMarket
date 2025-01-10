using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENV.UI
{
    public class ContextMenuMap
    {
        Dictionary<int, Func<System.Windows.Forms.ContextMenuStrip>> _menues =
            new Dictionary<int, Func<System.Windows.Forms.ContextMenuStrip>>();
        Dictionary<int, Func<System.Windows.Forms.ContextMenuStrip>> _menuFactories =
            new Dictionary<int, Func<System.Windows.Forms.ContextMenuStrip>>();
        protected void Add(int index,Func<System.Windows.Forms.ContextMenuStrip> contextMenu)
        {
            _menuFactories.Add(index, contextMenu);
            _menues.Add(index, () =>
                                   {
                                       var result = contextMenu();
                                       _menues[index] = () => result;
                                       _dispose.Add(result);
                                       return result;
                                   });
        }

        internal void InternalAdd(int index, Func<System.Windows.Forms.ContextMenuStrip> contextMenu)
        {
            Add(index, contextMenu);
        }

        List<IDisposable> _dispose = new List<IDisposable>();
        public System.Windows.Forms.ContextMenuStrip Find(int index)
        {
            if (_menues.ContainsKey(index))
            {
                return _menues[index]();
            }
            return null;
        }
        public System.Windows.Forms.ContextMenuStrip Create(int index)
        {
            if (_menues.ContainsKey(index))
            {
                var r =  _menuFactories[index]();
                _dispose.Add(r);
                return r;
            }
            return null;
        }
        public void Dispose()
        {
            foreach (var menu in _dispose)
            {
                menu.Dispose();
            }
        }
    }
}
