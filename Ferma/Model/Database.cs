using Ferma;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ferma.Model 
{
    public class Database<T> : IEnumerable
    {
        #region Private Variables
        private string filename;
        #endregion

        #region Public Properties
        public ObservableCollection<T> VirtualDatabase { set; get; }
        public T SelectedItem { set; get; }
        public int Count { private set; get; }
        #endregion

        #region Constructors
        public Database(string filename)
        {
            this.filename = filename;
            VirtualDatabase = new ObservableCollection<T>();
            Count = VirtualDatabase.Count;
            try
            {
                Deserialize();
            }
            catch (FileNotFoundException)
            {
                Serialize();
            }
        }
        #endregion

        #region Methods
        public void Add(T arg)
        {
            VirtualDatabase.Add(arg);
            Count++;
            Serialize();
        }

        public void Remove(T arg)
        {
            VirtualDatabase.Remove(arg);
            Count--;
            Serialize();
        }

        public void CopyFrom(Database<T> arg)
        {
            var argCount = arg.Count;
            for (int i = 0; i < argCount; i++)
            {
                VirtualDatabase.Insert(argCount, arg[i]);
            }
        }

        public void Replace()
        {
            Serialize();
        }

        public bool IsEmpty()
        {
            if (Count == 0) return true;
            return false;
        }

        private void Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<T>));
            using (FileStream stream = new FileStream(filename+".xml", FileMode.Create))
            {
                serializer.Serialize(stream, VirtualDatabase);
            }
        }

        private void Deserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<T>));
            using (FileStream stream = new FileStream(filename+ ".xml", FileMode.Open))
            {
                IEnumerable<T> UserData = (IEnumerable<T>)serializer.Deserialize(stream);
                foreach (T temp in UserData)
                {
                    VirtualDatabase.Add(temp);
                    Count++;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                return VirtualDatabase[index];
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var temp in VirtualDatabase)
                yield return temp;
        }

        public void Clear()
        {
            VirtualDatabase.Clear();
            Serialize();
        }

        #endregion
    }
}