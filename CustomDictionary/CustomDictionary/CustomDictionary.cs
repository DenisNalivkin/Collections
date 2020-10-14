using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
  public class CustomDictionary <T,V> where V : new()
    {      
       List<PairKeyAndValue<T,V>> KeyAndValuePairs;
       public int count { get; private  set; }

        public CustomDictionary()
        {
           KeyAndValuePairs = new List<PairKeyAndValue<T, V>>();
           
        }

        public V this[T key]
        {
         get
          {
           PairKeyAndValue<T, V> currentPair;
           foreach (var pair in KeyAndValuePairs)
           {
           if (pair.key.Equals(key))
           {
             return pair.value;
           }

           }
            throw new KeyNotFoundException();
           }
             
         set
         {
          PairKeyAndValue<T, V> currentPair;
          bool wasSeted = false;
          foreach (var pair in KeyAndValuePairs)
          {
             if (pair.key.Equals(key))
             {
               pair.value = value;
               wasSeted = true;
               break;                 
             }
          }
          if (!wasSeted)
          {
             throw new KeyNotFoundException();
          }                
            }
        }

        public void Add (T key, V value)
        {
            PairKeyAndValue<T,V> pairKeyAndValue = new PairKeyAndValue<T,V>(key, value);
            KeyAndValuePairs.Add(pairKeyAndValue);
            count += 1;       
        }

        public bool ContainsKey(T Key)
        {
            bool wantedKeyWasFound = false;
            PairKeyAndValue<T, V> currentPair;
            foreach(var pair in KeyAndValuePairs)
            {
                if (pair.key.Equals(Key))
                {
                    wantedKeyWasFound = true;
                    break;                    
                }
            }
            return wantedKeyWasFound;            
        }

        public bool TryGetValue (T key, out V value) 
        {           
            value = new V();
            bool wantedKeyWasFound = false;
            foreach (var pair in KeyAndValuePairs)
            {
                if(pair.key.Equals(key))
                {
                    wantedKeyWasFound = true;
                    value = pair.value;
                    break;
                }                        
            }
            return wantedKeyWasFound;           
        }

        public void Remove (T key)
        {
            foreach (var pair in KeyAndValuePairs)
            {
                if(pair.key.Equals(key))
                {
                    KeyAndValuePairs.Remove(pair);
                    this.count -= 1;
                    break;                                  
                }
            }
        }

        public void Clear ()
        {       
         KeyAndValuePairs.Clear();
         this.count = 0;                    
        }









    }



}
