
using System;
namespace BateEkranDeneme.Classes
{
    public class EvrakPrimaryKey
    {
        private int mikroRecNo = 0;
        private Guid mikroGuid = new Guid();

        public int MikroRecNo
        {
            get { return mikroRecNo; }
            set { mikroRecNo = value; }
        }

        public Guid MikroGuid
        {
            get { return mikroGuid; }
            set { mikroGuid = value; }
        }
    }
}