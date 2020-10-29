using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    class CustomDictionaryIEnumeratorT_V <T>: IEnumerator<T>
    {
        List<T> KeyAndValuePairs;
        T currentPair;
        private int position;
      

        public CustomDictionaryIEnumeratorT_V(List<T> KeyAndValuePairs)
        {
            this.KeyAndValuePairs = KeyAndValuePairs;
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
           if (Current == null && position == -1)
            {
                position++;
                currentPair = KeyAndValuePairs[position];
                return true;              
            }
           if (position < KeyAndValuePairs.Count-1)
            {
                position++;
                currentPair = KeyAndValuePairs[position];
                return true;
            }
            Reset();
            return false;
                      
        }

        public void Reset()
        {
            currentPair = default(T);
        }



    }
}
