using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    class CustomDictionaryIEnumeratorT_V <T,V>: IEnumerator<T,V>
    {
        List<PairKeyAndValue<T,V>> KeyAndValuePairs;
        PairKeyAndValue<T,V> currentPair;
        private int position;
      

        public CustomDictionaryIEnumeratorT_V(List<PairKeyAndValue<T,V>> KeyAndValuePairs)
        {
            this.KeyAndValuePairs = KeyAndValuePairs;
            this.position = -1;
        }



        public T Current
        {
            get
            {
                return currentPair.key;               
            }
            
        }

        object IEnumerator<T,V>.Current
        {
            get
            {
                return (object)this.Current;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
           if ( currentPair == null && position == -1)
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
            currentPair = null;
        }



    }
}
