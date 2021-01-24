using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    /// <summary>
    /// This class implementation interface IEnumerator generic.
    /// </summary>
    /// <typeparam name="T">This generic type is object class PairKeyAndValue. </typeparam>
    class CustomDictionaryIEnumeratorT_V <T>: IEnumerator<T>
    {
        List<T> keyValuePairs;
        T currentPair;
        private int position;
      

        public CustomDictionaryIEnumeratorT_V(List<T> KeyAndValuePairs)
        {
            this.keyValuePairs = KeyAndValuePairs;
            this.position = -1;
        }

       
        public T Current
        {
            get
            {                         
                return currentPair;
            }
            
        }

        object IEnumerator.Current
        {
            get
            {
                return currentPair;
            }
        }
        /// <summary>
        /// This method does finalize for object.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// This method  goes over objects PairKeyAndValue and return them for  property Current.
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
           if (Current == null && position == -1)
            {
                position++;
                currentPair = keyValuePairs[position];
                return true;              
            }
           if (position < keyValuePairs.Count-1)
            {
                position++;
                currentPair = keyValuePairs[position];
                return true;
            }
            Reset();
            return false;

        }


        /// <summary>
        /// This method install default value for property currentPair.
        /// </summary>
        public void Reset()
        {
            currentPair = default(T);
        }



    }
}
