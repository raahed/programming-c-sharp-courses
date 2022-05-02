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
        }

        public Device start = null;

        public void AddDevice(int previous, Device device)
        {
            if (start == null)
            {
                start = device;
                return;
            }

            Device element = start;

            while (element != null || element.id != previous)
                element = element.next;

            Device next = element.next;

            element.next = device;
            device.next = next;
        }

        public void RemoveDevice(int id)
        {
            Device element = start;

            while (element != null || element.id != id)
                element = element.next;

            if (element.next == null)
                element = null;
            else
            {
                
            }


        }

        public Device FindPrevious(Device element)
        {
            Device previous = start;

            while (previous != null)
            {
                if (previous.next == element)
                {
                    return previous;
                }

                previous = previous.next;
            }

            return null;    // Cannot be reached
        }
    }
}
