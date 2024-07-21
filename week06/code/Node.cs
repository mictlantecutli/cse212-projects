public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        //if the value is less than the current data
        if (value < Data)
        {
            // Insert to the left side of the tree
            if (Left is null) //if the left is nothing, create a new node with the values
                Left = new Node(value);
            else //but if there is something in the left side
            {
                if (!Left.Contains(value)) //and if the value is not contained in the left side, look for one left empty side to insert the value
                {
                    Left.Insert(value);
                }
            }

        }
        //if the value enter by the user us greater than current
        //it goes to the right side
        else
        {
            // Insert to the right. If there is nothing set a new node with the value
            if (Right is null)
                Right = new Node(value);
            else //if there is something in the right side
            {
                if (!Right.Contains(value))//but only if the value is not contained in the right side of the tree, INSERT the value
                {
                    Right.Insert(value);//make a recursion to look a place with nothing to insert the value
                }
            }

        }
    }
    //The Cracking the Coding Interview Book
    public bool Contains(int value)
    {
        //if the value entered by the user is equal to the current. it return true
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)//if the value is less than current data it goes to verify to the left side
        {
            if (Left == null) //if the left is null it will be false, or not contained
            {
                return false;
            }
            else
            {
                return Left.Contains(value); //else verify if it is true or false to all the nodes of the left side
            }
        }
        else //it is the same the before code, but for right side
        {
            if (Right == null)
            {
                return false;
            }
            else
            {
                return Right.Contains(value);
            }
        }

    }

    public int GetHeight()
    {
        //set variables to track number of nodes in every side
        int leftSide = 0;
        int rightSide = 0;

        // If there is something in the left side, continue looking for nodes until it is null
        if (Left != null)
        {
            leftSide = Left.GetHeight();
        }

        //do the same before for the right side until it is null
        if (Right != null)
        {
            rightSide = Right.GetHeight();
        }

        //if the left or right side are null, add 1 plus the max of the children of left or right side
        return 1 + Math.Max(leftSide, rightSide);
    }
}