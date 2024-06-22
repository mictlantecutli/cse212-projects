public static class Priority
{
    public static void Test()
    {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: The function adds items to the queue, at the end of the list.
        // Each item has priority and priority value.
        // Expected Result: Visits, read, parents, work
        Console.WriteLine("Test 1");
        var highPriorities = new PriorityQueue();
        highPriorities.Enqueue("visits", 3);
        highPriorities.Enqueue("read", 5);
        highPriorities.Enqueue("parents", 8);
        highPriorities.Enqueue("work", 4);
        Console.WriteLine(highPriorities); //Priorities the order should be [visits, read, parents, work]



        //while (players.Length > 0)
        //    players.GetNextPerson();
        //Console.WriteLine(highPriorities);

        // Defect(s) Found: The Enqueue works fine it add every item at the end of the List



        Console.WriteLine("---------");

        // Test 2
        // Scenario: Every time an enqueue is made, the one with the highest priority should be shown, not the first index in the list.
        // Expected Result: family, meditate, finances, study, work, eat, exercise
        Console.WriteLine("Test 2");
        var highPriorities02 = new PriorityQueue();
        highPriorities02.Enqueue("study", 4);
        highPriorities02.Enqueue("meditate", 6);
        highPriorities02.Enqueue("eat", 2);
        highPriorities02.Enqueue("family", 7);
        highPriorities02.Enqueue("work", 3);
        highPriorities02.Enqueue("finances", 5);
        highPriorities02.Enqueue("exercise", 1);

        Console.WriteLine(highPriorities02);
        while (highPriorities02.Length > 0)
            Console.WriteLine(highPriorities02.Dequeue());

        // Defect(s) Found: In the PriorityQueue.cs there was no method to remove the highest priority index, so I added the method to remove it.
        // Also in the for loop I removed the -1 from the count of the elements in the queue list,
        // so that the loop would go through all the items.

        Console.WriteLine("---------");


        // Test 3
        // Scenario: When two items have the same value, the one closest to the start should be removed.
        // Expected Result: family, study, meditate, eat
        Console.WriteLine("Test 3");
        var highPriorities03 = new PriorityQueue();
        highPriorities03.Enqueue("study", 4);
        highPriorities03.Enqueue("meditate", 2);
        highPriorities03.Enqueue("family", 7);
        highPriorities03.Enqueue("eat", 2);

        Console.WriteLine(highPriorities03);
        while (highPriorities03.Length > 0)
            Console.WriteLine(highPriorities03.Dequeue());

        // Defect(s) Found:  I separated it into two conditions, one when the current value is greater than the previous largest value,
        // there the highPriorityIndex is updated to the new index with the highest value.
        // The other condition is when the current and past values ​​are equal, I don't update anything there, the highPriorityIndex stays the same,
        // what I want is to eliminate the item closest to the beginning.

        Console.WriteLine("---------");

        // Test 4
        // Scenario: when the queue is empty and I want to remove some item
        // Expected Result: arise the message: "The queue is empty."
        Console.WriteLine("Test 4");
        var highPriorities04 = new PriorityQueue();

        Console.WriteLine(highPriorities04.Dequeue());

        // Defect(s) Found: I think it works fine
    }
}