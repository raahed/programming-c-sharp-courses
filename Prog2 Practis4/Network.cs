namespace Prog2_Practis4
{
    internal class Network
    {
        public class Device
        {
            public Device next = null;

            public int id;

            public int upload = 0;

            public int download = 0;

            public override string ToString()
            {
                return $"Gerät mit der Adresse {id}: Anzahl Uploads/Downloads = {upload}/{download}";
            }
        }

        public Device start = null;

        public void AddDevice(int previous, Device device)
        {
            if (start == null)
            {
                start = device;
                device.next = start;
                return;
            }

            Device search = start;

            while (true)
            {
                if( search.id == previous ) { 
                    device.next = search.next.next;
                    search.next = device;
                    return; 
                }

                if (search.next == start)
                    throw new Exception("Previous device not exists.");

                search = search.next;
            }
        }

        public void RemoveDevice(int id)
        {
            if (start == null)
                throw new ArgumentNullException();

            Device search = start;

            while (true)
            {
                if(id == search.next.id)
                {
                    search.next = search.next.next;
                }

                if (search.next == start)
                    throw new Exception("Previous device not exists.");

                search = search.next;
            }
        }

        public void PrintNetwork()
        {
            Device element = start;

            while(true)
            {
                Console.WriteLine(element);

                if (element.next == start)
                    break;

                element = element.next;
            }
        }
    }
}
