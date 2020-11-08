using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioEnStepGeel.Messages
{
    class CloseMessage
    {
        public enum MessageType { Closed };
        public CloseMessage(MessageType Actie)
        {
            Type = Actie;
            Console.WriteLine("CloseMessage");
        }

        public MessageType Type { get; set; }
    }
}
