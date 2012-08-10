using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AIPolicy
{
    internal class UndoState<T> : IUndoState<T>
    {
        readonly BinaryFormatter _formatter;
        readonly byte[] _stateData;

        internal UndoState(T state)
        {
            _formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                try
                {
                    _formatter.Serialize(stream, state);
                    _stateData = stream.ToArray();
                }
// ReSharper disable EmptyGeneralCatchClause
                catch (Exception)
// ReSharper restore EmptyGeneralCatchClause
                {
                }
            }
        }

        public T State
        {
            get
            {
                using (var stream = new MemoryStream(_stateData))
                {
                    return (T)_formatter.Deserialize(stream);
                }
            }
        }
    }
}
