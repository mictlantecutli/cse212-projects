public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public int Length => _queue.Count;



    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue irregardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public String Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            Console.WriteLine("The queue is empty.");
            return null;
        }

        // Find the index of the item with the highest priority to remove
        var highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++)//I erase -1 to the _queue.Count, because with that not embrace all the elements in the queue
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)//If as you move through each index of the list you compare it with the first index (0)
            {
                highPriorityIndex = index;

            }
            else if (_queue[index].Priority == _queue[highPriorityIndex].Priority)
            {

            }

        }

        // Remove and return the item with the highest priority

        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        //Console.WriteLine(highPriorityIndex);

        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}