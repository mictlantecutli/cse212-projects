using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new Node(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // Create a new Node
        Node newNode = new Node(value);

        //if the list is empty, the head and tail will be the "newNode"
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;

        }
        //if the list is not empty
        else
        {
            newNode.Prev = _tail; //the previous the newNode will be the _tail
            _tail.Next = newNode; //the next of the _tail will be the newNode
            _tail = newNode; //Now the _tail will be the newNode

        }


    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // If in the list we have only one element. This element is _head and _tail
        //so when remove either of two set as "null"
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the tail
        // will be affected.
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null; // If the previous element of the _tail is not null, then set the next element of the previous of the _tail as NULL
            _tail = _tail.Prev; // Set the _tail as the previous element of the _tail
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        //we start from the _head, it is the first element 
        Node? current = _head;

        //while every element of the list is not null we iterate in every element of the list
        while (current is not null)
        {
            //if one of the element in the iteration is equal to the value(input)
            if (current.Data == value)
            {
                //if the element is at the end of the list, call the RemoveTail() function
                if (current == _tail)
                {
                    RemoveTail();
                }
                //if the element is at the fist of the list call the function RevoveHead() function
                else if (current == _head)
                {
                    RemoveHead();
                }
                //if the the list only have one element, set every one as null
                else if (_head == _tail)
                {
                    _head = null;
                    _tail = null;
                }
                else
                //if the current previous is not null, the next of this will be the next of the current
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;


                }

                return;
            }
            current = current.Next;
        }


    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        //we start from the _head, it is the first element  
        Node? current = _head;

        //while every element of the list is not null we iterate in every element of the list
        while (current is not null)
        {
            //if one of the element in the iteration is equal to the old value(input)
            if (current.Data == oldValue)
            {
                //create a new node with the new value input
                Node newNode = new Node(newValue);

                //the previous of the new node will be the same of the current node
                //the same with the next value of the new node, will be the next of the current
                newNode.Prev = current.Prev;
                newNode.Next = current.Next;


                //if the previous of the current is not null
                if (current.Prev != null)
                {
                    current.Prev.Next = newNode; // the next of the current previous will be the new Node 
                }
                else
                {
                    //When the list contain one element, so the element is the _head, and take the value of the newNode
                    _head = newNode;
                }

                //id the next of the current is not null
                if (current.Next != null)
                {
                    current.Next.Prev = newNode;
                }
                else
                //When the list contain one element, so the element is the _tail, and take the value of the newNode
                {
                    _tail = newNode;
                }
                current = current.Next;

            }
            else
            {
                current = current.Next;
            }
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        var curr = _tail; // Start the iteration at the end of the list since this is a backward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Prev; // Go backward in the linked list
        }
        //yield return 0; // replace this line with the correct yield return statement(s)
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}